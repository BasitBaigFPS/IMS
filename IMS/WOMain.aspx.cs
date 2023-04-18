using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Telerik.Web.UI;
using Telerik.Web.UI.Menu;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using BLL;
using DAL;



namespace IMS
{
    public partial class WOMain : System.Web.UI.Page
    {
        UserManager Uman = new UserManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];

            Uman.Uid = int.Parse(IMS["uid"]);
            Uman.Ubrhid = int.Parse(IMS["ubrhid"]);

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            HttpCookie IMS = Request.Cookies["IMS"];

            Uman.Uid = int.Parse(IMS["uid"]);
            Uman.Ubrhid = int.Parse(IMS["ubrhid"]);

            txtuserID.Text = IMS["uid"].ToString();

            if (RadGrid1.SelectedIndexes.Count == 0)
                RadGrid1.SelectedIndexes.Add(0);

            if (RadGrid2.SelectedIndexes.Count == 0)
            {
               // RadGrid2.Rebind();
               // RadGrid2.SelectedIndexes.Add(0);
                 
            }
        }


        //http://demos.telerik.com/aspnet-ajax/grid/examples/data-editing/automatic-crud-operations/defaultcs.aspx

        protected void RadGrid1_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (!(e.Item is GridEditFormInsertItem))
                {
                    GridEditableItem item = e.Item as GridEditableItem;
                    GridEditManager manager = item.EditManager;
                    GridTextBoxColumnEditor editor = manager.GetColumnEditor("EstimateNo") as GridTextBoxColumnEditor;
                    editor.TextBoxControl.Enabled = false;
                }
            }
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            RadGrid2.SelectedIndexes.Clear();
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        protected void RadGrid1_ItemUpdated(object sender, Telerik.Web.UI.GridUpdatedEventArgs e)
        {

        }

        protected void RadGrid1_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditFormItem)
                {
                    GridEditFormItem item = (GridEditFormItem)e.Item;
                    int id = Convert.ToInt32(item.GetDataKeyValue("EstimateNo"));

                    GridEditableItem edititem = e.Item as GridEditableItem;

                    //string wnews = (string)DataBinder.Eval(e.Item.DataItem,"news");  

                    string wnews = (edititem["Description"].Controls[0] as TextBox).Text;



                    if (id != 0)
                    {
                        //bool chk = Convert.ToBoolean(item.GetDataKeyValue("isactive"));
                        bool chk = (edititem["IsCancelled"].Controls[0] as CheckBox).Checked;

                        if (chk == true)
                        {
                          //  setpara(id, wnews, 1);
                        }
                        else
                        {
                           // setpara(id, wnews, 0);
                        }
                    }
                }
            }
        }

        protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
        {
            if (e.Item is GridEditableItem)
            {
                GridEditableItem editedItem = e.Item as GridEditableItem;
                //here editedItem.SavedOldValues will be the dictionary which holds the
                //predefined values

                //Prepare new dictionary object
                Hashtable newValues = new Hashtable();
                e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);
                //the newValues instance is the new collection of key -> value pairs
                //with the updated ny the user data
            }
        }
   
        protected void RadGrid1_ItemInserted(object source, GridInsertedEventArgs e)
        {
            if (e.Exception != null)
            {

                e.ExceptionHandled = true;
                SetMessage("Customer cannot be inserted. Reason: " + e.Exception.Message);

            }
            else
            {
                SetMessage("New customer is inserted!");
            }
        }

        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gridMessage))
            {
                DisplayMessage(gridMessage);
            }
        }



        protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        protected void RadGrid2_ItemUpdated(object sender, Telerik.Web.UI.GridUpdatedEventArgs e)
        {

        }

        protected void RadGrid2_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (e.Item is GridEditFormItem)
                {
                    GridEditFormItem item = (GridEditFormItem)e.Item;
                    int id = Convert.ToInt32(item.GetDataKeyValue("EstimateNo"));

                    GridEditableItem edititem = e.Item as GridEditableItem;

                    //string wnews = (string)DataBinder.Eval(e.Item.DataItem,"news");  

                    string workdesc = (edititem["WorkDesc"].Controls[0] as TextBox).Text;

                    string wcost = (edititem["Cost"].Controls[0] as TextBox).Text;

                    if (id != 0)
                    {
                        //bool chk = Convert.ToBoolean(item.GetDataKeyValue("isactive"));
                      
                    }
                }
            }
        }
        
        
        //protected void RadGrid2_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        //{
        //    if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        //    {
        //        if (!(e.Item is GridEditFormInsertItem))
        //        {
        //            GridEditableItem item = e.Item as GridEditableItem;
        //            GridEditManager manager = item.EditManager;
        //            GridTextBoxColumnEditor editor = manager.GetColumnEditor("EstimateNo") as GridTextBoxColumnEditor;
        //            editor.TextBoxControl.Enabled = false;
        //        }
        //    }
        //}
   
        //protected void RadGrid2_ItemInserted(object source, GridInsertedEventArgs e)
        //{
        //    if (e.Exception != null)
        //    {

        //        e.ExceptionHandled = true;
        //        SetMessage("Work/Project cannot be inserted. Reason: " + e.Exception.Message);

        //    }
        //    else
        //    {
        //        SetMessage("New Work is inserted!");
        //    }
        //}

        //protected void RadGrid2_PreRender(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(gridMessage))
        //    {
        //        DisplayMessage(gridMessage);
        //    }
        //}

        //protected void RadGrid2_InsertCommand(object sender, GridCommandEventArgs e)
        //{
        //    if (e.Item is GridEditableItem)
        //    {
        //        GridEditableItem editedItem = e.Item as GridEditableItem;
        //        //here editedItem.SavedOldValues will be the dictionary which holds the
        //        //predefined values

        //        //Prepare new dictionary object
        //        Hashtable newValues = new Hashtable();
        //        e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);
        //        //the newValues instance is the new collection of key -> value pairs
        //        //with the updated ny the user data
        //    }
        //}

        //protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
        //{
        //    //Accessing Edit Form
        //    if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        //    {
        //        GridEditableItem editItem = (GridEditableItem)e.Item;
        //        // Access textbox using column UniqueName  
        //        //TextBox txtAction = (TextBox)editItem["WorkDesc"].Controls[0];
        //        //txtAction.Width = 500;
        //        //txtAction.TextMode = TextBoxMode.MultiLine;
        //    }
        //}

 
        
        
        
        protected void RadGrid3_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        private static DataTable GetDataTable(string queryString)
        {
            String ConnString = SqlHelper.connectionstring;
            SqlConnection MySqlConnection = new SqlConnection(ConnString);
            SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter();
            MySqlDataAdapter.SelectCommand = new SqlCommand(queryString, MySqlConnection);

            DataTable myDataTable = new DataTable();
            MySqlConnection.Open();
            try
            {
                MySqlDataAdapter.Fill(myDataTable);
            }
            finally
            {
                MySqlConnection.Close();
            }

            return myDataTable;
        }

        private DataTable WOMaster
        {
            get
            {
                object obj = this.Session["WOMaster"];
                if ((!(obj == null)))
                {
                    return ((DataTable)(obj));
                }
                DataTable myDataTable = new DataTable();
                myDataTable = GetDataTable("SELECT * FROM tblWOMaster");
                this.Session["WOMaster"] = myDataTable;
                return myDataTable;
            }
        }

        private DataTable GridSource
        {
            get
            {
                Object obj = this.ViewState["_gds"];
                if (obj != null)
                {
                    return (DataTable)obj;
                }
                else
                {
                    string queryString = "SELECT EstMastID,EstimateNo,WorkNo,WorkDesc,Cost,Paid FROM [INVENTORY].[dbo].[tblWOMaster] Order By EstimateNo,WorkNo";
                    String ConnString = SqlHelper.connectionstring;
                    SqlConnection MySqlConnection = new SqlConnection(ConnString);
                    SqlDataAdapter MySqlDataAdapter = new SqlDataAdapter();
                    MySqlDataAdapter.SelectCommand = new SqlCommand(queryString, MySqlConnection);
                    
                    
                    
                    
                    //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
                    //  System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Nwind.mdb"));
                    //OleDbDataAdapter adapter = new OleDbDataAdapter();
                    //adapter.SelectCommand = new OleDbCommand("SELECT TOP 10 OrderID, EmployeeID, OrderDate, ShipName FROM Orders", conn);



                    DataTable table = new DataTable();
                    MySqlConnection.Open();
                    try
                    {
                        MySqlDataAdapter.Fill(table);

                        //adapter.Fill(table);
                    }
                    finally
                    {
                        MySqlConnection.Close();
                    }
                    this.ViewState["_gds"] = table;
                    return table;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            tblWOMain.SelectCommand = "SELECT [EstimateNo],[Description] FROM [INVENTORY].[dbo].[tblWOMain] where fkUserID=@UserID and Estimateno='" + txtEstimateno.Text + "'";
            RadGrid1.Rebind();
        }

        private void DisplayMessage(string text)
        {
            RadGrid1.Controls.Add(new LiteralControl(string.Format("<span style='color:red'>{0}</span>", text)));
        }

        private void SetMessage(string message)
        {
            gridMessage = message;
        }

        private string gridMessage = null;


    }
        
}