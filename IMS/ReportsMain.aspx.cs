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

namespace IMS
{
    public partial class ReportsMain : System.Web.UI.Page
    {
        UserManager UMan = new UserManager();
        IMSManager iman = new IMSManager();
        StoreManager sm = new StoreManager();
        RequisitionManager Reqman = new RequisitionManager();

       
        //Telerik.Reporting.Report report = new Telerik.Reporting.Report();
        Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();

        //Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
        //Telerik.Reporting.SqlDataSourceParameter sqlpara = new Telerik.Reporting.SqlDataSourceParameter();
        //Telerik.Reporting.Processing.ReportProcessor reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            //System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
            //printerSettings.PrinterName = GetDefaultPrinter();
            //System.Drawing.Printing.StandardPrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
            //Telerik.Reporting.Report rpt = new Telerik.Reporting.Report();

  
            //Report Name Paramters Through Query String
            String rpt = Request.QueryString["rptname"];
            String grnno = Request.QueryString["grno"];     //For Goods Receipt Note
            String ginno = Request.QueryString["gino"];     //For Goods Issue Note
            String INVCode = Request.QueryString["INVCode"];  //For Inventory Code Ledger
            String mirno = Request.QueryString["mirno"];     //For MIR 
            String gpno = Request.QueryString["gpno"];     //For Gate Pass
            String pono = Request.QueryString["pono"];     //For Purchase Order
            String reqno = Request.QueryString["reqno"];     //For Quarterly Requisition

            String isustat = Request.QueryString["isustat"];   //Items Issuance Status (Permanent / Temporary)

            String brhid = Request.QueryString["UserBranch"];

            

            String sybreqno = "0";
            Boolean showcancel = false;

            int reqcat = 5;

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");



            iman.PrintGRN = int.Parse(grnno == "" || grnno == null ? "0" : grnno);
            iman.PrintGIN = int.Parse(ginno == "" || ginno == null ? "0" : ginno);
            iman.PrintMIR = int.Parse(mirno == "" || mirno == null ? "0" : mirno);
            iman.PrintGP = int.Parse(gpno == "" || gpno == null ? "0" : gpno);
            iman.PrintQRF = int.Parse(reqno == "" || reqno == null ? "0" : reqno);
            iman.PrintSybRQ = int.Parse(sybreqno == "" || sybreqno == null ? "0" : sybreqno);

            iman.PrintPO = int.Parse(pono == "" || pono == null ? "0" : pono);

            iman.PrintQRCat = reqcat;
            iman.InvCode = INVCode;

            iman.PrintSysType = "KH";

            //IMS["grpuserdptid"]

            
            iman.Uid = int.Parse(IMS["uid"]);
            UMan.Uname = IMS["uname"].ToString();

            UMan.Ugid = int.Parse(IMS["ugroupid"]);
            iman.Pkbrhid = int.Parse(IMS["grpuserbrhid"]);
            iman.Pkdeptid = int.Parse(IMS["grpuserdptid"] == null ? "0" : IMS["grpuserdptid"]);
            iman.PkstoreID = int.Parse(IMS["grpuserstoreid"]);
            

            iman.PksysID = iman.GetBranchSystemID(iman.Pkbrhid);

            //This Block Needs To Be Modified/Update Later to Make These Manual Checks directly from the Database Records. --Basit
            //==========================================================================================================




            //if (iman.Pkbrhid != 19)
            //{
            //    iman.PkstoreID = iman.GetStores(iman.Pkbrhid);
            //}             

            //if (UMan.Ugid == 31 || UMan.Ugid == 32 || UMan.Ugid == 39)    //All Branches Kitchen & Regular Store Managment Group
            //{
            //    iman.Pkdeptid = 14;
            //}

            //if (UMan.Ugid == 31 && iman.Pkbrhid == 19 || UMan.Ugid == 32 && iman.Pkbrhid == 19)   //Head Office Kitchen & Regular Store Managmenet Group
            //{
            //    iman.Pkdeptid = 14;
            //    iman.PkstoreID = 2;
            //}
            //if (UMan.Ugid == 28 || UMan.Ugid == 29)   //SMCHS Main Store Management Group
            //{
            //    iman.Pkdeptid = 14;
            //    iman.PkstoreID = 1;
            //}
            //if (UMan.Ugid == 37)   //I.T Assest Management Group
            //{
            //    iman.Pkdeptid = 10;
            //    iman.PkstoreID = 22;
            //}

            //if (UMan.Ugid == 38)   //General Assest Management Group
            //{
            //    iman.PkstoreID = 0;
            //}
            //if (UMan.Ugid == 79)   //Sports Assest Management Group
            //{
            //    iman.Pkdeptid = 17;
            //    iman.PkstoreID = 0;
            //}

            
            //=========================================================================================

            //if (!IsPostBack)
            //{       

                //Set Report Viewer Parameters
                        //this.ReportViewer1.ShowPrintButton = true;
                        //this.ReportViewer1.ShowPrintPreviewButton = true;
                        //this.ReportViewer1.ShowExportGroup = true;
                //RV.Report.PageSettings.BackgroundColor
                

                // Specifying an URL or a file path


                if (rpt == "ItemList")
                {

                    ItemList("Reports/CategoryWiseItemList.trdx");                    
                }

                if (rpt == "AssetsCodeLables")
                {
                    AssetsCodeList("Reports/AssetsCodeLables.trdx");
                }

                if (rpt == "GINAssetsCodeList")
                {
                    GINAssetsCodeList("Reports/GINAssetsCodeList.trdx");
                }

                if (rpt == "ItemsRateList")
                {
                    ItemRateList("Reports/ItemsRateList.trdx");
                }


                if (rpt == "FullStoreInventoryBalances")
                {
                    ItemBalance1("Reports/FullStoreInventoryBalances.trdx");
                }

                if (rpt == "StoreInventoryBalancesCustom")
                {
                    ItemBalanceCustom("Reports/StoreInventoryBalancesCustom.trdx");
                }

                if (rpt == "StoreInventoryBalances")
                {

                    if (UMan.Ugid == 27 || UMan.Ugid == 28 || UMan.Ugid == 29 || UMan.Ugid == 39 || UMan.Ugid == 33 || UMan.Ugid == 49)
                    {
                       ItemBalance1("Reports/StoreInventoryBalances_All.trdx");
                    }
                    else
                    { 
                      ItemBalance1("Reports/StoreInventoryBalances.trdx");
                    }
                }

                if (rpt == "ITInventoryBalances")
                {
                    ItemITBalance("Reports/ITInventoryBalances.trdx");
                }

                if (rpt == "SPInventoryBalances")
                {
                   ItemSPRBalance("Reports/SPInventoryBalances.trdx");
                }


                if (rpt == "StoreInventoryValuation_ALL")
                {
                    InventoryValuation("Reports/StoreInventoryValuation_ALL.trdx");
                }
          

                if (rpt == "StoreTransactionsInfo")
                {
                    StoreTransaction("Reports/StoreTransactionsInfo.trdx");                
                }

                if (rpt == "ItemsFrequencyReport")
                {
                    ItemFrequency("Reports/ItemsFrequencyReport.trdx");
                }

                if (rpt == "GoodsReceiptNote")
                {
                    if (txtDocID.Text == "")
                    {

                        if (iman.PrintGRN == 0)
                        {
                            iman.PrintGRN = int.Parse(iman.GetLastID(iman.Pkbrhid, iman.Pkdeptid, "GRN") == "" ? "0" : iman.GetLastID(iman.Pkbrhid, iman.Pkdeptid, "GRN"));

                        }

                        txtDocID.Text = iman.PrintGRN.ToString();
                    }
                    else
                    {
                        iman.PrintGRN = int.Parse(txtDocID.Text);
                    }

                    GoodReceiveNote1("Reports/GoodsReceiptNote.trdx", iman.PrintGRN);                   
                }

                if (rpt == "GoodsIssueNote")
                {
                    if (txtDocID.Text == "")
                    {
                        if (iman.PrintGIN == 0)
                        {
                            iman.PrintGIN = int.Parse(iman.GetLastID(iman.Pkbrhid, iman.Pkdeptid, "GIN") == "" ? "0" : iman.GetLastID(iman.Pkbrhid, iman.Pkdeptid, "GIN"));
                        }
                        txtDocID.Text = iman.PrintGIN.ToString();
                    }
                    else
                    {
                        iman.PrintGIN = int.Parse(txtDocID.Text);
                    }

                    GoodIssueNote1("Reports/GoodsIssueNote.trdx", iman.PrintGIN);
                }

