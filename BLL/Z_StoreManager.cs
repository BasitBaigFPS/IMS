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
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", "");
            param[1] = new SqlParameter("@Token", "B");

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }

        public DataTable GetStores()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", fkbrhID);
            param[1] = new SqlParameter("@Token", Token);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        public StoreManager GetStore()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", pkstoreID);
            param[1] = new SqlParameter("@Token", Token);

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

        #endregion
    }
}
