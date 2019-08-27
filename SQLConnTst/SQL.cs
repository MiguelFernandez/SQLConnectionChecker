using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SQLConnTst
{
    public class SQL
    {
        public List<string> First5ColumnNames { get; set; } = new List<string>();
        public List<string> First5Rows { get; set; } = new List<string>();
        public bool HasError { get; set; }
        public SQLConnectionString ConnectionString { get; set; } = new SQLConnectionString();
        public string ErrorMessage { get; set; } = string.Empty;
        public string ConnectToSQL()
        {
            try
            {
                HasError = false;
                var connectionString = ConnectionString.FullConnectionString;
                //var connectionString = $"Server=tcp:mferncervsql.database.windows.net,1433;Initial Catalog={ConnectionString.InitialCatalog};Persist Security Info=False;User ID={ConnectionString.Username};Password={ConnectionString.Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Password\";";
                string queryString = $"select top 1 * from {ConnectionString.TableName}";
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(queryString, connection);

                    connection.Open();
                    //var first5ColumnNames = new List<string>();
                    //var first5Rows = new List<string>();
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    var columns = reader.FieldCount;
                    var hasRows = reader.HasRows;
                    var schemaTable = reader.GetSchemaTable();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (i > 4)
                        {
                            break;
                        }
                        First5ColumnNames.Add(reader.GetName(i));
                    }


                    if (reader.HasRows)
                    {
                        reader.Read();
                        var tempRow = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            tempRow += reader[i].ToString() + ", ";
                        }
                        First5Rows.Add(tempRow);


                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                    connection.Close();

                    return "";

                }

            }

            catch (Exception ex)
            {
                string errorJson = JsonConvert.SerializeObject(ex, Formatting.Indented);
                HasError = true;
                ErrorMessage = errorJson;
                return "";
            }
           


        }
    }
}