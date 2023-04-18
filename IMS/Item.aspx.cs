using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using BLL;

namespace IMS
{
    public partial class Item : System.Web.UI.Page
    {
       // UserManager UMan = new UserManager();
        ItemManager im = new ItemManager();
        IMSManager iman = new IMSManager();
        UserManager UMan = new UserManager();
        RequisitionManager ReqMan = new RequisitionManager();


        #region Helper Method

        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }

        private void SetupForm()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            iman.Uid = int.Parse(IMS["uid"]);
            iman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            UMan.Ugid = int.Parse(IMS["ugroupid"]);
            UMan.Grpuserbrhid = int.Parse(IMS["grpuserbrhid"]);
            UMan.Grpuserdeptid = int.Parse(IMS["grpuserdptid"]);
            UMan.Grpuserstoreid = int.Parse(IMS["grpuserstoreid"]);

            //iman.Uid = 1527;
            //iman.Pkdeptid = 14;
            //iman.Pkbrhid = 19;

            if (UMan.Ugid == 37)
            {
                yearlyitem.Style.Add("display", "none");
            }

             

            GetCategory();


            Telerik.Web.UI.RadComboBoxItem ct = new Telerik.Web.UI.RadComboBoxItem();
            ct.Text = "Choose Category";
            ct.Value = "Choose Category";
            cmbCategory.Items.Add(ct);
            cmbCategory.SelectedIndex = cmbCategory.Items.Count - 1;

            Telerik.Web.UI.RadComboBoxItem sct = new Telerik.Web.UI.RadComboBoxItem();
            sct.Text = "Choose Sub Category";
            sct.Value = "Choose Sub Category";
            cmbSubCategory.Items.Add(sct);
            cmbSubCategory.SelectedIndex = cmbSubCategory.Items.Count - 1;


            Telerik.Web.UI.RadComboBoxItem hd = new Telerik.Web.UI.RadComboBoxItem();
            hd.Text = "Choose Items Head";
            hd.Value = "Choose Items Head";
            cmbItemHead.Items.Add(hd);
            cmbItemHead.SelectedIndex = cmbItemHead.Items.Count - 1;

