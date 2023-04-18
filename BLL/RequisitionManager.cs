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
    public class RequisitionManager
    {


        #region Class Constructor

        public RequisitionManager()
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
        private int uid;
        private int _reqtypeid;
        private int _reqsubtypid;

        private string sysid;            
        private int pkbrhid;
        private int pkdeptid;
        private int pkstoreid;

        //Requisition Budget Parameters
        private int pkacdid;
        private int qurtID;
        private string reqMonths;
        private string reqTitle;

  
        //Requisition Main Parameters
        private int _fkReqBudgID;
        private int _studStrength;
        private int _perHeadCost;
        private Double _budgetAmount;


        private int _ReqNumber;
        private string _expDelivDate;

        private string _submissionDate;


        //Requisition Transaction Parameters
        private int fkItemID;
        private string Description;
        private Single InStockBalance;
        private string Unit;
        private Single QttyRequired;
        private Single Rate;
        private Double Amount;

        public int Posted { get; set; }

        public string Token { get; set; }

        public string HORateToken { get; set; }

        public string InvCode { get; set; }

         
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

        public int Pkacdid
        {
            get { return pkacdid; }
            set { pkacdid = value; }
        }

        public int QurtID
        {
            get { return qurtID; }
            set { qurtID = value; }
        }

        public string ReqMonths
        {
            get { return reqMonths; }
            set { reqMonths = value; }
        }

        public string ReqTitle
        {
            get { return reqTitle; }
            set { reqTitle = value; }
        }

        public int Pkstoreid
        {
            get { return pkstoreid; }
            set { pkstoreid = value; }
        }
       
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

        public int Reqtypeid
        {
            get
            {
                return _reqtypeid;
            }
            set
            {
                _reqtypeid = value;
            }

        }

        public int Reqsubtypid
        {
            get
            {
                return _reqsubtypid;
            }
            set
            {
                _reqsubtypid = value;
            }
        
        }

        public int FkReqBudgID
        {
            get { return _fkReqBudgID; }
            set { _fkReqBudgID = value; }
        }

        public int StudStrength
        {
            get { return _studStrength; }
            set { _studStrength = value; }
        }

        public int PerHeadCost
        {
            get { return _perHeadCost; }
            set { _perHeadCost = value; }
        }

        public Double BudgetAmount
        {
            get { return _budgetAmount; }
            set { _budgetAmount = value; }
        }

        public string ExpDelivDate
        {
            get { return _expDelivDate; }
            set { _expDelivDate = value; }
        }

        public string SubmissionDate
        {
            get { return _submissionDate; }
            set { _submissionDate = value; }
        }

        #endregion

        #region Helper Methods


        public int GetStudStrength(int brhid)
        {
            int totstud = 0;
            if (brhid != 25)
            {
                string sql = "select dbo.GetStudStrength(" + brhid.ToString() + ") as total";

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    totstud = (Int32)cmd.ExecuteScalar();
                }
            }
            return totstud;
        }

        public string GetRequisitionNo(int brhid)
        {
            //int reqno = 0;
            

            string sql = "Select pkReqID from tblRequisitionMain where fkbrhid=" + brhid.ToString() + " and isactive=1";
            //SqlParameter param = new SqlParameter();
            //param.ParameterName = "@ReqID";
            //param.Value = DBNull.Value;

            //string sql = "SELECT COALESCE(@ReqID + ',', '') + convert(varchar,pkReqID) from tblRequisitionMain where fkbrhid=" + brhid.ToString() + " and isactive=1";

            string reqids = "";

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            reqids = reqids + "," + dr["pkReqID"];
                        }

                        reqids = reqids.Substring(1);
                    }
                    dr.Close();
                }
                
               
                
                //param.SourceColumn = "pkReqID";
              
                //cmd.Parameters.Add(param);
                //reqno = (Int32)cmd.ExecuteScalar();
                //reqids = cmd.ExecuteScalar().ToString();
            }

            
            return reqids;
        }

         


        public string GetRequisitionNo(int brhid, int budgetid)
        {
            string sql = "Select pkReqID from tblRequisitionMain where fkbrhid=" + brhid.ToString() + " and fkReqBudgID=" + budgetid.ToString() + " and isactive=1";

            string reqids = "";

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            reqids = reqids + "," + dr["pkReqID"];
                        }

                        reqids = reqids.Substring(1);
                    }
                    dr.Close();
                }

            }


            return reqids;
        }

        public string GetReqSubDate(int brhid, int budgetid)
        {
            string sql = "Select SubmitDate from tblRequisitionMain where fkbrhid=" + brhid.ToString() + " and fkReqBudgID=" + budgetid.ToString() + " and isactive=1";

            string reqsubdate = "";

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            reqsubdate = dr["SubmitDate"].ToString();
                        }
                    }
                    dr.Close();
                }

            }
            return reqsubdate;
        }

        public DataTable GetSybReqType(string token)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@brhid", Pkbrhid);
            param[1] = new SqlParameter("@budgid", 0);
            param[2] = new SqlParameter("@Token", token);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectReqBudget", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetReqType(string token)
        {
            if (token=="IT")
            {
                Pkbrhid = 19;
            }


            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@brhid", Pkbrhid);
            param[1] = new SqlParameter("@budgid", 0);
            param[2] = new SqlParameter("@Token", token);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectReqBudget", param);

             if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetReqITType(string token, int fkbrhid)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@brhid", 19);
            param[1] = new SqlParameter("@budgid", 0);
            param[2] = new SqlParameter("@Token", token);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectReqBudget", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetReqITSubType()
        {
            string sql = "SELECT pkReqSubTypID,RequisitionSubType FROM  tblReqSubType  where fkreqtypid=8";

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetReqBudgetInfo(int budgetid)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@brhid", Pkbrhid);
            param[1] = new SqlParameter("@budgid", budgetid);
            param[2] = new SqlParameter("@Token", "RB");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectReqBudget", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetItemsByReqType(int ReqTypeID, int ReqSubTypeID)
        {
            DataSet ds;
            //if (ReqTypeID != 0)
            //{

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@fkbrhID", @Pkbrhid);
                param[1] = new SqlParameter("@fkdeptid", @Pkdeptid);            
                param[2] = new SqlParameter("@reqtypeid", @ReqTypeID);
                param[3] = new SqlParameter("@reqsubtypeid", @ReqSubTypeID);

                ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectReqItemList", param);
             //}

                //else 
                //{
                //    string sql;
                //    if (ReqSubTypeID == 5)
                //    {
                //        sql = "SELECT fkReqSubTypID,[fkItemHeadID],[ItemHeadTitle],[fkItemID],[ItemTitle],[Unit],[Rate],[IsActive] FROM [INVENTORY].[dbo].[View_RequisitionItemList]";
                //        sql = sql + " where fkReqSubTypID in (5,6,8) ORDER BY fkReqSubTypID, ItemHeadTitle";
                //    }
                //    else 
                //    {
                //        sql = "SELECT fkReqSubTypID,[fkItemHeadID],[ItemHeadTitle],[fkItemID],[ItemTitle],[Unit],[Rate],[IsActive] FROM [INVENTORY].[dbo].[View_RequisitionItemList]";
                //        sql = sql + " where fkReqSubTypID=7 ORDER BY fkReqSubTypID, ItemHeadTitle";
                //    }

                //    ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);            
                //}


                if (ds.Tables[0] != null)
                    return ds.Tables[0];
                else
                    return new DataTable();
            
        }

        public DataTable GetItemsByRateState(int ReqSubTypeID, string ratstatid)
        {
            DataSet ds;


                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ratstat", ratstatid);
                param[1] = new SqlParameter("@reqsubtypeid", ReqSubTypeID);

                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_SetRateState", param);

   
                string sql;

                if (this.HORateToken == "HO")
                {
                    if (ReqSubTypeID == 18)
                    {
                        sql = "SELECT fkReqSubTypID,[ReqGroup],[fkItemHeadID],[ItemHeadTitle],[fkItemID],[ItemTitle],[Unit],[Rate],[IsActive] FROM View_ITRequisitionItemList";
                        sql = sql + " ORDER BY ItemHeadTitle ASC";
                    }
                    else
                    {
                        sql = "SELECT fkReqSubTypID,[ReqGroup],[fkItemHeadID],[ItemHeadTitle],[fkItemID],[ItemTitle],[Unit],[Rate],[IsActive] FROM [INVENTORY].[dbo].[View_RequisitionItemListHO]";
                        sql = sql + " where fkReqSubTypID in (3,5,6,7,8)";
                        sql = sql + " ORDER BY  CASE WHEN SubTypeId = 8 THEN 1 WHEN SubTypeId = 5 THEN 2 WHEN SubTypeId = 7 THEN 3 ELSE 4 END ASC, ItemHeadTitle ASC";
                    }
                }
                else
                {
                 
                    if (ReqSubTypeID == 5)
                    {
                        sql = "SELECT fkReqSubTypID,[ReqGroup],[fkItemHeadID],[ItemHeadTitle],[fkItemID],[ItemTitle],[Unit],[Rate],[IsActive] FROM [INVENTORY].[dbo].[View_RequisitionItemList]";
                        sql = sql + " where fkItemID not in (111,1019,11148,11239,156,11149,158,157,1020,11147) and fkReqSubTypID in (5,6,8)";
                        sql = sql + " ORDER BY  CASE WHEN SubTypeId = 8 THEN 1 WHEN SubTypeId = 5 THEN 2 WHEN SubTypeId = 7 THEN 3 ELSE 4 END ASC, ItemHeadTitle ASC";
                    }
                    else
                    {
                        sql = "SELECT fkReqSubTypID,[ReqGroup],[fkItemHeadID],[ItemHeadTitle],[fkItemID],[ItemTitle],[Unit],[Rate],[IsActive] FROM [INVENTORY].[dbo].[View_RequisitionItemList]";
                        sql = sql + " where fkReqSubTypID=" + ReqSubTypeID.ToString() + " ";
                        sql = sql + " ORDER BY  CASE WHEN SubTypeId = 8 THEN 1 WHEN SubTypeId = 5 THEN 2 WHEN SubTypeId = 7 THEN 3 ELSE 4 END ASC, ItemHeadTitle ASC";
                    }
                }
                ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);
         


            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }


        public void ExtendReqDate(string ReqNo, string extdate, string Token)
        {
            string sql;

            if (Token == "ALL")
            {
                sql = "UPDATE [INVENTORY].[dbo].[tblRequisitionMain] ";
                sql = sql + " SET ModifiedDateTime=getdate(),ModifiedBy=" + Uid.ToString() + ", SubmitDate='" + extdate + "'";
                sql = sql + " where fkdeptID=" + Pkdeptid.ToString() + " AND ISACTIVE=1";
            }
            else
            {
                sql = "UPDATE [INVENTORY].[dbo].[tblRequisitionMain] ";
                sql = sql + " SET ModifiedDateTime=getdate(),ModifiedBy=" + Uid.ToString() + ", SubmitDate='" + extdate + "'";
                sql = sql + " where pkreqID=" + ReqNo.ToString() + " AND ISACTIVE=1";
            }


 
            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
        }

        public int IURequistion(DataTable dt, ref int reqno)
        {
            int result = 0;

            //fkbrhid = int.Parse(dt.Rows[0]["fkIssueToBranchID"].ToString());
            //fkstoreid = int.Parse(dt.Rows[0]["fkIssueToStoreID"].ToString());
            //fkdepartid = int.Parse(dt.Rows[0]["fkIssueToDeptID"].ToString());

            int totalrecd = dt.Rows.Count;
            this.Token = "I";
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                if (i == totalrecd)
                {
                    this.Token = "L";
                }

                //if (row["fkItemID"].ToString()=="111")
                //{
                //    string itq = row["QtyRequired"].ToString();
                //}
                
                SqlParameter[] param = new SqlParameter[21];

            	param[0] = new SqlParameter("@CreatedBy", Uid.ToString());
		        param[1] = new SqlParameter("@fkbrhID",row["brhid"].ToString());
	        	param[2] = new SqlParameter("@fkstoreID",row["storeid"].ToString());
                param[3] = new SqlParameter("@fkdeptID", 14);
                param[4] = new SqlParameter("@fkReqBudgID",FkReqBudgID.ToString());
	        	param[5] = new SqlParameter("@StudStrength",StudStrength.ToString());
	        	param[6] = new SqlParameter("@PerHeadCost",PerHeadCost.ToString());
	        	param[7] = new SqlParameter("@BudgetAmount",BudgetAmount.ToString());
	        	param[8] = new SqlParameter("@ExpDelivDate",ExpDelivDate.ToString());
                param[9] = new SqlParameter("@fkItemHeadID", row["fkItemHeadID"].ToString());              
	        	param[10] = new SqlParameter("@fkItemID",row["fkItemID"].ToString());
	        	param[11] = new SqlParameter("@Description",row["ItemTitle"].ToString());
	        	param[12] = new SqlParameter("@InStockBalance",row["Balance"].ToString());
	        	param[13] = new SqlParameter("@Unit",row["Unit"].ToString());
                param[14] = new SqlParameter("@PropQtty", row["ProposedQtty"].ToString());
	        	param[15] = new SqlParameter("@QttyRequired",row["QtyRequired"].ToString());
	        	param[16] = new SqlParameter("@Rate",row["Rate"].ToString());
	        	param[17] = new SqlParameter("@Amount",row["Amount"].ToString());
                param[18] = new SqlParameter("@Remarks", row["Remarks"].ToString());
                param[19] = new SqlParameter("@Token", this.Token);
                param[20] = new SqlParameter("@ReturReqID", SqlDbType.Int);
                param[20].Direction = ParameterDirection.Output;

                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IURequisition", param);
           
                result = (int)param[20].Value;

                reqno = result;

     
            }

            return result;
        }

        public int IUITRequistion(DataTable dt, ref int reqno)
        {
            int result = 0;

            //Remove Zero Required Quantity Rows to Clean Data Table and Get Only Required Quantity Rows
            var rows = dt.Select("QtyRequired=0");

            foreach (var row in rows)
                row.Delete();

            
 
            int totalrecd = dt.Rows.Count;
            this.Token = "I";
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                if (i == totalrecd)
                {
                    this.Token = "L";
                }

                SqlParameter[] param = new SqlParameter[21];

                param[0] = new SqlParameter("@CreatedBy", Uid.ToString());
                param[1] = new SqlParameter("@fkbrhID", row["brhid"].ToString());

                param[2] = new SqlParameter("@fkdeptID", row["deptid"].ToString());
                param[3] = new SqlParameter("@fkReqBudgID", FkReqBudgID.ToString());
                param[4] = new SqlParameter("@StudStrength", StudStrength.ToString());
                param[5] = new SqlParameter("@PerHeadCost", PerHeadCost.ToString());
                param[6] = new SqlParameter("@BudgetAmount", BudgetAmount.ToString());
                param[7] = new SqlParameter("@ExpDelivDate", ExpDelivDate.ToString());

                param[8] = new SqlParameter("@fkItemHeadID", row["fkItemHeadID"].ToString());
                param[9] = new SqlParameter("@fkItemID", row["fkItemID"].ToString());
                param[10] = new SqlParameter("@Description", row["ItemTitle"].ToString());
                param[11] = new SqlParameter("@InStockBalance", row["Balance"].ToString());
                param[12] = new SqlParameter("@Unit", row["Unit"].ToString());
                param[13] = new SqlParameter("@QttyRequired", row["QtyRequired"].ToString());
                param[14] = new SqlParameter("@Rate", row["Rate"].ToString());
                param[15] = new SqlParameter("@Amount", row["Amount"].ToString());

                param[16] = new SqlParameter("@fkReqLocID", row["LocToID"].ToString());
                param[17] = new SqlParameter("@fkempID", row["IsuToID"].ToString());

                param[18] =  new SqlParameter("@LocQttyInfo",row["Remarks"].ToString());

                param[19] = new SqlParameter("@Token", this.Token);
                param[20] = new SqlParameter("@ReturReqID", SqlDbType.Int);

                param[20].Direction = ParameterDirection.Output;

                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUITRequisition", param);

                result = (int)param[20].Value;

                reqno = result;

            }

            return result;
        }


        public DataTable GetReqSummary(int RequID)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@fkbrhID", Pkbrhid);
            param[1] = new SqlParameter("@fkReqID", RequID);


            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_GetITRequisitionSummary", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }


        public int IULABRequistion(DataTable dt, ref int reqno)
        {
            int result = 0;

            //fkbrhid = int.Parse(dt.Rows[0]["fkIssueToBranchID"].ToString());
            //fkstoreid = int.Parse(dt.Rows[0]["fkIssueToStoreID"].ToString());
            //fkdepartid = int.Parse(dt.Rows[0]["fkIssueToDeptID"].ToString());

            int totalrecd = dt.Rows.Count;
            this.Token = "I";
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                if (i == totalrecd)
                {
                    this.Token = "L";
                }

                SqlParameter[] param = new SqlParameter[18];

                param[0] = new SqlParameter("@CreatedBy", Uid.ToString());
                param[1] = new SqlParameter("@fkbrhID", row["brhid"].ToString());

                param[2] = new SqlParameter("@fkdeptID", "31");
                param[3] = new SqlParameter("@fkReqBudgID", FkReqBudgID.ToString());
                param[4] = new SqlParameter("@StudStrength", StudStrength.ToString());
                param[5] = new SqlParameter("@PerHeadCost", PerHeadCost.ToString());
                param[6] = new SqlParameter("@BudgetAmount", BudgetAmount.ToString());
                param[7] = new SqlParameter("@ExpDelivDate", ExpDelivDate.ToString());

                param[8] = new SqlParameter("@fkItemHeadID", row["fkItemHeadID"].ToString());
                param[9] = new SqlParameter("@fkItemID", row["fkItemID"].ToString());
                param[10] = new SqlParameter("@Description", row["ItemTitle"].ToString());
                param[11] = new SqlParameter("@InStockBalance", row["Balance"].ToString());
                param[12] = new SqlParameter("@Unit", row["Unit"].ToString());
                param[13] = new SqlParameter("@QttyRequired", row["QtyRequired"].ToString());
                param[14] = new SqlParameter("@Rate", row["Rate"].ToString());
                param[15] = new SqlParameter("@Amount", row["Amount"].ToString());
                param[16] = new SqlParameter("@Token", this.Token);
                param[17] = new SqlParameter("@ReturReqID", SqlDbType.Int);

                param[17].Direction = ParameterDirection.Output;

                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IULABRequisition", param);

                result = (int)param[17].Value;

                reqno = result;

            }

            return result;
        }

        public bool CheckBudget(DataTable dt, Double budgamt)
        {
            bool budok = true;

            Double amt = 0;

            foreach (DataRow row in dt.Rows)
            {
                amt = amt + Double.Parse(row["Amount"].ToString());            
            }

            if (amt > budgamt)
            {
               budok = false;
            }

            return budok;

        }

        public void IUItemRates(DataTable dt, string ratstatid)
        {
             
            foreach (DataRow row in dt.Rows)
            {
               
                SqlParameter[] param = new SqlParameter[4];

                param[0] = new SqlParameter("@CreatedBy", Uid.ToString());
                param[1] = new SqlParameter("@fkItemID", row["fkItemID"].ToString());
                param[2] = new SqlParameter("@Rate", row["Rate"].ToString());
                param[3] = new SqlParameter("@ratstat", ratstatid);

                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemRates", param);
            }
        }

        public void IUSybItemRates(DataTable dt, string ratstatid)
        {


            foreach (DataRow row in dt.Rows)
            {

                SqlParameter[] param = new SqlParameter[4];

                param[0] = new SqlParameter("@CreatedBy", Uid.ToString());
                param[1] = new SqlParameter("@fkItemID", row["fkItemID"].ToString());
                param[2] = new SqlParameter("@Rate", row["Rate"].ToString());
                param[3] = new SqlParameter("@ratstat", ratstatid);

                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUSybItemRates", param);
            }
        }

        public void ApplyRates()
        {
            object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IURatesApply");

        }

        public void ApplySybRates()
        {
            object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUSybRatesApply");

        }

        public void ApplyInventoryRates()
        {
            object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUInventoryRates");

        }

        public bool CheckITReqBudget()
        {
            bool ReqActive = false;
            int budgid = 0;

            string sql = "Select pkReqBudgID from tblRequBudget where fkbrhid=" + Pkbrhid.ToString() + " and fkdeptid=" + Pkdeptid.ToString() + " and fkacdid=" + Pkacdid.ToString() + " and isactive=1";

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                budgid = (Int32)cmd.ExecuteScalar();
            }

            if (budgid > 0)
            {
                ReqActive = true;
            }

            return ReqActive;
        }

        public void IUITReqBudget()
        {
            int result = 0;
 
            SqlParameter[] param = new SqlParameter[4];                     
            param[0] = new SqlParameter("@CreatedBy", Uid.ToString());
            param[1] = new SqlParameter("@fkdeptID", Pkdeptid.ToString());
            param[2] = new SqlParameter("@fkbrhID", Pkbrhid.ToString());

            param[3] = new SqlParameter("@submitdate", SubmissionDate.ToString());
            

            SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUReqBudgetIT", param);
        }


        public int IUReqBudget(DataTable dt, ref int reqno)
        {
            int result = 0;

            int totalrecd = dt.Rows.Count;
            this.Token = "F";
            //int i = 1;
            foreach (DataRow row in dt.Rows)
            {

                if (row["strength"].ToString() != "0" || row["phcost"].ToString() != "0")
                {

                    SqlParameter[] param = new SqlParameter[15];

                    param[0] = new SqlParameter("@pkReqBudgID", row["pkReqBudgID"].ToString());
                    param[1] = new SqlParameter("@CreatedBy", Uid.ToString());
                    param[2] = new SqlParameter("@ModifiedBy", Uid.ToString());
                    param[3] = new SqlParameter("@fkacdID", Pkacdid.ToString());
                    param[4] = new SqlParameter("@fkbrhID", row["pkbrhid"].ToString());
                    param[5] = new SqlParameter("@fkdeptID", Pkdeptid.ToString());
                    param[6] = new SqlParameter("@fkQuatID", QurtID.ToString());

                    param[7] = new SqlParameter("@fkReqTypID", @Reqtypeid);
                    param[8] = new SqlParameter("@fkReqSubTypID", @Reqsubtypid);
                    param[9] = new SqlParameter("@Strength", row["strength"].ToString());
                    param[10] = new SqlParameter("@QPHCost", row["phcost"].ToString());

                    param[11] = new SqlParameter("@ReqMonths", @ReqMonths);
                    param[12] = new SqlParameter("@ReqTitle", @ReqTitle);
                    param[13] = new SqlParameter("@EstBudgetAmt", row["budget"].ToString());
                    param[14] = new SqlParameter("@Token", @Token);

                    object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUReqBudget", param);

                    reqno = result;

                    this.Token = "I";
                }

            }

            return result;
        }


        public DataTable GetSybItemsByReqType(int ReqTypeID, int ReqSubTypeID, int sysid, int acdid, string grade)
        {
            DataSet ds;
 
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@reqtypeid", @ReqTypeID);
            param[1] = new SqlParameter("@reqsubtypeid", @ReqSubTypeID);
            param[2] = new SqlParameter("@sysid", sysid);
            param[3] = new SqlParameter("@acdid", acdid);
            param[4] = new SqlParameter("@grade", grade);


            ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectSybReqItemList", param);
           
            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();

        }


        public void ProduceNewYearStrength(int comid, int cityid)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@comid", comid);
            param[1] = new SqlParameter("@cityid", cityid);

            object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_GenerateSyllabusStrength", param);
        }

        public void IUSyllabusReq(DataTable dt, int comid, int cityid, string Grade)
        {
            

            int totalrecd = dt.Rows.Count;
 
            foreach (DataRow row in dt.Rows)
            {

                     SqlParameter[] param = new SqlParameter[16];

                

                         param[0] = new SqlParameter("@CreatedBy", Uid.ToString());
                         param[1] = new SqlParameter("@fkacdID", Pkacdid.ToString());
                         param[2] = new SqlParameter("@fkcomID", comid);
                         param[3] = new SqlParameter("@fkcityID", cityid);
                         param[4] = new SqlParameter("@grade", Grade);
                         param[5] = new SqlParameter("@fkReqTypID", @Reqtypeid);
                         param[6] = new SqlParameter("@fkReqSubTypID", @Reqsubtypid);
                         param[7] = new SqlParameter("@Strength", @StudStrength);
                         param[8] = new SqlParameter("@fkitemID", row["fkitemid"].ToString());
                         param[9] = new SqlParameter("@Unit", row["Unit"].ToString());
                         param[10] = new SqlParameter("@Rate", row["Rate"].ToString());
                         param[11] = new SqlParameter("@PCRatio", row["QtyRequired"].ToString());
                         param[12] = new SqlParameter("@remarks", "");
                         param[14] = new SqlParameter("@Posted", @Posted);                
                         param[15] = new SqlParameter("@Token", @Token);

                         object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUSyllabusReq", param);
                     

            }

           
        }

        public void GenerateSyllabusReq(int comid, int cityid)
        {

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@fkcomID", comid);
            param[1] = new SqlParameter("@fkcityID", cityid);
            param[2] = new SqlParameter("@fkacdid", this.Pkacdid);

            object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_GenerateSybDistribution", param);

        }
        
     
        public void ProcessFinalSyllabusReq(int comid, int cityid)
        {

                SqlParameter[] param = new SqlParameter[4];


                param[0] = new SqlParameter("@createdby", Uid.ToString());
                param[1] = new SqlParameter("@fkcomID", comid);
                param[2] = new SqlParameter("@fkcityID", cityid);
                param[3] = new SqlParameter("@fkacdid", this.Pkacdid);
          

                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUSybRequisition", param);

        }

        public int  IUSyllabusReq(DataTable dt, int uid)
        {
            string brhid="0";
            string acdid="0";
            string Grade="0";
            string total="0";
            int lastmir = 0;

            int totalrecd = dt.Rows.Count;
            this.Token = "I";
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                if (i == totalrecd)
                {
                    this.Token = "L";
                }

                total = row["ReqTotal"].ToString();

                if (int.Parse(total) != 0)
                {
                    brhid = row["fkbrhid"].ToString();
                    acdid = row["fkacdid"].ToString();
                    Grade = row["Grade"].ToString();


                    if (int.Parse(total) != 0 && i != totalrecd)
                    {
                        SqlParameter[] param = new SqlParameter[6];

                        param[0] = new SqlParameter("@createdby", Uid.ToString());
                        param[1] = new SqlParameter("@fkacdid", acdid);
                        param[2] = new SqlParameter("@fkbrhid", brhid);
                        param[3] = new SqlParameter("@Grade", Grade);
                        param[4] = new SqlParameter("@total", total);
                        param[5] = new SqlParameter("@Token", this.Token);

                        object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUSybRequisition_INDV", param);

                        this.Token = "P";
                    }
                }
                    if (i == totalrecd)
                    {
                        this.Token = "L";

                        SqlParameter[] param = new SqlParameter[6];

                        param[0] = new SqlParameter("@createdby", Uid.ToString());
                        param[1] = new SqlParameter("@fkacdid", acdid);
                        param[2] = new SqlParameter("@fkbrhid", brhid);
                        param[3] = new SqlParameter("@Grade", Grade);
                        param[4] = new SqlParameter("@total", total);
                        param[5] = new SqlParameter("@Token", this.Token);

                        object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUSybRequisition_INDV", param);
                    }

             
            }


            lastmir = GetLastMIR(brhid);

            return lastmir;
        }

        public int GetLastMIR(string brhid)
        {
            int LastMIR = 0;

               string sql = "select max(mirnumber) as LastMIR FROM tblMIRequest where fkIssueByBranchID="+brhid;

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sql);

                if (dr.Read())
                {
                    LastMIR = int.Parse(dr["LastMIR"].ToString());
                }

                dr.Close();
                dr = null;


                return LastMIR;
        }




        #endregion





    }
}
