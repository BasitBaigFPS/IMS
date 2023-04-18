using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace IMS
{
    public partial class GridViewCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridview();
            }
        }

        //Store Procedure for This Example

            //CREATE PROCEDURE CrudOperations 
            //@productid int = 0, 
            //@productname varchar(50)=null, 
            //@price int=0, 
            //@status varchar(50) 
            //AS 
            //BEGIN 
            //SET NOCOUNT ON; 
            //--- Insert New Records 
            //IF @status='INSERT' 
            //BEGIN 
            //INSERT INTO productinfo1(productname,price) VALUES(@productname,@price) 
            //END 
            //--- Select Records in Table 
            //IF @status='SELECT' 
            //BEGIN 
            //SELECT productid,productname,price FROM productinfo1 
            //END 
            //--- Update Records in Table  
            //IF @status='UPDATE' 
            //BEGIN 
            //UPDATE productinfo1 SET productname=@productname,price=@price WHERE productid=@productid 
            //END 
            //--- Delete Records from Table 
            //IF @status='DELETE' 
            //BEGIN 
            //DELETE FROM productinfo1 where productid=@productid 
            //END 
            //SET NOCOUNT OFF 
            //END





        protected void BindGridview()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection("Data Source=MIT;Initial Catalog=OGSMS;Persist Security Info=True;User ID=sa;Password=fps123"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("crudoperations", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SELECT");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDetails.DataSource = ds;
                    gvDetails.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    gvDetails.DataSource = ds;
                    gvDetails.DataBind();
                    int columncount = gvDetails.Rows[0].Cells.Count;
                    gvDetails.Rows[0].Cells.Clear();
                    gvDetails.Rows[0].Cells.Add(new TableCell());
                    gvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvDetails.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }
        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                TextBox txtname = (TextBox)gvDetails.FooterRow.FindControl("txtpname");
                TextBox txtprice = (TextBox)gvDetails.FooterRow.FindControl("txtprice");
                crudoperations("INSERT", txtname.Text, txtprice.Text, 0);
            }
        }
        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDetails.EditIndex = e.NewEditIndex;
            BindGridview();
        }
        protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetails.EditIndex = -1;
            BindGridview();
        }
        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetails.PageIndex = e.NewPageIndex;
            BindGridview();
        }
        protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int productid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["productid"].ToString());
            TextBox txtname = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtProductname");
            TextBox txtprice = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtProductprice");
            crudoperations("UPDATE", txtname.Text, txtprice.Text, productid);
        }
        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["productid"].ToString());
            string productname = gvDetails.DataKeys[e.RowIndex].Values["productname"].ToString();
            crudoperations("DELETE", productname, "", productid);
        }
        protected void crudoperations(string status, string productname, string price, int productid)
        {
            using (SqlConnection con = new SqlConnection("Data Source=MIT;Initial Catalog=OGSMS;Persist Security Info=True;User ID=sa;Password=fps123"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("crudoperations", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "INSERT")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@productname", productname);
                    cmd.Parameters.AddWithValue("@price", price);
                }
                else if (status == "UPDATE")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@productname", productname);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@productid", productid);
                }
                else if (status == "DELETE")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@productid", productid);
                }
                cmd.ExecuteNonQuery();
                lblresult.ForeColor = Color.Green;
                lblresult.Text = productname + " details " + status.ToLower() + "d successfully";
                gvDetails.EditIndex = -1;
                BindGridview();
            }
        }
    }
}