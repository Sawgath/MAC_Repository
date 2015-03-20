using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coder4_Blog_Application
{
    public partial class TopicView : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {

         selected_topic();
            Label3.Text = "";

        }

        public int hello()
        {
            if (Request.QueryString["uhd"] != null)
            {
                return Convert.ToInt32(Request.QueryString["uhd"]);
                //return 4;

            }
            else
            {
                return 0;
                //return 4;
            }
        }

        public void selected_topic()
        {
            Stack<TopicUser> sList = new Stack<TopicUser>();
            string connectionString = WebConfigurationManager.ConnectionStrings["myConnectionString1"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            //OleDbConnection cn = new OleDbConnection(connectionString);
            //TopicUser aShowUser = new TopicUser();
            string name = "";
            int nameid = 0;
            int passid = hello();
            //name = getname(passid);
            connection.Open();
            TopicUser aShowUser2 = new TopicUser();
            string query = "SELECT * FROM  Article_tb WHERE topic_id = "+ passid;
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            var dr = command.ExecuteReader();

            if(dr.Read())
            {
                TopicUser aShowUser = new TopicUser();
                aShowUser.User_Id = Convert.ToInt32(dr["user_id"]);
                nameid = Convert.ToInt32(dr["user_id"]);
                aShowUser.Topic_Id = passid;
                aShowUser.date = dr["Date"].ToString();
                aShowUser.Topic = dr["title"].ToString();
                aShowUser.Des = dr["description"].ToString();
                //Label1.Text = dr["Topic"].ToString();
                //Label2.Text = Server.HtmlDecode(dr["Description"].ToString());

                aShowUser2 = aShowUser;

            }
            
            connection.Close();


            aShowUser2.name = getname(nameid, connection);

            PrintTopic(aShowUser2);

            populatingComments();
        }


        public void PrintTopic(TopicUser aUser)
        {

                string a = "";
                string b = "";
                string total = "";
            
                a = "<h2><a href=TopicView.aspx?uhd=" + aUser.Topic_Id + ">" + aUser.Topic + "</a><h2></br>";
                a = a + "<h3><i> Author :" + aUser.name + " </i> <h3></br>";
                a = a + "<h5><i> Date :" + aUser.date + " </i> <h5></br>";
                b =  Server.HtmlDecode(aUser.Des)  + "</br>";
                total = total + a + b;

          
                Label1.Text = total;
            
        }

        public string getname(int i, SqlConnection connection)
        {

            connection.Open();
            string query = "SELECT * FROM  [User] WHERE ID="+i;
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            var dr1 = command.ExecuteReader();

            if (dr1.Read())
            {
                string a = dr1["Name"].ToString();
                connection.Close();
                return a;
            }
            else
            {
                connection.Close();
                return "anonymous";
            }
            

            
        }



      

        public class TopicUser
        {
            public int User_Id { get; set; }
            public int Topic_Id { get; set; }
            public string name { get; set; }
            public string date { get; set; }
            public string Topic { get; set; }
            public string Des { get; set; }


        }
        public class CommentUser
        {
            public int User_Id { get; set; }
            public int Topic_Id { get; set; }
            public string name { get; set; }
            public string date { get; set; }
            public string comments { get; set; }


        }
        public class temp1user
        {
            public int User_Id { get; set; }
           
            public string name { get; set; }
        

        }


        public void populatingComments()
        {
            Stack<CommentUser> sList = new Stack<CommentUser>();
            string connectionString = WebConfigurationManager.ConnectionStrings["myConnectionString1"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            int f = hello();

            connection.Open();
            string query = ("SELECT * FROM  [Comments1_tb] WHERE topic_id=" + f);
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            var dr = command.ExecuteReader();

            while (dr.Read())
            {
                CommentUser aShowUser = new CommentUser();
                aShowUser.User_Id = Convert.ToInt32(dr["user_id"]);
                aShowUser.Topic_Id = Convert.ToInt32(dr["topic_id"]);
                //int i = Convert.ToInt32(dr["topic_id"]);   
                aShowUser.date = dr["date"].ToString();
                aShowUser.name = dr["Name"].ToString();
                aShowUser.comments = dr["comments"].ToString();
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
                a = "<h3>" + alist.name + "<h3/></br>";
                a = a + "<h5><i> Date :" + alist.date + " </i> </br><h5>";
                b = "<h4>" + alist.comments + "...........................................</h4>" + "</br>";
                total = total + a + b;

            }
            Label2.Text = total;
         

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CommentUser aShowUser = new CommentUser();
            temp1user temp1=new temp1user();
            aShowUser.Topic_Id = hello();
            temp1 = NamingProcess(nameTextBox1.Text);
            aShowUser.name = temp1.name;
            aShowUser.User_Id = temp1.User_Id;
            aShowUser.date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            aShowUser.comments =commentsTextbox.InnerHtml;

            string connectionString = WebConfigurationManager.ConnectionStrings["myConnectionString1"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            
            
           
            connection.Open();
            string query = "INSERT INTO [Comments1_tb](topic_id,user_id,date,Name,comments) VALUES(" + aShowUser.Topic_Id + "," + aShowUser.User_Id + ",'" + aShowUser.date + "','" + aShowUser.name + "','" + aShowUser.comments + "')";
            
            SqlCommand command = new SqlCommand(query, connection);
            var rowAffected = command.ExecuteNonQuery();
            connection.Close();
            
            Response.Redirect(Request.RawUrl);


        }


        public temp1user NamingProcess(string  name)
        {
            
            string connectionString = WebConfigurationManager.ConnectionStrings["myConnectionString1"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM  [User] WHERE Name = '" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            var dr = command.ExecuteReader();
            if (dr.Read())
            {
                temp1user aUser = new temp1user();
                aUser.name = dr["Name"].ToString();
                aUser.User_Id=Convert.ToInt32(dr["ID"].ToString());
                connection.Close();
                return aUser;
                
            }
            else
            {
                
                connection.Close();
                Label3.Text = "User is't registered / found in Database";
                temp1user aUser = new temp1user();
                aUser.name = "Anonymous User";
                aUser.User_Id = 0;
                return aUser;
                
            }
            

            
        }

     
    }
}