                if (rpt == "MaterialReturnGIN")
                {
                    if (txtDocID.Text == "")
                    {
                        if (iman.PrintGIN == 0)
                        {
                            iman.PrintGIN = int.Parse(iman.GetLastID(iman.Pkbrhid, iman.Pkdeptid, "GIN") == "" ? "0" : iman.GetLastID(iman.Pkbrhid, iman.Pkdeptid, "GIN"));
                        }
                        txtDocID.Text = iman.PrintGIN.ToString();
                    }
                    else
                    {
                        iman.PrintGIN = int.Parse(txtDocID.Text);
                    }

                    MaterialReturnGIN("Reports/MaterialReturnGIN.trdx", iman.PrintGIN);
                }

                if (rpt == "GIN_GRN_Info")
                {
                    GIN_GRN_Info("Reports/GIN_GRN_Info.trdx");
                }


                if (rpt == "DailyStoreTransactions")
                {
                    DailyTrans("Reports/DailyStoreTransactions.trdx");
                }


                if (rpt == "ItemLedger")
                {
                    ItemLedger("Reports/ItemLedger.trdx", iman.InvCode);
                }

                if (rpt == "LinkItemLedger")
                {
                    LinkItemLedger("Reports/LinkItemLedger.trdx", iman.InvCode);
                }

                
                if (rpt == "MaterialIssueRequest")
                {
                    if (txtDocID.Text == "")
                    {
                        if (iman.PrintMIR == 0)
                        {
                            iman.PrintMIR = int.Parse(iman.GetLastID(iman.Pkbrhid, iman.Pkdeptid, "MIR") == "" ? "0" : iman.GetLastID(iman.Pkbrhid, iman.Pkdeptid, "MIR"));
                        }
                        txtDocID.Text = iman.PrintMIR.ToString();
                    }
                    else
                    {
                        iman.PrintMIR = int.Parse(txtDocID.Text);
                    }

                    txtDocID.Text = iman.PrintMIR.ToString();
                     
                    MIR1("Reports/MaterialIssueRequest.trdx", iman.PrintMIR);
                }

                if (rpt == "GatePass")
                {
                    GatePass1("Reports/GatePass.trdx", iman.PrintGP);
                }

                if (rpt == "PurchaseOrder")
                {
                    PurchaseOrder("Reports/PurchaseOrder.trdx", iman.PrintPO);
                }

                if (rpt == "ITRequisition")
                {
                    ITRequisition("Reports/AnnualITRequisition.trdx", iman.PrintQRF);
                }

                if (rpt == "QuarterlyRequisition")
                {
                    if (iman.Pkdeptid == 31)
                    {
                        LabRequisition("Reports/QuarterlyLabRequisition.trdx", iman.PrintQRF);
                    }
                   
                    else
                    {
                        
                       //DateTime expiration_date = DateTime.ParseExact("12/23/2017", "M/d/yyyy", CultureInfo.InvariantCulture);
                       //DateTime currentDateTime = DateTime.Now;
                       //if (expiration_date < currentDateTime)
                       //{
                       //    Requisition("Reports/QuarterlyRequisition_Expiry.trdx", iman.PrintQRF);
                       //}
                       //else
                       //{
                       //    Requisition("Reports/QuarterlyRequisition.trdx", iman.PrintQRF);
                       //}

                       Requisition("Reports/QuarterlyRequisition.trdx", iman.PrintQRF);

                    }
                }


                if (rpt == "SYB_AnnualRequisition")
                {

                    SybReq_Annual("Reports/SYB_AnnualRequisition.trdx",iman.PrintSybRQ);
                }

                if (rpt == "SYB_ReqType_PCRatio")
                {

                    SybReq_PerChildRatioList("Reports/SYB_ReqType_PCRatio.trdx");
                }

                if (rpt == "SYB_DistributionList")
                {

                    SybDistributionList("Reports/SYB_DistributionList.trdx");
                }

                if (rpt == "BW_ConsQuartRequisition")
                {
                    Consol_Requisition("Reports/BW_ConsQuartRequisition.trdx", iman.PrintQRCat);
                }

                if (rpt == "BW_Dyn_ConsStockBalance_Requisition")
                {
                    DynConsol_Requisition("Reports/BW_Dyn_ConsStockBalance_Requisition.trdx", iman.PrintQRCat);
                }

                if (rpt == "OABW_Dyn_ConsStockBalance_Requisition")
                {
                    DynOAConsol_Requisition("Reports/OABW_Dyn_ConsStockBalance_Requisition.trdx", iman.PrintQRCat);
                }
                if (rpt == "OABW_Dyn_ConsSyllabusRequisition")
                {
                    DynOAConsol_SyllabusRequisition("Reports/OABW_Dyn_ConsSyllabusRequisition.trdx", iman.PrintQRCat, iman.PrintSysType);
                }
                if (rpt == "BW_DateW_ConsStockInhand")
                {
                    BranchWiseDateWise_StockBalance("Reports/BW_DateW_ConsStockInhand.trdx");
                }


                
                if (rpt == "SportsTransaction")
                {
                    txtDocID.Text = txtDocID.Text == "" ? iman.PrintGIN.ToString() : txtDocID.Text;
                    iman.PrintGIN = int.Parse(txtDocID.Text) == 0 ? 1 : int.Parse(txtDocID.Text);

                    if (isustat=="Temp")
                    {
                        SportsItemIssue("Reports/GoodsIssueNote_DeptWiseTemp.trdx", iman.PrintGIN);
                    }
                    else
                    {
                        SportsItemIssue("Reports/GoodsIssueNote_DeptWise.trdx", iman.PrintGIN);
                    }


                    
                }
          
            //}
        }

        protected void chkShowCancel_CheckedChanged(object sender, EventArgs e)
        {

        }




