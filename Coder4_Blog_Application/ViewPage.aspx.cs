using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace Coder4_Blog_Application
{
    public partial class ViewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           User aUser=new User();
           aUser.Topic = TextBox1.Text;
           aUser.Des = Server.HtmlEncode(TextArea1.Value);
            //Label1.Text = aUser.Topic + "  " + aUser.Des;

            string connectionString = WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();
                string query = String.Format("INSERT INTO topic2(Topic,Description) VALUES('{0}','{1}')", aUser.Topic, aUser.Des);
               SqlCommand command = new SqlCommand(query, connection);
                var rowAffected = command.ExecuteNonQuery();
                connection.Close();

            //return rowAffected > 0;
                Response.Redirect("http://localhost:38369/HomePage.aspx");
        }
    }

    public class User
    {
        public string Topic { get; set; }
        public string  Des { get; set; }


    }
}