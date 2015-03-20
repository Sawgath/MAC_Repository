using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coder4_Blog_Application
{
    public partial class PopularPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_all_Out();

        }

        public void Load_all_Out()
        {
            Stack<showUser> sList = new Stack<showUser>();
            string connectionString = WebConfigurationManager.ConnectionStrings["myConnectionString1"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            //OleDbConnection cn = new OleDbConnection(connectionString);


            connection.Open();
            string query = ("SELECT * FROM  [Article_tb] ORDER BY count_like");
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            var dr = command.ExecuteReader();

            while (dr.Read())
            {
                showUser aShowUser = new showUser();
                aShowUser.User_Id = Convert.ToInt32(dr["user_id"]);
                aShowUser.Topic_Id = Convert.ToInt32(dr["topic_id"]);
                aShowUser.date = dr["Date"].ToString();
                aShowUser.Topic = dr["title"].ToString();
                aShowUser.Des = dr["description"].ToString();
                aShowUser.count = Convert.ToInt32(dr["count_like"]);
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
                a = "<h2><a href=TopicView.aspx?uhd=" + alist.Topic_Id + ">" + alist.Topic + "</a><h2></br>";
                a = a + "<h5><i>Viewed :"+ alist.count +"  Date :" + alist.date + " </i> </br><h5>";
                // removing all html tags...........
                string noHTML = Regex.Replace(Server.HtmlDecode(alist.Des), @"<[^>]+>|&nbsp;", "").Trim();
                string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");
                // limiting the text...............
                string last = noHTMLNormalised.Substring(0, 200);
                b = "<h4>" + last + "...........................................</h4>" + "</br>";
                total = total + a + b;

            }
            Label1.Text = total;

        }

        public class showUser
        {
            public int User_Id { get; set; }
            public int Topic_Id { get; set; }
            public int count { get; set; }
            public string date { get; set; }
            public string Topic { get; set; }
            public string Des { get; set; }


        }

        

    }
}