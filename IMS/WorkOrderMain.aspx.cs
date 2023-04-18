using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace IMS
{
    public partial class WorkOrderMain : System.Web.UI.Page
    {
        protected void RadGrid1_BatchEditCommand(object sender, Telerik.Web.UI.GridBatchEditingEventArgs e)
        {
            SavedChangesList.Visible = true;
        }

        protected void RadGrid1_ItemUpdated(object source, Telerik.Web.UI.GridUpdatedEventArgs e)
        {
            GridEditableItem item = (GridEditableItem)e.Item;
            String id = item.GetDataKeyValue("ProductID").ToString();
            if (e.Exception != null)
            {
                e.KeepInEditMode = true;
                e.ExceptionHandled = true;
                NotifyUser("Product with ID " + id + " cannot be updated. Reason: " + e.Exception.Message);
            }
            else
            {
                NotifyUser("Product with ID " + id + " is updated!");
            }
        }

        protected void RadGrid1_ItemInserted(object source, GridInsertedEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                NotifyUser("Product cannot be inserted. Reason: " + e.Exception.Message);
            }
            else
            {
                NotifyUser("New product is inserted!");
            }
        }

        protected void RadGrid1_ItemDeleted(object source, GridDeletedEventArgs e)
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            String id = dataItem.GetDataKeyValue("ProductID").ToString();
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                NotifyUser("Product with ID " + id + " cannot be deleted. Reason: " + e.Exception.Message);
            }
            else
            {
                NotifyUser("Product with ID " + id + " is deleted!");
            }

        }

        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            RadNumericTextBox unitsNumericTextBox = (RadGrid1.MasterTableView.GetBatchColumnEditor("UnitsInStock") as GridNumericColumnEditor).NumericTextBox;
            unitsNumericTextBox.Width = Unit.Pixel(60);
        }

        private void NotifyUser(string message)
        {
            RadListBoxItem commandListItem = new RadListBoxItem();
            commandListItem.Text = message;
            SavedChangesList.Items.Add(commandListItem);
        }

        protected void rblChangeButtonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListItem selectedItem = rblChangeEditEventType.SelectedItem;
            //switch (selectedItem.Value)
            //{
            //    case "click":
            //        RadGrid1.MasterTableView.BatchEditingSettings.OpenEditingEvent = GridBatchEditingEventType.Click;
            //        break;
            //    case "dblclick":
            //        RadGrid1.MasterTableView.BatchEditingSettings.OpenEditingEvent = GridBatchEditingEventType.DblClick;
            //        break;
            //    case "mousedown":
            //        RadGrid1.MasterTableView.BatchEditingSettings.OpenEditingEvent = GridBatchEditingEventType.MouseDown;
            //        break;
            //    case "mouseup":
            //        RadGrid1.MasterTableView.BatchEditingSettings.OpenEditingEvent = GridBatchEditingEventType.MouseUp;
            //        break;
            //}
            //RadGrid1.Rebind();
        }

        protected void rblChangeEditType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListItem selectedItem = rblChangeEditType.SelectedItem;
            //switch (selectedItem.Value)
            //{
            //    case "Row":
            //        RadGrid1.MasterTableView.BatchEditingSettings.EditType = GridBatchEditingType.Row;
            //        break;
            //    case "Cell":
            //        RadGrid1.MasterTableView.BatchEditingSettings.EditType = GridBatchEditingType.Cell;
            //        break;
            //}
            //RadGrid1.Rebind();
        }
    }
}