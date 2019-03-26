using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADOConnectedTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection getconnection()
        {
            return (con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()));
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            using (getconnection())
            {
                using (cmd = new SqlCommand("Proc_Insert_AddressBook", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId", AddressID.Text);
                    cmd.Parameters.AddWithValue("@FirstName", FName.Text);
                    cmd.Parameters.AddWithValue("@LastName", LName.Text);
                    cmd.Parameters.AddWithValue("@Email", Email.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", Phone.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("Record Inserted");
                }
            }

        }

        protected void Update_Click(object sender, EventArgs e)
        {
            using (getconnection())
            {
                using (cmd = new SqlCommand("Proc_Update_AddressBook", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId", AddressID);
                    cmd.Parameters.AddWithValue("@LastName", LName.Text);
                    cmd.Parameters.AddWithValue("@FirstName", FName.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("record updated");
                }
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {

            using (cmd = new SqlCommand("Proc_Delete_AddressBook", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AddressId", AddressID);
            
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("record Deleted");
            }
        }

        protected void FName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}