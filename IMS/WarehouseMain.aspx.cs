using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Menu;
using System.Text;
using BLL;
using System.Data;

namespace IMS
{
    public partial class WarehouseMain : System.Web.UI.Page
    {


 #region Class Level Objects


    //StudentManager studman = new StudentManager();
    //WebNews wnews = new WebNews();

         //DashBoard Class Calling
        IMSManager Iman = new IMSManager();
        UserManager Uman = new UserManager();
        DashBoardManager dbm = new DashBoardManager();


    #endregion

    #region Events
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
      
        
        DBParaSetup();

        if (dbm.UserGroupID == 31 || dbm.UserGroupID == 29 || dbm.UserGroupID == 27 || dbm.UserGroupID == 28 || dbm.UserGroupID == 49)
        {
                      
        }


        
     //   Panel3();   //Top 10 Most Issued Items at Main Store & Branches
      //  Panel7();   //View Transaction Log Since Date


        //if (dbm.UserGroupID == 31 || dbm.UserGroupID == 28 || dbm.UserGroupID == 37)
        //{
        //    Panel1();   //MIR Send By Branches To Main store  
        //    Panel2();   //UnConfirm GIN Record at Main Store
        //    Panel3();  //Top 10 Most Issued Items at Store & Branches
        //    Panel4();   //Show Zero Balance Items List
        //    Panel5();   //Last 5 GIN Issued
        //    Panel6();   //Last 5 GRN Received 

        //    Panel8();   //Un Received GIN By Branches
        //}

        //if (dbm.UserGroupID == 31)
        //{
        //    Panel8();   //Un Received GIN By Branches
        //}




            //HttpCookie IMS = Request.Cookies["IMS"];
            //if (IMS == null)
            //    Response.Redirect("logout.aspx");

            //Uman.Uid = int.Parse(IMS["uid"]);
            //Uman.Ubrhid = int.Parse(IMS["ubrhid"]);
            //Uman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
            //Uman.Ugid = int.Parse(IMS["ugroupid"]);
            //Uman.Uname = IMS["uname"];

            //lblUser.Text = "Welcome " + Uman.Uname;
            //lblBranch.Text = IMS["BranchName"] + '-' + IMS["Department"];
            //lblCity.Text = IMS["UCity"] == "1" ? "Karachi" : "Hyderabad";


        

    }

    protected void update_Click(object sender, EventArgs e)
    {
        //WebNews wnews = new WebNews();
        //SqlParameter[] param = new SqlParameter[6];

        //string token = "I";
        //wnews.Msguser = (string)Session["User"];

        //wnews.Msguser = wnews.Msguser.Substring(8, wnews.Msguser.Length - 9);
        //wnews.Newsinfo = txtNews.Text;

        //    param[0] = new SqlParameter("@pknwsID", int.Parse("0"));
        //    param[1] = new SqlParameter("@createby", wnews.Msguser);
        //    param[2] = new SqlParameter("@modifyby", "");
        //    param[3] = new SqlParameter("@newsinfo", wnews.Newsinfo);
        //    param[4] = new SqlParameter("@isactive", true);
        //    param[5] = new SqlParameter("@token", token);

        //  int newrecid = wnews.InsertNews("sp_InsertUpdateNews", param);

        //  if (newrecid > 0)
        //  {
        //      showMessageBox("Website News Successfully Published.");
        //  }

    }

    protected void showMessageBox(string message)
    {
        //string sScript;
        //message = message.Replace("'", "\'");
        //sScript = String.Format("alert('{0}');", message);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", sScript, true);
    }

    #endregion


    #region Helper Methods

