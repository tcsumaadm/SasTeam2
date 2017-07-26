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
    public partial class dbtest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { BindGrid(); }

        }

        private void BindGrid()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);

            try
            {
                con.Open();
                SqlDataReader sdr;
                DataTable dt = new DataTable();

                for (int i = 0; i == 2; i++)
                {
                    string query = "Select Top " + i + "* from Team";
                    SqlCommand cmd = new SqlCommand(query, con);
                    sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                }

                GridView1.DataSource = dt;
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
    }
}