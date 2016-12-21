using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;

namespace serverDB
{
    class db
    {
        private const string connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=vetal-1996;Database=cars;";
        public NpgsqlConnection dbConnection { get; }

        public db()
        {
            dbConnection = new NpgsqlConnection(connectionString);
        }

        public void addCar(string model, string  color, string year)
        {
            openConnection();
            NpgsqlCommand command = new NpgsqlCommand(@"INSERT INTO list VALUES ('" + model + @"','" + color + @"','"+year+@"');", dbConnection);
            int c = command.ExecuteNonQuery();
            closeConnection();
        }

        //public string[,,] get()
        //{
        //    openConnection();
        //    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM list", dbConnection);
        //    NpgsqlDataReader reader = command.ExecuteReader();
        //    string[,,] ss = new string[reader.FieldCount, reader.FieldCount, reader.FieldCount];
        //    int i = 0;
        //    if (reader.HasRows)
        //    {
        //        foreach (DbDataRecord rec in reader)
        //        {
        //            int it = int.Parse(rec["admin_id"].ToString());
        //            string name = rec["admin_username"].ToString();
        //            string pass = rec["admin_password"].ToString();
        //            ss[i,i,i] = 
        //             i++;


        //        }
        //    }
        //    connection.closeConnection();
        //}

        public void openConnection()
        {
            dbConnection.Open();
        }

        public void closeConnection()
        {
            dbConnection.Close();
        }
    }
}
