using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASTeam
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////  var webRequest = WebRequest.Create(@"http://localhost:53284/mail.html");
            //var webRequest = WebRequest.Create(@"http://10.16.38.138:4502/cf#/content/basemail/BaseEmail.html");

            //using (var response = webRequest.GetResponse())
            //using (var content = response.GetResponseStream())
            //using (var reader = new StreamReader(content))
            //{
            //    var strContent = reader.ReadToEnd();
            //}

            string html = "<html><head>   <title></title></head><body>    *Prod<table>        <tr id='name'>           <td>name</td>            <td>$name</td>        </tr>        <tr id='tpsnum'>            <td>tpsnum</td>            <td>$tpsnum</td>        </tr>        <tr>            <td></td>            <td></td>        </tr>        <tr>            <td></td>            <td></td>        </tr>           </table>Prod* </body></html>";

            if (html.Contains("*Prod"))
            {
                PopulateProd(html);
            }


            //if (!IsPostBack)
            //    BindGrid();

        }


        private void PopulateProd(string html)
        {
            string tablestring = html.Substring(html.IndexOf("*Prod"), html.IndexOf("Prod*")+5 - html.IndexOf("*Prod"));
            
            string[] rows = tablestring.Split(new string[] { "<tr" }, StringSplitOptions.None);

            string[] parts = Regex.Split(tablestring, @"(?=<tr)");

            StringBuilder updatedtable = new StringBuilder();

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].Contains("id='name'") && rows[i].Contains("$name"))
                {
                    string name = "Peter Singh Dsuoza 123 CD example";
                    rows[i] = "<tr" + rows[i].Replace("$name", name);
                    updatedtable = updatedtable.Append(rows[i]);
                }
            }
            string a = html.Replace(tablestring, updatedtable.ToString());
            Response.Write(a);


        }
    }
}