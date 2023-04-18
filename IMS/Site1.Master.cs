using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Menu;

using BLL;

namespace IMS
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        UserManager Uman = new UserManager();
   
        protected void Page_Load(object sender, EventArgs e)
        {

            //this.usergroup.Value = "1";
           // Session["RRB1"] = RadRibbonBar1;

            if (Page.IsPostBack == false)
            {
                
             
                 //Uman.GetUserInfo(Uman.Uid);


                UserManager Uman = new UserManager();

                HttpCookie IMS = Request.Cookies["IMS"];
                if (IMS == null)
                    Response.Redirect("logout.aspx");

                Uman.Uid = int.Parse(IMS["uid"]);
                Uman.Ubrhid = int.Parse(IMS["ubrhid"]);
                Uman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
                Uman.Ugid = int.Parse(IMS["ugroupid"]);
                Uman.Uname = IMS["uname"];
           

                lblUser.Text = "Welcome " +Uman.Uname.ToString();
                lblBranch.Text = IMS["Department"] + '-' + IMS["BranchName"];
                lblCity.Text = IMS["UCity"] == "1" ? "Karachi" : "Hyderabad";

                // AS PER USER RIGHTS FIRST WE SHOW THE MENU TABS WHICH ARE ALLOWED FOR THE LOGGIN USER


                //ShowMenuTabs(Uman.Uid);


                // AS PER USER RIGHTS SECOND WE SHOW THE RIBBON ITEMS WHICH ARE ALLOWED FOR THE LOGGIN USER

                //ShowTabItems(Uman.Uid);


                //Setup

                if (Uman.GetUserTabs("TabSetup") == false)
                {                  
                    Menu1.Items.Remove(Menu1.FindItem("Setup"));
                }
                else
                {
                    if (Uman.GetUserGroups("GroupNewStore") == false)
                    {
                        //MenuItem item = Menu1.FindItem("Setup/Store");
                        //item.Parent.ChildItems.Remove(item);                    
                    }
                
                    if (Uman.GetUserGroups("GroupVendor") == false)
                    {                                                 
                        //MenuItem item = Menu1.FindItem("Setup/Vendors");
                        //item.Parent.ChildItems.Remove(item);                        
                    }

                    if (Uman.GetUserGroups("GroupItems") == false)
                    {
                        //MenuItem item = Menu1.FindItem("Setup/Item");
                        //item.Parent.ChildItems.Remove(item);
                    }

                    if (Uman.GetUserGroups("GroupItemHead") == false)
                    {
                        //MenuItem item = Menu1.FindItem("Setup/Item");
                        //item.Parent.ChildItems.Remove(item);
                    }

                    if (Uman.GetUserGroups("GroupLocation") == false)
                    {
                        //MenuItem item = Menu1.FindItem("Setup/Locations");
                        //item.Parent.ChildItems.Remove(item);
                    }                                 
                }

                //Procurement

                if (Uman.GetUserTabs("TabProcure") == false)
                {
                    Menu1.Items.Remove(Menu1.FindItem("Procurement"));

                    //MenuItem item = Menu1.FindItem("Procurement");
                    //item.Parent.ChildItems.Remove(item);
                }
                else
                {
                    if (Uman.GetUserGroups("GroupReqBudg") == false)
                    {
                        MenuItem item = Menu1.FindItem("Procurement/Requisition Budget");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupSybReq") == false)
                    {
                        MenuItem item = Menu1.FindItem("Procurement/Syllabus Requisition");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupItmRates") == false)
                    {
                        MenuItem item = Menu1.FindItem("Procurement/Item Rates");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupQuot") == false)
                    {
                        MenuItem item = Menu1.FindItem("Procurement/New Quotation");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupPO") == false)
                    {
                        MenuItem item = Menu1.FindItem("Procurement/NewPO");
                        item.Parent.ChildItems.Remove(item);
                    }

                }
                            

                //Disbursement

                if (Uman.GetUserTabs("TabDisburs") == false)
                {
                    Menu1.Items.Remove(Menu1.FindItem("Disbursement"));
                    //MenuItem item = Menu1.FindItem("Disbursement");
                    //item.Parent.ChildItems.Remove(item);
                }
                else
                {
                    if (Uman.GetUserGroups("GroupWO") == false)
                    {
                        MenuItem item = Menu1.FindItem("Disbursement/Work Order");
                        item.Parent.ChildItems.Remove(item);
                    }
                }

                
                //Material

                if (Uman.GetUserTabs("TabMaterial") == false)
                {
                    Menu1.Items.Remove(Menu1.FindItem("Material"));
                    //MenuItem item = Menu1.FindItem("Material");
                    //item.Parent.ChildItems.Remove(item);
                }
                else
                {
                    if (Uman.GetUserGroups("GroupMRequ") == false)
                    {
                        MenuItem item = Menu1.FindItem("Material/MIR");
                        item.Parent.ChildItems.Remove(item);
                    }
                }

                //Assets


                if (Uman.GetUserTabs("TabAsset") == false)
                {
                    Menu1.Items.Remove(Menu1.FindItem("Assets"));
                    //MenuItem item = Menu1.FindItem("Assets");
                    //item.Parent.ChildItems.Remove(item);
                }
                else
                {
                    if (Uman.GetUserGroups("GroupFA_OPStock") == false)
                    {
                        //MenuItem item = Menu1.FindItem("Assets/Opening Stock");
                        //item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupFA_OPBStock") == false)
                    {
                        //MenuItem item = Menu1.FindItem("Assets/Opening Bulk Stock");
                        //item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupDepartment") == false)
                    {
                        MenuItem item = Menu1.FindItem("Assets/Department");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupFA_Issue") == false)
                    {
                        MenuItem item = Menu1.FindItem("Assets/Issue Items");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupFA_Receive") == false)
                    {
                        MenuItem item = Menu1.FindItem("Assets/Received Items");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupFA_Status") == false)
                    {
                        MenuItem item = Menu1.FindItem("Assets/Item Status");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupSports") == false)
                    {
                        MenuItem item = Menu1.FindItem("Assets/DOCUpdate");
                        item.Parent.ChildItems.Remove(item);
                    }

                }

                //Store

                if (Uman.GetUserTabs("TabStore") == false)
                {
                    Menu1.Items.Remove(Menu1.FindItem("Store"));
                    //MenuItem item = Menu1.FindItem("Store");
                    //item.Parent.ChildItems.Remove(item);
                }
                else
                {
                    if (Uman.GetUserGroups("GroupOPStock") == false)
                    {
                        //MenuItem item = Menu1.FindItem("Store/Opening Stock");
                        //item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupOPBStock") == false)
                    {
                        //MenuItem item = Menu1.FindItem("Store/Opening Bulk Stock");
                        //item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupStore") == false)
                    {
                        MenuItem item = Menu1.FindItem("Store/Store");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupIssue") == false)
                    {
                        MenuItem item = Menu1.FindItem("Store/Issue Items");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupReceive") == false)
                    {
                        MenuItem item = Menu1.FindItem("Store/Receive Items");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupITM_Status") == false)
                    {
                        MenuItem item = Menu1.FindItem("Store/Item Status");
                        item.Parent.ChildItems.Remove(item);
                    }
                }
     

               // Reports
                if (Uman.GetUserTabs("TabReport") == false)
                {
                    Menu1.Items.Remove(Menu1.FindItem("Reports"));
                    //MenuItem item = Menu1.FindItem("Reports");
                    //item.Parent.ChildItems.Remove(item);
                }
                else
                {
                    if (Uman.GetUserGroups("GroupItemList") == false)
                    {
                        MenuItem item = Menu1.FindItem("Reports/Item List");
                        item.Parent.ChildItems.Remove(item);
                    }

                    if (Uman.GetUserTabs("IBR Reports") == false)
                    {
                        Menu1.Items.Remove(Menu1.FindItem("IBR Reports"));
                    }
                    else
                    {
                        if (Uman.GetUserGroups("GroupInvBalance") == false)
                        {
                            MenuItem item = Menu1.FindItem("Reports/IBR Reports/Inv. Balance");
                            item.Parent.ChildItems.Remove(item);
                        }

                        if (Uman.GetUserGroups("GroupFullInvBalance") == false)
                        {
                            MenuItem item = Menu1.FindItem("Reports/IBR Reports/Full Inv. Balance");
                            item.Parent.ChildItems.Remove(item);
                        }
                        if (Uman.GetUserGroups("GroupITInvBalance") == false)
                        {
                            MenuItem item = Menu1.FindItem("Reports/IBR Reports/IT Inv. Balance");
                            item.Parent.ChildItems.Remove(item);
                        }
                    }
                    //if (Uman.GetUserGroups("GroupMIRRPT") == false)
                    //{
                    //    MenuItem item = Menu1.FindItem("Reports/Store Trans.");
                    //    item.Parent.ChildItems.Remove(item);
                    //}
                    if (Uman.GetUserGroups("GroupMIR") == false)
                    {
                        MenuItem item = Menu1.FindItem("Reports/MIR");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupGRN") == false)
                    {
                        MenuItem item = Menu1.FindItem("Reports/GRN");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupGIN") == false)
                    {
                        MenuItem item = Menu1.FindItem("Reports/GIN");
                        item.Parent.ChildItems.Remove(item);
                    }
                    if (Uman.GetUserGroups("GroupGPass") == false)
                    {
                        MenuItem item = Menu1.FindItem("Reports/GatePass");
                        item.Parent.ChildItems.Remove(item);
                    }
                    //if (Uman.GetUserGroups("GroupINVLedger") == false)
                    //{
                    //    MenuItem item = Menu1.FindItem("Reports/Opening Stock");
                    //    item.Parent.ChildItems.Remove(item);
                    //}

                  
                    if (Uman.GetUserGroups("GroupItemFreqList") == false)
                    {
                        MenuItem item = Menu1.FindItem("Reports/Item Frequency");
                        item.Parent.ChildItems.Remove(item);
                    }
    
                    //Admin Reports
                    //if (Uman.Uid == 2924)
                    //{
                      
                       
                    //}
                    if (Uman.GetUserTabs("Admin Reports") == false)
                    {
                        MenuItem item = Menu1.FindItem("Reports/Admin Reports");
                        item.Parent.ChildItems.Remove(item);
                    }
                    else
                    {

                        if (Uman.GetUserGroups("GroupStoreTrans") == false)
                        {
                            MenuItem item = Menu1.FindItem("Reports/Admin Reports/Store Trans.");
                            item.Parent.ChildItems.Remove(item);
                        }
                        if (Uman.GetUserGroups("GroupRequ") == false)
                        {
                            MenuItem item = Menu1.FindItem("Reports/Admin Reports/Requisition");
                            item.Parent.ChildItems.Remove(item);
                        }
                        if (Uman.GetUserGroups("GroupStockRequ") == false)
                        {
                            MenuItem item = Menu1.FindItem("Reports/Admin Reports/RequisitionStock");
                            item.Parent.ChildItems.Remove(item);
                        }
                        if (Uman.GetUserGroups("GroupConsRequ") == false)
                        {
                            MenuItem item = Menu1.FindItem("Reports/Admin Reports/Cons.RequisitionStock");
                            item.Parent.ChildItems.Remove(item);
                        }
                        if (Uman.GetUserGroups("GroupSybDist") == false)
                        {
                            MenuItem item = Menu1.FindItem("Reports/Admin Reports/SyllabusDistributionList");
                            item.Parent.ChildItems.Remove(item);
                        }

                    }

                }
 
    


            }

         
         //   this.RadRibbonBar1.FindGroupByValue("GroupStore").Focus();

            

        }


        protected void RadRibbonBar1_Load(object sender, EventArgs e)
        {

        }

        protected void RadMenu1_ItemDataBound(object sender, RadMenuEventArgs e)
        {
            if (e.Item.Text == "Home")
            {
                e.Item.Attributes["NavigateUrl"] = e.Item.NavigateUrl;
                e.Item.NavigateUrl = "Main.aspx";
            }
        } 

        protected void RadRibbonBar1_ApplicationMenuItemClick(object sender, RibbonBarApplicationMenuItemClickEventArgs e)
        {
            //RadRibbonBar rrb = (RadRibbonBar)sender;

            
        }

        protected void RadRibbonBar1_ButtonClick(object sender, RibbonBarButtonClickEventArgs e)
        {
            if (e.Button.Value == "btnStore")
            {                
                Response.Redirect("StoreInventory.aspx");
                e.Group.Focus();
            }
        }

        protected void RadRibbonBar1_SelectedTabChange(object sender, RibbonBarSelectedTabChangeEventArgs e)
        {
            e.Tab.Focus();
        }

        protected void ChooseDesktopImage_PreRender(object sender, EventArgs e)
        {
            
        }

        protected void Department_Click(object sender, EventArgs e)
        {
         //   this.RadRibbonBar1.FindTabByValue("Assets").Focus();
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        //protected void showMessageBox(string message)
        //{
        //    string sScript;
        //    message = message.Replace("'", "\'");
        //    sScript = String.Format("alert('{0}');", message);
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        //}


        //protected void RadRibbonBar1_ButtonClick(object sender, RibbonBarButtonClickEventArgs e)
        //{
        //    string message = string.Format("Button {0} was clicked.", e.Button.Text);
        //    string details = string.Format("Group: {0}, Index: {1}", e.Group.Text, e.Index);

        //    // textBox1.Text = string.Format("{0} {1}", message, details);

        //    //showMessageBox(string.Format("{0} {1}", message, details));
        //}

    }
}