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
using System.Net;
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
            Stack<showUser> sList = new Stack<showUser>(); 
            string connectionString = WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            //OleDbConnection cn = new OleDbConnection(connectionString);
            
            
            connection.Open();
            string query = ("SELECT * FROM  topic2");
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            var dr = command.ExecuteReader();
            
            while (dr.Read())
            {
                showUser aShowUser=new showUser();
                aShowUser.Topic = dr["Topic"].ToString();
                aShowUser.Des = dr["Description"].ToString();
                //Label1.Text = dr["Topic"].ToString();
                //Label2.Text = Server.HtmlDecode(dr["Description"].ToString());
                sList.Push(aShowUser);

            }
            connection.Close();
            string a = "";
            string b = "";
            string total = "";
            foreach (var alist in sList)
            {
                a = alist.Topic + "</br>";
                b = Server.HtmlDecode(alist.Des) + "</br>";
                total =total  +  a + b;
               
            }
            Label1.Text =total;
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

        public class showUser
        {
            public string Topic { get; set; }
            public string Des { get; set; }


        }

    }
}