using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



class Queries
{
    static SqlConnection conn = new SqlConnection(@"Data Source = ZCM-233204864\SQLEXPRESS;Initial Catalog = Video_Club; Integrated Security = True");

    public static void ExecuteNonquery(string query)
    {
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (SqlException ex)
        {
            conn.Close();
            throw ex;
        }
    }

    public static DataTable ExecuteQuery(string query)
    {
        try
        {
            DataTable table = null;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            table = new DataTable();
            adapter.Fill(table);
            conn.Close();
            return table;
        }
        catch (SqlException ex)
        {
            conn.Close();
            throw ex;
        }
    }
}

