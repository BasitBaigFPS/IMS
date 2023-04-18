using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
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
		public string unit  { get; set; }
		public string isactive  { get; set; }
        public string isyearly { get; set; }
        public string Token { get; set; }

        public int pksysID { get; set; }
        public int pksysIDTo { get; set; }

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
        public int HeadID { get; set; }

        public int fkIssueByBranchID { get; set; }
        public int fkIssueToBranchID { get; set; }
		public int fkIssueByStoreID  { get; set; }
		public int fkIssueToStoreID  { get; set; }
		public int fkIssueByDeptID  { get; set; }
		public int fkIssueToDeptID  { get; set; }
		public int fkIssueByID { get; set; }
		public int fkIssuedToID { get; set; }
        public string IssuedStatus { get; set; }    // For Permanent / Temporary Issued
        public string IssuedType { get; set; }      // For Internal / External Issued 

        public string Itemstatustype { get; set; }    //To Change Item Status Type like Discontinue, Deactivate, Disposed

        public bool ReqItem { get; set; }
        public int ReqSubID { get; set; }

        public string RecvStatus { get; set; }

		public int GINNumber { get; set; }
        public int GRNNumber { get; set; }
        public int GPNumber { get; set; }
        public int REQNumber { get; set; }
		public int fkVendorID { get; set; }

        public string dcno { get; set; }
        public string dcdate { get; set; }
        public string invoice { get; set; }
        public string vehicle { get; set; }
        public string ponumber { get; set; }

        public int OLDGRN { get; set; }
        public int OLDGIN { get; set; }
        public int OLDMIR { get; set; }

		public string IssuDate { get; set; }
		public string InvCode { get; set; }
		public int Qtty { get; set; }
		public string Remarks { get; set; }
        public string IssuetoID { get; set; }
        public string RecvfromID { get; set; }
		public int IsCancel { get; set; }
		public string CancelReason { get; set; }
		public string ReceivedValidity { get; set; }
		public string ReturnValidity { get; set; }

        public string insp_empcode { get; set; }
        public int receivedByID { get; set; }

        public int IssueConfirm { get; set; }

        #endregion

        #region Helper Methods
  
        public int IUItem()
        {
            int result = 0;
            int status = 0;
            int yearlystatus = 0;

            if (this.isactive == "True")
            {
                status = 1;
            }
            else
            {
                status = 0;
            }
            if (this.isyearly == "True")
            {
                yearlystatus = 1;
            }
            else
            {
                yearlystatus = 0;
            }


            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@itemid", itemid);
            param[1] = new SqlParameter("@CreatedBy", this.receivedByID);
            param[2] = new SqlParameter("@ModifiedBy", ModifiedBy);
            param[3] = new SqlParameter("@fkcatid", fkcatid);
            param[4] = new SqlParameter("@fksubcatid", fksubcatid);
            param[5] = new SqlParameter("@fkitemheadid", fkitemheadid);
            param[6] = new SqlParameter("@typeid", typeid);
            param[7] = new SqlParameter("@itemtitle", itemtitle);
            param[8] = new SqlParameter("@itemdesc", itemdesc);
            param[9] = new SqlParameter("@reqsubid", ReqSubID);
            param[10] = new SqlParameter("@unit", unit);
            param[11] = new SqlParameter("@GLCode", GLCode);
            param[12] = new SqlParameter("@isyearly", yearlystatus);            
            param[13] = new SqlParameter("@isactive", status);
            param[14] = new SqlParameter("@Token", Token);

            if (this.Token == "I" || this.Token == "IR")
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

        public bool checkDuplicateItem(string ItemName, int Token)
        {
            bool status = false;
            string sql = string.Empty;

            if (Token == 1)  ///Match the Item with Like Operator To Show Similar Items
            {
                sql = "select top 1 ItemTitle  FROM tblItems where itemtitle like '%" + ItemName + "%'";
            }
            else
            {
                //If User Insist To save the Item, Then Match The Exact Item to Check the Difference is Duplicat overall then Reject Duplicate Creation
                sql = "select top 1 ItemTitle FROM tblItems where itemtitle='" + ItemName + "'";
            }

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    status = true;     //Item Already Exisit
                }
                dr.Close();

            }
            return status;
        }





        public List<string> GetMatchItems(string ItemName)
        {
            //Method to Show Pending Transactions 

            string sqlstr = "";

            if (ItemName.Length > 4)
            {
                  sqlstr = "select ItemTitle  FROM tblItems where itemtitle like '%" + ItemName.Substring(0, 5) + "%'";
            }
            else
            {
                  sqlstr = "select ItemTitle  FROM tblItems where itemtitle like '%" + ItemName.Substring(0, 3) + "%'";
            }
            
            SqlDataReader dr;
            List<string> listMatchItems = new List<string>();

            dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlstr);

            string listitem;
            while (dr.Read())
            {
                listitem = dr["ItemTitle"].ToString().TrimEnd();
                listMatchItems.Add(listitem);
            }

            dr.Close();

            return listMatchItems;

        }


        public int IUItemHead()
        {
            int result = 0;
            int status = 0;

            if (this.isactive == "True")
            {
                status = 1;
            }
            else
            {
                status = 0;
            }


            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@itemheadid", itemid);
            param[1] = new SqlParameter("@CreatedBy", this.receivedByID);
            param[2] = new SqlParameter("@ModifiedBy", ModifiedBy);
            param[3] = new SqlParameter("@fkcatid", fkcatid);
            param[4] = new SqlParameter("@fksubcatid", fksubcatid);
            param[5] = new SqlParameter("@headtitle", itemtitle);
            param[6] = new SqlParameter("@isactive", status);
            param[7] = new SqlParameter("@Token", Token);

            if (this.Token == "I")
            {
                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemHead", param);
                if (o != null)
                    result = int.Parse(o.ToString());
            }
            else
            {
                result = SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemHead", param);
                if (result == -1)
                    result = 1;
                else
                    result = 0;
            }

            return 0;

        }

        public DataSet GetCategories()
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", CatID);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", "C");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public int GetStore(int brhid)
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

        public int GetStore(int brhid, string Token)
        {
            int storid = 0;

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", brhid);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", Token);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    storid = int.Parse(row[0].ToString());
                }

            return storid;
        }

        public DataSet GetStores(int brhid)
        {
            string issu_type = @IssuedType;

            int usrDeptID = @fkdepartid;
            
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@brhid", brhid);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectStore",param);

            if (ds.Tables[0] != null)
            {

                    for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];

                        if (ds.Tables[0].Rows.Count==1)
                        {
                            break;
                        }

                        if (@Token == "TO")
                        {
                            if (dr["fkbrhid"].ToString() == "25" && dr["pkstoreid"].ToString() == @fkIssueByStoreID.ToString() && @Token == "TO")
                            {
                                dr.Delete();
                                ds.AcceptChanges();
                                //goto Outer;
                            }
                        }
                        else
                        {
                            if (dr["fkbrhid"].ToString() == "25" && dr["pkstoreid"].ToString() == "1" && usrDeptID.ToString() != "14")
                            {
                                dr.Delete();
                                ds.AcceptChanges();
                                goto Outer;
                            }
                            
                            if (dr["fkbrhid"].ToString() == "19" && dr["pkstoreid"].ToString() == "2" && usrDeptID.ToString() == "14")
                            {
                                dr.Delete();
                                ds.AcceptChanges();
                                goto Outer;
                            }
                            if (dr["fkbrhid"].ToString() == "19" && dr["pkstoreid"].ToString() == "2" && usrDeptID.ToString() == "10")
                            {
                                dr.Delete();
                                ds.AcceptChanges();
                                goto Outer;
                            }
                            if (dr["fkbrhid"].ToString() == "19" && dr["pkstoreid"].ToString() == "22" && usrDeptID.ToString() != "10")
                            {
                                dr.Delete();
                                ds.AcceptChanges();
                                goto Outer;
                            }

                        Outer:
                            continue;
                        }
                    }
                //ds.AcceptChanges();
                return ds;
            }
            else
                return new DataSet();
        }

        public DataSet GetEmployees(int brhid, int deptid, string Token)
        {
            int iusrID = @fkIssueByID;

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@brhid", brhid);
            param[1] = new SqlParameter("@dptid", deptid);
            param[2] = new SqlParameter("@Token", Token);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectEmpolyee", param);

            if (ds.Tables[0] != null)
            {
                if (iusrID != 0)
                {
                    for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
                    {

                        DataRow dr = ds.Tables[0].Rows[i];
                        if (dr["pkempID"].ToString() != iusrID.ToString())
                            dr.Delete();
                    }
                    ds.AcceptChanges();
                }

                return ds;

            }
            else
                return new DataSet();
        }

        public DataSet GetEmpStore(int storid, int deptid, string Token)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@brhid", storid);
            param[1] = new SqlParameter("@dptid", deptid);
            param[2] = new SqlParameter("@Token", Token);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectEmpolyee", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public DataSet GetEmployees(int brhid)
        {
            string Token = "I";

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@brhid", brhid);
            param[1] = new SqlParameter("@dptid", int.Parse("0"));
            param[2] = new SqlParameter("@Token", Token);

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

        public DataSet GetSysBranches(int sysid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@sysid", sysid);
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectSysBranches",param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public DataSet GetSubCategories()
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", CatID);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", "C");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public DataSet GetItemHeads()
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", this.SubCatID);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", "H");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public DataTable GetItems()
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", SubCatID);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", "I");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetItems(int id, string token)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", id);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", token);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetItems(int id, int id1, string token)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", id);
            param[2] = new SqlParameter("@ID1", id1);
            param[3] = new SqlParameter("@Token", token);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetItems(int sysid, int id, int id1, string token)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", sysid);
            param[1] = new SqlParameter("@ID", id);
            param[2] = new SqlParameter("@ID1", id1);
            param[3] = new SqlParameter("@Token", token);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public ItemManager GetItem()
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", itemid);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", Token);

            SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (dr.Read())
            {
                this.itemid = int.Parse(dr["pkitemID"].ToString());
                this.itemtitle = dr["itemTitle"]!=null?dr["itemTitle"].ToString():string.Empty;
                this.itemcode =  dr["ItemCode"]!=null?dr["ItemCode"].ToString():string.Empty;
                this.itemdesc = dr["ItemDescription"] != null?dr["ItemDescription"].ToString():string.Empty;
                this.fkcatid = dr["fkCatID"] != null ? int.Parse(dr["fkCatID"].ToString()) : 0;
                this.fksubcatid = dr["fkSubCatID"] != null ? int.Parse(dr["fkSubCatID"].ToString()) : 0;
                this.fkitemheadid = dr["fkItemHeadID"] != null ? int.Parse(dr["fkItemHeadID"].ToString()) : 0;
                this.GLCode = dr["GLCode"] != null ? dr["GLCode"].ToString() : string.Empty;
                this.unit =  dr["Unit"] != null ?  dr["Unit"].ToString():string.Empty;
                this.isactive = dr["IsActive"].ToString();
            }

            dr.Close();
            dr = null;
            param = null;

            return this;
        }

        public DataTable GetAllItems(string itemtype, int headid)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@itemtype", itemtype);
            param[1] = new SqlParameter("@itemheadid", headid);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectItem",param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetAllItems(int headid)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@itemtype", "");
            param[1] = new SqlParameter("@itemheadid", headid);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectItem", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetAllItems()
        {
            SqlParameter[] param = new SqlParameter[2];


            param[0] = new SqlParameter("@pkItemID", "");
            param[1] = new SqlParameter("@fkdeptid", this.fkdepartid);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectItems", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable CheckItem(int sysid, int brhid, int storeid, int itemid)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", sysid);
            param[1] = new SqlParameter("@fkbrhid", brhid);
            param[2] = new SqlParameter("@fkstoreid", storeid);
            param[3] = new SqlParameter("@fkitemid", itemid);   


            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_CheckitemInventory", param);
    

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable CheckItem(int brhid, int deptid, int itemid)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@fkbrhid", brhid);
            param[1] = new SqlParameter("@fkdepartid", deptid);
            param[2] = new SqlParameter("@fkitemid", itemid);   


            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_CheckitemInventoryFA", param);
 
            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public int GetItemCategory(int itemid)
        { 
           SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", itemid);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", "II");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            int catid=0;
            if (ds.Tables[0] != null)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    catid = int.Parse(row[0].ToString());
                }
            }
            return catid;            
        }

        public DataTable getItembalance(int brhid, int storeid, string inventorycode, string Token)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@fkbrhid", brhid);
            param[1] = new SqlParameter("@fkstoreid", storeid);
            param[2] = new SqlParameter("@fkitemcode", inventorycode);
            param[3] = new SqlParameter("@Token", Token);

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
            param[0] = new SqlParameter("@brhid",brhid);
            
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_Selectlocation", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }
        
        public DataSet GetDepartment(int uid)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserID", uid);


            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectDepartment", param);
            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public int IUItemOpeningBalance()
        {
            int result = 0;
            SqlParameter[] param = new SqlParameter[12];
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
            param[11] = new SqlParameter("@sysid", this.pksysID);

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

        public int IUItemOpeningBalance_FA()
        {
            int result = 0;
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@CreatedByModifiedby", this.CreatedBy);
            param[1] = new SqlParameter("@fkbrhID", this.fkbrhid);
            param[2] = new SqlParameter("@fkStoreID", this.fkstoreid);
            param[3] = new SqlParameter("@fkDeptID", this.fkdepartid);
            param[4] = new SqlParameter("@fkLocID", this.fklocid);
            param[5] = new SqlParameter("@fkItemID", this.fkitemid);
            param[6] = new SqlParameter("@fkempID", int.Parse("0"));
            param[7] = new SqlParameter("@Model", this.itemmodel);
            param[8] = new SqlParameter("@Brand", this.itembrand);
            param[9] = new SqlParameter("@OPBalance", this.opbalance);
            param[10] = new SqlParameter("@OrderLimit", this.orderlimit);
            param[11] = new SqlParameter("@Token", Token);

            param[12] = new SqlParameter("@fkbrhID1", this.fkIssueByBranchID);
            param[13] = new SqlParameter("@fkDeptID1", this.fkIssueByDeptID);


            if (this.Token == "I")
            {
                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemOpeningBalance_FA", param);
                if (o != null)
                    result = int.Parse(o.ToString());
            }
            else
            {
                result = SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemOpeningBalance_FA", param);
                if (result == -1)
                    result = 1;
                else
                    result = 0;
            }

            return 0;

        }

        public int IUItemOpeningBalance(DataTable dt)
        {
            int result = 0;

            foreach (DataRow row in dt.Rows)
            {
                fkitemid = int.Parse(row[0].ToString());
                opbalance = float.Parse(row[4].ToString() == "" ? "0" : row[4].ToString());
                orderlimit = float.Parse(row[5].ToString() == "" ? "0" : row[5].ToString());
                itemmodel = row[6].ToString();
                itembrand = row[7].ToString();
                Token = "I";

                if (opbalance != 0)
                {
                    SqlParameter[] param = new SqlParameter[12];
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
                    param[11] = new SqlParameter("@sysid", this.pksysID);

                    if (this.Token == "I")
                    {
                        object o;
               
                            o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemOpeningBalance", param);
                            if (o != null)
                                result = int.Parse(o.ToString());
                    }
                }
            }
            return 0;

        }

        public int IUItemOpeningBalance_FA(DataTable dt)
        {
            int result = 0;


            foreach (DataRow row in dt.Rows)
            {
                fkitemid = int.Parse(row[0].ToString());
                opbalance = float.Parse(row[4].ToString() == "" ? "0" : row[4].ToString());
                orderlimit = float.Parse(row[5].ToString() == "" ? "0" : row[5].ToString());

                if (this.fkdepartid == 31)
                {
                    this.fkIssuedToID = this.CreatedBy;
                }

                itemmodel = row[6].ToString();
                itembrand = row[7].ToString();
                Token = "I";
      

                if (opbalance != 0)
                {
                    SqlParameter[] param = new SqlParameter[14];
                    param[0] = new SqlParameter("@CreatedByModifiedby", this.CreatedBy);
                    param[1] = new SqlParameter("@fkbrhID", this.fkbrhid);
                    param[2] = new SqlParameter("@fkStoreID", this.fkstoreid);
                    param[3] = new SqlParameter("@fkDeptID", this.fkdepartid);
                    param[4] = new SqlParameter("@fkLocID", this.fklocid);
                    param[5] = new SqlParameter("@fkItemID", this.fkitemid);
                    param[6] = new SqlParameter("@fkempID", row[8].ToString() == "" ? this.fkIssuedToID : int.Parse(row[8].ToString()));
                    param[7] = new SqlParameter("@Model", this.itemmodel);
                    param[8] = new SqlParameter("@Brand", this.itembrand);
                    param[9] = new SqlParameter("@OPBalance", this.opbalance);
                    param[10] = new SqlParameter("@OrderLimit", this.orderlimit);
                    param[11] = new SqlParameter("@Token", Token);
                    param[12] = new SqlParameter("@fkbrhID1", this.fkIssueByBranchID);
                    param[13] = new SqlParameter("@fkDeptID1", this.fkIssueByDeptID);

                    if (this.Token == "I")
                    {
                        object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemOpeningBalance_FA", param);
                        if (o != null)
                            result = int.Parse(o.ToString());
                    }
                }
            }
            return 0;

        }

        public DataTable GetInventoryList(int brhid, int storeid, int deptid)
        {
            string sql;

            sql = "SELECT  [fkbrhID],[fkDeptID],[fkStoreID],[InventoryCode],[ItemCode],[fkItemID],[ItemName],[CurrentBalance],[Qtty],[NewBal],[IsuToID],[empName],[Remarks]";
            sql = sql + " FROM [INVENTORY].[dbo].[tblBranchInventoryList]";
            sql = sql + " where fkbrhid= " + brhid.ToString() + " AND fkStoreID=" + storeid.ToString() + " AND fkDeptID=" + deptid.ToString();
            sql = sql + " Order By ItemName";

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();

        }

        public DataTable GetStoreInventory(int storeid, int deptid)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@SYSID", this.pksysID);
            param[1] = new SqlParameter("@storeid", storeid);
            param[2] = new SqlParameter("@catid", int.Parse("0"));
            param[3] = new SqlParameter("@deptid", deptid);

            
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectStoreInventory", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetFullStoreInventory(int storeid, int deptid)
        {
            DataSet ds;

            if (deptid == 14)
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@storeid", storeid);
                param[1] = new SqlParameter("@deptid", deptid);

                ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectStoreInventoryAll", param);
            }
            else if (storeid == 22 && deptid == 10)
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@storeid", storeid);
                param[1] = new SqlParameter("@deptid", deptid);

                ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectStoreInventoryAll", param);
            }
            else
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@fkbrhid", storeid);
                param[1] = new SqlParameter("@deptid", deptid);
                param[2] = new SqlParameter("@Headid", "0");

                ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectStoreInventoryFA", param);

            }
            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetStoreInventory(int sysid, int storeid, int deptid)
        {
            this.pksysID = sysid;
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", this.pksysID);
            param[1] = new SqlParameter("@storeid", storeid);
            param[2] = new SqlParameter("@catid", @fkitemheadid);
            param[3] = new SqlParameter("@deptid", deptid);
          
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectStoreInventory", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetStoreByDepartment(int sysid, int storeid, int deptid, int headid)
        {
            this.pksysID = sysid;
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", this.pksysID);
            param[1] = new SqlParameter("@storeid", storeid);
            param[2] = new SqlParameter("@catid", headid);
            param[3] = new SqlParameter("@deptid", deptid);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectStoreInventory", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetStoreInventory(int storeid, int catid, int subcatid, int headid)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@sysid", this.pksysID);
            param[1] = new SqlParameter("@storeid", storeid);
            param[2] = new SqlParameter("@catid", catid);
            param[3] = new SqlParameter("@subcatid", subcatid);
            param[4] = new SqlParameter("@headid", headid);


            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_StoreInventory", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetDeptInventory(int deptid, int fkbrhid, int headid)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@fkbrhid", fkbrhid);
            param[1] = new SqlParameter("@deptid", deptid);
            param[2] = new SqlParameter("@Headid", headid);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_DepartmentInventory", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetItemsByGIN(string status, int GinNo)
        {

            //this.fkIssueByStoreID = 26;
            //this.fkIssueByDeptID = 2;
            //this.fkIssueToStoreID = 22;
                         
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@IssuByfkbrhID", @fkIssueByBranchID);
            param[1] = new SqlParameter("@IssuByfkstoreID", @fkIssueByStoreID);
            param[2] = new SqlParameter("@IssuByfkdeptID", @fkIssueByDeptID);
            param[3] = new SqlParameter("@IssuTofkbrhID", @fkIssueToBranchID);
            param[4] = new SqlParameter("@IssuTofkstoreID", @fkIssueToStoreID);
            param[5] = new SqlParameter("@IssuTofkdeptID", @fkIssueToDeptID);
            param[6] = new SqlParameter("@Ginno", GinNo);
            param[7] = new SqlParameter("@IsuStatus", status);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectGINData", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public DataTable GetItemsByMIR(int MirNo)
        {
             
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@IssuByfkbrhID", @fkIssueByBranchID);
            param[1] = new SqlParameter("@IssuByfkstoreID", @fkIssueByStoreID);
            param[2] = new SqlParameter("@IssuByfkdeptID", @fkIssueByDeptID);
            param[3] = new SqlParameter("@IssuTofkbrhID", @fkIssueToBranchID);
            param[4] = new SqlParameter("@IssuTofkstoreID", @fkIssueToStoreID);
            param[5] = new SqlParameter("@IssuTofkdeptID", @fkIssueToDeptID);
            param[6] = new SqlParameter("@Sysid", @pksysID);
            param[7] = new SqlParameter("@Mirno", MirNo);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectMIRData", param);

            if (ds.Tables[0] != null)
            {
                
                ds.Tables[0].DefaultView.Sort = "ItemTitle";
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }


        public DataTable GetBranchMIR()
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@IssuTofkbrhID", @fkIssueToBranchID);
            param[1] = new SqlParameter("@IssuTofkstoreID", @fkIssueToStoreID);
            param[2] = new SqlParameter("@IssuTofkdeptID", @fkIssueToDeptID);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectNewMIRData", param);

            if (ds.Tables[0] != null)
            {
                
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();

            }
            
        }


        public bool checkGINConfirmStatus(int oldGIN, int storeid)
        {
            bool status;
            string sql = "select top 1 fkIssueByStoreID,GINNumber,IssuedConfirm FROM tblIssued where GINNumber=" + oldGIN.ToString() + " and fkIssueByStoreID=" + storeid.ToString() + " and IssuedConfirm=1";

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        status = true;     //OLD GIN Already COnfirmed, No more Additional Entries
                    }
                    else
                    {
                        status = false;   //OLD GIN Not COnfirmed, Allowed Additional Entries

                    }
                    dr.Close();

                }
          

            return status;

        }


        public bool checkGINSaved(int stor, string item, float qty)
        {
            bool status;
            string sql = "select top 1 fkIssueByStoreID,Qtty,invcode FROM tblIssued where fkIssueByStoreID=" + stor.ToString() + " and ";
            sql = sql + " Invcode='" + item + "' and Qtty=" + qty.ToString() + " and convert(varchar,convert(date,CreatedDate,102),103)='" + DateTime.Now.ToShortDateString() + "'";

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    status = true;     //GIN Saved....Generate New Number
                }
                else
                {
                    status = false;   //GIN Not Saved...Stop and Inform User....

                }
                dr.Close();
            }
            

            return status;

        }


        public int IUIssueItem(DataTable dt, ref int ginno, ref int gpno)
        {
            bool IsGinSaved;

             

                int result = 0;

                //fkbrhid = int.Parse(dt.Rows[0]["Issue Branch Id"].ToString());
                //fkstoreid = int.Parse(dt.Rows[0]["Issue Store Id"].ToString());
                //fkdepartid = this.fkdepartid;

                string invcode = dt.Rows[0]["Item Code"].ToString();
                float qtty = int.Parse(dt.Rows[0]["Qty Issued"].ToString());

                if (fkIssueByDeptID != 14)
                {
                    this.fkIssueToStoreID = 0;
                }
 

                foreach (DataRow row in dt.Rows)
                {
                 
                    
                    qtty = float.Parse(row["Qty Issued"].ToString());
                    IssuedStatus = row["Item Status"].ToString();
                    fkIssueToStoreID = int.Parse(row["Issue to Store Id"].ToString());

                    if (qtty > 0)
                    {

                        SqlParameter[] param = new SqlParameter[29];
                        param[0] = new SqlParameter("@CreatedBy", this.CreatedBy);
                        param[1] = new SqlParameter("@fkIssueByBranchID", this.fkIssueByBranchID);
                        param[2] = new SqlParameter("@fkIssueToBranchID", row["Issue to Branch Id"].ToString());
                        param[3] = new SqlParameter("@fkIssueByStoreID", this.fkIssueByStoreID);
                        param[4] = new SqlParameter("@fkIssueToStoreID", this.fkIssueToStoreID);
                        param[5] = new SqlParameter("@fkIssueToDeptID", fkdepartid.ToString());
                        param[6] = new SqlParameter("@fkIssueByID", row["Issue by Id"].ToString());
                        param[7] = new SqlParameter("@fkIssuedToID", row["Issue to Id"].ToString());
                        param[8] = new SqlParameter("@IssuedStatus", row["Item Status"].ToString());
                        param[24] = new SqlParameter("@IssuedType", row["Item Type"].ToString());
                        param[9] = new SqlParameter("@GINNumber", 0);
                        param[10] = new SqlParameter("@fkVendorID", 0);
                        param[11] = new SqlParameter("@IssuDate", "0");
                        param[12] = new SqlParameter("@InvCode", row["Item Code"].ToString());
                        param[13] = new SqlParameter("@Qtty", qtty);
                        param[14] = new SqlParameter("@Remarks", this.Remarks);
                        param[15] = new SqlParameter("@IsCancel", false);
                        param[16] = new SqlParameter("@CancelReason", "");
                        param[17] = new SqlParameter("@ReceivedValidity", row["Ackdate"].ToString());
                        param[18] = new SqlParameter("@ReturnValidity", row["Retdate"].ToString());
                        param[19] = new SqlParameter("@Token", @Token);
                        param[20] = new SqlParameter("@pkIssuID", 0);
                        param[21] = new SqlParameter("@fkitemid", 0);
                        param[22] = new SqlParameter("@ModifiedBy", @Token == "I" ? 0 : this.CreatedBy);
                        param[23] = new SqlParameter("@fkIssueByDeptID", this.fkIssueByDeptID);
                        param[25] = new SqlParameter("@oldGIN", @OLDGIN);
                        param[26] = new SqlParameter("@IsConfirm", @IssueConfirm);
                        param[27] = new SqlParameter("@MIRNumber", DBNull.Value);
                        param[28] = new SqlParameter("@IssuedToID", @fkIssuedToID);


                        object obj = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemIssued", param);

                        result = obj != null ? (int)obj : 0;

                        //   result = (Int32)SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemIssued", param);

                        if (result > 0)
                            result = 1;
                        else
                            result = 0;
                    }

                }

                IsGinSaved = checkGINSaved(this.fkIssueByStoreID, invcode, qtty);
            
       

           int serial=0;

           //if (IsGinSaved == true)  // Checking if GIN Record Properly Saved...
           //{

               //Process Call to Generate the GIN Number
               ///sp_SetGetRPTSerial

               if (@OLDGIN == 0)
               {

                   serial = RptSerial(fkIssueByBranchID, fkIssueByStoreID, this.fkIssueByDeptID, 3, IssuedStatus);
                   ginno = serial;

                   GPNumber = RptSerial(fkIssueByBranchID, fkIssueByStoreID, this.fkIssueByDeptID, 5, IssuedStatus);
                   gpno = GPNumber;

                   return serial;
               }
               else
               {
                   serial = @OLDGIN;
               }
           //}

            return serial;
        }

        public int MaterialReturn(DataTable dt, ref int ginno, ref int gpno)
        {
            bool IsGinSaved;



            int result = 0;

            fkbrhid = int.Parse(dt.Rows[0]["Issue Branch Id"].ToString());
            fkstoreid = int.Parse(dt.Rows[0]["Issue Store Id"].ToString());
           // fkdepartid = int.Parse(dt.Rows[0]["Issue To Department ID"].ToString());

            string invcode = dt.Rows[0]["Item Code"].ToString();
            int qtty = int.Parse(dt.Rows[0]["Qty Issued"].ToString());

            //IsGinSaved = checkGINSaved(fkstoreid, invcode, qtty);
            //if (IsGinSaved==true )
            //{
            //   return 0;
            //}
            if (fkdepartid != 14 && fkbrhid != 25)
            {
                fkstoreid = 0;
            }

            //row["Issue Store Id"].ToString()

            foreach (DataRow row in dt.Rows)
            {
                qtty = int.Parse(row["Qty Issued"].ToString());
                IssuedStatus = row["Item Status"].ToString();
                SqlParameter[] param = new SqlParameter[29];
                param[0] = new SqlParameter("@CreatedBy", this.CreatedBy);
                param[1] = new SqlParameter("@fkIssueByBranchID", row["Issue Branch Id"].ToString());
                param[2] = new SqlParameter("@fkIssueToBranchID", 0);
                param[3] = new SqlParameter("@fkIssueByStoreID", fkstoreid.ToString());
                param[4] = new SqlParameter("@fkIssueToStoreID", 0);
                param[5] = new SqlParameter("@fkIssueToDeptID", fkdepartid.ToString());
                param[6] = new SqlParameter("@fkIssueByID", row["Issue by Id"].ToString());
                param[7] = new SqlParameter("@fkIssuedToID", 0);
                param[8] = new SqlParameter("@IssuedStatus", row["Item Status"].ToString());
                param[24] = new SqlParameter("@IssuedType", row["Item Type"].ToString());
                param[9] = new SqlParameter("@GINNumber", 0);
                param[10] = new SqlParameter("@fkVendorID", this.fkVendorID);
                param[11] = new SqlParameter("@IssuDate", "0");
                param[12] = new SqlParameter("@InvCode", row["Item Code"].ToString());
                param[13] = new SqlParameter("@Qtty", qtty);
                param[14] = new SqlParameter("@Remarks", "QC Rejected Items Return To Vendor For Replacement.");
                param[15] = new SqlParameter("@IsCancel", false);
                param[16] = new SqlParameter("@CancelReason", "");
                param[17] = new SqlParameter("@ReceivedValidity", row["Ackdate"].ToString());
                param[18] = new SqlParameter("@ReturnValidity", row["Retdate"].ToString());
                param[19] = new SqlParameter("@Token", @Token);
                param[20] = new SqlParameter("@pkIssuID", 0);
                param[21] = new SqlParameter("@fkitemid", 0);
                param[22] = new SqlParameter("@ModifiedBy", @Token == "I" ? 0 : this.CreatedBy);
                param[23] = new SqlParameter("@fkIssueByDeptID", this.fkIssueByDeptID);
                param[25] = new SqlParameter("@oldGIN", @OLDGIN);
                param[26] = new SqlParameter("@IsConfirm", @IssueConfirm);
                param[27] = new SqlParameter("@MIRNumber", DBNull.Value);
                param[28] = new SqlParameter("@IssuedToID", @fkIssuedToID);


                object obj = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemIssued", param);

                result = obj != null ? (int)obj : 0;




                //   result = (Int32)SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemIssued", param);

                if (result > 0)
                    result = 1;
                else
                    result = 0;


            }

            IsGinSaved = checkGINSaved(fkstoreid, invcode, qtty);



            int serial = 0;

            //if (IsGinSaved == true)  // Checking if GIN Record Properly Saved...
            //{

            //Process Call to Generate the GIN Number
            ///sp_SetGetRPTSerial

            if (@OLDGIN == 0)
            {

                serial = RptSerial(fkbrhid, fkstoreid, this.fkIssueByDeptID, 3, IssuedStatus);
                ginno = serial;

                GPNumber = RptSerial(fkbrhid, fkstoreid, this.fkIssueByDeptID, 5, IssuedStatus);
                gpno = GPNumber;

                return serial;
            }
            else
            {
                serial = @OLDGIN;
            }
            //}

            return serial;
        }


        public int IUIssueItemMIR(DataTable dt, ref int ginno, ref int gpno)
        {
            int result = 0;

            fkbrhid = int.Parse(dt.Rows[0]["fkIssueToBranchID"].ToString());
            fkstoreid = int.Parse(dt.Rows[0]["fkIssueToStoreID"].ToString());
            fkdepartid = int.Parse(dt.Rows[0]["fkIssueToDeptID"].ToString());

            int IBy_fkbrhid = int.Parse(dt.Rows[0]["fkIssueToBranchID"].ToString());
            int IBy_fkstoreid = int.Parse(dt.Rows[0]["fkIssueToStoreID"].ToString());
            int IBy_fkdeptid = int.Parse(dt.Rows[0]["fkIssueByDeptID"].ToString());

            IssuedStatus = "P";

            foreach(DataRow row in dt.Rows)
            {

                if (float.Parse(row["Qtty"].ToString()) > 0)
                {

                    SqlParameter[] param = new SqlParameter[29];
                    param[0] = new SqlParameter("@CreatedBy", this.CreatedBy);
                    param[1] = new SqlParameter("@fkIssueByBranchID", row["fkIssueToBranchID"].ToString());
                    param[2] = new SqlParameter("@fkIssueToBranchID", row["fkIssueByBranchID"].ToString());
                    param[3] = new SqlParameter("@fkIssueByStoreID", row["fkIssueToStoreID"].ToString());
                    param[4] = new SqlParameter("@fkIssueToStoreID", row["fkIssueByStoreID"].ToString());
                    param[5] = new SqlParameter("@fkIssueToDeptID", row["fkIssueByDeptID"].ToString());
                    param[6] = new SqlParameter("@fkIssueByID", row["fkIssuedToID"].ToString());
                    param[7] = new SqlParameter("@fkIssuedToID", row["fkIssueByID"].ToString());
                    param[8] = new SqlParameter("@IssuedStatus", IssuedStatus);
                    param[24] = new SqlParameter("@IssuedType", "E");
                    param[9] = new SqlParameter("@GINNumber", 0);
                    param[10] = new SqlParameter("@fkVendorID", 0);
                    param[11] = new SqlParameter("@IssuDate", "0");
                    param[12] = new SqlParameter("@InvCode", row["InvCode"].ToString());
                    //param[13] = new SqlParameter("@Qtty", row["QtyIssue"].ToString()=="0" ? row["Qtty"].ToString() : row["QtyIssue"].ToString());
                    param[13] = new SqlParameter("@Qtty", row["Qtty"].ToString());
                    param[14] = new SqlParameter("@Remarks", "0");
                    param[15] = new SqlParameter("@IsCancel", false);
                    param[16] = new SqlParameter("@CancelReason", "");
                    param[17] = new SqlParameter("@ReceivedValidity", DateTime.Now.ToString("MM-dd-yyyy"));
                    param[18] = new SqlParameter("@ReturnValidity", "");
                    param[19] = new SqlParameter("@Token", @Token);
                    param[20] = new SqlParameter("@pkIssuID", 0);
                    param[21] = new SqlParameter("@fkitemid", 0);
                    param[22] = new SqlParameter("@ModifiedBy", @Token == "I" ? 0 : this.CreatedBy);
                    param[23] = new SqlParameter("@fkIssueByDeptID", row["fkIssueToDeptID"].ToString());
                    param[25] = new SqlParameter("@oldGIN", @OLDGIN);
                    param[26] = new SqlParameter("@IsConfirm", @IssueConfirm);
                    param[27] = new SqlParameter("@MIRNumber", row["MIRNumber"].ToString());
                    param[28] = new SqlParameter("@IssuedToID", this.IssuetoID);

                    //result = (int)SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemIssued", param);

                    result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemIssued", param);


                    if (result > 0)
                        result = 1;
                    else
                        result = 0;
                }

            }

            //Process Call to Generate the GIN Number
            ///sp_SetGetRPTSerial
            int serial;
            if (@OLDGIN == 0)
            {

                serial = RptSerial(IBy_fkbrhid, IBy_fkstoreid, IBy_fkdeptid, 3, IssuedStatus);
                ginno = serial;

                GPNumber = RptSerial(IBy_fkbrhid, IBy_fkstoreid, IBy_fkdeptid, 5, IssuedStatus);
                gpno = GPNumber;

                return serial;
            }
            else
            {
                serial = @OLDGIN;
            }
           
            return serial;
        }

        public void CloseMIR(string MIRNO)
        {
            string sql;

            sql = "UPDATE [INVENTORY].[dbo].[tblMIRequest] ";
            sql = sql + " SET ModifiedDate=getdate(), IsReceived=1, Remarks='" + "Closed By Main Store" + "'";
            sql = sql + " where MIRCode='" + MIRNO + "'";

            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
        }

        public void UpdateIssueConfirm(int GinNo, string status)
        { 
                int result = 0;
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@fkbrhID", @fkIssueByBranchID);
                param[1] = new SqlParameter("@fkstoreID", @fkIssueByStoreID);
                param[2] = new SqlParameter("@fkdeptID", @fkIssueByDeptID);
                param[3] = new SqlParameter("@Ginno", GinNo);
                param[4] = new SqlParameter("@IsuStatus", status);
                param[5] = new SqlParameter("@ConfirmStatus", @IssueConfirm);

                result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_ConfirmGINIssued", param);

                 if (result > 0)
                     result = 1;
                 else
                     result = 0;
       
        
        }

        public void IUIssueItemInternal(DataTable dt)
        {
            int result = 0;
            //, ref int ginno

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {

                    SqlParameter[] param = new SqlParameter[25];

                    param[1] = new SqlParameter("@pkIssuID", 0);
                    param[2] = new SqlParameter("@CreatedBy", this.CreatedBy);
                    param[3] = new SqlParameter("@ModifiedBy", @Token == "I" ? 0 : this.CreatedBy);
                    param[4] = new SqlParameter("@fkIssueByBranchID", int.Parse(row["fkbrhid"].ToString()));
                    param[5] = new SqlParameter("@fkIssueToBranchID", int.Parse(row["fkbrhid"].ToString()));
                    param[6] = new SqlParameter("@fkIssueByDeptID", int.Parse(row["fkDeptID"].ToString()));
                    param[7] = new SqlParameter("@fkIssueToDeptID", @fkIssuedToID);
                    param[8] = new SqlParameter("@fkIssueByID", @fkIssueByID);
                    param[9] = new SqlParameter("@fkIssuedToID", @fkIssueByID);
                    param[10] = new SqlParameter("@STOREBY", int.Parse(row["fkStoreID"].ToString()));
                    param[11] = new SqlParameter("@IssuedStatus", @IssuedStatus);
                    param[12] = new SqlParameter("@IssuedType", @IssuedType);
                    param[13] = new SqlParameter("@GINNumber", 0);
                    param[14] = new SqlParameter("@IssuDate", "0");
                    param[15] = new SqlParameter("@fkitemid", int.Parse(row["fkitemid"].ToString()));
                    param[16] = new SqlParameter("@ItemCode", row["ItemCode"].ToString());
                    param[17] = new SqlParameter("@Qtty", float.Parse(row["Qtty"].ToString()));
                    param[18] = new SqlParameter("@FBalance", float.Parse(row["NewBal"].ToString()));
                    param[19] = new SqlParameter("@Remarks", row["Remarks"].ToString());
                    param[20] = new SqlParameter("@IssuedToID", row["IsuToID"].ToString());
                    param[21] = new SqlParameter("@IsCancel", false);
                    param[22] = new SqlParameter("@CancelReason", "");
                    param[23] = new SqlParameter("@oldGIN", @OLDGIN);
                    param[24] = new SqlParameter("@Token", @Token);



                    result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemIssuedInternal", param);


                    if (result > 0)
                        result = 1;
                    else
                        result = 0;

                }
            }

        }

        public int IUIssueItem(DataTable dt)
        {
             
            int result = 0;

            foreach (DataRow row in dt.Rows)
            {

                    SqlParameter[] param = new SqlParameter[29];
                    param[0] = new SqlParameter("@pkIssuID", 0);
                    param[1] = new SqlParameter("@CreatedBy", this.CreatedBy);
                    param[2] = new SqlParameter("@ModifiedBy", @Token == "I" ? 0 : this.CreatedBy);
                    param[3] = new SqlParameter("@fkIssueByBranchID", @fkIssueByBranchID);
                    param[4] = new SqlParameter("@fkIssueToBranchID", @fkIssueToBranchID);
                    param[5] = new SqlParameter("@fkIssueByStoreID", "0");
                    param[6] = new SqlParameter("@fkIssueToStoreID", "0");
                    param[7] = new SqlParameter("@fkIssueByDeptID", this.fkIssueByDeptID);
                    param[8] = new SqlParameter("@fkIssueToDeptID", @fkIssueToDeptID);                    
                    param[9] = new SqlParameter("@fkIssueByID", @fkIssueByID);
                    param[10] = new SqlParameter("@fkIssuedToID", @fkIssuedToID);
                    param[11] = new SqlParameter("@IssuedStatus", @IssuedStatus);
                    param[12] = new SqlParameter("@IssuedType", @IssuedType);
                    param[13] = new SqlParameter("@MIRNumber", DBNull.Value);
                    param[14] = new SqlParameter("@GINNumber", 0);
                    param[15] = new SqlParameter("@fkVendorID", DBNull.Value);
                    param[16] = new SqlParameter("@IssuDate", DBNull.Value);
                    param[17] = new SqlParameter("@fkitemid", row["fkitemid"].ToString()); 
                    param[18] = new SqlParameter("@InvCode", row["InvCode"].ToString());
                    param[19] = new SqlParameter("@Qtty", row["QTTY"].ToString());
                    param[20] = new SqlParameter("@Remarks", row["Remarks"].ToString());
                    param[21] = new SqlParameter("@IssuedToID", @fkIssuedToID.ToString());
                    param[22] = new SqlParameter("@IsCancel", false);
                    param[23] = new SqlParameter("@CancelReason", DBNull.Value);
                    param[24] = new SqlParameter("@ReceivedValidity", DBNull.Value);
                    param[25] = new SqlParameter("@ReturnValidity", DBNull.Value);
                    param[26] = new SqlParameter("@oldGIN", @OLDGIN);
                    param[27] = new SqlParameter("@Token", @Token);
                    param[28] = new SqlParameter("@IsConfirm", @IssueConfirm);

                    object obj = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemIssued", param);

                    result = obj != null ? (int)obj : 0;

                    if (result > 0)
                        result = 1;
                    else
                        result = 0;
                 

            }

 
            int serial = 0;

            if (@IssuedStatus == "LO" || @IssuedStatus == "DP")
            {
                serial = RptSerial(@fkIssueByBranchID, 0, this.fkIssueByDeptID, 3, @IssuedStatus);
            }
            else
            {
                serial = RptSerial(@fkIssueByBranchID, 0, this.fkIssueByDeptID, 3, @IssuedStatus);
            }

            return serial;
        }

        public int IUTransferInternal(DataTable dt, ref int ginno)
        {
            int result = 0;


            foreach (DataRow row in dt.Rows)
            {

                SqlParameter[] param = new SqlParameter[23];
                param[0] = new SqlParameter("@CreatedBy", this.CreatedBy);
                param[1] = new SqlParameter("@fkIssueByBranchID", @fkIssueByBranchID);
                param[2] = new SqlParameter("@fkIssueToBranchID", @fkIssueToBranchID);
                param[3] = new SqlParameter("@fkIssueByDeptID", @fkIssueByDeptID);
                param[4] = new SqlParameter("@fkIssueToDeptID", @fkIssueToDeptID);
                param[5] = new SqlParameter("@fkIssueByID", @fkIssueByID);
                param[6] = new SqlParameter("@fkIssuedToID", @fkIssuedToID);
                param[7] = new SqlParameter("@IssuedStatus", @IssuedStatus);
                param[8] = new SqlParameter("@IssuedType", @IssuedType);
                param[9] = new SqlParameter("@GINNumber", 0);
                param[10] = new SqlParameter("@IssuDate", "0");
                param[11] = new SqlParameter("@InvCode", row["Item Code"].ToString());
                param[12] = new SqlParameter("@Qtty", row["Qty Issued"].ToString());
                param[13] = new SqlParameter("@Remarks", @Remarks);
                param[14] = new SqlParameter("@IsCancel", false);
                param[15] = new SqlParameter("@CancelReason", "");
                param[16] = new SqlParameter("@Token", @Token);
                param[17] = new SqlParameter("@pkIssuID", 0);
                param[18] = new SqlParameter("@fkitemid", 0);
                param[19] = new SqlParameter("@ModifiedBy", @Token == "I" ? 0 : this.CreatedBy);
                param[20] = new SqlParameter("@oldGIN", @OLDGIN);
                param[21] = new SqlParameter("@FromSysID", this.pksysID);
                param[22] = new SqlParameter("@ToSysID", this.pksysIDTo);

                result = (int)SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUTransferInternal", param);


                if (result > 0)
                    result = 1;
                else
                    result = 0;

            }

       
            int serial;

            int storeid = 1;
              

                serial = RptSerial(@fkIssueByBranchID, storeid, @fkIssueByDeptID, 3, "R");
                ginno = serial;

                serial = RptSerial(@fkIssueByBranchID, storeid, @fkIssueToDeptID, 4, "R");
                 

                return serial;
           
 
        }

        public Int32 IUReceivedItems(DataTable dt)
        {
            int serial = 0;
            int result = 0;
            RecvStatus = "P";

            int checklastrecord = 0;

            foreach (DataRow row in dt.Rows)
            {
                checklastrecord++;

                if (checklastrecord == dt.Rows.Count && @OLDGRN==0)
                {
                    Token = "L";
                }
                
                
                SqlParameter[] param = new SqlParameter[24];
                param[0] = new SqlParameter("@CreatedBy", @CreatedBy);
                param[1] = new SqlParameter("@ModifiedBy", @ModifiedBy);
                param[2] = new SqlParameter("@fkVendID", @fkVendorID);
                param[3] = new SqlParameter("@fkRecvByStoreID", @fkstoreid);
                param[4] = new SqlParameter("@fkRecvByDeptID", @fkdepartid);
                param[5] = new SqlParameter("@fkReceivedByID", @receivedByID);
                param[6] = new SqlParameter("@recvstatus", @RecvStatus);
                param[7] = new SqlParameter("@dcno", @dcno);
                param[8] = new SqlParameter("@dcdate", @dcdate);
                param[9] = new SqlParameter("@invoice", @invoice);
                param[10] = new SqlParameter("@vehicle", @vehicle);
                param[11] = new SqlParameter("@fkItemID", row[0].ToString());
                param[12] = new SqlParameter("@Qtty", row[4].ToString());
                param[13] = new SqlParameter("@Remarks", "");
                param[14] = new SqlParameter("@IsCancel", false);
                param[15] = new SqlParameter("@CancelReason", "NA");
                param[16] = new SqlParameter("@empno_insp", this.insp_empcode);                
                param[17] = new SqlParameter("@oldGRN", @OLDGRN);
                param[18] = new SqlParameter("@Token", @Token);
                param[19] = new SqlParameter("@sysid", this.pksysID);
                param[20] = new SqlParameter("@model", row[2].ToString());
                param[21] = new SqlParameter("@brand", row[3].ToString());
                param[22] = new SqlParameter("@ponumber", @ponumber);

                param[23] = new SqlParameter("@RetuSerial", SqlDbType.Int);

                param[23].Direction = ParameterDirection.Output;

                //result = (int)SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemReceived_Vendor", param);

                result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemReceived_Vendor", param);

                if (Token == "L")
                {
                    serial = (int)param[23].Value;
                }

            }
            //Process Call to Generate the GRN Number
            //sp_SetGetRPTSerial

            //int serial;
            //if (@OLDGRN == 0)
            //{
            //    serial = RptSerial(@fkbrhid, @fkstoreid, @fkdepartid, 4, @RecvStatus);
            //}
            //else
            //{
            //  serial = @OLDGRN;
            //}
         return serial;
       }

        public Int32 IUReceivedItemsGIN(DataTable dt)
        {
            int serial = 0;
            int result = 0;
            int ginackno = 0;
            int checklastrecord = 0;

            foreach (DataRow row in dt.Rows)
            {
                ginackno = int.Parse(row["GINNumber"].ToString());

                checklastrecord++;

                if (checklastrecord == dt.Rows.Count)
                {
                    Token = "L";
                }


                SqlParameter[] param = new SqlParameter[22];
                param[0] = new SqlParameter("@CreatedBy", @CreatedBy);
                param[1] = new SqlParameter("@ModifiedBy", @ModifiedBy);
                param[2] = new SqlParameter("@fkIssuByBranchID", @fkIssueByBranchID);
                param[3] = new SqlParameter("@fkIssuByStoreID", @fkIssueByStoreID);
                param[4] = new SqlParameter("@fkIssuByDeptID", @fkIssueByDeptID);
                param[5] = new SqlParameter("@fkIssuByID", int.Parse(row["fkIssueByID"].ToString()));
                param[6] = new SqlParameter("@fkRecvByBranchID", @fkIssueToBranchID);
                param[7] = new SqlParameter("@fkRecvByStoreID", @fkIssueToStoreID);
                param[8] = new SqlParameter("@fkRecvByDeptID", @fkIssueToDeptID);
                param[9] = new SqlParameter("@fkReceivedByID", @receivedByID);
                param[10] = new SqlParameter("@recvstatus", @RecvStatus);
                param[11] = new SqlParameter("@fkItemID", int.Parse(row["fkItemID"].ToString()));
                param[12] = new SqlParameter("@Qtty", float.Parse(row["Qtty"].ToString()));
                param[13] = new SqlParameter("@model", row["Model"].ToString());
                param[14] = new SqlParameter("@brand", row["Brand"].ToString());
                param[15] = new SqlParameter("@Remarks", "");
                param[16] = new SqlParameter("@IsCancel", false);
                param[17] = new SqlParameter("@CancelReason", "NA");
                param[18] = new SqlParameter("@empno_insp", this.insp_empcode);                
                param[19] = new SqlParameter("@Token", @Token);
                param[20] = new SqlParameter("@GINNumber", int.Parse(row["GINNumber"].ToString()));

                param[21] = new SqlParameter("@RetuSerial", SqlDbType.BigInt);

                param[21].Direction = ParameterDirection.Output;

       
                result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemReceived_GIN", param);

                if (Token == "L")
                {
                    serial = int.Parse(param[21].Value.ToString());
                }

            
                //result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemReceived_GIN", param);


                //if (result > 0)
                //    result = 1;
                //else
                //    result = 0;


            }

            return serial;
            //Process Call to Generate the GRN Number
            //sp_SetGetRPTSerial

           // ReceivedAcknowledge(ginackno);

            //int serial;
           // serial = RptSerial(@fkIssueToBranchID, @fkIssueToStoreID, @fkIssueToDeptID, 4, @RecvStatus);            
           // return serial;
        }

        public Int32 IUReceivedItemsGIN(string Ginnumber)
        {
            int serial = 0;
            int result = 0;

                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@CreatedBy", @CreatedBy);
                param[1] = new SqlParameter("@fkIssuByStoreID", @fkIssueByStoreID);
                param[2] = new SqlParameter("@fkReceivedByID", @receivedByID);
                param[3] = new SqlParameter("@GINNumber", Ginnumber);

                param[4] = new SqlParameter("@RetuSerial", SqlDbType.BigInt);

                param[4].Direction = ParameterDirection.Output;


                result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemReceived_GINAll", param);

 
                serial = int.Parse(param[4].Value.ToString());
  
         

            return serial;
 
        }


        public void ReceivedAcknowledge(int ginackno)
        { 


            int result;
            SqlParameter[] param1 = new SqlParameter[8];

            param1[0] = new SqlParameter("@fkIssuByBranchID", @fkIssueByBranchID);
            param1[1] = new SqlParameter("@fkIssuByStoreID", @fkIssueByStoreID);
            param1[2] = new SqlParameter("@fkIssuByDeptID", @fkIssueByDeptID);
            param1[3] = new SqlParameter("@fkRecvByBranchID", @fkIssueToBranchID);
            param1[4] = new SqlParameter("@fkRecvByStoreID", @fkIssueToStoreID);
            param1[5] = new SqlParameter("@fkRecvByDeptID", @fkIssueToDeptID);
            param1[6] = new SqlParameter("@recvstatus", @RecvStatus);
            param1[7] = new SqlParameter("@GINNumber", ginackno);

            result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemReceived_ACK", param1);
            
                //ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUItemReceived_ACK", param1);


            if (result > 0)
                result = 1;
            else
                result = 0;     
        }
        
        public int IUReceivedItemsStaff(DataTable dt)
        {
            int result = 0;
            int serial = 0;
            RecvStatus = "P";

            int checklastrecord = 0;


            if (this.fkbrhid == 25 && this.fkdepartid == 14)
            {
                foreach (DataRow row in dt.Rows)
                {
                    checklastrecord++;

                    if (checklastrecord == dt.Rows.Count && @OLDGRN == 0)
                    {
                        Token = "L";
                    }

                    SqlParameter[] param = new SqlParameter[13];

                    param[0] = new SqlParameter("@CreatedBy", @CreatedBy);
                    param[1] = new SqlParameter("@ModifiedBy", @ModifiedBy);
                    param[2] = new SqlParameter("@sysid", @pksysID);                    
                    param[3] = new SqlParameter("@fkRecvByBranchID", @fkbrhid);
                    param[4] = new SqlParameter("@fkRecvByDeptID", @fkdepartid);
                    param[5] = new SqlParameter("@fkReceivedByID", @receivedByID);
                    param[6] = new SqlParameter("@recvstatus", @RecvStatus);
                    param[7] = new SqlParameter("@fkItemID", row[0].ToString());
                    param[8] = new SqlParameter("@Qtty", row[3].ToString());
                    param[9] = new SqlParameter("@Remarks", @Remarks);
                    param[10] = new SqlParameter("@recvfromid", @RecvfromID);
                    param[11] = new SqlParameter("@Token", @Token);


                    param[12] = new SqlParameter("@RetuSerial", SqlDbType.Int);

                    param[12].Direction = ParameterDirection.Output;

                    result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemReceived_Recoverd", param);

                    if (Token == "L")
                    {
                        serial = (int)param[12].Value;
                    }
                }
            }

            else
            {
                
                foreach (DataRow row in dt.Rows)
                {
                    checklastrecord++;

                    if (checklastrecord == dt.Rows.Count && @OLDGRN == 0)
                    {
                        Token = "L";
                    }

                    SqlParameter[] param = new SqlParameter[12];

                    param[0] = new SqlParameter("@CreatedBy", @CreatedBy);
                    param[1] = new SqlParameter("@ModifiedBy", @ModifiedBy);
                    param[2] = new SqlParameter("@fkRecvByBranchID", @fkbrhid);
                    param[3] = new SqlParameter("@fkRecvByDeptID", @fkdepartid);
                    param[4] = new SqlParameter("@fkReceivedByID", @receivedByID);
                    param[5] = new SqlParameter("@recvstatus", @RecvStatus);
                    param[6] = new SqlParameter("@fkItemID", row[0].ToString());
                    param[7] = new SqlParameter("@Qtty", row[3].ToString());
                    param[8] = new SqlParameter("@Remarks", @Remarks);
                    param[9] = new SqlParameter("@recvfromid", @RecvfromID);
                    param[10] = new SqlParameter("@Token", @Token);


                    param[11] = new SqlParameter("@RetuSerial", SqlDbType.Int);

                    param[11].Direction = ParameterDirection.Output;

                    result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemReceived_Staff", param);

                    if (Token == "L")
                    {
                        serial = (int)param[11].Value;
                    }
                }
            }
  
            return serial;
        }

        public int IUBranchReturns(DataTable dt)
        {
            int serial = 0;
            int result = 0;
            int ginackno = 0;
            int checklastrecord = 0;

            foreach (DataRow row in dt.Rows)
            {
                ginackno = int.Parse(row["GINNumber"].ToString());

                checklastrecord++;

                if (checklastrecord == dt.Rows.Count)
                {
                    Token = "L";
                }


                SqlParameter[] param = new SqlParameter[23];
                param[0] = new SqlParameter("@CreatedBy", @CreatedBy);
                param[1] = new SqlParameter("@ModifiedBy", @ModifiedBy);
                param[2] = new SqlParameter("@fkIssuByBranchID", @fkIssueByBranchID);
                param[3] = new SqlParameter("@fkIssuByStoreID", @fkIssueByStoreID);
                param[4] = new SqlParameter("@fkIssuByDeptID", @fkIssueByDeptID);
                param[5] = new SqlParameter("@fkIssuByID", int.Parse(row["fkIssueByID"].ToString()));
                param[6] = new SqlParameter("@fkRecvByBranchID", @fkIssueToBranchID);
                param[7] = new SqlParameter("@fkRecvByStoreID", @fkIssueToStoreID);
                param[8] = new SqlParameter("@fkRecvByDeptID", @fkIssueToDeptID);
                param[9] = new SqlParameter("@fkReceivedByID", @receivedByID);
                param[10] = new SqlParameter("@recvstatus", @RecvStatus);
                param[11] = new SqlParameter("@fkItemID", int.Parse(row["fkItemID"].ToString()));
                param[12] = new SqlParameter("@Qtty", float.Parse(row["Qtty"].ToString()));
                param[13] = new SqlParameter("@model", row["Model"].ToString());
                param[14] = new SqlParameter("@brand", row["Brand"].ToString());
                param[15] = new SqlParameter("@Remarks", "");
                param[16] = new SqlParameter("@IsCancel", false);
                param[17] = new SqlParameter("@CancelReason", "NA");
                param[18] = new SqlParameter("@empno_insp", this.insp_empcode);
                param[19] = new SqlParameter("@Token", @Token);
                param[20] = new SqlParameter("@GINNumber", int.Parse(row["GINNumber"].ToString()));

                param[21] = new SqlParameter("@RetuSerial", SqlDbType.Int);

                param[21].Direction = ParameterDirection.Output;


                result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemReturn_Branch", param);

                if (Token == "L")
                {
                    serial = (int)param[21].Value;
                }

            }

            return serial;

        }

        public void ItemStatusUpdate(DataTable dt)
        {
            int result = 0;
            //, ref int ginno

            foreach (DataRow row in dt.Rows)
            {

                SqlParameter[] param = new SqlParameter[23];
                param[0] = new SqlParameter("@CreatedBy", this.CreatedBy);
                param[1] = new SqlParameter("@fkIssueByBranchID", @fkIssueByBranchID);
                param[2] = new SqlParameter("@fkIssueToBranchID", @fkIssueToBranchID);
                param[3] = new SqlParameter("@fkIssueByDeptID", @fkIssueByDeptID);
                param[4] = new SqlParameter("@fkIssueToDeptID", @fkIssueToDeptID);
                param[5] = new SqlParameter("@fkIssueByID", @fkIssueByID);
                param[6] = new SqlParameter("@fkIssuedToID", @fkIssuedToID);
                param[7] = new SqlParameter("@IssuedStatus", @IssuedStatus);
                param[8] = new SqlParameter("@IssuedType", @IssuedType);
                param[9] = new SqlParameter("@GINNumber", 0);
                param[10] = new SqlParameter("@IssuDate", "0");
                param[11] = new SqlParameter("@ItemCode", row["Item Code"].ToString());                
                param[12] = new SqlParameter("@Qtty", row["Qty Issued"].ToString());
                param[13] = new SqlParameter("@Remarks", @Remarks);
                param[14] = new SqlParameter("@IsCancel", false);
                param[15] = new SqlParameter("@CancelReason", "");
                param[16] = new SqlParameter("@Token", @Token);
                param[17] = new SqlParameter("@pkIssuID", 0);
                param[18] = new SqlParameter("@fkitemid", 0);
                param[19] = new SqlParameter("@ModifiedBy", @Token == "I" ? 0 : this.CreatedBy);
                param[20] = new SqlParameter("@oldGIN", @OLDGIN);
                param[21] = new SqlParameter("@ItemStatus", this.Itemstatustype);
                param[22] = new SqlParameter("@STOREBY", this.fkstoreid);
           
                result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUItemStatus", param);


                if (result > 0)
                    result = 1;
                else
                    result = 0;

            }

        }
        
        public int RptSerial(int brhid, int storeid, int deptid, int rptno, string status)
        {
            int serial;
            SqlParameter[] param1 = new SqlParameter[6];
         
            param1[0] = new SqlParameter("@fkbrhid", brhid);
            param1[1] = new SqlParameter("@fkstoreid", storeid);
            param1[2] = new SqlParameter("@fkdeptid", deptid);
            param1[3] = new SqlParameter("@rptno", rptno);
            param1[4] = new SqlParameter("@status", status);
            param1[5] = new SqlParameter("@RetuSerial", SqlDbType.Int);



            param1[5].Direction = ParameterDirection.Output;

            //object o1 = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_SetGetRPTSerial", param1);

            

            int result;
            result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_SetGetRPTSerial", param1);
            
            serial = (int)param1[5].Value;

            return serial;

        }

        public void GenerateGatePass(int brhid, int storeid, int deptid, int gpno)
        {

            SqlParameter[] param1 = new SqlParameter[5];

            param1[0] = new SqlParameter("@fkBranchID", brhid);
            param1[1] = new SqlParameter("@fkStoreID", storeid);
            param1[2] = new SqlParameter("@fkDeptID", deptid);
            param1[3] = new SqlParameter("@GPNumber", gpno);
            param1[4] = new SqlParameter("@Token", "I");

            object gp = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_MakeGatePass", param1);

        }

        public int IUMaterialIssueRequest(DataTable dt, ref int mirno)
        {
            int result = 0;


            foreach (DataRow row in dt.Rows)
            {
               
                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@CreatedBy", this.CreatedBy);
                param[1] = new SqlParameter("@fkIssueByBranchID", @fkIssueByBranchID);
                param[2] = new SqlParameter("@fkIssueToBranchID", @fkIssueToBranchID);

                param[3] = new SqlParameter("@fkIssueByStoreID", @fkIssueByStoreID);
                param[4] = new SqlParameter("@fkIssueToStoreID", @fkIssueToStoreID);

                param[5] = new SqlParameter("@fkIssueByDeptID", @fkIssueByDeptID);
                param[6] = new SqlParameter("@fkIssueToDeptID", @fkIssueToDeptID);

                param[7] = new SqlParameter("@fkIssueByID", @fkIssueByID);
                param[8] = new SqlParameter("@fkIssuedToID", @fkIssuedToID);

                param[9] = new SqlParameter("@MIRNumber", 0);
                param[10] = new SqlParameter("@IssuDate", "0");
                param[11] = new SqlParameter("@ItemCode", row["Item Code"].ToString());
                param[12] = new SqlParameter("@Qtty", row["Qtty Request"].ToString());
                param[13] = new SqlParameter("@Remarks", @Remarks);

                param[14] = new SqlParameter("@Token", @Token);
                param[15] = new SqlParameter("@pkMIRID", 0);
                param[16] = new SqlParameter("@ModifiedBy", @Token == "I" ? 0 : this.CreatedBy);                
                param[17] = new SqlParameter("@oldMIR", @OLDMIR);
                param[18] = new SqlParameter("@fkReqID", @REQNumber);

                param[19] = new SqlParameter("@CheckMIR", SqlDbType.Int);

                
                param[19].Direction = ParameterDirection.Output;

                result = (int)SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IUMIR", param);

                //mirno = (int)param[19].Value;

                //result = (int)param[19].Value;

                if (result > 0)
                    result = 1;
                else
                    result = 0;


            }

            //Process Call to Generate the GIN Number
            ///sp_SetGetRPTSerial
            int serial;
            if (@OLDMIR == 0)
            {

                serial = RptSerial(@fkIssueByBranchID, @fkIssueByStoreID, @fkIssueByDeptID, 7, IssuedStatus);
                mirno = serial;


                return serial;
            }
            else
            {
                serial = @OLDMIR;
            }

            return serial;
        }

        public void SendReportEmail(int brhid, int storeid, int deptid, int rptid, int rptno)
        {
           
            SqlParameter[] param1 = new SqlParameter[5];

            param1[0] = new SqlParameter("@brhid", brhid);
            param1[1] = new SqlParameter("@storid", storeid);
            param1[2] = new SqlParameter("@deptid", deptid);
            param1[3] = new SqlParameter("@rptid", rptid);
            param1[4] = new SqlParameter("@rptno", rptno);
        
             object o1 = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_SendEmailAlert", param1);

        }

        private void UploadFiles()
        {

            //string s_Image_Name = txt_Image_Name.Text.ToString();
            //if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            //{
            //    byte[] n_Image_Size = new byte[FileUpload1.PostedFile.ContentLength];
            //    HttpPostedFile Posted_Image = FileUpload1.PostedFile;
            //    Posted_Image.InputStream.Read(n_Image_Size, 0, (int)FileUpload1.PostedFile.ContentLength);

            //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = "INSERT INTO Images(Name,[Content],Size,Type)" +
            //                      " VALUES (@Image_Name,@Image_Content,@Image_Size,@Image_Type)";
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Connection = conn;

            //    SqlParameter Image_Name = new SqlParameter("@Image_Name", SqlDbType.VarChar, 500);
            //    Image_Name.Value = txt_Image_Name.Text;
            //    cmd.Parameters.Add(Image_Name);

            //    SqlParameter Image_Content = new SqlParameter("@Image_Content", SqlDbType.Image, n_Image_Size.Length);
            //    Image_Content.Value = n_Image_Size;
            //    cmd.Parameters.Add(Image_Content);

            //    SqlParameter Image_Size = new SqlParameter("@Image_Size", SqlDbType.BigInt, 99999);
            //    Image_Size.Value = FileUpload1.PostedFile.ContentLength;
            //    cmd.Parameters.Add(Image_Size);

            //    SqlParameter Image_Type = new SqlParameter("@Image_Type", SqlDbType.VarChar, 500);
            //    Image_Type.Value = FileUpload1.PostedFile.ContentType;
            //    cmd.Parameters.Add(Image_Type);


            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    conn.Close();

           // }

        }

        private void UploadFile(object FileUpload1)
        {

            

                //<asp:FileUpload ID="FileUpload1" runat="server" />

                //<asp:Button ID="btnUpload" runat="server" Text="Upload"

                //OnClick="btnUpload_Click" />

                //<br />

                //<asp:Label ID="lblMessage" runat="server" Text=""

                //Font-Names = "Arial"></asp:Label>




            // Read the file and convert it to Byte Array

            //string filePath = FileUpload1.PostedFile.FileName;

            //string filename = Path.GetFileName(filePath);

            //string ext = Path.GetExtension(filename);

            //string contenttype = String.Empty;



            ////Set the contenttype based on File Extension

            //switch (ext)
            //{

            //    case ".doc":

            //        contenttype = "application/vnd.ms-word";

            //        break;

            //    case ".docx":

            //        contenttype = "application/vnd.ms-word";

            //        break;

            //    case ".xls":

            //        contenttype = "application/vnd.ms-excel";

            //        break;

            //    case ".xlsx":

            //        contenttype = "application/vnd.ms-excel";

            //        break;

            //    case ".jpg":

            //        contenttype = "image/jpg";

            //        break;

            //    case ".png":

            //        contenttype = "image/png";

            //        break;

            //    case ".gif":

            //        contenttype = "image/gif";

            //        break;

            //    case ".pdf":

            //        contenttype = "application/pdf";

            //        break;

            //}

            //if (contenttype != String.Empty)
            //{



            //    Stream fs = FileUpload1.PostedFile.InputStream;

            //    BinaryReader br = new BinaryReader(fs);

            //    Byte[] bytes = br.ReadBytes((Int32)fs.Length);



            //    //insert the file into database

            //    string strQuery = "insert into tblFiles(Name, ContentType, Data)" +

            //       " values (@Name, @ContentType, @Data)";

            //    SqlCommand cmd = new SqlCommand(strQuery);

            //    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;

            //    cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value

            //      = contenttype;

            //    cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;

            //    InsertUpdateData(cmd);

            //    lblMessage.ForeColor = System.Drawing.Color.Green;

            //    lblMessage.Text = "File Uploaded Successfully";

            //}

            //else
            //{

            //    lblMessage.ForeColor = System.Drawing.Color.Red;

            //    lblMessage.Text = "File format not recognised." +

            //      " Upload Image/Word/PDF/Excel formats";

            //}

        }


        public DataTable GetBranchGINMIR(string branchname)
        {

            string sqlstring;

            sqlstring = "SELECT BranchID,[BranchName],[GINNumber],[MIRNumber],[TotalItemsIssued],[TotalQuantityRequired],[TotalQuantityIssued],[TotalQuantityRequired]-[TotalQuantityIssued] As Balance";
            sqlstring = sqlstring + " FROM [INVENTORY].[dbo].[View_GIN_ISSUED_MIR_SEND] order by branchname,ginnumber ";
            sqlstring = sqlstring + " where BranchName = '" + branchname + "'";



            SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sqlstring);

            DataTable dt = new DataTable();
            dt.Load(dr);

            if (dt != null)
            {

                return dt;
            }
            else
            {
                return new DataTable();

            }

        }


        #endregion
    }
}
