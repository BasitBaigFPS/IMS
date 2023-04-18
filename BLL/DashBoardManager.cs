using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using System.Configuration;

namespace BLL
{
    public class DashBoardManager
    {

        #region Class Constructor

        public DashBoardManager()
         {
            conn.ConnectionString = SqlHelper.connectionstring;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;


         }

        #endregion

        #region Class Level Objects

        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        #endregion

        #region Public/Private Properties     

		
        public string pkSysID { get; set; }
        public int fkbrhid { get; set; }
        public int fkstoreid { get; set; }
        public int fkdepartid { get; set; }
        public string storeName { get; set; }

        public float opbalance { get; set; }
        public float orderlimit { get; set; }

        public int GINNumber { get; set; }
        public int GRNNumber { get; set; }
        public int GPNumber { get; set; }

        public int UserGroupID { get; set; }

        #endregion

        #region Helper Methods

        public DataTable GetStoreInventory(string dbpanel, int brhid, int storeid, int deptid)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@DBpanelID", dbpanel);
            param[1] = new SqlParameter("@fkbrhid", brhid);
            param[2] = new SqlParameter("@fkstoreid", storeid);
            param[3] = new SqlParameter("@fkdeptid", deptid);


            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_DASHBOARD", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }


        public List<string> GetTransLog()
        {
            //Method to Show Pending Transactions 

            string sqlstr;
            SqlDataReader dr;
            List<string> listRange = new List<string>();

            if (UserGroupID == 49 || UserGroupID == 27 || UserGroupID == 28 || UserGroupID == 29 || UserGroupID == 39)
            {
                sqlstr = "select TOP 5 storeid, storename, 'Last Tran.Date:' + CONVERT(VARCHAR(10),CONVERT(DATE,MAX(CreatedDate),103),110) as LastTransDate, cast(DATEDIFF(DAY,MAX(CreatedDate),GETDATE()) as varchar)+' Day(s) Passed!' AS NoTransSince";
                sqlstr = sqlstr + " FROM [INVENTORY].[dbo].[View_StoreTransactions]";
                sqlstr = sqlstr + " GROUP BY StoreName,storeid";
                sqlstr = sqlstr + " HAVING MAX(CreatedDate) < getdate()";
                sqlstr = sqlstr + " ORDER BY storeid ";

                dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlstr);

                string listitem;
                while (dr.Read())
                {
                    listitem = dr["storename"].ToString().TrimEnd() + " - " + dr["LastTransDate"].ToString().TrimEnd() + " - " + dr["NoTransSince"].ToString().TrimEnd();
                    listRange.Add(listitem);
                }

            }
            else
            {
                sqlstr = "select TOP 5 storeid, storename, 'Last Tran.Date:' + CONVERT(VARCHAR(10),CONVERT(DATE,MAX(CreatedDate),103),110) as LastTransDate, cast(DATEDIFF(DAY,MAX(CreatedDate),GETDATE()) as varchar)+' Day(s) Passed!' AS NoTransSince";
                sqlstr = sqlstr + " FROM [INVENTORY].[dbo].[View_StoreTransactions]";
                sqlstr = sqlstr + " GROUP BY StoreName,storeid";
                sqlstr = sqlstr + " HAVING MAX(CreatedDate) < getdate() and storeid=" + @fkstoreid;
                sqlstr = sqlstr + " ORDER BY storeid ";

                dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlstr);

                string listitem;
                while (dr.Read())
                {
                    listitem = dr["LastTransDate"].ToString().TrimEnd() + " - " + dr["NoTransSince"].ToString().TrimEnd();
                    listRange.Add(listitem);            
                }

            }
             
            dr.Close();

