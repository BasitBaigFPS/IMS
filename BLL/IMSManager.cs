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
    public class IMSManager
    {
        #region Class Constructor

        public IMSManager()
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

        //private string uname;
        private string brhname;
        //private string uemail;
        //private string udept;
        //private string urights;
        //private int urightsid;
        //private int ubrhid;
        private int uid;
        //private int ugid;
        //private string brhEmail;
        //private string brhAddress;
        //private string brhHEmail;

        private string sysid;
        private int pkbrhid;
        private int pkcomid;
        private int pkcityid;
        private int pkdeptid;
        private int pksysID;
        private int pkstoreID;
        private string issuetoID;
        private string Remark;
        private string CancelRemark;

        public string Token { get; set; }
        public int PrintGRN { get; set; }
        public int PrintGIN { get; set; }
        public int PrintMIR { get; set; }
        public int PrintGP { get; set; }
        public int PrintQRF { get; set; }
        public int PrintSybRQ { get; set; }
        public int PrintPO { get; set; }
        
        public int PrintQRCat { get; set; }

        public string PrintSysType { get; set; }

        public string InvCode { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }

        public int PksysID
        {
            get
            {
                return this.pksysID;
            }
            set
            {
                this.pksysID = value;
            }
        }

        //public int Ubrhid
        //{
        //    get
        //    {
        //        return this.ubrhid;
        //    }
        //    set
        //    {
        //        this.ubrhid = value;
        //    }
        //}
        public int Pkdeptid
        {
            get
            {
                return this.pkdeptid;
            }
            set
            {
                this.pkdeptid = value;
            }
        }
        public int Pkcityid
        {
            get
            {
                return this.pkcityid;
            }
            set
            {
                this.pkcityid = value;
            }
        }
        public int Pkcomid
        {
            get
            {
                return this.pkcomid;
            }
            set
            {
                this.pkcomid = value;
            }
        }
        public int Pkbrhid
        {
            get
            {
                return this.pkbrhid;
            }
            set
            {
                this.pkbrhid = value;
            }
        }
        public int PkstoreID
        {
            get
            {
                return this.pkstoreID;
            }
            set
            {
                this.pkstoreID = value;
            }
        }

        public string IssuetoID
        {
            get { return issuetoID; }
            set { issuetoID = value; }
        }

        public int fkreqTypeID { get; set; }

        public string Sysid
        {
            get
            {
                return this.sysid;
            }
            set
            {
                this.sysid = value;
            }
        }  
        public string Brhname
        {
            get
            {
                return this.brhname;
            }
            set
            {
                this.brhname = value;
            }
        }

        public int Uid
        {
            get
            {
                return this.uid;
            }
            set
            {
                this.uid = value;
            }
        }

        public string Remarks
        {
            get { return Remark; }
            set { Remark = value; }
        }
        public string CancelRemarks
        {
            get { return CancelRemark; }
            set { CancelRemark = value; }
        }

 
        #endregion

        #region Helper Methods


        //public IMSManager giveuserinfo(int Uid)
        //{
        //    try
        //    {

        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@Uid", Uid);

        //        SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "sp_IMS_userinfo", param);

        //        if (dr.Read())
        //        {

        //            this.Uid = int.Parse(dr["pkUserid"].ToString());
        //            this.Uname = dr["UName"].ToString();
        //            this.Uemail = dr["Email"].ToString();
        //            this.Sysid = dr["SystemID"].ToString();
        //            this.Brhname = dr["BranchName"].ToString();
        //            this.Udept = dr["Department"].ToString();
        //            this.Urights = dr["Rrights"].ToString();
        //            this.Urightsid = int.Parse(dr["fkGID"].ToString());
        //            this.pkbrhid = int.Parse(dr["pkbrhID"].ToString());
        //            this.Pkcomid = int.Parse(dr["pkcomID"].ToString());
        //            this.Pkcityid = int.Parse(dr["brhCity"].ToString());
        //            this.BrhEmail = dr["brhEmail"].ToString();
        //            this.BrhAddress = dr["brhAddress"].ToString();
        //            this.BrhHEmail = dr["brhHEmail"].ToString();
        //            this.pkdeptid = int.Parse(dr["pkdeptID"].ToString());

        //        }

        //        return this;

        //    }
        //    finally
        //    {

        //        conn.Close();

        //    }
        //}
       


        public DataTable GetSystem()
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", PksysID);
            param[1] = new SqlParameter("@ID", 0);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", "SY");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public int GetBranchSystemID(int fkbrhid)
        {
            int sysid=0;
            int brhid;
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectBranches");

            if (ds.Tables[0] != null)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    brhid = int.Parse(row[1].ToString());
                    if (fkbrhid == brhid)
                    {
                        sysid = int.Parse(row[2].ToString());
                        return sysid;
                    }
                }
            }
            return sysid;
           
        }

        public int GetStores(int brhid)
        {
            int storid=0;

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", brhid);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", "SB");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                   storid = int.Parse(row[0].ToString());
                }

            return storid;
        }

        public int GetBranchBYStore(int storid)
        {
            int brhid=0;

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", storid);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", "SN");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                   brhid = int.Parse(row["fkbrhid"].ToString());
                }

            return brhid;
        }

        public int GetReqID(int brhid, string ReqTyp)
        {
            int ReqID = 0;


            string sql = "select dbo.GetReqIDForMIR(" + brhid.ToString() + ",'" + ReqTyp + "') as ReqNo";

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    ReqID = (Int32)cmd.ExecuteScalar();
                }

                return ReqID;
        }


        public DataTable GetReqItems(int reqid, string reqtyp)
        {
            string sql;

            if (reqtyp != "S")
            {
                sql = "SELECT pkReqID, fkbrhid, ItemCode as [Item Code], ItemTitle as [Item Name],Unit,dbo.GetCurrentBalance(fkbrhid,fkstoreID,fkitemid) as Balance,QttyRequired as [Qtty Request] ";
                sql = sql + "FROM [INVENTORY].[dbo].[tblRequisition_View] where pkreqid=" + reqid.ToString();
            }
            else
            {
                sql = "SELECT pkReqID, fkbrhid, ItemCode as [Item Code], ItemTitle as [Item Name],Unit,dbo.GetCurrentBalance(fkbrhid,fkstoreID,fkitemid) as Balance,QttyRequired as [Qtty Request] ";
                sql = sql + "FROM [INVENTORY].[dbo].[tblSylbRequisition_View] where pkreqid=" + reqid.ToString();

            }

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);
            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable(); 
        }


        public string  GetLastID(int brhid, int deptid, string DocTyp)
        {
            string DocID;


            string sql = "select dbo.GetLastDocID(" + brhid.ToString() + "," + deptid.ToString()  + ",'" + DocTyp + "') as DocNo";

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                DocID = cmd.ExecuteScalar().ToString();
            }

            return DocID;
        }

        public  DataTable GetRPTData(string brhid, string deptid, string ginno)
        {
            //const string connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=AdventureWorks;Integrated Security=True";

            string selectCommandText = "SELECT fkIssueByBranchID, fkIssueByStoreID, fkIssueByDeptID, IssuByBranch , IssuByStore  , IssuByDept  , IssuBy  , GINNumber    , GINCode    , IssuDate    , fkItemID    , InvCode,";
            selectCommandText = selectCommandText + "ItemTitle   , Qtty     , Unit      , Model      , Brand      , IssuedStatus     , ReceivedValidity     , ReturnValidity    , IssuToBranch      , IssuToStore     , IssuToDept    , IssuTo,";
            selectCommandText = selectCommandText + "VendorName      , Remarks  FROM  INVENTORY . dbo . View_GoodsIssueNote";
            selectCommandText = selectCommandText + " where fkissuebybranchid='" + brhid + "' and fkIssueByDeptID='" + deptid + "' and GINNumber='" + ginno + "'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommandText, conn);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable GetDOCItems(int docid, string doctyp)
        {
            string sql = string.Empty;

            if (doctyp == "GIN")
            {
                sql = "SELECT pkIssuID as pkDocID,fkIssueByBranchID,fkIssueByDeptID,GINNumber,gincode as DocCode,IssuDate,IssuedStatus as TrStatus,fkItemID,InvCode,dbo.Get_ItemName(fkItemID) as ItemTitle,Qtty,IsCancel,Remarks,CancelReason ";
                sql = sql + "FROM [INVENTORY].[dbo].[tblIssued] ";
                sql = sql + "where  fkIssueByBranchID=" + this.pkbrhid.ToString() + " and fkIssueByDeptID=" + pkdeptid.ToString() + " and GINNumber=" + docid.ToString() + " AND ISNULL(IsReceived,0)=0";
                sql = sql + " Order By ItemTitle";
            }
            else if (doctyp == "GRN")
            {
                sql = "SELECT pkRecvID as pkDocID,fkRecvByBranchID,fkRecvByDeptID,GRNNumber,GRNCode as DocCode,DCDate,ReceivedStatus as TrStatus,fkItemID,InvCode,dbo.Get_ItemName(fkItemID) as ItemTitle,Qtty,IsCancel,Remarks,CancelReason ";
                sql = sql + "FROM [INVENTORY].[dbo].[tblReceived] ";
                sql = sql + "where  fkRecvByBranchID=" + pkbrhid.ToString() + " and fkRecvByDeptID=" + pkdeptid.ToString() + "  and GRNNumber=" + docid.ToString();
                sql = sql + " Order By ItemTitle";
            }
            else if (doctyp == "MIR")
            {
                sql = "SELECT pkMirID as pkDocID,fkIssueByBranchID,fkIssueByDeptID,MIRNumber,MIRCode as DocCode,IssuDate,'P' as TrStatus,fkItemID,ItemCode as InvCode,dbo.Get_ItemName(fkItemID) as ItemTitle,Qtty,IsCancel,Remarks,CancelReason ";
                sql = sql + "FROM [INVENTORY].[dbo].[tblMIRequest] ";
                sql = sql + "where  fkIssueByBranchID=" + pkbrhid.ToString() + " and fkIssueByDeptID=" + pkdeptid.ToString() + "  and MIRNumber=" + docid.ToString();
                sql = sql + " Order By ItemTitle";
            }
           

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public int UpdateIssueItem(DataTable dt, int ginno)
        {           
            
            foreach (DataRow row in dt.Rows)
            {
                 pkbrhid = int.Parse(row["fkIssueByBranchID"].ToString());
                 pkdeptid = int.Parse(row["fkIssueByDeptID"].ToString());

                 int fkitemid = int.Parse(row["fkitemid"].ToString());
                 string invcode = row["INVCode"].ToString();
                 float qtty = int.Parse(row["Qtty"].ToString());

                 string Status = row["TrStatus"].ToString();

                 string cancelreason = string.Empty;
 
                    string checkcancel = row["IsCancel"].ToString();
                    if (checkcancel!="")
                    {
                        cancelreason = this.CancelRemark;
                    }
 

                    SqlParameter[] param = new SqlParameter[10];
                    param[0] = new SqlParameter("@GINNumber", ginno);
                    param[1] = new SqlParameter("@fkitemid", fkitemid);
                    param[2] = new SqlParameter("@InvCode", invcode);
                    param[3] = new SqlParameter("@fkbranchid", pkbrhid);
                    param[4] = new SqlParameter("@fkdeptid", pkdeptid);
                    param[5] = new SqlParameter("@Qtty", qtty);
                    param[6] = new SqlParameter("@Remarks", this.Remarks);
                    param[7] = new SqlParameter("@IsCancel", row["IsCancel"]);
                    param[8] = new SqlParameter("@CancelReason", cancelreason);
                    param[9] = new SqlParameter("@IssuedStatus", Status);

                    object obj = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_UpdateGIN", param);
 
            }
            return ginno;
        }
        //0333-2309613
        public int UpdateReceivedItem(DataTable dt, int grnno)
        {

            foreach (DataRow row in dt.Rows)
            {
                pkbrhid = int.Parse(row["fkRecvByBranchID"].ToString());
                pkdeptid = int.Parse(row["fkRecvByDeptID"].ToString());

                int fkitemid = int.Parse(row["fkitemid"].ToString());
                string invcode = row["INVCode"].ToString();
                float qtty = int.Parse(row["Qtty"].ToString());

                string Status = row["TrStatus"].ToString();

                string cancelreason = string.Empty;

                string checkcancel = row["IsCancel"].ToString();
                if (checkcancel != "")
                {
                    cancelreason = this.CancelRemark;
                }

                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@GRNNumber", grnno);
                param[1] = new SqlParameter("@fkitemid", fkitemid);
                param[2] = new SqlParameter("@InvCode", invcode);
                param[3] = new SqlParameter("@fkbranchid", pkbrhid);
                param[4] = new SqlParameter("@fkdeptid", pkdeptid);
                param[5] = new SqlParameter("@Qtty", qtty);
                param[6] = new SqlParameter("@Remarks", this.Remarks);
                param[7] = new SqlParameter("@IsCancel", row["IsCancel"]);
                param[8] = new SqlParameter("@CancelReason", cancelreason);
                param[9] = new SqlParameter("@ReceivedStatus", Status);

                object obj = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_UpdateGRN", param);

            }
            return grnno;

        }

        public string CancelDocument(string docref, string docno)
        {
            string documentid = docno.Substring(8, docno.Length-8);

            string sql = string.Empty;

            if (docref == "GIN" && this.CancelRemark!=null)
            {
                sql = "UPDATE [INVENTORY].[dbo].[tblIssued] ";
                sql = sql + " SET ModifiedDate=getdate(), QTTY=0, IsCancel=1, CancelReason='" + this.CancelRemark + "', Remarks='" + this.Remarks + "'";
                sql = sql + " where GINCODE='" + documentid + "'";

                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
            }

            if (docref == "GRN" && this.CancelRemark != null)
            {
                sql = "UPDATE [INVENTORY].[dbo].[tblReceived] ";
                sql = sql + " SET ModifiedDate=getdate(), QTTY=0, IsCancel=1, CancelReason='" + this.CancelRemark + "', Remarks='" + this.Remarks + "'";
                sql = sql + " where GRNCODE='" + documentid + "'";

                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
            }

            if (sql==string.Empty)
            {
                return "Please Mention Cancellation Reason Then Try Again!";
            }
            else
            {
                return " Is Successfully Cancelled!";
            }
            
        }

        public string RevertDocument(string docref, string docno)
        {

            string documentid = string.Empty;
            
            if (docno.Length != 0)
            {
                documentid = docno.Substring(8, docno.Length - 8);
            }
            else { return " No Document ID Found!"; }

            string sql = string.Empty;

            if (docref == "GIN" && this.CancelRemark != null)
            {
                sql = "UPDATE [INVENTORY].[dbo].[tblIssued] ";
                sql = sql + " SET ModifiedDate=getdate(), IsCancel=0, CancelReason='" + this.CancelRemark + "', Remarks='" + this.Remarks + "'";
                sql = sql + " where GINCODE='" + documentid + "'";

                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
            }

            if (docref == "GRN" && this.CancelRemark != null)
            {
                sql = "UPDATE [INVENTORY].[dbo].[tblReceived] ";
                sql = sql + " SET ModifiedDate=getdate(),   IsCancel=0, CancelReason='" + this.CancelRemark + "', Remarks='" + this.Remarks + "'";
                sql = sql + " where GRNCODE='" + documentid + "'";

                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
            }

            if (sql == string.Empty)
            {
                return "Please Mention Revert Reason Then Try Again!";
            }
            else
            {
                return " Is Successfully Revert!";
            }

        }


        public DataTable GetSportsItems()
        {
            string sql = string.Empty;

                sql = "SELECT pkInvID,fkItemID,InvCode,dbo.Get_ItemName(fkItemID) as ItemTitle,CRBalance,0 AS QTTY, Remarks ";
                sql = sql + "FROM [INVENTORY].[dbo].[tblInventory] ";
                sql = sql + "where isnull(CRBalance,0)<>0 and fkbrhid=" + this.pkbrhid.ToString() + " and fkItemID in (select pkitemid FROM [INVENTORY].[dbo].[tblItems] where fkCatID=9)";
                sql = sql + " Order By ItemTitle";
 
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }


        public DataTable GetStaffItems(int dept)
        {
            string sql = string.Empty;

            sql = "SELECT CreatedDate as IssueDate,DBO.Get_BranchName(fkIssueToBranchID) AS Branch,dbo.GetEmployeeName(fkIssuedToID) as Employee,GINCode,InvCode,dbo.Get_ItemName(fkItemID) as Item,Qtty";
            sql = sql + " FROM [INVENTORY].[dbo].[tblIssued] ";
            sql = sql + " where fkIssueByDeptID=" + dept.ToString();
            sql = sql + " Order By InvCode";

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }




        #endregion
    }
}
