using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing.Printing;
using System.Globalization;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Drawing;
using Telerik.Web.UI;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;
using System.IO;
using System.Text;
using BLL;
using DAL;


namespace IMS
{
    public partial class NewVendor : System.Web.UI.Page
    {
        #region Class Level Objects

        VendorManager VendMan = new VendorManager();


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            //cmbTypes.Filter = RadComboBoxFilter.Contains;

            if (Page.IsPostBack == false)
            {
                PopulateVendtype();
                PopulateVendcategory();

            }




        }


        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }


        private void PopulateVendtype()
        {
            SqlConnection con = new SqlConnection();


            DataTable dtvtyp = new DataTable();

            string query = "SELECT pkVendTypID,VendType FROM tblVendorType Order By VendType";
            SqlCommand cmd = new SqlCommand(query);

            con.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;


            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);

            dtvtyp = ds.Tables[0];

       
            cmbTypes.DataSource = dtvtyp;
            cmbTypes.DataTextField = "VendType";
            cmbTypes.DataValueField = "pkVendTypID";
            cmbTypes.DataBind();


            Telerik.Web.UI.RadComboBoxItem vt = new Telerik.Web.UI.RadComboBoxItem();
            vt.Text = "---Please Select---";
            vt.Value = "---Please Select---";
            cmbTypes.Items.Add(vt);
            cmbTypes.SelectedIndex = cmbTypes.Items.Count - 1;

        }


        private void PopulateVendcategory()
        {
            SqlConnection con = new SqlConnection();


            DataTable dtvcat = new DataTable();

            string query = "SELECT pkVendCatID,VCatName FROM tblVendCategory Order By VCatName";
            SqlCommand cmd = new SqlCommand(query);

            con.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;


            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);

            dtvcat = ds.Tables[0];

            
            cmbCatagories.DataSource = dtvcat;
            cmbCatagories.DataTextField = "VCatName";
            cmbCatagories.DataValueField = "pkVendCatID";
            cmbCatagories.DataBind();


            Telerik.Web.UI.RadComboBoxItem vcat = new Telerik.Web.UI.RadComboBoxItem();
            vcat.Text = "---Please Select---";
            vcat.Value = "---Please Select---";
            cmbCatagories.Items.Add(vcat);
            cmbCatagories.SelectedIndex = cmbCatagories.Items.Count - 1;

        }


        protected void SaveVendor()
        {
            string vndid = cmbTypes.SelectedValue.ToString();
            string vndname = txtName.Text;

            SqlConnection con = new SqlConnection();

            con.ConnectionString = SqlHelper.connectionstring;
 

            string query = string.Empty;

            ///@vndtyp,@vndcat,
            /////fkVendCatID,fkVendTypID

            //VendMan.VendorType = int.Parse(cmbTypes.SelectedValue.ToString());
            //VendMan.VendorCat = int.Parse(cmbCatagories.SelectedValue.ToString());

            query = "INSERT INTO tblVendors(VendorName,CPName1,CPNumber1,fkVendTypID,fkVendCatID,Isactive) VALUES(@vndname,@cpname,@cpcell,@vndtyp,@vndcat,@active)";
       
            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@vndname", vndname);
            cmd.Parameters.AddWithValue("@cpname", txtCP.Text);
            cmd.Parameters.AddWithValue("@cpcell", txtCPCell.Text);
            cmd.Parameters.AddWithValue("@vndtyp", cmbTypes.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@vndcat", cmbCatagories.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@active", "1");

            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            showMessageBox("New Vendor/Supplier Successfully Added into IMS.----" + txtName.Text);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveVendor();
        }

        protected void cmbTypes_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            
        }
 
        protected void cmbCatagories_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            
        }





    }
}