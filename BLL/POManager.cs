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
    public class POManager
    {
        #region Class Constructor

        public POManager()
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

        public string Token { get; set; }

        private int uid;
        private int pkdeptid;
        private int vendorID;
        private int pkacdid;
        private string qurtID;

        private int _PONumber;
        private int _QuotID;
        private string _expDelivDate;
        private string _POIssuDate;
        private string _QuotDate;

        private string _ContPerson;
        private string _ShipAt;
        private string _TermsConditions;


        private int fkItemID;
        private string ItemTitle;
        private Single InStockBalance;
        private string Unit;
        private Single QttyRequired;
        private Single InStock;
        private Single Rate;
        private Double Amount;
        private Boolean _NewPO;

        public Boolean NewPO
        {
            get { return _NewPO; }
            set { _NewPO = value; }
        }
        private Double _GrossAmount;


        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }
        public int Pkdeptid
        {
            get { return pkdeptid; }
            set { pkdeptid = value; }
        }
        public int VendorID
        {
            get { return vendorID; }
            set { vendorID = value; }
        }

        public string ContPerson
        {
            get { return _ContPerson; }
            set { _ContPerson = value; }
        }
        public string ShipAt
        {
            get { return _ShipAt; }
            set { _ShipAt = value; }
        }

        public string TermsConditions
        {
            get { return _TermsConditions; }
            set { _TermsConditions = value; }
        }

        public int PONumber
        {
            get { return _PONumber; }
            set { _PONumber = value; }
        }

        public string ExpDelivDate
        {
            get { return _expDelivDate; }
            set { _expDelivDate = value; }
        }
        public int QuotID
        {
            get { return _QuotID; }
            set { _QuotID = value; }
        }
        public string POIssuDate
        {
            get { return _POIssuDate; }
            set { _POIssuDate = value; }
        }
        public string QuotDate
        {
            get { return _QuotDate; }
            set { _QuotDate = value; }
        }

        public Double GrossAmount
        {
            get { return _GrossAmount; }
            set { _GrossAmount = value; }
        }

        #endregion



        #region Helper Methods


        public DataTable GetPOItemsByReqType(int fkacdid, int fkcomid, int fkcityid, string potype, int HOtoken)
        {
            DataSet ds;

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@fkacdid", fkacdid);
            param[1] = new SqlParameter("@fkcomid", fkcomid);
            param[2] = new SqlParameter("@fkcityid", fkcityid);
            param[3] = new SqlParameter("@potype", potype);
            param[4] = new SqlParameter("@HOToken", HOtoken);



            ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_SelectPOItemList", param);


            if (ds.Tables[0] != null)
                return ds.Tables[0];
            else
                return new DataTable();

        }


        public int IUPurchaseOrder(DataTable dt, ref int POno)
        {
            int pono = 0;

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

                SqlParameter[] param = new SqlParameter[22];

                param[0] = new SqlParameter("@CreatedBy", Uid.ToString());
		        param[1] = new SqlParameter("@fkreqpoID", row["pkreqpoID"].ToString());

                param[2] = new SqlParameter("@IssueDate", DateTime.Parse(this.POIssuDate).ToString("yyyy-MM-dd"));
                param[3] = new SqlParameter("@POReqNo", int.Parse(row["poreqno"].ToString()));
                param[4] = new SqlParameter("@fkQuotID", QuotID);
                param[5] = new SqlParameter("@QuotDate", DateTime.Parse(this.QuotDate).ToString("yyyy-MM-dd"));  
                param[6] = new SqlParameter("@fkVendID",  VendorID);
                param[7] = new SqlParameter("@ContactPerson", ContPerson);
                param[8] = new SqlParameter("@fkDeptID", Pkdeptid);
                param[9] = new SqlParameter("@ShipAt", ShipAt);
                param[10] = new SqlParameter("@ShipDate", DateTime.Parse(this.ExpDelivDate).ToString("yyyy-MM-dd"));
                param[11] = new SqlParameter("@TermsConditions", TermsConditions);
                param[12] = new SqlParameter("@GrossAmount", GrossAmount);
                param[13] = new SqlParameter("@Discount", 0);
                param[14] = new SqlParameter("@fkItemID", int.Parse(row["fkitemid"].ToString()));
                param[15] = new SqlParameter("@InStockBalance", int.Parse(row["InStock"].ToString()));
                param[16] = new SqlParameter("@Unit",  row["Unit"].ToString());
                param[17] = new SqlParameter("@QttyRequired", float.Parse(row["POQuantity"].ToString()));
                param[18] = new SqlParameter("@Rate",  float.Parse(row["Rate"].ToString()));
                param[19] = new SqlParameter("@Amount", int.Parse(row["Amount"].ToString()));
                param[20] = new SqlParameter("@NewPO", this.NewPO);                
		        param[21] = new SqlParameter("@Token", this.Token);
                
                //param[21] = new SqlParameter("@ReturPOID", SqlDbType.Int);
                //param[21].Direction = ParameterDirection.Output;
               

                object o = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IUPurchaseOrder", param);

                if (this.Token == "L")
                {
                    string sql = "select top 1 pkPOID from tblPurchaseMain as PONo Order by pkPOID Desc";

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        pono = (Int32)cmd.ExecuteScalar();
                    }

                   // result = (int)param[21].Value;

                    POno = pono;

                    conn.Close();
                }
            }

            return pono;
        }


        #endregion
    }
}
