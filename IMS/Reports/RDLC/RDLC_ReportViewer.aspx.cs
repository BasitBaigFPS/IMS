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
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Text;
using BLL;
using DAL;
namespace IMS.Reports.RDLC
{
    public partial class RDLC_ReportViewer : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
           
        protected void Page_Load(object sender, EventArgs e)
        {

            printregularchallan();
        }


        private void printregularchallan()
        {
            

            //con.Open();
            string sqlstr = "";

            int elistno = 15424;
            string chlno = "19256";
            int comid=1;
            string grdnam="PN";
            string grdsec="3";
            int brhid = 21;



            int fndchlno = int.Parse(chlno);

            if (chlno != "" && chlno != "0")
            {
                sqlstr = "SELECT * FROM tblRegularFeeChallan where FeeListNo=" + elistno + " and ChallanID=" + fndchlno + " and IsCancel IS NULL ORDER BY GRADE, GRDSEC";
            }
            else
            {
                if (grdnam == "" || grdnam == null)
                {
                    sqlstr = "SELECT * FROM tblRegularFeeChallan where FeeListNo=" + elistno + " and IsCancel IS NULL ORDER BY GRADE, GRDSEC";
                }
                else
                {
                    if (grdsec == "")
                    {
                        sqlstr = "SELECT * FROM tblRegularFeeChallan where FeeListNo=" + elistno + " and grade ='" + grdnam + "' and IsCancel IS NULL ORDER BY GRADE, GRDSEC";
                    }
                    else
                    {
                        sqlstr = "SELECT * FROM tblRegularFeeChallan where FeeListNo=" + elistno + " and grade ='" + grdnam + "' and grdsec ='" + grdsec + "' and IsCancel IS NULL ORDER BY ROLLNO";
                    }

                }
            }

            sqlstr = "SELECT FeeListNo, regcode, fkacdid, fkbrhID, brhname, brhcode, fkcomID, fkcityID, fkgrdID, ChallanID, ChallanNo, RollNo, Name, Grade, GrdSec,";
            sqlstr = sqlstr + " TuitionFees, 0 as Admission, SecurityFees, Syllabus, Computer, Magazine, Calendar, Labority, Art, Library, Biannual,  SubjectDesc, OtherAmount, OtherDesc,";
            sqlstr = sqlstr + " TotalAmount, MonthFrom, MonthTo, BillMode, ChallanIsuDate, ChallanDueDate, ChallanFinalDate,  Concesion, BillPeriod, ArrHistory, ArrAmount, PayHistory, PaidAmount,";
            sqlstr = sqlstr + " bankaccount, bankdescription,AdjAmount, WHTax, ExpiryDate, DisputedAmount, CourseFees, CourseDesc FROM tblRegularFeeChallan_tblbilling";
            sqlstr = sqlstr + " where FeeListNo=" + elistno + " and ChallanID=" + fndchlno + " ORDER BY GRADE, GRDSEC";

            string MyRptName;

            string conString = ConfigurationManager.ConnectionStrings["SMSConn"].ConnectionString;

            SqlConnection con = new SqlConnection(conString);

            con.Open();
            SqlCommand cmd = new SqlCommand(sqlstr, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);

            int[] adminuser = new int[10] { 95, 113, 152, 166, 93, 105, 99, 1607, 85, 155 };

           // SqlDataReader dr = cmd.ExecuteReader();

 
            if (comid == 1)
            {
 
                MyRptName = "Reports\\RDLC\\RegFeeChallanNew_FPS.rdlc";

            }
            else
            {
 
                 MyRptName = "Reports\\RDLC\\RegFeeChallanNew_HSS.rdlc";
 
            }

 
            ReportViewer1.LocalReport.ReportPath = MyRptName;

 
            //ReportParameter parameters = new ReportParameter();

            //parameters = new ReportParameter("RptAmount", ReportParameterType, "");

            //ReportViewer1.LocalReport.SetParameters(parameters);

            ReportViewer1.ProcessingMode = ProcessingMode.Local;


            ReportViewer1.LocalReport.ReportPath = MyRptName;


          //  ReportViewer1.LocalReport.ReportPath = Server.MapPath(MyRptName);

            ReportDataSource rds = new ReportDataSource();

            rds.Name = "DataSet1";
            
            rds.Value = ds.Tables[0];

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);


            ReportViewer1.LocalReport.DataSources.Add(rds);

            ReportViewer1.LocalReport.Refresh();
 
 
            //this.Controls.Add(ReportViewer1);
             

        }

        //private DataTable GetData(string query)
        //{
        //    string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    SqlCommand cmd = new SqlCommand(query);
        //    using (SqlConnection con = new SqlConnection(conString))
        //    {
        //        using (SqlDataAdapter sda = new SqlDataAdapter())
        //        {
        //            cmd.Connection = con;

        //            sda.SelectCommand = cmd;
        //            using (Customers dsCustomers = new Customers())
        //            {
        //                sda.Fill(dsCustomers, "DataTable1");
        //                return dsCustomers;
        //            }
        //        }
        //    }
        //}


    }
}