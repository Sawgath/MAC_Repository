using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coder4_Blog_Application
{
    public partial class ShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_all_Out();
        }



        public void Load_all_Out()
        {

            string connectionString = WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            //OleDbConnection cn = new OleDbConnection(connectionString);
            
            
            connection.Open();
            string query = ("SELECT * FROM  topic1");
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            var dr = command.ExecuteReader();
            
            while (dr.Read())
            {
                Label1.Text = dr["Topic"].ToString();
                Label2.Text = dr["Description"].ToString();

            }
            connection.Close();


            //cn.Open();
            //OleDbCommand cmd = new OleDbCommand(query, cn);
            //OleDbDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{

            //    Label1.Text = reader["Topic"].ToString();



            //    pID1.InnerText = reader["Description"].ToString();
                

            //}



            //reader.Close();
            //cn.Close();
        }

    }
}