            return listRange;

        }

        public List<string> GetMIRList()
        {
            // Method to Show Latest MIR Send By Branches to Main Store

            List<string> listRange = new List<string>();

            string sqlstr = "SELECT TOP 10 fkIssueToStoreID, BRHNAME, STORENAME, MIRCODE, TOTALITEMS, ISRECEIVED FROM DB_ActiveMIRInfo WHERE fkIssueToStoreID=" + @fkstoreid + " Order by BRHNAME";
           
            //SqlCommand cmd = new SqlCommand(sqlstr, conn);
            //SqlDataReader dr = cmd.ExecuteReader();

            SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlstr);

            if (dr.Read())
            {

                listRange.Add("Branch Name   : " + dr["BRHNAME"].ToString().TrimEnd());
                listRange.Add("StoreName     : " + dr["STORENAME"].ToString().TrimEnd());
                listRange.Add("MIR-No        : " + dr["MIRCODE"].ToString().TrimEnd());
                listRange.Add("Items in MIR  : " + dr["TOTALITEMS"].ToString().TrimEnd());
                listRange.Add("================================");

            }
            else
            {
                listRange.Add("");
                //No New MIR Record!
            }
            //DataTable dt = new DataTable();
            //DataRow dtr = dt.NewRow();
            //dt.Rows.Add(dr);
            //dt.Load(dr);

            dr.Close();

            //listRange.Add("q");
            //listRange.Add("s");

            return listRange;

        }

        public List<string> GetUCGinList()
        {
            //Method to Show UNComfirmed GIN Record, Pending at Main Store 


            List<string> listRange = new List<string>();

            //string sqlstr = "SELECT [Branch],[GINCode],[IssuedConfirm],[IsCancel],[IssuedStatus],[IssuedType],[fkIssueByBranchID],[fkIssueByStoreID],[fkIssueByDeptID]";

            //sqlstr = sqlstr + " FROM [INVENTORY].[dbo].[View_UnConfirmedGIN] WHERE fkIssueByStoreID=" + @fkstoreid + " Order By GINNumber Desc";



            string sqlstr = "select TOP 10 Branch,GINCode, count(gincode) as TotalUnConfirmed FROM [INVENTORY].[dbo].[View_UnConfirmedGIN]";
            sqlstr = sqlstr + " where fkIssueByBranchID=" + @fkbrhid + " and fkIssueByStoreID=" + @fkstoreid + " group by branch,GINCode order by branch";
            
            SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlstr);

            string listitem;
            while (dr.Read())
            {
                //lenof = (dr["Branch"].ToString().TrimEnd() + "-" + dr["GINCode"].ToString().TrimEnd() + "-" + dr["IssuedConfirm"].ToString().TrimEnd()).Length;
                listitem = dr["Branch"].ToString().TrimEnd() + "   -   " + dr["GINCode"].ToString().TrimEnd();
                listRange.Add(listitem);
                //+ "   -   " + dr["TotalUnConfirmed"].ToString().TrimEnd()
                //listRange.Add(string.Join("", Enumerable.Repeat('-', lenof)));                
            }
           
            dr.Close();

            return listRange;

        }

        public List<string> GetZeroBalanceItem()
        {
            //Method to Show UNComfirmed GIN Record, Pending at Main Store 


            List<string> listRange = new List<string>();

            //string sqlstr = "SELECT fkIssueToStoreID, BRHNAME, STORENAME, MIRCODE, TOTALITEMS, ISRECEIVED FROM DB_ActiveMIRInfo WHERE fkIssueToStoreID=" + @fkstoreid;

            string sqlstr = "Select TOP 10 [fkbrhID],[fkStoreID],cattitle as Title, count(itemtitle) as Total";
            sqlstr = sqlstr + " FROM [INVENTORY].[dbo].[View_ZeroBalanceInventory] where fkstoreid=" + @fkstoreid;
            sqlstr = sqlstr + " group by [fkbrhID],[fkStoreID],cattitle order by cattitle";

            SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlstr);

            string listitem;
            while (dr.Read())
            {                
                listitem = dr["Title"].ToString().TrimEnd() + "   -   " + dr["Total"].ToString().TrimEnd();
                listRange.Add(listitem);             
            }

            dr.Close();

            return listRange;

        }

        public List<string> GetMostIssuedItems()
        {
            //Method to Show UNComfirmed GIN Record, Pending at Main Store 


            List<string> listRange = new List<string>();

            //string sqlstr = "SELECT fkIssueToStoreID, BRHNAME, STORENAME, MIRCODE, TOTALITEMS, ISRECEIVED FROM DB_ActiveMIRInfo WHERE fkIssueToStoreID=" + @fkstoreid;
            //and pkCatID in (1,2) 

            string sqlstr = "SELECT TOP 10 [fkIssueByBranchID],[fkIssueByStoreID],[fkIssueByDeptID],pkCatID,[ItemCount],[ItemCode],[ItemTitle],[QttyIssued],[IsCancel]";
            sqlstr = sqlstr + ",[StoreName],[deptName] FROM [INVENTORY].[dbo].[View_MostFrequentlyIssuedItems] where fkIssueByStoreID=" + @fkstoreid + " order by QttyIssued desc";
 
            SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlstr);

            string listitem;
            //listitem = "        Item Title     " + "\t" + "Item Count" + "\t" + "Quantity Issued";
            //listRange.Add(listitem);
            //listitem = "=================" + "\t" + "======" + "\t" + "=======";
            //listRange.Add(listitem);

            while (dr.Read())
            {               
                listitem = dr["ItemTitle"].ToString().TrimEnd() + "   -   (" + dr["ItemCount"].ToString().TrimEnd() + ")   -   " + dr["QttyIssued"].ToString().TrimEnd();
                listRange.Add(listitem);                               
            }

            dr.Close();
            return listRange;

        }

        public List<string> GetTop5GIN()
        {
            //Method to Show TOP 5 GIN Record 


            List<string> listRange = new List<string>();

            //string sqlstr = "SELECT top 5 convert(date,CreatedDate,108) as CreatedDate, fkIssueByStoreID, GINCode, COUNT(fkItemID) AS TotalItems";
            //sqlstr = sqlstr + " FROM [INVENTORY].[dbo].[tblIssued]";
            //sqlstr = sqlstr + " GROUP BY fkIssueByBranchID, fkIssueByStoreID, GINCode, IsCancel, convert(date,CreatedDate,108)";
            //sqlstr = sqlstr + " HAVING (IsCancel IS NULL) and fkIssueByStoreID=" + @fkstoreid + " order by CreatedDate desc";
            string sqlstr;
            if (@fkstoreid == 1)
            {
                sqlstr = " SELECT top 5 convert(date,I.CreatedDate,108) as CreatedDate, I.fkIssueByStoreID, I.GINCode, S.StoreCode,";
                sqlstr = sqlstr + " CASE WHEN I.IsReceived IS NULL AND I.IssuedType='E' THEN 'PENDING' ELSE 'RECEIVED' END AS STATUS";
                sqlstr = sqlstr + " FROM [INVENTORY].[dbo].[tblIssued] I";
                sqlstr = sqlstr + " INNER JOIN [INVENTORY].[dbo].[tblStores] S  ON S.pkStoreID = I.fkIssueByStoreID";
                sqlstr = sqlstr + " GROUP BY I.fkIssueByBranchID, I.fkIssueByStoreID, I.GINCode, I.IsCancel,I.IssuedConfirm,I.IsReceived,I.IssuedType, convert(date,I.CreatedDate,108),S.StoreCode";
                sqlstr = sqlstr + " HAVING (I.IsCancel IS NULL) and I.fkIssueByStoreID=" + @fkstoreid + " AND I.IssuedConfirm=1 AND I.IsReceived IS NULL Order by convert(date,I.CreatedDate,108) DESC, I.GINCODE desc";
                
            }
            else
            {

                //sqlstr = " SELECT top 15 convert(date,I.CreatedDate,108) as CreatedDate, I.fkIssueByStoreID, I.GINCode, S.StoreCode,";
                //sqlstr = sqlstr + " CASE WHEN I.IsReceived IS NULL THEN 'PENDING' ELSE 'RECEIVED' END AS STATUS";
                //sqlstr = sqlstr + " FROM [INVENTORY].[dbo].[tblIssued] I";
                //sqlstr = sqlstr + " INNER JOIN [INVENTORY].[dbo].[tblStores] S  ON S.pkStoreID = I.fkIssueToStoreID";
                //sqlstr = sqlstr + " GROUP BY I.fkIssueByBranchID, I.fkIssueByStoreID, I.GINCode, I.IsCancel,I.IssuedConfirm,I.IsReceived, convert(date,I.CreatedDate,108),S.StoreCode";
                //sqlstr = sqlstr + " HAVING (I.IsCancel IS NULL) and I.fkIssueByStoreID=" + @fkstoreid + " Order by convert(date,I.CreatedDate,108) DESC, I.GINCODE desc";
                //I.IssuedConfirm=1 AND AND I.IsReceived IS NULL
                if (@fkstoreid == 0)
                {
                    sqlstr = "SELECT top 5 convert(date,I.CreatedDate,108) as CreatedDate, I.fkIssueByDeptID, I.GINCode, B.brhCode as StoreCode,";
                    sqlstr = sqlstr + "  CASE WHEN I.IsReceived IS NULL AND I.IssuedType='E' THEN 'PENDING' ELSE 'RECEIVED' END AS STATUS ";
                    sqlstr = sqlstr + "  FROM [INVENTORY].[dbo].[tblIssued] I INNER JOIN [INVENTORY].[dbo].[tblBranches]  B  ";
                    sqlstr = sqlstr + "  ON B.pkbrhID  = I.fkIssueByBranchID ";
                    sqlstr = sqlstr + "  GROUP BY I.fkIssueByBranchID, I.fkIssueByDeptID, I.GINCode, I.IsCancel,I.IssuedConfirm,I.IsReceived,I.IssuedType, convert(date,I.CreatedDate,108),B.brhCode ";
                    sqlstr = sqlstr + "  HAVING (I.IsCancel IS NULL) AND I.fkIssueByBranchID=" + @fkbrhid + " and I.fkIssueByDeptID=" + @fkdepartid + " AND I.IssuedConfirm=1 AND I.IsReceived IS NULL Order by convert(date,I.CreatedDate,108) DESC, I.GINCODE desc";
                }
                else
                {
                    sqlstr = "SELECT top 5 convert(date,I.CreatedDate,108) as CreatedDate, I.fkIssueByDeptID, I.GINCode, B.brhCode as StoreCode,";
                    sqlstr = sqlstr + "  CASE WHEN I.IsReceived IS NULL AND I.IssuedType='E' THEN 'PENDING' ELSE 'RECEIVED' END AS STATUS ";
                    sqlstr = sqlstr + "  FROM [INVENTORY].[dbo].[tblIssued] I INNER JOIN [INVENTORY].[dbo].[tblBranches]  B  ";
                    sqlstr = sqlstr + "  ON B.pkbrhID  = I.fkIssueByBranchID ";
                    sqlstr = sqlstr + "  GROUP BY I.fkIssueByBranchID, I.fkIssueByStoreID,I.fkIssueByDeptID, I.GINCode, I.IsCancel,I.IssuedConfirm,I.IsReceived,I.IssuedType, convert(date,I.CreatedDate,108),B.brhCode ";
                    sqlstr = sqlstr + "  HAVING (I.IsCancel IS NULL) AND I.fkIssueByBranchID=" + @fkbrhid + " and I.fkIssueByStoreID=" + @fkstoreid + " AND I.IssuedConfirm=1 AND I.IsReceived IS NULL Order by convert(date,I.CreatedDate,108) DESC, I.GINCODE desc";
                }


            }

            SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlstr);

            string listitem;
            //"" 


            while (dr.Read())
            {
                int codelength = (dr["GINCode"].ToString().Length - 8);
                string txtginno = dr["GINCode"].ToString().Substring(codelength, (dr["GINCode"].ToString().Length - codelength));

                listitem = dr["CreatedDate"].ToString().Substring(0, 10) + "  -  <b><a target='blank' href=ReportsMain.aspx?rptname=GoodsIssueNote&gino=" + int.Parse(txtginno).ToString().Trim() + ">" + dr["GINCode"].ToString().TrimEnd() + "</a>" + "</b>   -   " + dr["StoreCode"].ToString().TrimEnd() + "   -  <b>" + dr["STATUS"].ToString().TrimEnd() + "</b>";
                
                //listitem = dr["CreatedDate"].ToString().Substring(0, 10) + " - " + dr["GINCode"].ToString().TrimEnd() + " - " + dr["StoreCode"].ToString().TrimEnd() + " - " + dr["STATUS"].ToString().TrimEnd();
                listRange.Add(listitem);
            }

            dr.Close();
            return listRange;

        }

        public List<string> GetTop5GRN()
        {
            //Method to Show TOP 5 GRN Record 


            List<string> listRange = new List<string>();

            //string sqlstr = "SELECT top 5 convert(date,CreatedDate,108) as CreatedDate, fkRecvByBranchID, GRNCode, COUNT(fkItemID) AS TotalItems";
            //sqlstr = sqlstr + " FROM [INVENTORY].[dbo].[tblReceived]";
            //sqlstr = sqlstr + " GROUP BY fkRecvByBranchID, fkRecvByStoreID, GRNCode, IsCancel, convert(date,CreatedDate,108)";
            //sqlstr = sqlstr + " HAVING (IsCancel IS NULL) and fkRecvByStoreID=" + @fkstoreid + " order by CreatedDate desc";

            string sqlstr;

            if (@fkbrhid != 25)
            {
                sqlstr = "SELECT top 5 convert(date,CreatedDate,108) as CreatedDate, fkRecvByBranchID,GRNNUMBER, GRNCode, COUNT(fkItemID) AS TotalItems";
                sqlstr = sqlstr + " FROM [INVENTORY].[dbo].[tblReceived]";
                sqlstr = sqlstr + " GROUP BY fkRecvByBranchID, fkRecvByStoreID,GRNNUMBER, GRNCode, IsCancel, convert(date,CreatedDate,108)";
                sqlstr = sqlstr + " HAVING (IsCancel IS NULL) and fkRecvByBranchID=" + @fkbrhid + " order by CreatedDate desc, GRNNUMBER DESC";
            }
            else 
            {

                if (@fkstoreid != 0)
                {
                    sqlstr = "SELECT top 5 convert(date,CreatedDate,108) as CreatedDate, fkRecvByBranchID,GRNNUMBER, GRNCode, COUNT(fkItemID) AS TotalItems";
                    sqlstr = sqlstr + " FROM [INVENTORY].[dbo].[tblReceived]";
                    sqlstr = sqlstr + " GROUP BY fkRecvByBranchID, fkRecvByStoreID,GRNNUMBER, GRNCode, IsCancel, convert(date,CreatedDate,108)";
                    sqlstr = sqlstr + " HAVING (IsCancel IS NULL) and fkRecvByStoreID=" + @fkstoreid + " order by CreatedDate desc, GRNNUMBER DESC";
                }
                else
                {
                    sqlstr = "SELECT top 5 convert(date,CreatedDate,108) as CreatedDate, fkRecvByBranchID,GRNNUMBER, GRNCode, COUNT(fkItemID) AS TotalItems";
                    sqlstr = sqlstr + " FROM [INVENTORY].[dbo].[tblReceived]";
                    sqlstr = sqlstr + " GROUP BY fkRecvByBranchID, fkRecvByDeptID,GRNNUMBER, GRNCode, IsCancel, convert(date,CreatedDate,108)";
                    sqlstr = sqlstr + " HAVING (IsCancel IS NULL) and fkRecvByDeptID=" + @fkdepartid + " order by CreatedDate desc, GRNNUMBER DESC";

                }

            }



            SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlstr);

            string listitem;

            while (dr.Read())
            {

                int codelength = (dr["GRNCode"].ToString().Length - 8);
                if (codelength > 0)
                {
                    string txtgrnno = dr["GRNCode"].ToString().Substring(codelength, (dr["GRNCode"].ToString().Length - codelength));

                    listitem = dr["CreatedDate"].ToString().Substring(0, 10) + "  -  <b><a target='blank' href=ReportsMain.aspx?rptname=GoodsReceiptNote&grno=" + int.Parse(txtgrnno).ToString().Trim() + ">" + dr["GRNCode"].ToString().TrimEnd() + "</a>" + "</b>   -   " + dr["TotalItems"].ToString().TrimEnd();


                    //   listitem = dr["CreatedDate"].ToString().Substring(0,10) + " - " + dr["GRNCode"].ToString().TrimEnd() + " - " + dr["TotalItems"].ToString().TrimEnd();
                    listRange.Add(listitem);
                }
            }

            dr.Close();
            return listRange;

        }

        private void GetRandomNumber()
        {

            Random rnd = new Random();
            int month = rnd.Next(1, 13); // creates a number between 1 and 12
            int dice = rnd.Next(1, 7); // creates a number between 1 and 6
            int card = rnd.Next(52); // creates a number between 0 and 51


        }

        public List<string> GetUNRGinList()
        {
            //Method to Show UNReceived GIN Record, Issued From Main Store But Pending at Branch
            //and I.fkIssueByStoreID=1

            string sqlstr;
            List<string> listRange = new List<string>();

            int depid = @fkdepartid;

            if (@fkbrhid == 25)
            {

                if (@fkstoreid==2)
                {

                    sqlstr = "SELECT TOP 25 convert(varchar(10),I.CreatedDate,102) as IssuedDate, I.fkIssueByStoreID, I.fkIssueToBranchID,I.GINCode, S.StoreCode as MainStore,";
                    sqlstr = sqlstr + " CASE WHEN isnull(I.IsReceived,0)=0 THEN 'PENDING/UNRECEIVED' ELSE 'RECEIVED' END AS STATUS FROM [INVENTORY].[dbo].[tblIssued] I";
                    sqlstr = sqlstr + " LEFT OUTER JOIN [INVENTORY].[dbo].[tblStores] S  ON S.pkStoreID = I.fkIssueByStoreID";
                    sqlstr = sqlstr + " GROUP BY  I.GINCode, I.IsCancel,I.IssuedConfirm,I.IsReceived,I.IssuedType, convert(varchar(10),I.CreatedDate,102),S.StoreCode,I.fkIssueByStoreID,I.fkIssueToStoreID, I.fkIssueToBranchID, I.fkIssueToDeptID";
                    sqlstr = sqlstr + " HAVING (isnull(I.IsCancel,0)=0) AND I.IssuedType='E' AND I.IssuedConfirm=1 AND isnull(I.IsReceived,0)=0 AND I.fkIssueToBranchID=" + @fkbrhid + " AND I.fkIssueToDeptID=" + @fkdepartid + " AND I.fkIssueToStoreID=" + @fkstoreid + "";
                    sqlstr = sqlstr + " Order by convert(varchar(10),I.CreatedDate,102) desc";
                }
                else
                {
                    sqlstr = "SELECT TOP 25 convert(varchar(10),I.CreatedDate,102) as IssuedDate, I.fkIssueByStoreID, I.fkIssueToBranchID,I.GINCode, S.StoreCode as MainStore,";
                    sqlstr = sqlstr + " CASE WHEN isnull(I.IsReceived,0)=0 THEN 'PENDING/UNRECEIVED' ELSE 'RECEIVED' END AS STATUS FROM [INVENTORY].[dbo].[tblIssued] I";
                    sqlstr = sqlstr + " LEFT OUTER JOIN [INVENTORY].[dbo].[tblStores] S  ON S.pkStoreID = I.fkIssueByStoreID";
                    sqlstr = sqlstr + " GROUP BY  I.GINCode, I.IsCancel,I.IssuedConfirm,I.IsReceived,I.IssuedType, convert(varchar(10),I.CreatedDate,102),S.StoreCode,I.fkIssueByStoreID,I.fkIssueToStoreID, I.fkIssueToBranchID, I.fkIssueToDeptID";
                    sqlstr = sqlstr + " HAVING (isnull(I.IsCancel,0)=0) AND I.IssuedType='E' AND I.IssuedConfirm=1 AND isnull(I.IsReceived,0)=0 AND I.fkIssueToBranchID=" + @fkbrhid + " AND I.fkIssueToDeptID=" + @fkdepartid + " AND I.fkIssueByStoreID<>" + @fkstoreid + " AND I.fkIssueToStoreID=" + @fkstoreid + "";
                    sqlstr = sqlstr + " Order by convert(varchar(10),I.CreatedDate,102) desc";
                }


                // sqlstr = sqlstr + " HAVING (I.IsCancel IS NULL) AND I.IssuedType='E' AND I.IssuedConfirm=1 AND isnull(I.IsReceived,0)=0 AND I.fkIssueToBranchID=" + @fkbrhid + " AND I.fkIssueToDeptID=" + @fkdepartid + " AND I.fkIssueByStoreID<>" + @fkstoreid + " Order by convert(varchar(10),I.CreatedDate,102) desc";                
                //AND YEAR(convert(varchar(10),I.CreatedDate,102))=2017
            }
            else
            {

                sqlstr = "SELECT TOP 25 convert(varchar(10),I.CreatedDate,102) as IssuedDate, I.fkIssueByStoreID, I.fkIssueToBranchID,I.GINCode, S.StoreCode as MainStore,";
                sqlstr = sqlstr + " CASE WHEN isnull(I.IsReceived,0)=0 THEN 'PENDING/UNRECEIVED' ELSE 'RECEIVED' END AS STATUS FROM [INVENTORY].[dbo].[tblIssued] I";
                sqlstr = sqlstr + " INNER JOIN [INVENTORY].[dbo].[tblStores] S  ON S.pkStoreID = I.fkIssueByStoreID";
                sqlstr = sqlstr + " GROUP BY  I.GINCode, I.IsCancel,I.IssuedConfirm,I.IsReceived,I.IssuedType, convert(varchar(10),I.CreatedDate,102),S.StoreCode,I.fkIssueByStoreID, I.fkIssueToBranchID, I.fkIssueToDeptID";
                sqlstr = sqlstr + " HAVING (isnull(I.IsCancel,0)=0) AND I.IssuedType='E' AND I.IssuedConfirm=1 AND isnull(I.IsReceived,0)=0 AND I.fkIssueToBranchID=" + @fkbrhid +  " Order by convert(varchar(10),I.CreatedDate,102) desc";

                //" AND I.fkIssueToDeptID=" + @fkdepartid +
            
            }
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlstr);

            string listitem;

            if (@fkbrhid == 25 && @fkstoreid == 1 || @fkbrhid == 25 && @fkstoreid == 2)
            {
                while (dr.Read())
                {
                  //listitem = dr["MainStore"].ToString().TrimEnd() + "  -  <b>" + dr["GINCode"].ToString().TrimEnd()  + "</b>   -   " + dr["IssuedDate"].ToString().TrimEnd() + "   -  <b>" + dr["STATUS"].ToString().TrimEnd() + "</b>";
                    listitem = dr["MainStore"].ToString().TrimEnd() + "  -  <b><a target='blank' href=BranchReturn.aspx?ginno=" + dr["GINCode"].ToString().TrimEnd() + ">" + dr["GINCode"].ToString().TrimEnd() + "</a>" + "</b>   -   " + dr["IssuedDate"].ToString().TrimEnd() + "   -  <b>" + dr["STATUS"].ToString().TrimEnd() + "</b>";                    
                    listRange.Add(listitem);
                }
            }
            if (@fkbrhid != 25 && @fkstoreid != 1 && @fkstoreid != 22 && @fkstoreid != 0)
            {
                while (dr.Read())
                {
                    listitem = dr["MainStore"].ToString().TrimEnd() + "  -  <b><a target='blank' href=ReceivedGIN.aspx?ginno=" + dr["GINCode"].ToString().TrimEnd() + ">" + dr["GINCode"].ToString().TrimEnd() + "</a>" + "</b>   -   " + dr["IssuedDate"].ToString().TrimEnd() + "   -  <b>" + dr["STATUS"].ToString().TrimEnd() + "</b>";
                    listRange.Add(listitem);
                }
            }

            if (@fkbrhid != 25 && @fkstoreid == 0 && depid!=10)
            {
                while (dr.Read())
                {
                    listitem = dr["MainStore"].ToString().TrimEnd() + "  -  <b><a target='blank' href=ReceivedGIN.aspx?ginno=" + dr["GINCode"].ToString().TrimEnd() + ">" + dr["GINCode"].ToString().TrimEnd() + "</a>" + "</b>   -   " + dr["IssuedDate"].ToString().TrimEnd() + "   -  <b>" + dr["STATUS"].ToString().TrimEnd() + "</b>";
                    listRange.Add(listitem);
                }
            }


            dr.Close();

            return listRange;

            //<a href="ReportsMain.aspx?rptname=GoodsReceiptNote&amp;grno=<%= txtginno.Text %>" target="_blank">Print</a>
            // Response.Redirect("ReportsMain.aspx?rptname=GoodsReceiptNote&grno="+txtgrnno.Text);
        }

  
        #endregion






    }

}
