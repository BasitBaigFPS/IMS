using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
//using Model.ReadOnly;

namespace IMS
{
    public partial class DefaultTelerikPivotGrid : System.Web.UI.Page
    {
  
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            chkBox1.CheckedChanged += new EventHandler(chkBox1_CheckedChanged);
            chkBox2.CheckedChanged += new EventHandler(chkBox2_CheckedChanged);
            chkBox3.CheckedChanged += new EventHandler(chkBox3_CheckedChanged);
            chkBox4.CheckedChanged += new EventHandler(chkBox4_CheckedChanged);
            chkBox5.CheckedChanged += new EventHandler(chkBox5_CheckedChanged);
            RadPivotGrid1.NeedDataSource += new EventHandler<PivotGridNeedDataSourceEventArgs>(RadPivotGrid1_NeedDataSource);
        }
 
        protected void chkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RadPivotGrid1.AllowSorting = chkBox1.Checked;
            RadPivotGrid1.Rebind();
        }
        protected void chkBox2_CheckedChanged(object sender, EventArgs e)
        {
            RadPivotGrid1.ShowColumnHeaderZone = chkBox2.Checked;
            RadPivotGrid1.Rebind();
        }
        protected void chkBox3_CheckedChanged(object sender, EventArgs e)
        {
            RadPivotGrid1.ShowRowHeaderZone = chkBox3.Checked;
            RadPivotGrid1.Rebind();
        }
        protected void chkBox4_CheckedChanged(object sender, EventArgs e)
        {
            RadPivotGrid1.ShowDataHeaderZone = chkBox4.Checked;
            RadPivotGrid1.Rebind();
        }
        protected void chkBox5_CheckedChanged(object sender, EventArgs e)
        {
            RadPivotGrid1.EnableZoneContextMenu = chkBox5.Checked;
            RadPivotGrid1.Rebind();
        }

        private NorthwindReadOnlyEntities dataContext;

        protected NorthwindReadOnlyEntities DbContext
        {
            get
            {
                if (dataContext == null)
                {
                    dataContext = new NorthwindReadOnlyEntities();
                }
                return dataContext;
            }

        }
 
        protected void RadPivotGrid1_NeedDataSource(object sender, PivotGridNeedDataSourceEventArgs e)
        {
 
            var orderDetails = from o in DbContext.Orders
                               join od in DbContext.Order_Details on o.OrderID equals od.OrderID
                               join p in DbContext.Products on od.ProductID equals p.ProductID
                               where o.OrderDate.Value.Year >= 1997
                               select new
                               {
                                   Year = o.OrderDate.Value.Year,
                                   Quarter = (o.OrderDate.Value.Month / 4) + 1,
                                   ProductName = p.ProductName,
                                   Category = p.Category.CategoryName,
                                   TotalPrice = od.UnitPrice * od.Quantity,
                                   Quantity = od.Quantity,
                                   Discount = od.Discount
                               };
            RadPivotGrid1.DataSource = orderDetails;
        }
        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }
}






}