    private void DBParaSetup()
    {
        HttpCookie IMS = Request.Cookies["IMS"];
        if (IMS == null)
            Response.Redirect("logout.aspx");

        Uman.Uid = int.Parse(IMS["uid"]);
        Uman.Ubrhid = int.Parse(IMS["ubrhid"]);
        Uman.Pkdeptid = int.Parse(IMS["udptid"] == null ? "0" : IMS["udptid"]);
        Uman.Grpuserbrhid = int.Parse(IMS["grpuserbrhid"]);
        Uman.Grpuserdeptid = int.Parse(IMS["grpuserdptid"]);
        Uman.Grpuserstoreid = int.Parse(IMS["grpuserstoreid"]);

        dbm.fkdepartid = Uman.Grpuserdeptid;
        dbm.fkbrhid = Uman.Grpuserbrhid;
        dbm.fkstoreid = Uman.Grpuserstoreid;

               //        IMS["grpuserdptid"] = um.Grpuserdeptid.ToString();
               //IMS["grpuserbrhid"] = um.Grpuserbrhid.ToString();
          

        Uman.PkstoreID = int.Parse(IMS["grpuserstoreid"]);

        //if (Uman.Pkdeptid != 31 && Uman.Pkdeptid != 22 && Uman.Pkdeptid != 7 && Uman.Pkdeptid != 2)
        //{
        //    dbm.fkstoreid = Iman.GetStores(Uman.Ubrhid);
        //}
        //else
        //{
        //    dbm.fkstoreid = 0;
        //}
        dbm.UserGroupID = int.Parse(IMS["ugroupid"]);

        if (Uman.Ubrhid == 25 && Uman.Pkdeptid == 14)
        {
            dbm.fkstoreid = 1;
            dbm.fkdepartid = 14;

            txtstoreID.Text = dbm.fkstoreid.ToString();
            txtbranchID.Text = dbm.fkbrhid.ToString();
        }
        if (Uman.Ubrhid == 19 && dbm.UserGroupID == 31 || dbm.UserGroupID == 32)
        {
            dbm.fkstoreid = 2;
            dbm.fkdepartid = 14;

            txtstoreID.Text = dbm.fkstoreid.ToString();
            txtbranchID.Text = dbm.fkbrhid.ToString();
        }
        if (Uman.Ubrhid == 19 && Uman.Pkdeptid == 10)
        {
            dbm.fkstoreid = 22;
            dbm.fkdepartid = 10;

            txtstoreID.Text = dbm.fkstoreid.ToString();
            txtbranchID.Text = dbm.fkbrhid.ToString();
        }
        if (Uman.Ubrhid != 19 && dbm.UserGroupID == 31 || dbm.UserGroupID == 32)
        {
            dbm.fkdepartid = 14;

            txtstoreID.Text = "0";
            txtbranchID.Text = "0";
        }
        if (dbm.UserGroupID == 38)
        {
            dbm.fkdepartid = Uman.Pkdeptid;
            txtstoreID.Text = "0";
            txtbranchID.Text = "0";
        }
    }



    private void Panel1()
    {

        // Panel to Show Latest MIR Send By Branches to Main Store
     //   DBParaSetup();

        var sb = new StringBuilder();
        List<string> MyList = dbm.GetMIRList();

        var collection = MyList;
     

        if (collection.Count != 0)
        {
            //sb.Append("<h3>Latest MIR Info:</h3><ul class=\"results\">");

            sb.Append("<ul class=\"results\">");
            foreach (var item in collection)
            {
                sb.Append("<li>" + item.ToString() + "</li>");
                

            }
            sb.Append("</ul>");

         //   litMIRList.Text = sb.ToString();
             

        }
        else
        {
    //        litMIRList.Text = "<p>No New MIR Record!!!</p>";

        }

    
    }

    private void Panel2()
    {
        //Panel to Show UNComfirmed GIN Record, Pending at Main Store 

        DBParaSetup();


        var sb = new StringBuilder();
        List<string> MyList = dbm.GetUCGinList();

        var collection = MyList;


        if (collection.Count != 0)
        {
            sb.Append("<h3>UNConfirmed GIN:</h3><ul class=\"results\">");

            foreach (var item in collection)
            {
                sb.Append("<li>" + item.ToString() + "</li>");


            }
            sb.Append("</ul>");

        //    litUCGIN.Text = sb.ToString();


        }
        else
        {
      //      litUCGIN.Text = "<p>No UnConfirmed GIN Pending!!</p>";

        }

    }

