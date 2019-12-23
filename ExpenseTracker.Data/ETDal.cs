using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace ExpenseTracker.Data
{
    public class ETDal
    {
        private static string connectionString = @"Data Source=DB\\ETracker.db; Version=3; FailIfMissing=True; Foreign Keys=True;";
        //SQLiteConnection _con;

        //public ETDal() { _con = new SQLiteConnection(connectionString); }
        public static async Task<List<Data.ExpenseCategory>> GetCategories()
        {
            List<ExpenseCategory> cats = new List<ExpenseCategory>();
            try
            {
                System.Diagnostics.Debug.WriteLine($"SQLite ADO init {connectionString}");
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    System.Diagnostics.Debug.WriteLine($"SQLite ADO connection opened {conn.ConnectionString}");
                    string sql = "SELECT * FROM ExpenseCategory";// OrderBy  WHERE Id = " + langId;
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                ExpenseCategory cat = new ExpenseCategory();
                                cat.Id = reader.GetInt32(0); //Int32.Parse(reader["Id"].ToString());
                                cat.Category = reader.GetString(1); //reader["Category"].ToString();
                                cats.Add(cat);
                            }
                        }
                    }
                    conn.Close();
                    System.Diagnostics.Debug.WriteLine($"SQLite ADO connection closed");
                }
            }
            catch (SQLiteException e)
            {
                System.Diagnostics.Debug.WriteLine($"SQLiteException: {e.Message}");
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {ex.Message}");
                throw;
            }
            return cats;
        }
    }
}