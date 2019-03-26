using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ADOConnectedTest
{
    public class Connected
    {
        public partial class AddressBookConnected : System.Web.UI.Page
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

            protected void btnInsert_Click(object sender, EventArgs e)
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

            protected void btnDelete_Click(object sender, EventArgs e)
            {
                using (getconnection())
                {
                    using (cmd = new SqlCommand("Proc_Delete_AddressBook", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AddressId", AddressID.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Response.Write("record deleted");
                    }
                }
            }

            protected void btnUpdate_Click(object sender, EventArgs e)
            {
                using (getconnection())
                {
                    using (cmd = new SqlCommand("Proc_Update_AddressBook", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AddressId", t);
                        cmd.Parameters.AddWithValue("@FirstName", FName.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Response.Write("record updated");
                    }
                }
            }

            protected void btnSearch_Click(object sender, EventArgs e)
            {
                using (getconnection())
                {
                    using (cmd = new SqlCommand("Proc_Search_AddressBook", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LastName",LName.Text);
                        con.Open();
                        GridView1.DataSource = cmd.ExecuteReader();
                        GridView1.DataBind();
                    }
                }


            }
