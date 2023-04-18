using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Runtime.Serialization.Json;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Menu;
using BLL;



/// <summary>
/// Class Default. This is Main Project Startup File where Validate User Methog Authenticate User After Login / Redirecting From the ERP Portal.
/// </summary>
public partial class Default : System.Web.UI.Page 
{

    #region Class Level Objects    

    /// <summary>
    /// The uman
    /// This User Manager Class is use to Authenticate Logined User.
    /// </summary>
       UserManager Uman = new UserManager();

    #endregion

       protected void Page_Load(object sender, EventArgs e)
       {
           //Webconfig Encryption Code-----------

           //Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
           //ConnectionStringsSection connSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

           //connSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

           //config.Save();
           
           
           if (Page.IsPostBack == false)
           {
               ValidateUser();
           }
       }



    #region Helper Methods

       private void DeleteCookies()
       { 
       
           HttpCookie aCookie;
           string cookieName;
           int limit = Request.Cookies.Count - 1;
           for (int i = 0; i <= limit; i++)
           {
               cookieName = Request.Cookies.Get(i).Name;
               aCookie = new HttpCookie(cookieName);
               aCookie.Expires = DateTime.Now.AddDays(-1);
               Response.Cookies.Add(aCookie);
           }
       }


       private void ExpireAllCookies()
       {
           if (HttpContext.Current != null)
           {
               int cookieCount = HttpContext.Current.Request.Cookies.Count;
               for (var i = 0; i < cookieCount; i++)
               {
                   var cookie = HttpContext.Current.Request.Cookies[i];
                   if (cookie != null)
                   {
                       var cookieName = cookie.Name;
                       var expiredCookie = new HttpCookie(cookieName) { Expires = DateTime.Now.AddDays(-1) };
                       HttpContext.Current.Response.Cookies.Add(expiredCookie); // overwrite it
                   }
               }

               // clear cookies server side
               HttpContext.Current.Request.Cookies.Clear();
           }
       }

