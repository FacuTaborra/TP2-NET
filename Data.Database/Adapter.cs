using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        const string consKeyDefaultCnnString = "ConnStringExpress";

        SqlConnection _sqlConn;
        public SqlConnection sqlConn { get; set; }
        
        protected void OpenConnection()
        {
            //string connectionString ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            string connectionString = @"Server=localhost\\SQLEXPRESS;Database=tp2_net;Integrated Security=true; User=user_program; Password=user_program;";
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
