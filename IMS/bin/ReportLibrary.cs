using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Reporting.Expressions;

namespace IMS
{
    public static class PostageFunctions
    {
        [Function(Category = "Postage", Namespace = "PostageFunctions",Description = "Identifies the type of postage based on product weight (lbs)")]

        public static string GetPostageTypeByWeight(decimal itemWeight,string weightUnitOfMeasure)
        {

            if (weightUnitOfMeasure.Trim().Equals("G"))
            {

                itemWeight = GramsToPoundsConverter(itemWeight);

            }



            string postageType = "Priority Mail";



            if (itemWeight > 5)
            {

                postageType = "Logistical Service";

            }



            if (itemWeight >= 20)
            {

                postageType = "Pick Up Only";

            }



            return postageType;

        }



        private static decimal GramsToPoundsConverter(decimal weightInGrams)
        {

            //1lb = 453.59237g

            decimal poundInGrams = Convert.ToDecimal(453.59237);

            return weightInGrams / poundInGrams;

        }



    }


}