    private void Panel3()
    {
        //Top 10 Most Issued Items based on Count and Quantity
        ////http://demos.telerik.com/aspnet-ajax/htmlchart/examples/overview/defaultcs.aspx

       


        var sb = new StringBuilder();
        List<string> MyList = dbm.GetMostIssuedItems();

        var collection = MyList;

        if (collection.Count != 0)
        {
            sb.Append("<h3>Item Title     Item Count     Quantity Issued</h3><ul class=\"results\">");

            foreach (var item in collection)
            {
                sb.Append("<li>" + item.ToString() + "</li>");
            }
            sb.Append("</ul>");

           // litTopMostIssued.Text = sb.ToString();
        }
        else
        {
            //litTopMostIssued.Text = "<p>No Most Issued Item!!</p>";
        }
    }

    private void Panel4()
    {
        var sb = new StringBuilder();
        List<string> MyList = dbm.GetZeroBalanceItem();

        var collection = MyList;

        if (collection.Count != 0)
        {
            sb.Append("<ul class=\"results\">");

            foreach (var item in collection)
            {
                sb.Append("<li>" + item.ToString() + "</li>");
            }
            sb.Append("</ul>");

        //    litZeroBal.Text = sb.ToString();
        }
        else
        {
         //   litZeroBal.Text = "<p>No Zero Balance Items!!</p>";
        }

    }

    private void Panel5()
    {
        var sb = new StringBuilder();
        List<string> MyList = dbm.GetTop5GIN();

        var collection = MyList;

        if (collection.Count != 0)
        {
            sb.Append("<ul class=\"results\">");

            foreach (var item in collection)
            {
                sb.Append("<li>" + item.ToString() + "</li>");
            }
            sb.Append("</ul>");

       //     lit5GIN.Text = sb.ToString();
        }
        else
        {
         //  lit5GIN.Text = "<p>NO Items!!</p>";
        }

    }

    private void Panel6()
    {
        var sb = new StringBuilder();
        List<string> MyList = dbm.GetTop5GRN();

        var collection = MyList;

        if (collection.Count != 0)
        {
            sb.Append("<ul class=\"results\">");

            foreach (var item in collection)
            {
                sb.Append("<li>" + item.ToString() + "</li>");
            }
            sb.Append("</ul>");

      //     lit5GRN.Text = sb.ToString();
        }
        else
        {
  //      lit5GRN.Text = "<p>No Items!!</p>";
        }

    }

    private void Panel7()
    {
        var sb = new StringBuilder();
        List<string> MyList = dbm.GetTransLog();

        var collection = MyList;

        if (collection.Count != 0)
        {
            sb.Append("<ul class=\"results\">");

            foreach (var item in collection)
            {
                sb.Append("<li>" + item.ToString() + "</li>");
            }
            sb.Append("</ul>");

       //     litTrans.Text = sb.ToString();
             
        }
        else
        {
      //      litTrans.Text = "<p>No Items!!</p>";
        }

    }

    private void Panel8()
    {


        //Panel to Show UNReceived GIN Record, Issued From Main Store But Pending at Branch 

        DBParaSetup();


        var sb = new StringBuilder();
        List<string> MyList = dbm.GetUNRGinList();

        var collection = MyList;


        if (collection.Count != 0)
        {
            sb.Append("<h3>UNReceived GIN:</h3><ul class=\"results\">");

            foreach (var item in collection)
            {
                sb.Append("<li>" + item.ToString() + "</li>");
            }
            sb.Append("</ul>");

        //    litUNRGIN.Text = sb.ToString();


        }
        else
        {
       //     litUNRGIN.Text = "<p>No UNReceived GIN Pending!!</p>";

        }
    
    
    
    
    
    }

    #endregion




    }
}