            txtName.Text = "";
            txtDescription.Text = "";
            //txtCode.Text = "";
            //txtGLCode.Text = "";

        }

        public void GetCategory()
        {
            cmbCategory.DataSource = im.GetCategories();
            cmbCategory.DataTextField = "CatTitle";
            cmbCategory.DataValueField = "pkCatID";
            cmbCategory.DataBind();
        }

        public void GetSubCategory(int catid)
        {
            im.CatID = catid;
            cmbSubCategory.DataSource = im.GetSubCategories();
            cmbSubCategory.DataTextField = "SubCatTitle";
            cmbSubCategory.DataValueField = "pkSubCatID";
            cmbSubCategory.DataBind();

            GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString())); 
        }

        public void GetItemHead(int subcatid)
        {
            im.SubCatID = subcatid;

            cmbItemHead.DataSource = im.GetItemHeads();
            cmbItemHead.DataTextField = "ItemHeadTitle";
            cmbItemHead.DataValueField = "pkItemHeadID";
            cmbItemHead.DataBind();
        }

        public void GetItem()
        {
            if (Request.QueryString["ID"] != null)
            {
                string ID = Request.QueryString["ID"].ToString();

                im.itemid = int.Parse(ID);
                im.Token = "II";

                im = im.GetItem();

                txtName.Text = im.itemtitle;
                //txtCode.Text = im.itemcode;
                txtDescription.Text = im.itemdesc;
               // txtGLCode.Text = im.GLCode;
                txtUnit.Text = im.unit;
                if (im.isactive == "True")
                {
                    IsActive.Checked = true;
                }

                cmbCategory.SelectedValue = im.fkcatid.ToString();
                GetSubCategory(int.Parse(cmbCategory.SelectedValue.ToString()));
                cmbSubCategory.SelectedValue = im.fksubcatid.ToString();
                GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));   
                cmbItemHead.SelectedValue = im.fkitemheadid.ToString();
            }

        }


        public void GetReqSubType()
        {
            cmbItemType.DataSource = ReqMan.GetReqITSubType();
            cmbItemType.DataTextField = "RequisitionSubType";
            cmbItemType.DataValueField = "pkReqSubTypID";
            cmbItemType.DataBind();
        }


        public void saveItem()
        {

            im.itemtitle = txtName.Text;
            im.itemcode = string.Empty; // txtCode.Text;
            im.itemdesc = txtDescription.Text;
            im.GLCode = string.Empty; // txtGLCode.Text;
            im.unit = txtUnit.Text;
            im.fkcatid = int.Parse(cmbCategory.SelectedValue.ToString());
            im.fksubcatid = int.Parse(cmbSubCategory.SelectedValue.ToString());
            im.fkitemheadid = int.Parse(cmbItemHead.SelectedValue.ToString());

            if (IsActive.Checked==true)
            {
                im.isactive = "True";
            }
            else

            {
                im.isactive = "False";
            }

            if (IsYearly.Checked ==true)
            {
                im.isyearly = "True";
            }
            else
            {
                im.isyearly = "False";
            }

            if (Request.QueryString["ID"] != null)
            {
                im.itemid = int.Parse(Request.QueryString["ID"].ToString());
                im.Token = "U";
            }
            else
                im.Token = "I";

            if (IsReqItem.Checked==true)
            {
                im.Token = "IR";
                im.ReqItem = true;

                im.ReqSubID = int.Parse(cmbItemType.SelectedValue.ToString());
            }

            int result = im.IUItem();

            //if (result == 1)
                //winMessage.VisibleOnPageLoad = true;

            if (im.Token == "I")
            {
                showMessageBox("Item Successfully Inserted...!!!");
            }
            else
            {
                showMessageBox("Item Successfully Updated...!!!");
            }

            SetupForm();
            
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                SetupForm();
                GetItem();

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (im.checkDuplicateItem(txtName.Text, 2) == true)
            {
                showMessageBox("Duplicate Item Creation Not Allowed, Item Not Saved..!!!");
                btnSubmit.Visible = false;
                txtName.Text = "";
                txtDescription.Text = "";
                Response.Redirect("Main.aspx");
            }

            saveItem();
        }
      

        protected void cmbItemHead_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            im.SubCatID = int.Parse(cmbSubCategory.SelectedValue.ToString());
            im.fkitemheadid = int.Parse(cmbItemHead.SelectedValue.ToString());
        }

        protected void cmbCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetSubCategory(int.Parse(cmbCategory.SelectedValue.ToString()));
        }

        protected void cmbSubCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GetItemHead(int.Parse(cmbSubCategory.SelectedValue.ToString()));            
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            if (im.checkDuplicateItem(txtName.Text,1) == true)
            {
                showMessageBox("Similar Item(s) Already Exist, Please Review Before Duplicate Item Creation..!!!");

             //   return;
            }


            var sb = new StringBuilder();
            List<string> MyList = im.GetMatchItems(txtName.Text);

            var collection = MyList;


            if (collection.Count != 0)
            {
                sb.Append("<ul class=\"results\">");
                foreach (var item in collection)
                {
                    sb.Append("<li>" + item.ToString() + "</li>");
                }
                sb.Append("</ul>");

                ltlItemsList.Text = sb.ToString();

               // showMessageBox(sb.ToString());
            }
             

        }

        protected void cmbItemType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void IsReqItem_CheckedChanged(object sender, EventArgs e)
        {
            if (IsReqItem.Checked)
            {
                cmbItemType.Visible = true;
                GetReqSubType();
            }
            else
            {
                cmbItemType.Visible = false;
            }
        }

   

        

 

    }
}