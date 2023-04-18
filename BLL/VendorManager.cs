using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DAL;


namespace BLL
{
    public class VendorManager
    {
        #region Class Constructor

        public VendorManager()
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

        public int pkVendID { get; set; } 
		public int CreatedBy { get; set; }
		public int ModifiedBy { get; set; } 	
		public string VendorName { get; set; }

        public int VendorType { get; set; }

        public int VendorCat { get; set; }

        public int Vendorcell { get; set; }


        public string Token { get; set; }

        #endregion

        #region Helper Methods


        public DataSet GetVondors()
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@sysid", 0);
            param[1] = new SqlParameter("@ID", pkVendID);
            param[2] = new SqlParameter("@ID1", 0);
            param[3] = new SqlParameter("@Token", Token);

            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectData", param);

            if (ds.Tables[0] != null)
                return ds;
            else
                return new DataSet();
        }





       #endregion
    }
}
