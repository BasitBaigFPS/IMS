using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Reporting.Expressions;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;

namespace BLL
{
    public static class TelerikReportLibrary
    {

        [Function(Category = "NumberSum", Namespace = "UDF_ValueSum", Description = "Add and Sum Numbers through itteration or passing value to this function")]

        public static string GetValueSum(string value, string prvvalue, string resettoken)
        {
            int sumval = 0;

            if (resettoken == "T")
            {
                prvvalue = value;
            }
            else
            {
                prvvalue = (int.Parse(prvvalue) + int.Parse(value)).ToString();
            }

            sumval = int.Parse(prvvalue);

            return sumval.ToString();
        }
        

    }
}
