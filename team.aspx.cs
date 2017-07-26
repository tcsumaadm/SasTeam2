using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASTeam
{
    public partial class team : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string html = "<html><head>   <title></title></head><body>    *Prod<table>        <tr id='name'>           <td>name</td>            <td>$name</td>        </tr>        <tr id='tpsnum'>            <td>tpsnum</td>            <td>$tpsnum</td>        </tr>        <tr>            <td></td>            <td></td>        </tr>        <tr>            <td></td>            <td></td>        </tr>           </table>Prod* </body></html>";

            //if (html.Contains("*prod"))
            //{
            //    PopulateProd(html);
            //}


            if (!IsPostBack)
                BindGrid();

        }


        private void PopulateProd(string html)
        {
            string tablestring = html.Substring(html.IndexOf("*Prod"), html.IndexOf("Prod*"));
            string[] rows = tablestring.Split(new string[] { "<tr" }, StringSplitOptions.None);
            string updatedtable = string.Empty;

            for (int i = 0; i < rows.Length; i++)
            {

                if (rows[i].Contains("id='name'") && rows[i].Contains("$name'"))
                    rows[i].Replace("$name", "Ayushi Singh");
                updatedtable = updatedtable + rows[i];

            }
            html.Replace(tablestring, updatedtable);
            Response.Write(html);

        }


        private void BindGrid()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);

            try
            {
                con.Open();
                string query = "Select * from Team";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                GridView1.DataSource = sdr;
                GridView1.DataBind();
                con.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        //
        protected string SetSortDirection(SortDirection sortDirection)
        {
            if (sortDirection == SortDirection.Ascending)
            {
                return "DESC";
            }
            else
            {
                return "ASC";
            }
        }
        public SortDirection direction
        {
            get
            {
                if (ViewState["directionState"] == null)
                {
                    ViewState["directionState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["directionState"];
            }
            set
            {
                ViewState["directionState"] = value;
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            //  SetSortDirection(e.SortDirection);
            string sortingDirection = string.Empty;
            if (direction == SortDirection.Ascending)
            {
                direction = SortDirection.Descending;
                sortingDirection = "Desc";

            }
            else
            {
                direction = SortDirection.Ascending;
                sortingDirection = "Asc";

            }

            DataTable dt = (DataTable)Session["dt"];

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + sortingDirection;// ; SortDirection;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            for (int i = 1; i < GridView1.Columns.Count; i++)
            {
                TableHeaderCell cell = new TableHeaderCell();
                TextBox txtSearch = new TextBox();
                txtSearch.Attributes["placeholder"] = GridView1.Columns[i].HeaderText;
                txtSearch.CssClass = "search_textbox";
                txtSearch.Width = Unit.Percentage(100);
                cell.Controls.Add(txtSearch);
                row.Controls.Add(cell);
            }
            GridView1.HeaderRow.Parent.Controls.AddAt(1, row);

        }

        protected void GridView1_Sorting1(object sender, GridViewSortEventArgs e)
        {

        }
    }
}