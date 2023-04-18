using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace IMS
{
    public partial class DataEditForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadGrid1_BatchEditCommand(object sender, Telerik.Web.UI.GridBatchEditingEventArgs e)
        {
            SavedChangesList.Visible = true;
        }
 
        protected void RadGrid1_ItemUpdated(object source, Telerik.Web.UI.GridUpdatedEventArgs e)
        {
           
            GridEditableItem item = (GridEditableItem)e.Item;
            

            String id = item.GetDataKeyValue("pkRecvID").ToString();
            if (e.Exception != null)
            {
                e.KeepInEditMode = true;
                e.ExceptionHandled = true;
                NotifyUser("Item with ID " + id + " cannot be updated. Reason: " + e.Exception.Message);
            }
            else
            {
                NotifyUser("Item with ID " + id + " is updated!");
            }
        }

        protected void RadGrid1_ItemInserted(object sender, Telerik.Web.UI.GridInsertedEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                NotifyUser("Item cannot be inserted. Reason: " + e.Exception.Message);
            }
            else
            {
                NotifyUser("New Item is inserted!");
            }


        }


        protected void RadGrid1_ItemDeleted(object sender, Telerik.Web.UI.GridDeletedEventArgs e)
        {
            GridDataItem dataItem = (GridDataItem)e.Item;

            String id = dataItem.GetDataKeyValue("pkRecvID").ToString();
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                NotifyUser("Item with ID " + id + " cannot be deleted. Reason: " + e.Exception.Message);
            }
            else
            {
                NotifyUser("Item with ID " + id + " is deleted!");
            }

        }

 
        //protected void RadGrid1_PreRender(object sender, EventArgs e)
        //{
           
        //    //RadNumericTextBox unitsNumericTextBox = (RadGrid1.MasterTableView.GetBatchColumnEditor("fkItemID") as GridNumericColumnEditor).NumericTextBox;
        //    //unitsNumericTextBox.Width = Unit.Pixel(60);

        //    //TextBox QuantityPerUnitTextBox = (RadGrid1.MasterTableView.GetBatchColumnEditor("Qtty") as GridTextBoxColumnEditor).TextBoxControl;
        //    //QuantityPerUnitTextBox.Width = Unit.Pixel(120);
        //}
 
        private void NotifyUser(string message)
        {
            //RadListBoxItem commandListItem = new RadListBoxItem();
            //commandListItem.Text = message;
            //SavedChangesList.Items.Add(commandListItem);

            string sScript;
            message = message.Replace("'", "\'");
            sScript = String.Format("alert('{0}');", message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
        }
 
        protected void rblChangeButtonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem selectedItem = rblChangeEditEventType.SelectedItem;
            switch (selectedItem.Value)
            {
                case "click":
                    RadGrid1.MasterTableView.BatchEditingSettings.OpenEditingEvent = GridBatchEditingEventType.Click;
                    break;
                case "dblclick":
                    RadGrid1.MasterTableView.BatchEditingSettings.OpenEditingEvent = GridBatchEditingEventType.DblClick;
                    break;
                case "mousedown":
                    RadGrid1.MasterTableView.BatchEditingSettings.OpenEditingEvent = GridBatchEditingEventType.MouseDown;
                    break;
                case "mouseup":
                    RadGrid1.MasterTableView.BatchEditingSettings.OpenEditingEvent = GridBatchEditingEventType.MouseUp;
                    break;
            }
            RadGrid1.Rebind();
        }
 
        protected void rblChangeEditType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem selectedItem = rblChangeEditType.SelectedItem;
            switch (selectedItem.Value)
            {
                case "Row":
                    RadGrid1.MasterTableView.BatchEditingSettings.EditType = GridBatchEditingType.Row;
                    break;
                case "Cell":
                    RadGrid1.MasterTableView.BatchEditingSettings.EditType = GridBatchEditingType.Cell;
                    break;
            }
            RadGrid1.Rebind();
        }

        protected void txtGRN_TextChanged(object sender, EventArgs e)
        {
             RadGrid1.Rebind();
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            RadGrid1.Rebind();
            SavedChangesList.Visible = false;
        }


    }
}