       /// <summary>
       /// Validates the user. 
       /// This Method is use to Autheicate User by his/her User ID and update User Manager Properties according to their Branch,Department,Name and Rights.
       /// </summary>
    private void ValidateUser()
    {
        UserManager udt = Uman.Userdetail();

        string strUser = string.Empty;




//strUser = "95"; //	MIRZA BASIT ALI BAIG MR.	Head Office

//strUser = "166"; //   ZAHID HUSSAIN MR.	Head Office
//strUser = "113"; //	NABIL-UR-REHMAN SIDDIQUI MR.	Head Office
//strUser = "152"; //	NAYYER JAMAL MR.	Head Office
  //strUser = "93"; //	SALMAN KHAN MR.	Head Office

//strUser = "1607"; //	IQBAL KHAN MR.	FPS Hyderabad Office

//strUser = "2924"; //	Capt. Shahrukh Khan MR.	Head Office
//strUser = "79"; //	Raza K. Minhas MR.	Head Office
//strUser = "82"; //	Yasmeen Raza Minhas MRs.	Head Office

//strUser = "10415"; //	MUHAMMAD ALI IBRAHIM MR.	Head Office

 //strUser = "1527" ; //	SHAKIR ALI MR.	Head Office - STORE

//---2052, 2174


//strUser = "10400"; //  46208-pwd saba7782	SABAH AMIN SHEIKH  MS.	HeadOffice Store Incharge 

  // strUser = "119"; //	SYED UZAIR ALI	Head Office
 

//strUser = "1998"; //	SYED Maqbool Hassan - Operation Dept-Head Office


//strUser = "508"; //	COl. Sami Ullah Khan MR.	FPS Hyderabad
//strUser = "2443"; //	Qazi Owais MR.	FPS Hyderabad

//strUser = "94"; //	RAMLA JAMEEL MRS.	HeadOffice Store Incharge         
//strUser = "2314"; //	KHURRAM KHATRI  MR.	Head Office FINANCE

//strUser = "8"; //	    Mr. Robert(SCIENCE LAB INCHARGE - ALV)
//strUser = "31"; //	MOHAMMAD ASLAM (SCIENCE LAB INCHARGE - ALV)
//strUser = "2524"; //	MOHAMMAD JAMIL (SCIENCE LAB INCHARGE -  NCO)
//strUser = "878"; //	Mr.Fazal-uz-zaman Khan(SCIENCE LAB INCHARGE -  HSS CC)
//strUser = "752"; //	MOHAMMAD Aamir (SCIENCE LAB INCHARGE -  HSS JH)
//strUser = "192"; //	MS. WAJEEHA (SCIENCE LAB INCHARGE -  HABC)
//strUser = "2369"; //	MR. FAISAL (SCIENCE LAB INCHARGE -  OLDC)

  //strUser = "36518"; //NAJAM UL HUSSAIN HASHMI	A Level Campus
 strUser = "659"; //	MUHAMMED AMIR MR.
//strUser = "14808"; // SYED WASEEM ABBAS MR. Elementary Campus
// strUser = "708"; //	MOHAMMAD NOOR UL ISLAM MR.	Elementary Section (KMCHS)
//strUser = "271"; //	SYED FAHAD HUSSAIN MR.	Junior Campus North Nazimabad

 // strUser = "14740";  // ABDULLAH RAUF MR. Junior Campus

        //strUser = "37783";  // MUHAMMAD AHSAN SHARIF --- FPS Malir Campus

//strUser = "2002"; //	SYED NAWAZ ALI MR.	North Campus Junior 
//strUser = "1488"; //	ISMAT MR.	O Level North Campus
//strUser = "9291"; //	NOMAN SIDDIQUI MR.  O Level Defence Campus  

//strUser = "2451"; //	Saadat Ashrafi MR.	Head Start Pre PECHS 
//strUser = "17044"; //BENSON WILLIAM MR.		Head Start Pre PECHS 
//strUser = "8173"; //	Niaz Babar Naseeb MR.	Head Start Kindergarten PECHS
//strUser = "2042"; //	STEPHENSON GILL MR.	Head Start Junior PECHS
 //strUser = "715"; // MUHAMMAD IRFAN KHAN MR. MR. - HSS Junior High PEHS
 //strUser = "708"; //	NOOR-UL-ISlam MR.	Head Start Kindergarten Gulshan
//strUser = "2561"; //MOHAMMAD AMIR KHAN MR. Head Start Kindergarten Gulshan
//strUser = "8146"; //	SAAD MR.	Head Start Junior Gulshan
//strUser = "740"; //	MUHAMMAD NABEEL MR.	Head Start O LEVEL Gulshan
//strUser = "827"; //	Wasif George MR.	Head Start Clifton K
//strUser = "10527"; //	MOHAMMAD AHSAN SHARIF MR.	Head Start Clifton K

 //strUser = "19074"; //	AMIT KUMAR HARJIWAN MS.	Head Start Clifton K
        
//strUser = "2577"; //	RIZWAN WARSI MR.	Head Start Clifton Campus
//strUser = "1566"; //	MOHAMMAD NOUSHAD RAFIQUE MR.	Head Start Kindergarten North Nazimabad 

//strUser = "1882"; //MARYAM ARIF MS.  Head Start Kindergarten North Nazimabad 

//strUser = "2615"; //	Muhammad Aamir MR.	Defence Campus
//strUser = "2245"; //	ZEESHAN AHMED KHAN MR.	Autobahn School
//strUser = "25483"; //	RAFI UR REHMAN MR.	Autobahn School
//strUser = "16873"; //	SHAKIR ALI MALIK MR.	Elementary Section
//strUser = "21173"; //  ADIL MANZOOR  MR.  -- HYD Junior Section

//strUser = "8149"; //	SAAD BIN SAEED MR.  Elm EXT HYD

//41901  // 

//strUser = "89"; //	MURAD HUSSAIN MR.	FPS Sports Dept
 //strUser = "157"; //	FAHAD ALI AGHA MR.	HSS Sports Dept
// strUser = "459"; //	NAVEED GUL MOHAMMAD MR. FPS Sports Dept  -- NC O Level

 //strUser = "26499"; //	SADAF ADNAN MS. FPS Sports Dept  -- NC O Level
        

//strUser = "396"; //	FAWAD AMJAD ALI MR. FPS Sports Dept  -- O Level Defence


//strUser = "21"; //	SYED SHAHANSHAH H.HAMDANI MR. FPS Sports Dept  -- A Level
//strUser = "2420"; //	MUHAMMAD FARRUKH MR. FPS Sports Dept  -- Junior DHA
//strUser = "2192"; //	MUHAMMAD SAJJAD MUSHTAQ  MR. FPS Sports Dept  -- Junior Adamjee
//strUser = "383"; //	MOHAMMAD FAHIM MR. FPS Sports Dept  -- OLDC
//strUser = "396";  // FAWAD AMJAD ALI MR.   OLDC
//strUser = "16876"; //	ZAIN KHAN MR. FPS Sports Dept  -- NC Junior
//strUser = "17009"; //	HAMAIL TAHIR MS. FPS Sports Dept  -- ELM-Shah Faisal

//strUser = "2141"; //	SYED FOUZ UL HASSAN MR. FPS Sports Dept  -- HSS PRE

 //strUser = "23398";   //SALIMA IRFAN MRS. FPS Sports Dept  -- ELM-Shah Faisal

//strUser = "21"	A Level Campus
//strUser = "89"	Head Office
//strUser = "157"	Head Office
//strUser = "383"	O Level Defence Campus
//strUser = "396"	O Level Defence Campus
//strUser = "459";	//O Level North Campus
//strUser = "712"	Head Start Clifton Campus
//39150--HINA WARSI
//strUser = "1651"	Head Start Junior PECHS
//strUser = "1904"	Head Start Kindergarten North Nazimabad
//strUser = "1955";	//Head Start Clifton Campus
//strUser = "2141"	Head Start Pre PECHS
//strUser = "2192"	Junior Campus Mohammad Ali Society
//strUser = "2420"	Junior Campus Defence
//strUser = "2825"	Head Start Junior Gulshan
//strUser = "8143";	Junior Campus Mohammad Ali Society
//strUser = "10452";	//Head Start Junior High PECHS
// strUser = "10576";	//Head Start Kindergarten Gulshan
//strUser = "31769";	//Head Start O' Levels Gulshan
//strUser = "16876"	North Campus Junior
 //strUser = "16985";	//O Level North Campus
//strUser = "23398";	//Elementary Section Shahrah-e-Faisal



        //if (Request.Cookies["user"] != null)
        //    strUser = Request.Cookies["user"]["eid"].ToString();
        //else
        //    Response.Redirect("logout.aspx");




        UserManager um = Uman.GetUserInfo(int.Parse(strUser));


           if (um.Uname != string.Empty && um.Uname != null)
           {
               if (Request.Cookies["IMS"] != null)
                   Request.Cookies["IMS"].Expires = DateTime.Now.AddDays(-1);


               HttpCookie IMS = new HttpCookie("IMS");

               IMS["sysid"] = um.Sysid.ToString();
               IMS["comid"] = um.Pkcomid.ToString();
               IMS["uid"] = um.Uid.ToString();
               IMS["uname"] = um.Uname;
               IMS["ugroupid"] = um.Ugid.ToString();
               IMS["uemail"] = um.Uemail;
               IMS["BranchName"] = um.Brhname.ToString();
               IMS["Department"] = um.Udept.ToString();
               IMS["ubrhid"] = um.Ubrhid.ToString();
               IMS["udptid"] = um.Pkdeptid.ToString();
               IMS["grpuserdptid"] = um.Grpuserdeptid.ToString();
               IMS["grpuserbrhid"] = um.Grpuserbrhid.ToString();
               IMS["grpuserstoreid"] = um.Grpuserstoreid.ToString();

               IMS["UCity"] = um.Pkcityid.ToString();
               IMS["UCell"] = um.Ucell.ToString();

               Response.Cookies.Add(IMS);


               //if (um.Ugid==79)
               //{
               //    um.Pkdeptid = 17;
               //    IMS["udptid"] = "17";
                   
               //}

              // Response.Redirect("WorkOrder.aspx");

               if (um.Ugid==28)
               {
                 Response.Redirect("WarehouseMain.aspx");
                  // Response.Redirect("IssueQuickInventory.aspx");
               }
               else
               {
                   Response.Redirect("Main.aspx");
               }

               //Response.Redirect("frmInventoryFilter.aspx");
           }

           else
               Response.Write("<script language='javascript'> alert('Access Denied.'); window.close(); </script>");
       }

