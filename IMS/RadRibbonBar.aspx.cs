using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMS
{
    public partial class RadRibbonBar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  RadRibbonBar1.FindTabByValue("Setup").Visible = false;
          RadRibbonBar1.FindGroupByValue("Items").Visible = false;
        }

        protected void RadRibbonBar1_ButtonClick(object sender, Telerik.Web.UI.RibbonBarButtonClickEventArgs e)
        {
            if (e.Button.Text == "Store")
            {
                Response.Redirect("StoreMain.aspx");
            }





        }

        protected void RadRibbonBar1_ButtonToggle(object sender, Telerik.Web.UI.RibbonBarButtonToggleEventArgs e)
        {
            if (e.Button.Text == "Items")
            {
                Response.Redirect("ItemMain.aspx");
            }

            if (e.Button.Text == "Category")
            {
                
            }
            

        }

        protected void RadRibbonBar1_ApplicationMenuItemClick(object sender, Telerik.Web.UI.RibbonBarApplicationMenuItemClickEventArgs e)
        {

        }

        protected void RadRibbonBar1_MenuItemClick(object sender, Telerik.Web.UI.RibbonBarMenuItemClickEventArgs e)
        {

        }

        protected void RadRibbonBar1_SelectedTabChange(object sender, Telerik.Web.UI.RibbonBarSelectedTabChangeEventArgs e)
        {
            if (e.Tab.Text == "Setup")
            {
               // 
                //Response.Redirect("Main.aspx");
            }
        }

        protected void RadRibbonBar1_Load(object sender, EventArgs e)
        {
            
          
           
        }

        protected void RadRibbonBar1_Init(object sender, EventArgs e)
        {
          

            

            
        }
    }
}