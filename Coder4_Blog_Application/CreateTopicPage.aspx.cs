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
            string tempdate = "";
            User aUser = new User();
            aUser.User_Id = 3;
            aUser.date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            aUser.Topic = TextBox1.Text.Replace("'", "''"); ;

            aUser.Des = Server.HtmlEncode(TextArea1.Value);
            //Label1.Text = aUser.Topic + "  " + aUser.Des;

            string connectionString = WebConfigurationManager.ConnectionStrings["myConnectionString1"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            int i = 0;
            connection.Open();
            string query = String.Format("INSERT INTO Article_tb(user_id,title,Date,description,count_like) VALUES('{0}','{1}','{2}','{3}','{4}')", aUser.User_Id, aUser.Topic, aUser.date, aUser.Des,i);
            //string query="INSERT INTO Article_tb(user_id,title,Date,description,count_like) VALUES("+aUser.User_Id +",'"+ aUser.Topic+"','"+aUser.date +"','"+aUser.Des +"',"+i +")";
            SqlCommand command = new SqlCommand(query, connection);
            var rowAffected = command.ExecuteNonQuery();
            connection.Close();

            //return rowAffected > 0;
            Response.Redirect("http://localhost:38369/ShowPage.aspx");
        }
    }

    public class User
    {
        public int User_Id { get; set; }
        public string date { get; set; }
        public string Topic { get; set; }
        public string Des { get; set; }


    }
}