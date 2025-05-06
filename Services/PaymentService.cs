using bakery_management_system.Utils;
using Npgsql;  // Use Npgsql for PostgreSQL

namespace bakery_management_system.Services
{
    internal class PaymentService
    {
        public bool ProcessPayment(int employeeId, int customerId, int cartId, string paymentMethod, out string errorMessage)
        {
            errorMessage = string.Empty;

            using (var connection = DatabaseHelper.GetConnection()) // Ensure this returns an NpgsqlConnection
            {
                try
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        // Step 1: Calculate total amount for the specified cart
                        string query = @"SELECT SUM(c.quantity * p.price) 
                                         FROM Cart c 
                                         JOIN Products p ON c.product_id = p.product_id 
                                         WHERE c.employee_id = @employeeId AND c.cart_id = @cartId AND c.is_paid = false";
                        decimal totalAmount = 0m;

                        using (var cmd = new NpgsqlCommand(query, connection, transaction)) // Use NpgsqlCommand
                        {
                            cmd.Parameters.AddWithValue("@employeeId", employeeId);
                            cmd.Parameters.AddWithValue("@cartId", cartId);
                            totalAmount = Convert.ToDecimal(cmd.ExecuteScalar() ?? false);
                        }

                        if (totalAmount <= 0)
                        {
                            throw new Exception("No unpaid items in the specified cart.");
                        }

                        // Step 2: Insert payment
                        query = @"INSERT INTO Payments (payment_method, amount, payment_date) 
                                  VALUES (@paymentMethod, @amount, NOW())
                                  RETURNING payment_id;";  // PostgreSQL uses RETURNING for last inserted ID
                        int paymentId;
                        using (var cmd = new NpgsqlCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                            cmd.Parameters.AddWithValue("@amount", totalAmount);
                            paymentId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Step 3: Insert invoice
                        query = @"INSERT INTO Invoices (customer_id, employee_id, total_amount, invoice_date, payment_id) 
                                  VALUES (@customerId, @employeeId, @totalAmount, NOW(), @paymentId)
                                  RETURNING invoice_id;"; // PostgreSQL uses RETURNING for last inserted ID
                        int invoiceId;
                        using (var cmd = new NpgsqlCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@customerId", customerId);
                            cmd.Parameters.AddWithValue("@employeeId", employeeId);
                            cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                            cmd.Parameters.AddWithValue("@paymentId", paymentId);
                            invoiceId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Step 4: Add invoice items
                        query = @"INSERT INTO InvoiceItems (invoice_id, product_id, quantity, price)
                                  SELECT @invoiceId, c.product_id, c.quantity, p.price 
                                  FROM Cart c 
                                  JOIN Products p ON c.product_id = p.product_id 
                                  WHERE c.employee_id = @employeeId AND c.cart_id = @cartId AND c.is_paid = false";
                        using (var cmd = new NpgsqlCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
                            cmd.Parameters.AddWithValue("@employeeId", employeeId);
                            cmd.Parameters.AddWithValue("@cartId", cartId);
                            cmd.ExecuteNonQuery();
                        }

                        // Step 5: Mark the specified cart items as paid
                        query = "UPDATE Cart SET is_paid = true WHERE employee_id = @employeeId AND cart_id = @cartId AND is_paid = false";
                        using (var cmd = new NpgsqlCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@employeeId", employeeId);
                            cmd.Parameters.AddWithValue("@cartId", cartId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = $"Error processing payment: {ex.Message}";
                    return false;
                }
            }
        }
    }
}
