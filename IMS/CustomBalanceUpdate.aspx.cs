using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;


namespace IMS
{
    public partial class CustomBalanceUpdate : System.Web.UI.Page
    {

        StoreManager STMan = new StoreManager();

     

        protected void showMessageBox(string message)
        {
            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                

            }
        }

        private void SetupForm()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            //iman.Uid = int.Parse(IMS["uid"]);

            STMan.fkbrhID = int.Parse(IMS["ubrhid"]);
            STMan.fkdeptID = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
            STMan.pkstoreID = 0;

        }


        protected void btnInvoke_Click(object sender, EventArgs e)
        {
            SetupForm();

            if (STMan.fkdeptID==10)
            { STMan.Token = "IT"; }
            else
            { STMan.Token = "SB"; }

            string fromdate = txtDateFrom.Value;
            string todate = txtDateTo.Value;

            DataTable dt = STMan.GetStores();
            
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    STMan.pkstoreID = int.Parse(row[0].ToString());

                    if (STMan.pkstoreID==1)
                    { 
                        STMan.fkdeptID = 14;
                        STMan.UpdateInvBalanceCustom(STMan.fkbrhID, STMan.pkstoreID, STMan.fkdeptID, fromdate, todate);
                        break;
                    }

   
                    
                   // STMan.UpdateInvBalance(STMan.fkbrhID, STMan.pkstoreID, STMan.fkdeptID);
                }
            }
            

            showMessageBox("Customer Store Inventory Balances Have Been Successfully Updated......");

            Response.Redirect("~/ReportsMain.aspx?rptname=StoreInventoryBalancesCustom");

        }

    }
}