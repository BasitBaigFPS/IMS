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
    public class ItemManager
    {
        #region Class Constructor

        public ItemManager()
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

        public int itemid { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int fkcatid { get; set; }
        public int fksubcatid { get; set; }
        public int fkitemheadid { get; set; }
        public int typeid { get; set; }
        public string itemtitle { get; set; }
        public string itemcode { get; set; }
        public string itemdesc { get; set; }
        public string GLCode { get; set; }
        public string unit { get; set; }
        public int isactive { get; set; }
        public string Token { get; set; }


        public int fkbrhid { get; set; }

        public int fkstoreid { get; set; }
        public int fkdepartid { get; set; }
        public int fklocid { get; set; }

        public int fkitemid { get; set; }
        public string itemmodel { get; set; }
        public string itembrand { get; set; }

        public float opbalance { get; set; }
        public float orderlimit { get; set; }


        public int CatID { get; set; }
        public int SubCatID { get; set; }




        public int fkIssueByBranchID { get; set; }
        public int fkIssueToBranchID { get; set; }
        public int fkIssueByStoreID { get; set; }
        public int fkIssueToStoreID { get; set; }
        public int fkIssueByDeptID { get; set; }
        public int fkIssueToDeptID { get; set; }
        public int fkIssueByID { get; set; }
        public int fkIssuedToID { get; set; }
        public string IssuedStatus { get; set; }
        public int GINNumber { get; set; }
        public int fkVendorID { get; set; }
        public string IssuDate { get; set; }
        public string InvCode { get; set; }
        public int Qtty { get; set; }
        public string Remarks { get; set; }
        public int IsCancel { get; set; }
        public string CancelReason { get; set; }
        public string ReceivedValidity { get; set; }
        public string ReturnValidity { get; set; }


        #endregion

        #region Helper Methods

        public int IUItem()
        {
            int result = 0;
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@itemid", itemid);
            param[1] = new SqlParameter("@CreatedBy", CreatedBy);
            param[2] = new SqlParameter("@ModifiedBy", ModifiedBy);
            param[3] = new SqlParameter("@fkcatid", fkcatid);
            param[4] = new SqlParameter("@fksubcatid", fksubcatid);
            param[5] = new SqlParameter("@fkitemheadid", fkitemheadid);
            param[6] = new SqlParameter("@typeid", typeid);
            param[7] = new SqlParameter("@itemtitle", itemtitle);
            param[8] = new SqlParameter("@itemdesc", itemdesc);
            param[9] = new SqlParameter("@unit", unit);
            param[10] = new SqlParameter("@GLCode", GLCode);
            //param[11] = new SqlParameter("@itemcode", itemcode);
            param[11] = new SqlParameter("@isactive", 1);
            param[12] = new SqlParameter("@Token", Token);

            if (this.Token == "I")
            {
                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItems", param);
                if (o != null)
                    result = int.Parse(o.ToString());
            }
            else
            {
                result = SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItems", param);
                if (result == -1)
                    result = 1;
                else
                    result = 0;
            }

            return 0;

        }

        public DataSet GetCategories()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", CatID);
            param[1] = new SqlParameter("@Token", "C");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public DataSet GetStores(int brhid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@brhid", brhid);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectStore", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }



        public DataSet GetEmployees(int brhid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@brhid", brhid);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectEmpolyee", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public DataSet GetBranches()
        {

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectBranches");

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }


        public DataSet GetSubCategories()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", CatID);
            param[1] = new SqlParameter("@Token", "C");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public DataTable GetItems()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", SubCatID);
            param[1] = new SqlParameter("@Token", "I");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public ItemManager GetItem()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", itemid);
            param[1] = new SqlParameter("@Token", Token);

            SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (dr.Read())
            {
                itemid = int.Parse(dr["pkitemID"].ToString());
                itemtitle = dr["itemTitle"] != null ? dr["itemTitle"].ToString() : string.Empty;
                itemcode = dr["ItemCode"] != null ? dr["ItemCode"].ToString() : string.Empty;
                itemdesc = dr["ItemDescription"] != null ? dr["ItemDescription"].ToString() : string.Empty;
                fkcatid = dr["fkCatID"] != null ? int.Parse(dr["fkCatID"].ToString()) : 0;
                fksubcatid = dr["fkSubCatID"] != null ? int.Parse(dr["fkSubCatID"].ToString()) : 0;
                GLCode = dr["GLCode"] != null ? dr["GLCode"].ToString() : string.Empty;
                unit = dr["Unit"] != null ? dr["Unit"].ToString() : string.Empty;
            }

            dr.Close();
            dr = null;
            param = null;

            return this;
        }

        public DataTable GetAllItems(string itemtype)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@itemtype", itemtype);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectItem", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable CheckItem(int brhid, int storeid, int itemid)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@fkbrhid", brhid);
            param[1] = new SqlParameter("@fkstoreid", storeid);
            param[2] = new SqlParameter("@fkitemid", itemid);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_CheckitemInventory", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }


        public DataTable getItembalance(int brhid, int storeid, string inventorycode)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@fkbrhid", brhid);
            param[1] = new SqlParameter("@fkstoreid", storeid);
            param[2] = new SqlParameter("@fkitemcode", inventorycode);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_getbalanceitem", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable CheckItemFixedAsset(int brhid, int fkdepartid, int itemid)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@fkbrhid", brhid);
            param[1] = new SqlParameter("@fkdepartid", fkdepartid);
            param[2] = new SqlParameter("@fkitemid", itemid);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_CheckitemInventoryFA", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataSet Getlocations(int brhid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@brhid", brhid);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_Selectlocation", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public DataSet GetDepartment()
        {
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectDepartment");
            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public int IUItemOpeningBalance()
        {
            int result = 0;
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@CreatedByModifiedby", this.CreatedBy);
            param[1] = new SqlParameter("@fkbrhID", this.fkbrhid);
            param[2] = new SqlParameter("@fkStoreID", this.fkstoreid);
            param[3] = new SqlParameter("@fkDeptID", this.fkdepartid);
            param[4] = new SqlParameter("@fkLocID", this.fklocid);
            param[5] = new SqlParameter("@fkItemID", this.fkitemid);
            param[6] = new SqlParameter("@Model", this.itemmodel);
            param[7] = new SqlParameter("@Brand", this.itembrand);
            param[8] = new SqlParameter("@OPBalance", this.opbalance);
            param[9] = new SqlParameter("@OrderLimit", this.orderlimit);
            param[10] = new SqlParameter("@Token", Token);

            if (this.Token == "I")
            {
                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemOpeningBalance", param);
                if (o != null)
                    result = int.Parse(o.ToString());
            }
            else
            {
                result = SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemOpeningBalance", param);
                if (result == -1)
                    result = 1;
                else
                    result = 0;
            }

            return 0;

        }

        public DataTable getstoreinventory(int stroreid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@storeid", stroreid);


            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectStoreInventory", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable getstoreinventory(int fkdeptid, int fkbrhid)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@fkdeptid", fkdeptid);
            param[1] = new SqlParameter("@fkbrhid", fkbrhid);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectStoreInventoryFA", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }




        public int IUIssseItem(DataTable dt)
        {
            int result = 0;

            fkbrhid = int.Parse(dt.Rows[0]["Issue Branch Id"].ToString());
            fkstoreid = int.Parse(dt.Rows[0]["Issue Store Id"].ToString());


            foreach (DataRow row in dt.Rows)
            {
                SqlParameter[] param = new SqlParameter[24];
                param[0] = new SqlParameter("@CreatedBy", this.CreatedBy);
                param[1] = new SqlParameter("@fkIssueByBranchID", row["Issue Branch Id"].ToString());
                param[2] = new SqlParameter("@fkIssueToBranchID", row["Issue to Branch Id"].ToString());
                param[3] = new SqlParameter("@fkIssueByStoreID", row["Issue Store Id"].ToString());
                param[4] = new SqlParameter("@fkIssueToStoreID", row["Issue to Store Id"].ToString());
                param[5] = new SqlParameter("@fkIssueToDeptID", row["Issue to Department Id"].ToString());
                param[6] = new SqlParameter("@fkIssueByID", row["Issue by Id"].ToString());
                param[7] = new SqlParameter("@fkIssuedToID", row["Issue to Id"].ToString());
                param[8] = new SqlParameter("@IssuedStatus", row["Item Type"].ToString());
                param[9] = new SqlParameter("@GINNumber", 0);
                param[10] = new SqlParameter("@fkVendorID", 0);
                param[11] = new SqlParameter("@IssuDate", "0");
                param[12] = new SqlParameter("@InvCode", row["Item Code"].ToString());
                param[13] = new SqlParameter("@Qtty", row["Qty Issued"].ToString());
                param[14] = new SqlParameter("@Remarks", "0");
                param[15] = new SqlParameter("@IsCancel", false);
                param[16] = new SqlParameter("@CancelReason", "");
                param[17] = new SqlParameter("@ReceivedValidity", row["Ackdate"].ToString());
                param[18] = new SqlParameter("@ReturnValidity", row["Retdate"].ToString());
                param[19] = new SqlParameter("@Token", "I");
                param[20] = new SqlParameter("@pkIssuID", 0);
                param[21] = new SqlParameter("@fkitemid", 0);
                param[22] = new SqlParameter("@ModifiedBy", this.CreatedBy);
                param[23] = new SqlParameter("@fkIssueByDeptID", this.fkdepartid);

                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemIssued", param);
                if (o != null)
                    result = int.Parse(o.ToString());

                if (result == -1)
                    result = 1;
                else
                    result = 0;


            }

            //Process Call to Generate the GIN Number
            ///sp_SetGetRPTSerial
            int serial;
            SqlParameter[] param1 = new SqlParameter[5];

            param1[0] = new SqlParameter("@fkbrhid", fkbrhid);
            param1[1] = new SqlParameter("@fkstoreid", fkstoreid);
            param1[2] = new SqlParameter("@fkdeptid", 14);
            param1[3] = new SqlParameter("@rptno", 3);
            param1[4] = new SqlParameter("@RetuSerial", SqlDbType.Int);

            param1[4].Direction = ParameterDirection.Output;

            object o1 = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_SetGetRPTSerial", param1);

            serial = (int)param1[4].Value;

            return serial;


        }

        public int IUReceivedItems(DataTable dt)
        {
            int result = 0;

            fkbrhid = int.Parse(dt.Rows[0]["Issue Branch Id"].ToString());
            fkstoreid = int.Parse(dt.Rows[0]["Issue Store Id"].ToString());

      
            foreach (DataRow row in dt.Rows)
            {
                SqlParameter[] param = new SqlParameter[24];
                param[0] = new SqlParameter("@CreatedBy", this.CreatedBy);
                param[1] = new SqlParameter("@fkIssueByBranchID", row["Issue Branch Id"].ToString());
                param[2] = new SqlParameter("@fkIssueToBranchID", row["Issue to Branch Id"].ToString());
                param[3] = new SqlParameter("@fkIssueByStoreID", row["Issue Store Id"].ToString());
                param[4] = new SqlParameter("@fkIssueToStoreID", row["Issue to Store Id"].ToString());
                param[5] = new SqlParameter("@fkIssueToDeptID", row["Issue to Department Id"].ToString());
                param[6] = new SqlParameter("@fkIssueByID", row["Issue by Id"].ToString());
                param[7] = new SqlParameter("@fkIssuedToID", row["Issue to Id"].ToString());
                param[8] = new SqlParameter("@IssuedStatus", row["Item Type"].ToString());
                param[9] = new SqlParameter("@GINNumber", 0);
                param[10] = new SqlParameter("@fkVendorID", 0);
                param[11] = new SqlParameter("@IssuDate", "0");
                param[12] = new SqlParameter("@InvCode", row["Item Code"].ToString());
                param[13] = new SqlParameter("@Qtty", row["Qty Issued"].ToString());
                param[14] = new SqlParameter("@Remarks", "0");
                param[15] = new SqlParameter("@IsCancel", false);
                param[16] = new SqlParameter("@CancelReason", "");
                param[17] = new SqlParameter("@ReceivedValidity", row["Ackdate"].ToString());
                param[18] = new SqlParameter("@ReturnValidity", row["Retdate"].ToString());
                param[19] = new SqlParameter("@Token", "I");
                param[20] = new SqlParameter("@pkIssuID", 0);
                param[21] = new SqlParameter("@fkitemid", 0);
                param[22] = new SqlParameter("@ModifiedBy", this.CreatedBy);
                param[23] = new SqlParameter("@fkIssueByDeptID", this.fkdepartid);

                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemIssued", param);
                if (o != null)
                    result = int.Parse(o.ToString());

                if (result == -1)
                    result = 1;
                else
                    result = 0;


            }

        }


        #endregion
    }
}