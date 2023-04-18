using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace IMS
{
    public partial class BootstrapEditTableNew : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public class MyJSON
        {
            public string Name { get; set; }
            public string Dept { get; set; }
            public string Phone { get; set; }
        }

        [WebMethod]
        public static string GetChangeData(String data)
        {
            MyJSON myJson = JsonConvert.DeserializeObject<MyJSON>(data); 

            //string message = "Hello " + data;
            //return message;



            string name = myJson.Name.ToString();
            string dept = myJson.Dept.ToString();
            string phone = myJson.Phone.ToString();

            //the result to be returned!!
            //List<CASEXY> myCasesXY = new List<CASEXY>();

            ////grab from factory 
            //List<CASEXY> casesxy = FactoryCasesXY();

            //filter by criteria based on espid and metid...
           // myCasesXY = casesxy;

            //sérialiser!!
            string jsonData = JsonConvert.SerializeObject(name);

            return jsonData;


        }


    }
}