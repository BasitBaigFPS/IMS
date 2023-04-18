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
    public class StoreManager
    {
        #region Class Constructor

        public StoreManager()
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

        public int pkstoreID { get; set; } 
		public int CreatedBy { get; set; }
		public int ModifiedBy { get; set; } 
		public int fkbrhID { get; set; }
		public string storeName { get; set; }
        public string Description { get; set; } 
        public string GLCode { get; set; }
        public string Token { get; set; }
        public int fkdeptID { get; set; } 

        public string pkSysID { get; set; }


        #endregion

        #region Helper Methods

        public int IUItem()
        {
            int result = 0;
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@pkStoreID", pkstoreID);
            param[1] = new SqlParameter("@CreatedBy", CreatedBy);
            param[2] = new SqlParameter("@ModifiedBy", ModifiedBy);
            param[3] = new SqlParameter("@fkbrhid", fkbrhID);
            param[4] = new SqlParameter("@StoreName", storeName);
            param[5] = new SqlParameter("@Description", Description);
            param[6] = new SqlParameter("@GLCode", GLCode);
            param[7] = new SqlParameter("@Token", Token);

            if (this.Token == "I")
            {
                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUStores", param);
                if (o != null)
                    result = int.Parse(o.ToString());
            }
            else
            {
                result = SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUStores", param);
                if (result == -1)
                    result = 1;
                else
                    result = 0;
            }

            return 0;

        }

        public DataSet GetBranches()
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", "");
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", "B");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public DataSet GetBranches(int brhid)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", brhid);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", "B");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public DataTable GetStores()
        {
            DataSet ds = new DataSet();

            if (@fkdeptID == 14 || @fkdeptID == 10 || @Token == "SB" || @Token == "SP" || @Token == "HO" || @Token == "IT" || @Token == "ITB")
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@sysid", 0);
                param[1] = new SqlParameter("@ID", @fkbrhID);
                param[2] = new SqlParameter("@ID1", 0);
                param[3] = new SqlParameter("@Token", @Token);

                ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

                if (ds.Tables[0] != null)
                    return ds.Tables[0];
                else
                    return new DataTable();
            }
            else
            {
                return new DataTable();

            }

        }

        public StoreManager GetStore()
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", pkstoreID);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", Token);

            SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (dr.Read())
            {
                pkstoreID = int.Parse(dr["pkStoreID"].ToString());
                fkbrhID = int.Parse(dr["fkbrhid"].ToString());
                storeName = dr["StoreName"] != null ? dr["StoreName"].ToString() : string.Empty;
                Description = dr["Description"] != null ? dr["Description"].ToString() : string.Empty;
                GLCode = dr["GLCode"] != null ? dr["GLCode"].ToString() : string.Empty;
            }

            dr.Close();
            dr = null;
            param = null;

            return this;
        }

        public DataTable GetDepartment(int uid)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserID", uid);


            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectDepartment", param);
            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();

        }

        public DataTable GetStoreBalance(int brhid, int storeid, int deptid)
        {

            string sql;

            sql = "SELECT [fksysid],[fkbrhID],[fkStoreID],[fkDeptID],[SystemName],[brhName],[StoreName],[deptName]";
            sql = sql + ",[pkSubCatID],[pkCatID],[pkItemHeadID],[CatTitle],[SubCatTitle],[ItemHeadTitle],[fkItemTypeID]";
            sql = sql + ",[ItemCode],[ItemTitle],[InvCode],[Model],[Brand],[OPBDate],[OPBalance],[CRBalance],[IsActive]";
            sql = sql + "FROM [INVENTORY].[dbo].[View_StoreInventoryBalance]";
            sql = sql + " where fkbrhid=" + brhid + " and fkstoreID=" + storeid + " and fkDeptID=" + deptid;



            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text,sql);
            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable(); 

        }

        public int UpdateInvBalance(int fkbrhid, int fkstoreid, int fkdeptid)
        {
            //int result = 0;
            
            //SqlParameter[] param = new SqlParameter[3];
            //param[0] = new SqlParameter("@fkbrhid", fkbrhid);
            //param[1] = new SqlParameter("@fkStoreID", fkstoreid);
            //param[2] = new SqlParameter("@fkDeptID", fkdeptid);


            //object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_UpdateInventoryBalances", param);
            //if (o != null)
            //    result = int.Parse(o.ToString());
            //    result = 1;

            //    return result;



            int result = 0;
            object o;

            if (fkdeptid == 14)
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@fkbrhid", fkbrhid);
                param[1] = new SqlParameter("@storeid", fkstoreid);
                param[2] = new SqlParameter("@deptid", fkdeptid);
                param[3] = new SqlParameter("@opdate", "2016-06-01");
                param[4] = new SqlParameter("@TokenAll", 1);

                o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_PostYearlyIMSBalances", param);
            }
            else
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@brhid", fkbrhid);
                param[1] = new SqlParameter("@deptid", fkdeptid);                
                param[2] = new SqlParameter("@opdate", "2016-06-01");
                param[3] = new SqlParameter("@TokenAll", 1);

                o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_PostYearlyIMSBalances_Assets", param);

            }

            if (o != null)
                result = int.Parse(o.ToString());
            result = 1;

            return result;





        }

        public DataTable GetBranchInfo(string GinNumber)
        {
            string sql;

            sql = "SELECT [fkIssueByBranchID],[fkIssueToBranchID],[fkIssueByStoreID],[fkIssueToStoreID],[fkIssueByDeptID],[fkIssueToDeptID]";
            sql = sql + ",[IssuedStatus],[GINCode],[GINNumber],[IsCancel]";
            sql = sql + " FROM [INVENTORY].[dbo].[View_ItemReturnGIN]";
            sql = sql + " where GINCODE='" + GinNumber + "'";
            //sql = sql + " where fkIssueToBranchID=19 and fkIssueToStoreID in (1,22) and GINNumber=" + int.Parse(GinNumber).ToString();

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);
            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable(); 

        }

        public DataTable GetBranchInfo(string Gincode, string IssutoStoreID)
        {
            string sql;

            sql = "SELECT [fkIssueByBranchID],[fkIssueToBranchID],[fkIssueByStoreID],[fkIssueToStoreID],[fkIssueByDeptID],[fkIssueToDeptID]";
            sql = sql + ",[IssuedStatus],[GINCode],[GINNumber],[IsCancel]";
            sql = sql + " FROM [INVENTORY].[dbo].[View_ItemReturnGIN]";
            sql = sql + " where GINCode='" + Gincode + "' and fkIssueToStoreID ='" + IssutoStoreID + "'";
          
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);
            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();

        }

        public DataTable GetBranchGIN(string Gincode, string IssutoBranchID)
        {
            string sql;

            sql = "SELECT [fkIssueByBranchID],[fkIssueToBranchID],[fkIssueByStoreID],[fkIssueToStoreID],[fkIssueByDeptID],[fkIssueToDeptID]";
            sql = sql + ",[IssuedStatus],[GINCode],[GINNumber],[IsCancel]";
            sql = sql + " FROM [INVENTORY].[dbo].[View_GoodsIssueNote]";
            sql = sql + " where GINCode='" + Gincode + "' and fkIssueToBranchID ='" + IssutoBranchID + "'";

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);
            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();

        }
 

        public int UpdateInvBalanceCustom(int fkbrhid, int fkstoreid, int fkdeptid, string fromdate, string todate)
        {
            int result = 0;
            object o;

            if (fkdeptid == 14)
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@fkbrhid", fkbrhid);
                param[1] = new SqlParameter("@storeid", fkstoreid);
                param[2] = new SqlParameter("@deptid", fkdeptid);
                param[3] = new SqlParameter("@opdate", fromdate);
                param[4] = new SqlParameter("@TokenAll", 1);

                o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_PostYearlyIMSBalances", param);
            }
            else
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@fkbrhid", fkbrhid);
                param[1] = new SqlParameter("@opdate", fromdate);
                param[2] = new SqlParameter("@TokenAll", 1);
                
                o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_PostYearlyIMSBalances_Assets", param);
                
            }
            if (o != null)
                result = int.Parse(o.ToString());
            result = 1;

            return result;
        }


        
        #endregion
    }
}