        public void ResetPage()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            iman.Pkbrhid = int.Parse(IMS["ubrhid"]);
            iman.Uid = int.Parse(IMS["uid"]);
            UMan.Uname = IMS["uname"].ToString();
            iman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);

            iman.PksysID = iman.GetBranchSystemID(iman.Pkbrhid);

            iman.PkstoreID = iman.GetStores(iman.Pkbrhid);

            GetUserInfo();

            if (UMan.Ugid == 31 || UMan.Ugid == 32)
            {
                iman.Pkdeptid = 14;
            }

            if (UMan.Ugid == 31 && iman.Pkbrhid == 19 || UMan.Ugid == 32 && iman.Pkbrhid == 19)
            {
                iman.Pkdeptid = 14;
                iman.PkstoreID = 2;
            }


            if (UMan.Ugid == 28)
            {
                iman.Pkdeptid = 14;
                iman.PkstoreID = 1;
            }
        
        
        }

        public void GetUserInfo()
        {

            HttpCookie IMS = Request.Cookies["IMS"];
            if (IMS == null)
                Response.Redirect("logout.aspx");

            UMan.Uid = int.Parse(IMS["uid"]);
            UMan.Uname = IMS["uname"].ToString();
            UMan.Ubrhid = int.Parse(IMS["ubrhid"]);
            UMan.Pkdeptid = int.Parse(IMS["udptid"]);
            UMan.Ugid =  int.Parse(IMS["ugroupid"]);
        }

        public string GetDefaultPrinter()
        {
            System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                printerSettings.PrinterName = printer;
                if (printerSettings.IsDefaultPrinter)
                {
                    return printerSettings.PrinterName;
                    //return printer;
                }
            }
            return string.Empty;
        }

        
        private void ItemList(string reportname)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            uriReportSource.Uri = reportname;

            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void AssetsCodeList(string reportname)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            if (UMan.Ugid == 37)   //I.T Assest Management Group
            {
                txtDocID.Visible = false;
                btnRptShow.Visible = false;
                
                uriReportSource.Uri = reportname;
                this.ReportViewer1.ReportSource = uriReportSource;
            }

        }

        private void GINAssetsCodeList(string reportname)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            if (UMan.Ugid == 37)   //I.T Assest Management Group
            {
                txtDocID.Visible = false;
                btnRptShow.Visible = false;

                uriReportSource.Uri = reportname;
                this.ReportViewer1.ReportSource = uriReportSource;
            }

        }



        private void SybReq_PerChildRatioList(string reportname)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            uriReportSource.Uri = reportname;

            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void StoreTransaction(string reportname)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            uriReportSource.Uri = reportname;

            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void ItemFrequency(string reportname)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("FType", "T"));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Topn", 20));

            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void ItemRateList(string reportname)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            uriReportSource.Uri = reportname;

            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void ItemBalance(string reportname)
        {
          
                 
            
            //objectDataSource.DataSource = sm.GetStoreBalance(this.iman.Pkbrhid,this.iman.PkstoreID,iman.Pkdeptid);
            //report.DataSource = objectDataSource; 

            //Telerik.Reporting.InstanceReportSource reportSource = new Telerik.Reporting.InstanceReportSource();
            //reportSource.ReportDocument = report;

            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            uriReportSource.Uri = reportname;

            if (UMan.Ugid == 27 || UMan.Ugid == 29 || UMan.Ugid == 49)
            {
                uriReportSource.Parameters.Add("PrintBy", UMan.Uname.ToString());
                uriReportSource.Parameters.Add("System", this.iman.PksysID);
                uriReportSource.Parameters.Add("Branch", this.iman.Pkbrhid);
                uriReportSource.Parameters.Add("Store", this.iman.PkstoreID);
                //uriReportSource.Parameters.Add("Department", this.iman.Pkdeptid);
            }
            else
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("System",this.iman.PksysID));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store",  this.iman.PkstoreID));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Department", this.iman.Pkdeptid));
            }

            this.ReportViewer1.ShowPrintPreviewButton = true;
            this.ReportViewer1.ReportSource = uriReportSource;
        }


        private void ItemBalanceCustom(string reportname)
        {

                Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

                sqlDataSource.ConnectionString = "IMS_RPT_Conn";
                
                string selectCommandText;

                selectCommandText = "SELECT  [fksysID],[fkbrhID] ,[fkStoreID] ,[fkDeptID] ,[SystemName] ,[brhName] ,[StoreName] ,[deptName] ,[pkCatID] ,[pkSubCatID] ,[pkItemHeadID],[pkReqSubTypID],[RequisitionSubType] ,[pkItemID] ,[CatTitle],";
                selectCommandText = selectCommandText + "[SubCatTitle] ,[ItemHeadTitle] ,[fkItemTypeID],[pkItemID] ,[ItemCode] ,[ItemTitle] ,[InvCode] ,[Model] ,[Brand]  ,[Unit]  ,[OPBDate] ,[OPBalance]    ,[YearOPBDate] ,[YearOPBalance]  ,[QttyIssued] ,[QttyReceived] ,[CRBalance],[CustomRate],[InvPeriod]";
                selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_CustomizeStoreInventoryBalance]";
                selectCommandText = selectCommandText + " where fkStoreID=" + iman.PkstoreID.ToString();

                sqlDataSource.SelectCommand = selectCommandText;
                System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                //WHERE THE REPORTS RESIDE...
                const string Directory = "~/";
                //
                using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
                {
                    Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                    var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                    report.DataSource = sqlDataSource;
                    this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
                }


                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
                //this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("System", this.iman.PksysID));
                //this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                //this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Department", this.iman.Pkdeptid));

                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));

                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("ReqType", this.iman.fkreqTypeID));

                this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;

                // Calling the RefreshReport method in case this is a WinForms application.

                this.ReportViewer1.DataBind();

                this.ReportViewer1.RefreshReport();
 
        }

        private void ItemBalance1(string reportname)
        {
           bool FullReport;

           if (reportname == "Reports/FullStoreInventoryBalances.trdx")
           {
               FullReport = true;
               if (UMan.Ugid == 27 || UMan.Ugid == 28  || UMan.Ugid == 33 || UMan.Ugid == 49)
               {
                   reportname = "Reports/StoreInventoryBalances.trdx";
               }               
               else
               {
                   reportname = "Reports/StoreInventoryBalances.trdx";
               }

               if (UMan.Ugid == 29)
               {
                   FullReport = true;
                   reportname = "Reports/StoreInventoryBalances_All.trdx";
               }

           }
           else
           {
               FullReport = false;

               if (UMan.Ugid == 39)
               {
                   FullReport = true;
                   reportname = "Reports/StoreInventoryBalances_All.trdx";
                  
               }
               else
               {
                  

                   reportname = "Reports/StoreInventoryBalances.trdx";
               }
           }

            try
            {

                txtDocID.Visible = false;
                btnRptShow.Visible = false;

                Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

                sqlDataSource.ConnectionString = "IMS_RPT_Conn";
                
                string selectCommandText;

                if (this.iman.Pkdeptid == 14 && UMan.Ugid != 39 && this.iman.Pkdeptid == 14 && UMan.Ugid != 29)
                {
                    if (FullReport == true)
                    {

                        if (iman.Pkbrhid != 25)
                        {
                            selectCommandText = "SELECT  [fksysID],[fkbrhID] ,[fkStoreID] ,[fkDeptID] ,[SystemName] ,[brhName] ,[StoreName] ,[deptName] ,[pkCatID] ,[pkSubCatID] ,[pkItemHeadID] ,[pkItemID] ,[CatTitle],";
                            selectCommandText = selectCommandText + "[SubCatTitle] ,[ItemHeadTitle] ,[fkItemTypeID] ,[ItemCode] ,[ItemTitle] ,[InvCode] ,[Model] ,[Brand]  ,[Unit]  ,[OPBDate] ,[OPBalance]    ,[YearOPBDate] ,[YearOPBalance]  ,[QttyIssued] ,[QttyReceived] ,[CRBalance]  ,[IsActive]";
                            selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_StoreInventoryBalance]";
                            selectCommandText = selectCommandText + " where fkbrhID=" + iman.Pkbrhid.ToString();
                        }
                        else
                        {
                            selectCommandText = "SELECT  [fksysID],[fkbrhID] ,[fkStoreID] ,[fkDeptID] ,[SystemName] ,[brhName] ,[StoreName] ,[deptName] ,[pkCatID] ,[pkSubCatID] ,[pkItemHeadID] ,[pkItemID] ,[CatTitle],";
                            selectCommandText = selectCommandText + "[SubCatTitle] ,[ItemHeadTitle] ,[fkItemTypeID] ,[ItemCode] ,[ItemTitle] ,[InvCode] ,[Model] ,[Brand]  ,[Unit]  ,[OPBDate] ,[OPBalance]    ,[YearOPBDate] ,[YearOPBalance]  ,[QttyIssued] ,[QttyReceived] ,[CRBalance]  ,[IsActive]";
                            selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_StoreInventoryBalance]";
                            selectCommandText = selectCommandText + " where fkbrhID=" + iman.Pkbrhid.ToString() + " and fkStoreID=" + this.iman.PkstoreID.ToString();
                        }
                        
                        //+" and fkDeptID=" + this.iman.Pkdeptid.ToString();
                    }
                    else
                    {
                        // if (this.iman.Pkdeptid == 10 || this.iman.Pkdeptid == 2)

                        selectCommandText = "SELECT  [fksysID],[fkbrhID] ,[fkStoreID] ,[fkDeptID] ,[SystemName] ,[brhName] ,[StoreName] ,[deptName] ,[pkCatID] ,[pkSubCatID] ,[pkItemHeadID] ,[pkItemID] ,[CatTitle],";
                        selectCommandText = selectCommandText + "[SubCatTitle] ,[ItemHeadTitle] ,[fkItemTypeID] ,[ItemCode] ,[ItemTitle] ,[InvCode] ,[Model] ,[Brand]  ,[Unit]  ,[OPBDate] ,[OPBalance]    ,[YearOPBDate] ,[YearOPBalance]  ,[QttyIssued] ,[QttyReceived] ,[CRBalance]  ,[IsActive]";
                        selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_StoreInventoryBalance]";
                        selectCommandText = selectCommandText + " where fkbrhID=" + iman.Pkbrhid.ToString() + " and fkStoreID=" + this.iman.PkstoreID.ToString() + " AND CRBalance<>0";

                    }
                    //UMan.Ugid == 28
                }
                else
                {
                    if (FullReport == true)
                    {

                        selectCommandText = "SELECT  [fksysID],[fkbrhID] ,[fkStoreID] ,[fkDeptID] ,[SystemName] ,[brhName] ,[StoreName] ,[deptName] ,[pkCatID] ,[pkSubCatID] ,[pkItemHeadID] ,[pkItemID] ,[CatTitle],";
                        selectCommandText = selectCommandText + "[SubCatTitle] ,[ItemHeadTitle] ,[fkItemTypeID] ,[ItemCode] ,[ItemTitle] ,[InvCode] ,[Model] ,[Brand]  ,[Unit]  ,[OPBDate] ,[OPBalance]    ,[YearOPBDate] ,[YearOPBalance]  ,[QttyIssued] ,[QttyReceived] ,[CRBalance]  ,[IsActive]";
                        selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_StoreInventoryBalance]";
                    }
                    else
                    {
                        selectCommandText = "SELECT  [fksysID],[fkbrhID] ,[fkStoreID] ,[fkDeptID] ,[SystemName] ,[brhName] ,[StoreName] ,[deptName] ,[pkCatID] ,[pkSubCatID] ,[pkItemHeadID] ,[pkItemID] ,[CatTitle],";
                        selectCommandText = selectCommandText + "[SubCatTitle] ,[ItemHeadTitle] ,[fkItemTypeID] ,[ItemCode] ,[ItemTitle] ,[InvCode] ,[Model] ,[Brand]  ,[Unit]  ,[OPBDate] ,[OPBalance]    ,[YearOPBDate] ,[YearOPBalance]  ,[QttyIssued] ,[QttyReceived] ,[CRBalance]  ,[IsActive]";
                        selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_StoreInventoryBalance] WHERE CRBalance<>0";

                    }
                     
                }

                //sqlDataSource.SelectCommand = selectCommandText;
                //System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
                //settings.IgnoreWhitespace = true;
                ////WHERE THE REPORTS RESIDE...
                //const string Directory = "~/";
                ////
                //using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
                //{
                //    Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                //    var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                //    report.DataSource = sqlDataSource;
                //    this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
                //}

                //if (this.iman.Pkdeptid == 14 && UMan.Ugid != 39 && this.iman.Pkdeptid == 14 && UMan.Ugid != 29)
                //{
                //    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
                //    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("System", this.iman.PksysID));
                //    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                //    //this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
                //    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Department", this.iman.Pkdeptid));

                //}
                //else
                //{
                    
                //    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("System", this.iman.PksysID));
                //    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                //    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
                //    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
                //}

                //this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;

                //this.ReportViewer1.DataBind();

                //this.ReportViewer1.RefreshReport();

                uriReportSource.Uri = reportname;

                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("System", this.iman.PksysID));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                //uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Department", this.iman.Pkdeptid));

                this.ReportViewer1.ShowPrintPreviewButton = true;
                this.ReportViewer1.ReportSource = uriReportSource;

                // Calling the RefreshReport method in case this is a WinForms application.


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        private void ItemITBalance(string reportname)
        {

            try
            {

                txtDocID.Visible = false;
                btnRptShow.Visible = false;

                Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

                sqlDataSource.ConnectionString = "IMS_RPT_Conn";

                string selectCommandText;

               selectCommandText = "SELECT  [fksysID],[fkbrhID],[fkDeptID],[SystemName],[brhName],[deptName],[pkCatID],[pkSubCatID],[pkItemHeadID],[pkItemID],[CatTitle],[SubCatTitle],[ItemHeadTitle],";
               selectCommandText = selectCommandText + "[fkItemTypeID],[ItemCode],[InvCode],[ItemTitle],[Model],[Brand],[Unit],[OPBDate],[OPBalance],[YearOPBDate],[YearOPBalance],[QttyIssued],[QttyReceived],[CRBalance],[IsActive],[Expr1]";
               selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_ITInventoryBalance]";

               if (this.iman.Pkdeptid != 10 && this.iman.Pkdeptid != 9)
               {
                   if (iman.Pkbrhid!=25)
                   {
                       this.iman.Pkdeptid = 2;
                   }

                   selectCommandText = selectCommandText + " where fkbrhID=" + iman.Pkbrhid.ToString() + " and fkDeptID=" + this.iman.Pkdeptid.ToString();
               }
                
                sqlDataSource.SelectCommand = selectCommandText;
                System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                //WHERE THE REPORTS RESIDE...
                const string Directory = "~/";
                //
                using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
                {
                    Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                    var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                    report.DataSource = sqlDataSource;
                    this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
                }


                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("System", 4));
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Department", this.iman.Pkdeptid));

                this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;

                // Calling the RefreshReport method in case this is a WinForms application.

                this.ReportViewer1.DataBind();

                this.ReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void ItemSPRBalance(string reportname)
        {

            try
            {

                txtDocID.Visible = false;
                btnRptShow.Visible = false;

                Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

                sqlDataSource.ConnectionString = "IMS_RPT_Conn";

                string selectCommandText;

                selectCommandText = "SELECT  [fksysID],[fkbrhID],[fkDeptID],[SystemName],[brhName],[deptName],[pkCatID],[pkSubCatID],[pkItemHeadID],[pkItemID],[CatTitle],[SubCatTitle],[ItemHeadTitle],";
                selectCommandText = selectCommandText + "[fkItemTypeID],[ItemCode],[InvCode],[ItemTitle],[Model],[Brand],[Unit],[OPBDate],[OPBalance],[YearOPBDate],[YearOPBalance],[QttyIssued],[QttyReceived],[CRBalance],[IsActive],[Expr1]";
                selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_SPInventoryBalance]";

                if (this.iman.Pkbrhid != 25)
                {
                    //this.iman.Pkdeptid = 17;
                    selectCommandText = selectCommandText + " where fkbrhID=" + iman.Pkbrhid.ToString() + " and fkDeptID=" + this.iman.Pkdeptid.ToString();
                }
                

                sqlDataSource.SelectCommand = selectCommandText;
                System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                //WHERE THE REPORTS RESIDE...
                const string Directory = "~/";
                //
                using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
                {
                    Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                    var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                    report.DataSource = sqlDataSource;
                    this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
                }

                if (UMan.Ugid == 79)   //Sports Assest Management Group
                {
                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("System", iman.PksysID));
                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Department", this.iman.Pkdeptid));

                    
                }
                else
                {
                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
                }

                this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;

                // Calling the RefreshReport method in case this is a WinForms application.

                this.ReportViewer1.DataBind();

                this.ReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        private void InventoryValuation(string reportname)
        {

            uriReportSource.Uri = reportname;

            if (UMan.Ugid == 27 || UMan.Ugid == 29 || UMan.Ugid == 49)
            {
                uriReportSource.Parameters.Add("PrintBy", UMan.Uname.ToString());
                uriReportSource.Parameters.Add("System", this.iman.PksysID);
                uriReportSource.Parameters.Add("Branch", this.iman.Pkbrhid);
                uriReportSource.Parameters.Add("Store", this.iman.PkstoreID);
                //uriReportSource.Parameters.Add("Department", this.iman.Pkdeptid);
            }
            else
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("System",this.iman.PksysID));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store",  this.iman.PkstoreID));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Department", this.iman.Pkdeptid));
            }

            this.ReportViewer1.ShowPrintPreviewButton = true;
            this.ReportViewer1.ReportSource = uriReportSource;
        }


        private void GIN_GRN_Info(string reportname)
        {
            //string curdate = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-GB"));
            string curdate = DateTime.Now.ToString();

            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("fkbrhid", this.iman.Pkbrhid));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("fkstoreid", this.iman.PkstoreID));


            this.ReportViewer1.ShowPrintPreviewButton = true;
            this.ReportViewer1.ReportSource = uriReportSource;
        }
        
        private void DailyTrans(string reportname)
        {
            //string curdate = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-GB"));
            string curdate = DateTime.Now.ToString();
 
            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("TrsDate", curdate));

            this.ReportViewer1.ShowPrintPreviewButton = true;
            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void GoodReceiveNote(string reportname, int GRNNo)
        {
            
            uriReportSource.Uri = reportname;

            
            //string sql = "SELECT [BRANCHID],[STOREID],[DEPTID][RECVBYBRANCH],[RECVBYSTORE],[RECVBYDEPT],[RECVBYPERSON],[VendorName],[DCNo],[DDate],[InvoiceNo]";
            //sql = sql + ",[VehicleNo],[PONo],[ReceivedStatus],[GRNNumber],[GRNCode],[fkItemID],[InvCode],[ItemTitle],[Qtty],[Unit]";
            //sql = sql + ",[Model],[Brand],[Remarks],[RECVFROMBRANCH],[RECVFROMSTORE],[RECVFROMDEPT],[RECVFROMPERSON]";
            //sql = sql + " FROM [INVENTORY].[dbo].[View_GoodsReceiptNotes]";


            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
            //uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

                //<Filter Expression="=Fields.DEPTID" Operator="Equal" Value="=Parameters.Dept.Value" />

                //<ReportParameter Name="Dept" Type="Integer">
                //  <Value>
                //    <String></String>
                //  </Value>
                //</ReportParameter>


            if (GRNNo == 0)
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GRNno", 1));
            }
            else
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GRNno", GRNNo));
            }

            //this.ReportViewer1.ShowPrintButton = true;
            //
            //this.ReportViewer1.ShowExportGroup = true;

            //PrinterSettings PrintSet = new PrinterSettings();
            //PrintSet.PrinterName = GetDefaultPrinter();
            //StandardPrintController StandPrint = new StandardPrintController();

            //reportProcessor.PrintController = StandPrint;
            //reportProcessor.PrintReport(report, PrintSet); 

            this.ReportViewer1.ShowPrintPreviewButton = true;
            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void GoodReceiveNote1(string reportname, int GRNNo)
        {
            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

            sqlDataSource.ConnectionString = "IMS_RPT_Conn";

            string selectCommandText = "";

            if (this.iman.PkstoreID.ToString()!="0")
            {
                if (chkTempIssue.Checked == false)
                {
                    selectCommandText = "SELECT [RECVBYBRANCH] ,[RECVBYSTORE] ,[RECVBYDEPT] ,[RECVBYPERSON] ,[VendorName] ,[DCNo] ,[DDate] ,[InvoiceNo] ,[MIRNumber],[GINNumber],[VehicleNo] ,[PONo] ,[ReceivedStatus]";
                    selectCommandText = selectCommandText + ",[GRNNumber] ,[GRNCode] ,[fkItemID] ,[InvCode] ,[ItemTitle] ,[Qtty] ,[Unit] ,[Model] ,[Brand] ,[Remarks] ,[RECVFROMBRANCH] ,[RECVFROMSTORE],[RECVFROMDEPT]";
                    selectCommandText = selectCommandText + ",[RECVFROMPERSON],[RECVFROMNAME],[BRANCHID] ,[STOREID] ,[DEPTID]";
                    selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_GoodsReceiptNotes]";
                    selectCommandText = selectCommandText + " where BRANCHID=" + iman.Pkbrhid.ToString() + " and STOREID=" + this.iman.PkstoreID.ToString() + " and GRNNumber=" + GRNNo.ToString() + " ORDER BY ItemTitle";
              
                    if (chkShowCancel.Checked == true)
                    {
                        selectCommandText = "SELECT [RECVBYBRANCH] ,[RECVBYSTORE] ,[RECVBYDEPT] ,[RECVBYPERSON] ,[VendorName] ,[DCNo] ,[DDate] ,[InvoiceNo] ,[MIRNumber],[GINNumber],[VehicleNo] ,[PONo] ,[ReceivedStatus]";
                        selectCommandText = selectCommandText + ",[GRNNumber] ,[GRNCode] ,[fkItemID] ,[InvCode] ,[ItemTitle] ,[Qtty] ,[Unit] ,[Model] ,[Brand] ,[Remarks] ,[RECVFROMBRANCH] ,[RECVFROMSTORE],[RECVFROMDEPT]";
                        selectCommandText = selectCommandText + ",[RECVFROMPERSON],[RECVFROMNAME],[BRANCHID] ,[STOREID] ,[DEPTID], IsCancel";
                        selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_GoodsReceiptNotesCancelled]";
                        selectCommandText = selectCommandText + " where BRANCHID=" + iman.Pkbrhid.ToString() + " and STOREID=" + this.iman.PkstoreID.ToString() + " and GRNNumber=" + GRNNo.ToString() + " ORDER BY ItemTitle";

                        
                    }            
                
                }
                else
                {
                    selectCommandText = "SELECT [RECVBYBRANCH] ,[RECVBYSTORE] ,[RECVBYDEPT] ,[RECVBYPERSON] ,[VendorName] ,[DCNo] ,[DDate] ,[InvoiceNo] ,[MIRNumber],[GINNumber],[VehicleNo] ,[PONo] ,[ReceivedStatus]";
                    selectCommandText = selectCommandText + ",[GRNNumber] ,[GRNCode] ,[fkItemID] ,[InvCode] ,[ItemTitle] ,[Qtty] ,[Unit] ,[Model] ,[Brand] ,[Remarks] ,[RECVFROMBRANCH] ,[RECVFROMSTORE],[RECVFROMDEPT]";
                    selectCommandText = selectCommandText + ",[RECVFROMPERSON],[RECVFROMNAME],[BRANCHID] ,[STOREID] ,[DEPTID]";
                    selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_GoodsReceiptNotesTemp]";
                    selectCommandText = selectCommandText + " where BRANCHID=" + iman.Pkbrhid.ToString() + " and STOREID=" + this.iman.PkstoreID.ToString() + " and GRNNumber=" + GRNNo.ToString() + " ORDER BY ItemTitle";
                }                        
            }
            else
            {
                selectCommandText = "SELECT [RECVBYBRANCH] ,[RECVBYSTORE] ,[RECVBYDEPT] ,[RECVBYPERSON] ,[VendorName] ,[DCNo] ,[DDate] ,[InvoiceNo] ,[MIRNumber],[GINNumber],[VehicleNo] ,[PONo] ,[ReceivedStatus]";
                selectCommandText = selectCommandText + ",[GRNNumber] ,[GRNCode] ,[fkItemID] ,[InvCode] ,[ItemTitle] ,[Qtty] ,[Unit] ,[Model] ,[Brand] ,[Remarks] ,[RECVFROMBRANCH] ,[RECVFROMSTORE],[RECVFROMDEPT]";
                selectCommandText = selectCommandText + ",[RECVFROMPERSON],[RECVFROMNAME],[BRANCHID] ,[STOREID] ,[DEPTID]";
                selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_GoodsReceiptNotes_DeptWise]";
                selectCommandText = selectCommandText + " where BRANCHID=" + iman.Pkbrhid.ToString() + " and DEPTID=" + this.iman.Pkdeptid.ToString() + " and GRNNumber=" + GRNNo.ToString() + " ORDER BY ItemTitle";

                if (chkShowCancel.Checked == true)
                {
                    selectCommandText = "SELECT [RECVBYBRANCH] ,[RECVBYSTORE] ,[RECVBYDEPT] ,[RECVBYPERSON] ,[VendorName] ,[DCNo] ,[DDate] ,[InvoiceNo] ,[MIRNumber],[GINNumber],[VehicleNo] ,[PONo] ,[ReceivedStatus]";
                    selectCommandText = selectCommandText + ",[GRNNumber] ,[GRNCode] ,[fkItemID] ,[InvCode] ,[ItemTitle] ,[Qtty] ,[Unit] ,[Model] ,[Brand] ,[Remarks] ,[RECVFROMBRANCH] ,[RECVFROMSTORE],[RECVFROMDEPT]";
                    selectCommandText = selectCommandText + ",[RECVFROMPERSON],[RECVFROMNAME],[BRANCHID] ,[STOREID] ,[DEPTID], IsCancel";
                    selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_GoodsReceiptNotes]";
                    selectCommandText = selectCommandText + " where BRANCHID=" + iman.Pkbrhid.ToString() + " and STOREID=" + this.iman.PkstoreID.ToString() + " and GRNNumber=" + GRNNo.ToString() + " and IsCancel=1" + " ORDER BY ItemTitle";
                }  

            
            }


            sqlDataSource.SelectCommand = selectCommandText;
            System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            //WHERE THE REPORTS RESIDE...
            const string Directory = "~/";
            //
            using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
            {
                Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                report.DataSource = sqlDataSource;
                this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
            }

            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
 

            if (GRNNo == 0)
            {
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GRNno", 1));
            }
            else
            {
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GRNno", GRNNo));
            }

            this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;

            // Calling the RefreshReport method in case this is a WinForms application.

            this.ReportViewer1.DataBind();

            this.ReportViewer1.RefreshReport();
               
        }

        private void GoodIssueNote(string reportname, int GINNo)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

            if (GINNo == 0)
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GINno", 1));
            }
            else
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GINno", GINNo));
            }



            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void GoodIssueNote1(string reportname, int GINNo)
        {

            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

            sqlDataSource.ConnectionString = "IMS_RPT_Conn";

            string selectCommandText;

            if (chkTempIssue.Checked == false)
            {
                selectCommandText = "SELECT fkIssueByBranchID, fkIssueByStoreID, fkIssueByDeptID, IssuByBranch , IssuByStore  , IssuByDept  , IssuBy, MIRNumber, GINNumber    , GINCode    , IssuDate    , fkItemID    , InvCode,";
                selectCommandText = selectCommandText + "ItemTitle   , Qtty     , Unit , ActRate     , Model      , Brand      , IssuedStatus     , ReceivedValidity     , ReturnValidity    , IssuToBranch      , IssuToStore     , IssuToDept    , IssuTo,";
                selectCommandText = selectCommandText + "VendorName ,ItemStatus , Remarks  FROM  INVENTORY.dbo.View_GoodsIssueNote";
                selectCommandText = selectCommandText + " where fkissuebybranchid=" + iman.Pkbrhid.ToString() + " and fkIssueByDeptID=" + iman.Pkdeptid.ToString() + " and GINNumber=" + GINNo.ToString() + " ORDER BY ItemTitle";

                if (chkShowCancel.Checked == true)
                {
                    selectCommandText = "SELECT fkIssueByBranchID, fkIssueByStoreID, fkIssueByDeptID, IssuByBranch , IssuByStore  , IssuByDept  , IssuBy, MIRNumber, GINNumber    , GINCode    , IssuDate    , fkItemID    , InvCode,";
                    selectCommandText = selectCommandText + "ItemTitle   , Qtty     , Unit   , Model      , Brand      , IssuedStatus     , ReceivedValidity     , ReturnValidity    , IssuToBranch      , IssuToStore     , IssuToDept    , IssuTo,";
                    selectCommandText = selectCommandText + "VendorName,IsCancel, Remarks  FROM  INVENTORY.dbo.View_GoodsIssueNoteCancelled";
                    selectCommandText = selectCommandText + " where fkissuebybranchid=" + iman.Pkbrhid.ToString() + " and fkIssueByDeptID=" + iman.Pkdeptid.ToString() + " and GINNumber=" + GINNo.ToString() + " ORDER BY ItemTitle";

                    reportname = "Reports/GoodsIssueNote_Cancel.trdx";
                }

            }
            else
            {
                selectCommandText = "SELECT fkIssueByBranchID, fkIssueByStoreID, fkIssueByDeptID, IssuByBranch , IssuByStore  , IssuByDept  , IssuBy, MIRNumber, GINNumber    , GINCode    , IssuDate    , fkItemID    , InvCode,";
                selectCommandText = selectCommandText + "ItemTitle   , Qtty     , Unit  , ActRate     , Model      , Brand      , IssuedStatus     , ReceivedValidity     , ReturnValidity    , IssuToBranch      , IssuToStore     , IssuToDept    , IssuTo,";
                selectCommandText = selectCommandText + "VendorName      , Remarks  FROM  INVENTORY.dbo.View_GoodsIssueNoteTemp";
                selectCommandText = selectCommandText + " where fkissuebybranchid=" + iman.Pkbrhid.ToString() + " and fkIssueByDeptID=" + iman.Pkdeptid.ToString() + " and GINNumber=" + GINNo.ToString() + " ORDER BY ItemTitle";
            }



            sqlDataSource.SelectCommand = selectCommandText;
            System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            //WHERE THE REPORTS RESIDE...
            const string Directory = "~/";
            //
            using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
            {
                Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                report.DataSource = sqlDataSource;
                this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
            }

            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));

            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

            if (GINNo == 0)
            {
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GINno", 1));
            }
            else
            {
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GINno", GINNo));
            }

            this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;

            // Calling the RefreshReport method in case this is a WinForms application.
           
            this.ReportViewer1.DataBind();

            this.ReportViewer1.RefreshReport();

            //var objectDataSource = new Telerik.Reporting.ObjectDataSource();
            //objectDataSource.DataSource = iman.GetRPTData(iman.Pkbrhid.ToString(), iman.Pkdeptid.ToString(), GINNo.ToString()); // GetData returns a DataTable

            //// Creating a new report
            //var report = new Telerik.Reporting.Report();

           
        }


        private void MaterialReturnGIN(string reportname, int GINNo)
        {

            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

            sqlDataSource.ConnectionString = "IMS_RPT_Conn";

            string selectCommandText;


            selectCommandText = "SELECT [CreatedBy],[fkIssueByBranchID],[fkIssueByStoreID],[fkIssueByDeptID],[IssuByBranch],[IssuByStore],[IssuByDept],[IssuBy],[MIRNumber],[GINNumber],";
            selectCommandText = selectCommandText + "[GINCode],[IssuDate],[fkItemID],[InvCode],[ItemTitle],[Qtty],[Unit],[Model],[Brand],[IssuedStatus],[IssuedType],[ReceivedValidity],[ReturnValidity],";
            selectCommandText = selectCommandText + "[fkVendorID],[VendorName],[CPName1],[DeliverFrom],[fkIssueByID],[Remarks]  FROM [INVENTORY].[dbo].[View_MaterialReturn]";
            selectCommandText = selectCommandText + " where fkissuebybranchid=" + iman.Pkbrhid.ToString() + " and fkIssueByDeptID=" + iman.Pkdeptid.ToString() + " and GINNumber=" + GINNo.ToString();
           
            sqlDataSource.SelectCommand = selectCommandText;
            System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            //WHERE THE REPORTS RESIDE...
            const string Directory = "~/";
            //
            using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
            {
                Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                report.DataSource = sqlDataSource;
                this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
            }

            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));

            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

            if (GINNo == 0)
            {
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GINno", 1));
            }
            else
            {
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GINno", GINNo));
            }

            this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;

            // Calling the RefreshReport method in case this is a WinForms application.

            this.ReportViewer1.DataBind();

            this.ReportViewer1.RefreshReport();

            //var objectDataSource = new Telerik.Reporting.ObjectDataSource();
            //objectDataSource.DataSource = iman.GetRPTData(iman.Pkbrhid.ToString(), iman.Pkdeptid.ToString(), GINNo.ToString()); // GetData returns a DataTable

            //// Creating a new report
            //var report = new Telerik.Reporting.Report();


        }

        private void SportsItemIssue(string reportname, int GINNo)
        {
                    //btnAssets.Text = "General Report";

                    //string reportname = "Reports/GoodsIssueNote_DeptWise.trdx";

                    //iman.PrintGIN = int.Parse(txtDocID.Text);

                    //GINNo = 3261;
                    //iman.Pkdeptid = 2;


                    Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

                    sqlDataSource.ConnectionString = "IMS_RPT_Conn";


                    string selectCommandText = "SELECT fkIssueByBranchID, fkIssueByStoreID, fkIssueByDeptID, IssuByBranch , IssuByStore  , IssuByDept  , IssuBy  , GINNumber    , GINCode    , IssuDate    , fkItemID    , InvCode,";
                    selectCommandText = selectCommandText + "ItemTitle   , Qtty     , Unit      , Model      , Brand      , IssuedStatus , ItemStatus   , ReceivedValidity     , ReturnValidity    , IssuToBranch      , IssuToStore     , IssuToDept    , IssuTo,";
                    selectCommandText = selectCommandText + "VendorName      , Remarks  FROM  View_GoodsIssueNote";

                    if (reportname == "Reports/GoodsIssueNote_DeptWiseTemp.trdx")
                    {
                        selectCommandText = "SELECT * FROM  View_GoodsIssueNoteTemp ";
                    }
 
                    selectCommandText = selectCommandText + " where fkissuebybranchid=" + iman.Pkbrhid.ToString() + " and fkIssueByDeptID=" + iman.Pkdeptid.ToString() + " and GINNumber=" + GINNo.ToString();
 
                    sqlDataSource.SelectCommand = selectCommandText;
                    System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
                    settings.IgnoreWhitespace = true;
                    //WHERE THE REPORTS RESIDE...
                    const string Directory = "~/";
                    //
                    using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
                    {
                        Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                        var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                        report.DataSource = sqlDataSource;
                        this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
                    }

                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

                    if (GINNo == 0)
                    {
                        this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GINno", 1));
                    }
                    else
                    {
                        this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GINno", GINNo));
                    }

                    this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;
                    this.ReportViewer1.DataBind();
                    this.ReportViewer1.RefreshReport();

        }

        private void Report1_NeedDataSource(object sender, System.EventArgs e)
        {
            //Take the Telerik.Reporting.Processing.Report instance
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;

            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

            sqlDataSource.ConnectionString = "IMS_RPT_Conn";

            // Transfer the value of the processing instance of ReportParameter
            // to the parameter value of the sqlDataSource component
            sqlDataSource.Parameters[0].Value = report.Parameters["GINno"].Value;

            // Set the SqlDataSource component as it's DataSource
            report.DataSource = sqlDataSource;
        }

        private void ItemLedger(string reportname, string InvCode)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            uriReportSource.Uri = reportname;

            //string dtfrom = DateTime.Now.year();

            //DateTime dt = DateTime.ParseExact("2016-01-01", "ddMMyyyy", CultureInfo.InvariantCulture);
            //dt.ToString("yyyyMMdd");

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("invcode", InvCode));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("datefrom", "2016-06-01"));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("dateto", "2050-12-31"));

            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void LinkItemLedger(string reportname, string InvCode)
        {
       
            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("invcode", InvCode));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("datefrom", "2016-06-01"));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("dateto", "2050-12-31"));

            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void MIR(string reportname, int MIRNo)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

            if (MIRNo == 0)
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("MIRno", 1));
            }
            else
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("MIRno", MIRNo));
            }



            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void MIR1(string reportname, int MIRNo)
        {
            
            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

            sqlDataSource.ConnectionString = "IMS_RPT_Conn";

            //iman.Pkbrhid = 27;
            //iman.PkstoreID = 25;
            //MIRNo = 80;

            string selectCommandText = "SELECT [CreatedBy],[fkIssueByBranchID],[fkIssueByStoreID],[fkIssueByDeptID],[IssuByBranch],[IssuByStore],[IssuByDept],[IssuBy],[ReqTitle],[ReqMonths],[acdDescription],";
            selectCommandText = selectCommandText + "[MIRNumber],[MIRCode],[IssuDate],[ItemTitle],[Qtty],[Unit],[IssuToBranch],[IssuToStore],[IssuToDept],[IssuTo],[DeliverFrom],[DeliverTo],[fkIssueToBranchID],";
            selectCommandText = selectCommandText + "[fkIssueToDeptID],[fkIssueByID],[fkIssuedToID],[fkIssueToStoreID],[Remarks]  FROM[INVENTORY].[dbo].[View_MaterialIssueRequest]";
            selectCommandText = selectCommandText + " where fkIssueByBranchID=" + iman.Pkbrhid.ToString() + " and MIRNumber=" + MIRNo.ToString() + " ORDER BY ItemTitle";

            sqlDataSource.SelectCommand = selectCommandText;
            System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            //WHERE THE REPORTS RESIDE...
            const string Directory = "~/";
            //
            using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
            {
                Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                report.DataSource = sqlDataSource;
                this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
            }

            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
            this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

            if (MIRNo == 0)
            {
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("MIRno", 1));
            }
            else
            {
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("MIRno", MIRNo));
            }

            this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;

            // Calling the RefreshReport method in case this is a WinForms application.

            this.ReportViewer1.DataBind();

            this.ReportViewer1.RefreshReport();
                       
        }
       
        private void GatePass(string reportname, int GPNo)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

            if (GPNo == 0)
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GPno", 1));
            }
            else
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GPno", GPNo));
            }



            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void GatePass1(string reportname, int GPNo)
        {

            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

            sqlDataSource.ConnectionString = "IMS_RPT_Conn";

            string selectCommandText = "SELECT [CreatedBy],[IssueByBranchID],[IssueByStoreID],[IssueByDeptID],[IssuByBranch],[IssuByStore],[IssuByDept],[IssuBy],[GatePassID],[GatePassNo],[CreatedDate],";
            selectCommandText = selectCommandText + "[fkItemID],[InvCode],[ItemTitle],[Quantity],[Unit],[Model_Brand],[IssueStatus],[IssuedType],[IssuToBranch],[IssuToStore],[IssuToDept],[IssuTo],[fkVendorID]";
            selectCommandText = selectCommandText + ",[VendorName],[DeliverFrom],[DeliverTo],[IssueToBranchID],[IssueToDeptID],[Issuedby],[IssuedTo],[IssueToStoreID],[Remarks] FROM [INVENTORY].[dbo].[View_GatePass]";
            selectCommandText = selectCommandText + " where      IssueByDeptID=" + iman.Pkdeptid.ToString() + " and GatePassID=" + GPNo.ToString() + " order by ItemTitle";

            if (this.iman.Pkdeptid == 2)
            {
                reportname = "Reports/GatePassDeptWise.trdx";
            }
            
            sqlDataSource.SelectCommand = selectCommandText;
            System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            //WHERE THE REPORTS RESIDE...
            const string Directory = "~/";
            //
            using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
            {
                Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                report.DataSource = sqlDataSource;
                this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
            }

            if (this.iman.Pkdeptid == 2)
            {
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));
            }
            else
            {
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));
            }

            if (GPNo == 0)
            {
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GPno", 1));
            }
            else
            {
                this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GPno", GPNo));
            }

            this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;

            // Calling the RefreshReport method in case this is a WinForms application.

            this.ReportViewer1.DataBind();

            this.ReportViewer1.RefreshReport(); 
            

        }

        private void PurchaseOrder(string reportname, int PoNo)
        {

            Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

            sqlDataSource.ConnectionString = "IMS_RPT_Conn";

            string selectCommandText = "SELECT   [pkPOID],[fkcomid],[brhName],[deptName],[empName],[fkbrhID],[fkDeptID],[POReqCode],[ReqTitle],[DocCode],[POType],[IssueDate],[fkQuotID],[QuotDate],[VendorName],[ContactPerson],";
            selectCommandText = selectCommandText + "[ShipAt],[ShipDate],[TermsConditions],[GrossAmount],[Discount],[IsApproved],[IsActive],";
            selectCommandText = selectCommandText + "[fkreqpoID],[fkItemID],[ItemTitle],[ItemDescription],[Unit],[Rate],[Qtty],[Amount],[TranIsActive],AmountWords ";
            selectCommandText = selectCommandText + " from View_PurchaseOrder where  fkbrhID=" + this.iman.Pkbrhid.ToString() + " and fkDeptID=" + this.iman.Pkdeptid.ToString() + " and pkPOID=" + PoNo.ToString() + " order by ItemTitle";

 
            sqlDataSource.SelectCommand = selectCommandText;
            System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            //WHERE THE REPORTS RESIDE...
            const string Directory = "~/";
            //
            using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
            {
                Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                report.DataSource = sqlDataSource;
                this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
            }

                //this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("BranchID", this.iman.Pkbrhid));
                //this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("DeptID", this.iman.Pkdeptid));
                //this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("POnumber", PoNo));
         

            this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;

            // Calling the RefreshReport method in case this is a WinForms application.

            this.ReportViewer1.DataBind();

            this.ReportViewer1.RefreshReport();


        }

        private void Requisition(string reportname, int REQNo)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();

            if (UMan.Ugid == 27 || UMan.Ugid == 29 || UMan.Ugid == 39)
            {
                if (int.Parse(Session["brhid"].ToString()) != 0)
                {
                    this.iman.Pkbrhid = int.Parse(Session["brhid"].ToString());
                    this.iman.PkstoreID = int.Parse(Session["storid"].ToString());
                }
            }

            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
            //uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

            if (REQNo == 0)
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("REQNo", 1));
            }
            else
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("REQNo", REQNo));
            }

            

            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void SybReq_Annual(string reportname, int REQNo)
        {
            Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();

            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));

          
            //uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

            if (REQNo == 0)
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("REQNo", 1));
            }
            else
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("REQNo", REQNo));
            }



            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void SybDistributionList(string reportname)
        {
            uriReportSource.Uri = reportname;
            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void LabRequisition(string reportname, int REQNo)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
 

            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Department", this.iman.Pkdeptid));
            //uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

            if (REQNo == 0)
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("REQNo", 1));
            }
            else
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("REQNo", REQNo));
            }



            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void ITRequisition(string reportname, int REQNo)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();
            this.iman.Pkdeptid = 10;

            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Department", this.iman.Pkdeptid));
            //uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

            if (REQNo == 0)
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("REQNo", 1));
            }
            else
            {
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("REQNo", REQNo));
            }



            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void Consol_Requisition(string reportname, int ReqTypeID)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();

            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("ReqTypeID", ReqTypeID));

            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void DynConsol_Requisition(string reportname, int ReqTypeID)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();

            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("RptType", "S"));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("ReqType", ReqTypeID));

            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void BranchWiseDateWise_StockBalance(string reportname)
        {

            ///reportname = "Reports/TestReport.TRDX";

            uriReportSource.Uri = reportname;
            this.ReportViewer1.ReportSource = uriReportSource;
        }


        private void DynOAConsol_Requisition(string reportname, int ReqTypeID)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();

            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("RptType", "S"));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("ReqType", ReqTypeID));

            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void DynOAConsol_SyllabusRequisition(string reportname, int ReqTypeID, string PrintSysType)
        {
            //Telerik.Reporting.UriReportSource uriReportSource = new Telerik.Reporting.UriReportSource();

            uriReportSource.Uri = reportname;

            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("RptType", "Y"));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("ReqType", ReqTypeID));
            uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("SysType", PrintSysType));

            this.ReportViewer1.ReportSource = uriReportSource;
        }

        private void SettingReportFilter(string reportname)
        {          
            var settings = new System.Xml.XmlReaderSettings();
            settings.IgnoreWhitespace = true;

            using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(reportname, settings))
            {
                var xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();

                var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                //applying filtering
                Telerik.Reporting.Filter filter1 = new Telerik.Reporting.Filter();
           
                filter1.Expression = "Fields.Pro_codigo";
                filter1.Operator = Telerik.Reporting.FilterOperator.Equal;
                filter1.Value = "= 00002";

                report.Filters.Add(filter1);
                
                this.ReportViewer1.ReportSource = uriReportSource;
                //{
                //    ReportDocument = report;
                //}
            }



        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
           // Response.Redirect("Main.aspx");

            object typ = this.GetType();
            //window.open('javascript:window.open("", "_self", "");window.close();', '_self');
           // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Close_Window", "self.close();", true);
           ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);

           // ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "$(document).ready(function(){EnableControls();alert('Overrides successfully Updated.');DisableControls();});", true);
          // Page.ClientScript.RegisterStartupScript(this.GetType(), "close", "<script language=javascript>window.close();</script>");
           //Response.Redirect("Main.aspx");
        }
        
        protected void btnRPWidth_Click(object sender, EventArgs e)
        {

            if (this.ReportViewer1.Width == 918)
            {
                this.ReportViewer1.Width = 1500;
            }
            else
            {
                this.ReportViewer1.Width = 918;
            }
        }

        protected void btnAssets_Click(object sender, EventArgs e)
        {
            String rpt = Request.QueryString["rptname"];

            if (rpt == "GoodsIssueNote")
            {

                if (btnAssets.Text == "Assets Report")
                {
                    btnAssets.Text = "General Report";

                    string reportname = "Reports/GoodsIssueNote_DeptWise.trdx";

                    iman.PrintGIN = int.Parse(txtDocID.Text);

                    int GINNo = iman.PrintGIN;
                   // iman.Pkdeptid = 2;


                    Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

                    sqlDataSource.ConnectionString = "IMS_RPT_Conn";

                    
                    
                    string selectCommandText = "SELECT fkIssueByBranchID, fkIssueByStoreID, fkIssueByDeptID, IssuByBranch , IssuByStore  , IssuByDept  , IssuBy  , GINNumber    , GINCode    , IssuDate    , fkItemID    , InvCode,";
                    selectCommandText = selectCommandText + "ItemTitle   , Qtty     , Unit      , Model      , Brand      , IssuedStatus     , ReceivedValidity     , ReturnValidity    , IssuToBranch      , IssuToStore     , IssuToDept    , IssuTo,";
                    selectCommandText = selectCommandText + "VendorName      , Remarks  FROM  INVENTORY . dbo . View_GoodsIssueNote";
                    selectCommandText = selectCommandText + " where fkissuebybranchid=" + iman.Pkbrhid.ToString() + " and fkIssueByDeptID=" + iman.Pkdeptid.ToString() + " and GINNumber=" + GINNo.ToString();

                   
                    
                    
                    sqlDataSource.SelectCommand = selectCommandText;
                    System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
                    settings.IgnoreWhitespace = true;
                    //WHERE THE REPORTS RESIDE...
                    const string Directory = "~/";
                    //
                    using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
                    {
                        Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                        var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                        report.DataSource = sqlDataSource;
                        this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
                    }

                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

                    if (GINNo == 0)
                    {
                        this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GINno", 1));
                    }
                    else
                    {
                        this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GINno", GINNo));
                    }

                    this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;
                    this.ReportViewer1.DataBind();
                    this.ReportViewer1.RefreshReport();

                }
                else
                {
                    btnAssets.Text = "Assets Report";
                    iman.PrintGIN = int.Parse(txtDocID.Text);
                    GoodReceiveNote1("Reports/GoodsIssueNote.trdx", iman.PrintGRN);
                }
            }


            if (rpt == "GoodsReceiptNote" && btnAssets.Text == "Assets Report")
            {
                //GoodReceiveNote("Reports/GoodsReceiptNote_DeptWise.trdx", iman.PrintGRN);


                if (btnAssets.Text == "Assets Report")
                {
                    btnAssets.Text = "General Report";


                    string reportname = "Reports/GoodsReceiptNote_DeptWise.trdx";

                    iman.PrintGRN = int.Parse(txtDocID.Text);

                    int GRNNo = iman.PrintGRN;

                    if (iman.Pkbrhid!=25)
                    {
                      iman.Pkdeptid = 2;
                    }

                    Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

                    sqlDataSource.ConnectionString = "IMS_RPT_Conn";

                    string selectCommandText = "SELECT[RECVBYBRANCH],[RECVBYSTORE],[RECVBYDEPT],[RECVBYPERSON],[VendorName],[DCNo],[DDate],[InvoiceNo],[MIRNumber],[VehicleNo],[PONo],[ReceivedStatus]";
                    selectCommandText = selectCommandText + ",[GRNNumber],[GRNCode],[fkItemID],[InvCode],[ItemTitle],[Qtty],[Unit],[Model],[Brand],[Remarks],[RECVFROMBRANCH],[RECVFROMSTORE],[RECVFROMDEPT]";
                    selectCommandText = selectCommandText + ",[RECVFROMPERSON],[RECVFROMNAME],[BRANCHID],[STOREID],[DEPTID]";
                    selectCommandText = selectCommandText + " FROM [INVENTORY].[dbo].[View_GoodsReceiptNotes_DeptWise]";
                    selectCommandText = selectCommandText + " where BRANCHID=" + iman.Pkbrhid.ToString() + " and DEPTID=" + this.iman.Pkdeptid.ToString() + " and GRNNumber=" + GRNNo.ToString();


                    sqlDataSource.SelectCommand = selectCommandText;
                    System.Xml.XmlReaderSettings settings = new System.Xml.XmlReaderSettings();
                    settings.IgnoreWhitespace = true;
                    //WHERE THE REPORTS RESIDE...
                    const string Directory = "~/";
                    //
                    using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(Server.MapPath(Directory) + reportname, settings))
                    {
                        Telerik.Reporting.XmlSerialization.ReportXmlSerializer xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                        var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);

                        report.DataSource = sqlDataSource;
                        this.ReportViewer1.ReportSource = new InstanceReportSource { ReportDocument = report };
                    }

                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("PrintBy", UMan.Uname.ToString()));
                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                    this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));


                    if (GRNNo == 0)
                    {
                        this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GRNno", 1));
                    }
                    else
                    {
                        this.ReportViewer1.ReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GRNno", GRNNo));
                    }

                    this.ReportViewer1.ReportSource = this.ReportViewer1.ReportSource;

                    // Calling the RefreshReport method in case this is a WinForms application.

                    this.ReportViewer1.DataBind();

                    this.ReportViewer1.RefreshReport();

                    //******************************************************************************************************
                    //uriReportSource.Uri = reportname;

                    //uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                    //uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Dept", this.iman.Pkdeptid));

                    //if (GRNNo == 0)
                    //{
                    //    uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GRNno", 1));
                    //}
                    //else
                    //{
                    //    uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("GRNno", GRNNo));
                    //}
                    //this.ReportViewer1.ShowPrintPreviewButton = true;
                    //this.ReportViewer1.ReportSource = uriReportSource;
                    //this.ReportViewer1.RefreshReport();
                }
                else
                {
                    btnAssets.Text = "Assets Report";
                    iman.PrintGRN = int.Parse(txtDocID.Text);
                    GoodReceiveNote1("Reports/GoodsReceiptNote.trdx", iman.PrintGRN);
                }

            }

            if (rpt == "StoreInventoryBalances")
            {
                ResetPage();

                string reportname = "Reports/StoreInventoryBalances.trdx";

                iman.Pkdeptid = 2;
                iman.PkstoreID = 0;
                iman.PksysID = 4;

                uriReportSource.Uri = reportname;

                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("System", this.iman.PksysID));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Branch", this.iman.Pkbrhid));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Store", this.iman.PkstoreID));
                uriReportSource.Parameters.Add(new Telerik.Reporting.Parameter("Department", this.iman.Pkdeptid));

                this.ReportViewer1.ShowPrintPreviewButton = true;
                this.ReportViewer1.ReportSource = uriReportSource;
                this.ReportViewer1.RefreshReport();

            }

        }

        protected void btnRptShow_Click(object sender, EventArgs e)
        {
            String rpt = Request.QueryString["rptname"];
            
            if (rpt == "GoodsIssueNote")
            {
                iman.PrintGIN = int.Parse(txtDocID.Text);
                GoodIssueNote1("Reports/GoodsIssueNote.trdx", iman.PrintGIN);
            }
            if (rpt == "GoodsReceiptNote")
            {
                iman.PrintGRN = int.Parse(txtDocID.Text);
                GoodReceiveNote1("Reports/GoodsReceiptNote.trdx", iman.PrintGRN);
            }

            if (rpt == "GatePass")
            {
                iman.PrintGP = int.Parse(txtDocID.Text);
                GatePass1("Reports/GatePass.trdx", iman.PrintGP);
            }

            if (rpt == "MaterialIssueRequest")
            {
                iman.PrintMIR = int.Parse(txtDocID.Text);
                MIR1("Reports/MaterialIssueRequest.trdx", iman.PrintMIR);
            }
            if (rpt == "MaterialReturnGIN")
            {
                iman.PrintGIN = int.Parse(txtDocID.Text);
                MaterialReturnGIN("Reports/MaterialReturnGIN.trdx", iman.PrintGIN);
            }

            if (rpt == "PurchaseOrder")
            {
                iman.PrintPO = int.Parse(txtDocID.Text);
                PurchaseOrder("Reports/PurchaseOrder.trdx", iman.PrintPO);
            }

            if (rpt == "SportsTransaction")
            {
                string isustat = string.Empty;

                if (chkTempIssue.Checked == true)
                {
                    isustat = "Temp";
                }

                txtDocID.Text = txtDocID.Text == "" ? iman.PrintGIN.ToString() : txtDocID.Text;
                iman.PrintGIN = int.Parse(txtDocID.Text) == 0 ? 1 : int.Parse(txtDocID.Text);

                if (isustat == "Temp")
                {
                    SportsItemIssue("Reports/GoodsIssueNote_DeptWiseTemp.trdx", iman.PrintGIN);
                }
                else
                {
                    SportsItemIssue("Reports/GoodsIssueNote_DeptWise.trdx", iman.PrintGIN);
                }
            }
           
        }

        protected void chkTempIssue_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnOpenRDLC_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports/RDLC/RDLC_ReportViewer.aspx");
        }


    }
}