    #endregion

    /// <summary>
    /// Sends the SMS. This Method is use to Execute/Send Mobile SMS to the Given User as per Given Message on selected Mobile Number(s).
    /// </summary>
    /// <param name="touser">The touser. This parameter is use to assign User Mobile Number.</param>
    /// <param name="msg">The MSG. This parameter is use to Add Text Message for SMS.</param>
    public static void SendSMS(string touser, string msg)
    {

        string httpadd = "http://221.132.117.58:7700/sendsms_url.html?Username=03028501537&Password=123.123&From=FPS-KHI&To=";

        string mymessage = "&Message=" + msg;


        WebRequest request = WebRequest.Create("http://221.132.117.58:7700/sendsms_url.html?Username=03028501537&Password=123.123&From=FPS-KHI&To=" + touser + mymessage);
        WebResponse response = request.GetResponse();


           // // Create a request using a URL that can receive a post. 
           //WebRequest request = WebRequest.Create(myrequest);
           // // Set the Method property of the request to POST.
           // request.Method = "POST";
           // // Create POST data and convert it to a byte array.
           // string postData = "This is a test that posts this string to a Web server.";
           // byte[] byteArray = Encoding.UTF8.GetBytes(postData);
           // // Set the ContentType property of the WebRequest.
           // request.ContentType = "application/x-www-form-urlencoded";
           // // Set the ContentLength property of the WebRequest.
           // request.ContentLength = byteArray.Length;
           // // Get the request stream.
           // Stream dataStream = request.GetRequestStream();
           // // Write the data to the request stream.
           // dataStream.Write(byteArray, 0, byteArray.Length);
           // // Close the Stream object.
           // dataStream.Close();
           // // Get the response.
           // WebResponse response = request.GetResponse();
           // // Display the status.
           // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
           // // Get the stream containing content returned by the server.
           // dataStream = response.GetResponseStream();
           // // Open the stream using a StreamReader for easy access.
           // StreamReader reader = new StreamReader(dataStream);
           // // Read the content.
           // string responseFromServer = reader.ReadToEnd();
           // // Display the content.
           // //Console.WriteLine(responseFromServer);
           // // Clean up the streams.
           // reader.Close();
           // dataStream.Close();
           // response.Close();
      
    }



}
