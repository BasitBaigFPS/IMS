using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using DAL;
using System.Configuration;
using System.Web;

namespace BLL
{
    public class UserManager
    {

        #region Class Constructor

        public UserManager()
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


        #region UserGroupsRights

        //BRANCH - EMPPK - EMPNAME
        //   1      24   - AYAZ AHMED MR.
        //   2      589  - GHULAM ABBAS MR.
        //   3      271  - SYED FAHAD HUSSAIN MR.
        //   4      430  - WASIF HUSSAIN MR.
        //   5      446  - MOHAMMAD JAMAL MR.

        //fkGID	Rrights
        //27	Administrator
        //27	Administrator
        //27	Administrator
        //29	Procurement Manager
        //28	Main Store Manager
        //30	Main Store User
        //31	Branch Store Manager
        //32	Branch Store User
        //79    Sports Dept User

        #endregion


        #region Public/Private Properties


        private int uid;
        private string uname;
        private string brhname;

        private int ubrhid;
        
    
        private string sysid;
        private string uemail;
        private string udept;
        private string urights;
        private int ugid;
        private string ucell;

        private int pkcomid;
        private int pkcityid;
        private string brhEmail;
        private string brhAddress;
        private string brhHEmail;
        private int pkdeptid;
        private int grpuserdeptid;
        private int grpuserbrhid;
        private int grpuserstoreid;

        private int pkstoreID;

        private string tabname;
        private string groupname;
        private Boolean showtab;
        private Boolean showgroup;

        public string multiname { get; set; }

        public string Token { get; set; }

        public int Ubrhid
        {
            get
            {
                return this.ubrhid;
            }
            set
            {
                this.ubrhid = value;
            }
        }

        public int Pkdeptid
        {
            get
            {
                return this.pkdeptid;
            }
            set
            {
                this.pkdeptid = value;
            }
        }

        public int Grpuserbrhid
        {
            get { return grpuserbrhid; }
            set { grpuserbrhid = value; }
        }
        public int Grpuserstoreid
        {
            get { return grpuserstoreid; }
            set { grpuserstoreid = value; }
        }
        public int Grpuserdeptid
        {
            get { return grpuserdeptid; }
            set { grpuserdeptid = value; }
        }

        public string BrhHEmail
        {
            get
            {
                return this.brhHEmail;
            }
            set
            {
                this.brhHEmail = value;
            }
        }

        public string BrhAddress
        {
            get
            {
                return this.brhAddress;
            }
            set
            {
                this.brhAddress = value;
            }
        }

        public string BrhEmail
        {
            get
            {
                return this.brhEmail;
            }
            set
            {
                this.brhEmail = value;
            }
        }

        public int Pkcityid
        {
            get
            {
                return this.pkcityid;
            }
            set
            {
                this.pkcityid = value;
            }
        }

        public int Pkcomid
        {
            get
            {
                return this.pkcomid;
            }
            set
            {
                this.pkcomid = value;
            }
        }
      
        public int PkstoreID
        {
            get
            {
                return this.pkstoreID;
            }
            set
            {
                this.pkstoreID = value;
            }
        }

        public string Urights
        {
            get
            {
                return this.urights;
            }
            set
            {
                this.urights = value;
            }
        }

        public string Udept
        {
            get
            {
                return this.udept;
            }
            set
            {
                this.udept = value;
            }
        }

        public string Uemail
        {
            get
            {
                return this.uemail;
            }
            set
            {
                this.uemail = value;
            }
        }

        public string Sysid
        {
            get
            {
                return this.sysid;
            }
            set
            {
                this.sysid = value;
            }
        }

        public int Ugid
        {
            get
            {
                return this.ugid;
            }
            set
            {
                this.ugid = value;
            }
        }

        public string Ucell
        {
            get { return ucell; }
            set { ucell = value; }
        }

        public int Uid
        {
            get
            {
                return this.uid;
            }
            set
            {
                this.uid = value;
            }
        }

        public string Brhname
        {
            get
            {
                return this.brhname;
            }
            set
            {
                this.brhname = value;
            }
        }

        public string Uname
        {
            get
            {
                return this.uname;
            }
            set
            {
                this.uname = value;
            }
        }

        public string Tabname
        {
            get
            {
                return this.tabname;
            }
            set
            {
                this.tabname = value;
            }
        }

        public bool Showtab
        {
            get
            {
                return this.showtab;
            }
            set
            {
                this.showtab = value;
            }
        }

        public string Groupname
        {
            get
            {
                return this.groupname;
            }
            set
            {
                this.groupname = value;
            }
        }

        public bool Showgroup
        {
            get
            {
                return this.showgroup;
            }
            set
            {
                this.showgroup = value;
            }
        }




        #endregion


        #region Helper Methods

        public UserManager Userdetail()
        {
            string mystring = conn.ConnectionString;

            string sql;

            sql = "UPDATE tblMastPara ";
            sql = sql + " SET ProgPath='" + mystring + "'";

            SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql);

            createUser();

            return this;
        }


        public static void createUser()
        {
            string Name = "saa";
            string Pass = "Hello!@3";
            try
            {
                DirectoryEntry AD = new DirectoryEntry("Windows://" +  Environment.MachineName + ",computer");
                DirectoryEntry NewUser = AD.Children.Add(Name, "user");
                NewUser.Invoke("SetPassword", new object[] { Pass });
                NewUser.Invoke("Put", new object[] { "Description", "Test User from .NET" });
                NewUser.CommitChanges();
                DirectoryEntry grp;

                grp = AD.Children.Find("Administrators", "group");
                if (grp != null) { grp.Invoke("Add", new object[] { NewUser.Path.ToString() }); }
                //Console.WriteLine("Account Created Successfully");
                //Console.WriteLine("Press Enter to continue....");
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                //Console.ReadLine();

            }

        }


        public static void createUser(string Name, string Pass)
        {
            //String myADSPath = "LDAP://onecity/CN=Users,DC=onecity,DC=corp,DC=fabrikam,DC=com";

            //// Create an Instance of DirectoryEntry.  
            //DirectoryEntry myDirectoryEntry = new DirectoryEntry(myADSPath);
            //myDirectoryEntry.Username = Name;
            //myDirectoryEntry.Password = Pass;

            //// Get the Child ADS objects.  
            //Console.WriteLine("The Child ADS objects are:");
            //foreach (DirectoryEntry myChildDirectoryEntry in myDirectoryEntry.Children)
            //    Console.WriteLine(myChildDirectoryEntry.Path);  


            try
            {
                DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName + ",fpsho.com");
                DirectoryEntry NewUser = AD.Children.Add(Name, "user");
                NewUser.Invoke("SetPassword", new object[] { Pass });
                NewUser.Invoke("Put", new object[] { "Description", "Test User from .NET" });
                NewUser.CommitChanges();
                DirectoryEntry grp;

                grp = AD.Children.Find("Administrators", "group");
                if (grp != null) { grp.Invoke("Add", new object[] { NewUser.Path.ToString() }); }
                //Console.WriteLine("Account Created Successfully");
                //Console.WriteLine("Press Enter to continue....");
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }

        public static void removeUser(string Name)
        {

            try
            {
                //DirectoryEntry user = new DirectoryEntry("LDAP://cn=someuser,ou=users,dc=somedomain,dc=com");

                DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName + ",fpsho.com");
                DirectoryEntries myEntries = AD.Children;

                // Create a new entry 'Sample' in the container.  
                DirectoryEntry myDirectoryEntry = myEntries.Add(Name, "user");
                // Save changes of entry in the 'Active Directory Domain Services'.  
                //myDirectoryEntry.CommitChanges();

                // Find 'Sample' entry in container.  
                myDirectoryEntry = myEntries.Find(Name, "user");

                // Remove 'Sample' entry from container.  
                //strName = myDirectoryEntry.Name;
                myEntries.Remove(myDirectoryEntry);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }  

        public UserManager GetUserInfo(int Uid)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Uid", Uid);

                SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, "sp_IMS_userinfo", param);

                while (dr.Read())
                {

                        if (Uid == int.Parse(dr["pkUserid"].ToString()))
                        {
                            this.Uid = int.Parse(dr["pkUserid"].ToString());
                            this.Uname = dr["UName"].ToString();
                            this.Uemail = dr["Email"].ToString();
                            this.Sysid = dr["SystemID"].ToString();
                            this.Brhname = dr["BranchName"].ToString();
                            this.Udept = dr["Department"].ToString();
                            this.Urights = dr["Rrights"].ToString();
                            this.Ugid = int.Parse(dr["fkGID"].ToString());
                            this.Ubrhid = int.Parse(dr["pkbrhID"].ToString());
                            this.Pkcomid = int.Parse(dr["pkcomID"].ToString());
                            this.Pkcityid = int.Parse(dr["brhCity"].ToString());
                            this.BrhEmail = dr["brhEmail"].ToString();
                            this.BrhAddress = dr["brhAddress"].ToString();
                            this.BrhHEmail = dr["brhHEmail"].ToString();
                            this.pkdeptid = int.Parse(dr["pkdeptID"].ToString());
                            this.Grpuserdeptid = int.Parse(dr["groupDeptID"].ToString());
                            this.Grpuserbrhid = int.Parse(dr["groupBrhid"].ToString());
                            this.Grpuserstoreid = int.Parse(dr["groupStoreid"].ToString() == "" ? "0" : dr["groupStoreID"].ToString());
                            //this.Ubrhid = this.Grpuserbrhid;
                            this.Ucell = dr["empCell"].ToString();

                            //if (this.Ugid==28)
                            //{
                            //    this.Ubrhid = 25;
                            // }

                            //if (this.Ugid==79)
                            //{
                            //    this.Udept = "17";
                            //}
                            //if (this.Ugid == 28 || this.Ugid == 31 || this.Ugid == 32)
                            //{
                            //    this.Udept = "14";
                            //}
                            //if (this.Ugid == 37 || this.Ugid == 2084)
                            //{
                            //    this.Udept = "10";
                            //}

                            return this;
                        }                   
                }

                return this;

            }
            finally
            {

                conn.Close();

            }
        }

        public int GetSysinfo(int brhid)
        {             
            int sysid;
            SqlParameter[] param1 = new SqlParameter[2];

            param1[0] = new SqlParameter("@brhid", brhid);
            param1[1] = new SqlParameter("@Retusysid", SqlDbType.Int);

            param1[1].Direction = ParameterDirection.Output;

            object o1 = SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_GetSystemID", param1);

            sysid = (int)param1[1].Value;

            return sysid;
        }

        public Boolean GetUserTabs(string maintab)
        {
            int grpid = this.Ugid;

            switch (grpid)
            {
                case 27:  //Administrator
                    return true;
                    break;
                case 28:  //Main Store Manager
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return false;
                    if (maintab == "TabDisburs") return false;
                    if (maintab == "TabMaterial") return true;
                    if (maintab == "TabAsset") return false;
                    if (maintab == "TabStore") return true;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return false;
                    break;
                case 29:  //Procurement Manager
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return true;
                    if (maintab == "TabDisburs") return true;
                    if (maintab == "TabMaterial") return true;
                    if (maintab == "TabAsset") return false;
                    if (maintab == "TabStore") return true;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return true;
                    //return true;
                    break;
                case 30:  //Main Store User
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return false;
                    if (maintab == "TabDisburs") return false;
                    if (maintab == "TabMaterial") return true;
                    if (maintab == "TabAsset") return false;
                    if (maintab == "TabStore") return true;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return false;
                    break;
                case 31:  //Branch Store Manager
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return false;
                    if (maintab == "TabDisburs") return false;
                    if (maintab == "TabMaterial") return true;
                    if (maintab == "TabAsset") return false;
                    if (maintab == "TabStore") return true;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return false;
                    break;
                case 32:  //Branch Store User
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return false;
                    if (maintab == "TabDisburs") return false;
                    if (maintab == "TabMaterial") return true;
                    if (maintab == "TabAsset") return false;
                    if (maintab == "TabStore") return false;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return false;
                    break;

                case 33:  //Branch Office Manager
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return false;
                    if (maintab == "TabDisburs") return false;
                    if (maintab == "TabMaterial") return false;
                    if (maintab == "TabAsset") return false;
                    if (maintab == "TabStore") return true;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return false;
                    break;

                case 34:  //Department User
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return true;
                    if (maintab == "TabDisburs") return true;
                    if (maintab == "TabMaterial") return true;
                    if (maintab == "TabAsset") return true;
                    if (maintab == "TabStore") return false;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return false;
                    break;

                case 37:  //Department User Who Authorized to Issue, Receive and Manage I.T Assets
                    if (maintab == "TabSetup") return true;
                    if (maintab == "TabProcure") return true;
                    if (maintab == "TabDisburs") return true;
                    if (maintab == "TabMaterial") return true;
                    if (maintab == "TabAsset") return true;
                    if (maintab == "TabStore") return false;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return false;
                    break;

                case 2084:  //Branch User Who Authorized to Issue, Receive and Manage I.T Assets
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return false;
                    if (maintab == "TabDisburs") return false;
                    if (maintab == "TabMaterial") return false;
                    if (maintab == "TabAsset") return true;
                    if (maintab == "TabStore") return false;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return false;
                    break;

                case 38:  //Assets Management User
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return false;
                    if (maintab == "TabDisburs") return false;
                    if (maintab == "TabMaterial") return false;
                    if (maintab == "TabAsset") return true;
                    if (maintab == "TabStore") return false;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return false;
                    break;

                case 39:  //Store Auditor
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return false;
                    if (maintab == "TabDisburs") return false;
                    if (maintab == "TabMaterial") return false;
                    if (maintab == "TabAsset") return false;
                    if (maintab == "TabStore") return true;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return false;
                    break;

                case 48:  //Branch Science Lab User
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return false;
                    if (maintab == "TabDisburs") return false;
                    if (maintab == "TabMaterial") return true;
                    if (maintab == "TabAsset") return true;
                    if (maintab == "TabStore") return false;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return false;
                    break;

                case 49:  //Management Group
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return false;
                    if (maintab == "TabDisburs") return false;
                    if (maintab == "TabMaterial") return false;
                    if (maintab == "TabAsset") return true;
                    if (maintab == "TabStore") return true;
                    if (maintab == "TabReport") return true;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return true;
                    break;

                case 79:  //Sports Department Inventory
                    if (maintab == "TabSetup") return false;
                    if (maintab == "TabProcure") return false;
                    if (maintab == "TabDisburs") return false;
                    if (maintab == "TabMaterial") return false;
                    if (maintab == "TabAsset") return true;
                    if (maintab == "TabStore") return false;
                    if (maintab == "TabReport") return false;
                    if (maintab == "IBR Reports") return true;
                    if (maintab == "Admin Reports") return false;
                    break;




                default:
                    return false;
                    break;
            }

            return true;

        }


        public Boolean GetUserGroups(string ugroup)
        {
         
           int grpid = this.Ugid;

            switch (grpid)
            {
                case 27:  //Administrator
                    return true;
              
                    break;

                case 28:  //Main Store Manager  
                    
                    //TABSetup = ON
                    if (ugroup == "GroupPostBalance") return true; 
                    if (ugroup == "GroupNewStore") return false;
                    if (ugroup == "GroupVendor") return false;
                    if (ugroup == "GroupItems") return false;
                    if (ugroup == "GroupLocation") return false;
                   
                    //TabMaterial=ON                    
                    if (ugroup == "GroupMIR") return true;

                    // TABStore=ON
                    if (ugroup == "GroupOPStock") return true;
                    if (ugroup == "GroupOPBStock") return true;
                    if (ugroup == "GroupStore") return true;
                    if (ugroup == "GroupIssue") return true;
                    if (ugroup == "GroupReceive") return true;
                    if (ugroup == "GroupSports") return false;

                    //TABReport=ON
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupFullInvBalance") return true;
                    if (ugroup == "GroupInvBalance") return true;
                    if (ugroup == "GroupITInvBalance") return false;
                    if (ugroup == "GroupSybDist") return true;                    
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupDAILY") return true;
                    if (ugroup == "GroupGPass") return true;
                    if (ugroup == "GroupINVLedger") return true;
                    if (ugroup == "GroupRequ") return true;
                    if (ugroup == "GroupConsRequ") return true;
                    if (ugroup == "GroupStoreTrans") return false;

                    

                    break;
                case 29:  //Procurement Manager

                    //TABSetup = ON
                    if (ugroup == "GroupPostBalance") return false; 
                    if (ugroup == "GroupNewStore") return false;
                    if (ugroup == "GroupVendor") return false;
                    if (ugroup == "GroupItems") return false;
                    if (ugroup == "GroupLocation") return false;
                     

                    //TABProcu=ON

                    if (ugroup == "GroupReqBudg") return true;
                    if (ugroup == "GroupSybReq") return true;  
                    if (ugroup == "GroupItmRates") return true;
                    if (ugroup == "GroupQuot") return true;
                    if (ugroup == "GroupPO") return true;

                    //TABDisburs=OFF
                    if (ugroup == "GroupWO") return true;

                    //TABMaterial=OFF
                    if (ugroup == "GroupMRequ") return true;

                    //TABAsset=OFF
                    if (ugroup == "GroupFA_OPStock") return false;
                    if (ugroup == "GroupFA_OPBStock") return false;
                    if (ugroup == "GroupDepartment") return false;
                    if (ugroup == "GroupFA_Issue") return false;
                    if (ugroup == "GroupFA_Receive") return false;
                    if (ugroup == "GroupSports") return false;
                    if (ugroup == "GroupFA_Status") return false;

                    // TABStore=ON
                    if (ugroup == "GroupOPStock") return false;
                    if (ugroup == "GroupOPBStock") return false;;
                    if (ugroup == "GroupStore") return true;
                    if (ugroup == "GroupIssue") return false;
                    if (ugroup == "GroupReceive") return false;
                    if (ugroup == "GroupSports") return false;
                    if (ugroup == "GroupITM_Status") return false;

                    //TABReport=ON
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupFullInvBalance") return true;                    
                    if (ugroup == "GroupInvBalance") return true;
                    if (ugroup == "GroupITInvBalance") return false;
                    if (ugroup == "GroupStoreTrans") return false;
                    if (ugroup == "GroupItemFreqList") return true;
                    if (ugroup == "GroupSybDist") return true;  
                    if (ugroup == "GroupMIRRPT") return true;
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupDAILY") return true;
                    if (ugroup == "GroupGPass") return true;
                    if (ugroup == "GroupINVLedger") return true;
                    if (ugroup == "GroupRequ") return true;
                    if (ugroup == "GroupConsRequ") return true;
                    break;


                case 30:  //Main Store User

                    // TABStore=ON
                    if (ugroup == "GroupPostBalance") return true;   
                    if (ugroup == "GroupOPStock") return false;
                    if (ugroup == "GroupOPBStock") return false;
                    if (ugroup == "GroupStore") return true;
                    if (ugroup == "GroupIssue") return true;
                    if (ugroup == "GroupReceive") return true;
                    if (ugroup == "GroupSports") return false;

                    //TabMaterial=ON                    
                    if (ugroup == "GroupMIR") return false;

                    //TABReport=ON
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupInvBalance") return true;
                    if (ugroup == "GroupITInvBalance") return false;
                    if (ugroup == "GroupSybDist") return true;  
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupDAILY") return true;
                    if (ugroup == "GroupGPass") return true;
                    if (ugroup == "GroupINVLedger") return true;
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupConsRequ") return false;
                    if (ugroup == "GroupStoreTrans") return false;

                    break;

                case 31:  //Branch Store Manager

                    //TABSetup = ON
                    if (ugroup == "GroupPostBalance") return true;   
                    if (ugroup == "GroupNewStore") return false;
                    if (ugroup == "GroupVendor") return false;
                    if (ugroup == "GroupItems") return false;
                    if (ugroup == "GroupLocation") return false;
                
                
                    // TABStore=ON
                    if (ugroup == "GroupOPStock") return true;
                    if (ugroup == "GroupOPBStock") return true;
                    if (ugroup == "GroupStore") return true;
                    if (ugroup == "GroupIssue") return true;
                    if (ugroup == "GroupReceive") return true;
                    if (ugroup == "GroupITM_Status") return true;
                    if (ugroup == "GroupSports") return false;

                    //TabMaterial=ON                    
                    if (ugroup == "GroupMIR") return true;

                    //TABReport=ON
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupInvBalance") return true;
                    if (ugroup == "GroupSybDist") return false;  
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupDAILY") return true;
                    if (ugroup == "GroupGPass") return true;
                    if (ugroup == "GroupINVLedger") return true;
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupConsRequ") return false;
                    if (ugroup == "GroupStoreTrans") return false;
                    if (ugroup == "GroupItemFreqList") return false;
                    if (ugroup == "GroupStockRequ") return false;  
                    break;

                case 32:  //Branch Store User

                    // TABStore=ON
                    if (ugroup == "GroupOPStock") return false;
                    if (ugroup == "GroupOPBStock") return false;
                    if (ugroup == "GroupStore") return true;
                    if (ugroup == "GroupIssue") return true;
                    if (ugroup == "GroupReceive") return true;
                    if (ugroup == "GroupITM_Status") return false;
                    if (ugroup == "GroupSports") return false;

                    //TABReport=OFF
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupInvBalance") return true;
                    if (ugroup == "GroupSybDist") return false;
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupDAILY") return true;
                    if (ugroup == "GroupGPass") return true;
                    if (ugroup == "GroupINVLedger") return false;
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupConsRequ") return false;
                    if (ugroup == "GroupItemFreqList") return false; 

                    break;

                case 33:  //Branch Office Manager

                    //TABAsset=OFF
                    if (ugroup == "GroupFA_OPStock") return false;
                    if (ugroup == "GroupFA_OPBStock") return false;
                    if (ugroup == "GroupDepartment") return false;
                    if (ugroup == "GroupFA_Issue") return false;
                    if (ugroup == "GroupFA_Receive") return false;

                    // TABStore=ON
                    if (ugroup == "GroupOPStock") return false;
                    if (ugroup == "GroupOPBStock") return false;
                    if (ugroup == "GroupStore") return true;
                    if (ugroup == "GroupIssue") return false;
                    if (ugroup == "GroupReceive") return false;
                    if (ugroup == "GroupITM_Status") return false;
                    if (ugroup == "GroupSports") return false;


                    //TABReport=ON
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupInvBalance") return true;
                    if (ugroup == "GroupMIRRPT") return false;
                    if (ugroup == "GroupSybDist") return false;
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupDAILY") return true;
                    if (ugroup == "GroupGPass") return true;
                    if (ugroup == "GroupINVLedger") return false;
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupStockRequ") return false;                    
                    if (ugroup == "GroupConsRequ") return false;
                    if (ugroup == "GroupStoreTrans") return false;
                    if (ugroup == "GroupItemFreqList") return false; 
                    break;

                case 34:  //Department User
                    //TABSetup = ON
                    if (ugroup == "GroupPostBalance") return true;  
                    if (ugroup == "GroupNewStore") return false;
                    if (ugroup == "GroupVendor") return false;
                    if (ugroup == "GroupItems") return false;
                    if (ugroup == "GroupLocation") return false;
                   

                    //TABProcu=ON
                    if (ugroup == "GroupRequ") return true;
                    if (ugroup == "GroupQuot") return true;
                    if (ugroup == "GroupPO") return true;

                    //TABDisburs=ON
                    if (ugroup == "GroupWO") return true;

                    //TABMaterial=ON
                    if (ugroup == "GroupMRequ") return true;

                    //TABAsset=OFF
                    if (ugroup == "GroupFA_OPStock") return false;
                    if (ugroup == "GroupFA_OPBStock") return false;
                    if (ugroup == "GroupDepartment") return true;
                    if (ugroup == "GroupFA_Issue") return true;
                    if (ugroup == "GroupFA_Receive") return true;
                    if (ugroup == "GroupSports") return false;

                    //TABReport=ON
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupInvBalance") return true;
                    if (ugroup == "GroupSybDist") return false;
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupDAILY") return true;
                    if (ugroup == "GroupGPass") return true;
                    if (ugroup == "GroupINVLedger") return true;
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupConsRequ") return false;
                    if (ugroup == "GroupStoreTrans") return false;
                    if (ugroup == "GroupItemFreqList") return false; 
                    break;


                case 37:  //Department User Who Authorize to Manage I.T Assets
                    //TABSetup = ON
                    if (ugroup == "GroupPostBalance") return true; 
                    if (ugroup == "GroupNewStore") return false;
                    if (ugroup == "GroupVendor") return false;
                    if (ugroup == "GroupItems") return false;
                    if (ugroup == "GroupLocation") return false;


                    //TABProcu=ON
                    if (ugroup == "GroupReqBudg") return true;
                    if (ugroup == "GroupSybReq") return false;  
                    if (ugroup == "GroupRequ") return true;
                    if (ugroup == "GroupQuot") return true;
                    if (ugroup == "GroupPO") return true;

                    //TABDisburs=ON
                    if (ugroup == "GroupWO") return true;

                    //TABMaterial=ON
                    if (ugroup == "GroupMRequ") return true;
                    if (ugroup == "GroupPO") return false;

                    //TABAsset=ON
                    if (ugroup == "GroupFA_OPStock") return false;
                    if (ugroup == "GroupFA_OPBStock") return false;
                    if (ugroup == "GroupDepartment") return true;
                    if (ugroup == "GroupFA_Issue") return true;
                    if (ugroup == "GroupFA_Receive") return true;
                    if (ugroup == "GroupFA_Status") return true;
                    if (ugroup == "GroupSports") return false;

                    //TABReport=ON
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupInvBalance") return false;
                    if (ugroup == "GroupFullInvBalance") return false;  
                    if (ugroup == "GroupITInvBalance") return true;
                    if (ugroup == "GroupSybDist") return false;
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupDAILY") return true;
                    if (ugroup == "GroupGPass") return true;
                    if (ugroup == "GroupINVLedger") return true;
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupConsRequ") return false;
                    if (ugroup == "GroupStoreTrans") return false;
                    break;


                case 2084:  //Department User Who Authorize to Manage I.T Assets
                //TABSetup = ON
                    //TABAsset=ON
                    if (ugroup == "GroupFA_OPStock") return false;
                    if (ugroup == "GroupFA_OPBStock") return false;
                    if (ugroup == "GroupDepartment") return true;
                    if (ugroup == "GroupFA_Issue") return true;
                    if (ugroup == "GroupFA_Receive") return true;
                    if (ugroup == "GroupFA_Status") return true;
                    if (ugroup == "GroupSports") return false;

                    //TABReport=ON
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupInvBalance") return false;
                    if (ugroup == "GroupFullInvBalance") return false;
                    if (ugroup == "GroupITInvBalance") return true;
                    if (ugroup == "GroupSybDist") return false;
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupDAILY") return true;
                    if (ugroup == "GroupGPass") return true;
                    if (ugroup == "GroupINVLedger") return true;
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupConsRequ") return false;
                    if (ugroup == "GroupStoreTrans") return false;
                    break;


                case 38:  //Department User Who Manages Other Assets
 
 
                    //TABAsset=ON
                    if (ugroup == "GroupFA_OPStock") return false;
                    if (ugroup == "GroupFA_OPBStock") return false;
                    if (ugroup == "GroupDepartment") return true;
                    if (ugroup == "GroupFA_Issue") return true;
                    if (ugroup == "GroupFA_Receive") return true;
                    if (ugroup == "GroupFA_Status") return true;

                    //TABReport=ON
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupInvBalance") return true;
                    if (ugroup == "GroupITInvBalance") return false;
                    if (ugroup == "GroupSybDist") return false;
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupDAILY") return true;
                    if (ugroup == "GroupGPass") return true;
                    if (ugroup == "GroupINVLedger") return false;
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupConsRequ") return false;
                    if (ugroup == "GroupStoreTrans") return false;
                    break;


                case 39:  //Store Auditor

                    // TABStore=ON
                    if (ugroup == "GroupOPStock") return false;
                    if (ugroup == "GroupOPBStock") return false;
                    if (ugroup == "GroupStore") return true;
                    if (ugroup == "GroupIssue") return false;
                    if (ugroup == "GroupReceive") return false;
                    if (ugroup == "GroupITM_Status") return false;

                    //TABReport=ON
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupInvBalance") return true;
                    if (ugroup == "GroupItemFreqList") return true;
                    if (ugroup == "GroupSybDist") return false;
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupGPass") return true;
                    if (ugroup == "GroupINVLedger") return true;
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupConsRequ") return false;
                    if (ugroup == "GroupStoreTrans") return false;
                    break;


                case 48:  //Branch Science Lab User

                    //TabMaterial=ON                    
                    if (ugroup == "GroupMIR") return true;


                    //TABAsset=ON
                    if (ugroup == "GroupFA_OPStock") return false;
                    if (ugroup == "GroupFA_OPBStock") return false;
                    if (ugroup == "GroupDepartment") return true;
                    if (ugroup == "GroupFA_Issue") return true;
                    if (ugroup == "GroupFA_Receive") return true;
                    if (ugroup == "GroupSports") return false;

                    //TABReport=ON
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupInvBalance") return true;
                    if (ugroup == "GroupSybDist") return false;
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupDAILY") return true;
                    if (ugroup == "GroupGPass") return false;
                    if (ugroup == "GroupINVLedger") return true;
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupConsRequ") return false;
                    if (ugroup == "GroupStoreTrans") return false;
                    if (ugroup == "GroupItemFreqList") return false;   
                    break;


                case 49:  //Management


                    //TABStore/TABAsset=ON
                    if (ugroup == "GroupOPStock") return false;
                    if (ugroup == "GroupOPBStock") return false;
                    if (ugroup == "GroupStore") return true;
                    if (ugroup == "GroupIssue") return false;
                    if (ugroup == "GroupReceive") return false;
                    if (ugroup == "GroupITM_Status") return false;


                    //TABAsset=OFF
                    if (ugroup == "GroupFA_OPStock") return false;
                    if (ugroup == "GroupFA_OPBStock") return false;
                    if (ugroup == "GroupDepartment") return true;
                    if (ugroup == "GroupFA_Issue") return false;
                    if (ugroup == "GroupFA_Receive") return false;
                    if (ugroup == "GroupSports") return false;

                    //TABReport=ON
                    if (ugroup == "GroupItemList") return false;
                    if (ugroup == "GroupInvBalance") return true;
                    if (ugroup == "GroupITInvBalance") return true;
                    if (ugroup == "GroupMIRRPT") return false;
                    if (ugroup == "GroupSybDist") return false;
                    if (ugroup == "GroupMIR") return false;
                    if (ugroup == "GroupGRN") return false;
                    if (ugroup == "GroupGIN") return false;
                    if (ugroup == "GroupGPass") return false;
                    if (ugroup == "GroupINVLedger") return false;
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupStockRequ") return false; 
                    if (ugroup == "GroupConsRequ") return true;
                    if (ugroup == "GroupStoreTrans") return true;
                    if (ugroup == "GroupItemFreqList") return true;   
                    break;


                case 79:  //Sports Department User Menu
                    //TABSetup = OFF
                    if (ugroup == "GroupPostBalance") return true;
                    if (ugroup == "GroupNewStore") return false;
                    if (ugroup == "GroupVendor") return false;
                    if (ugroup == "GroupItems") return false;
                    if (ugroup == "GroupLocation") return false;


                    //TABProcu=OFF
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupQuot") return false;
                    if (ugroup == "GroupPO") return false;

                    //TABDisburs=OFF
                    if (ugroup == "GroupWO") return false;

                    //TABMaterial=OFF
                    if (ugroup == "GroupMIR") return false;
                    if (ugroup == "GroupMRequ") return false;

                    //TABAsset=ON
                    if (ugroup == "GroupFA_OPStock") return false;
                    if (ugroup == "GroupFA_OPBStock") return false;
                    if (ugroup == "GroupDepartment") return false;
                    if (ugroup == "GroupFA_Issue") return false;
                    if (ugroup == "GroupFA_Receive") return false;
                    if (ugroup == "GroupFA_Status") return false;

                    if (ugroup == "GroupSports") return true;

                    //TABReport=ON
                    if (ugroup == "GroupItemList") return true;
                    if (ugroup == "GroupInvBalance") return true;
                    if (ugroup == "GroupFullInvBalance") return false;
                    if (ugroup == "GroupITInvBalance") return false;
                    if (ugroup == "GroupSybDist") return false;
                    if (ugroup == "GroupGRN") return true;
                    if (ugroup == "GroupGIN") return true;
                    if (ugroup == "GroupDAILY") return true;
                    if (ugroup == "GroupGPass") return true;
                    if (ugroup == "GroupINVLedger") return true;
                    if (ugroup == "GroupRequ") return false;
                    if (ugroup == "GroupConsRequ") return false;
                    if (ugroup == "GroupStoreTrans") return false;
                    break;



                default:
                    return false;
                    break;
            }

            return true;

        }



        //private void sendEmail(string rno, string studname, string grd, string sec)
        //{
        //    try
        //    {
        //        string pBody = "ASA,<br>We would like to inform you that the following student has been mark withdrawal.";
        //        pBody = pBody + "<br>Please acknowledge!<br>";
        //        pBody = pBody + "<br>User Name: " + Request.Cookies["smsuser"]["ename"].ToString();
        //        pBody = pBody + "<br><br>Branch Name: " + Request.Cookies["smsuser"]["ebrh"].ToString() + "<br><br>";
        //        pBody = pBody + "Student Name   : " + studname + "<br>";
        //        pBody = pBody + "Roll No: " + rno + "<br>";
        //        pBody = pBody + "Grade  : " + grd + "<br>";
        //        pBody = pBody + "Section: " + sec + "<br>";
        //        pBody = pBody + "<br><br>Regards,<br>SMS 2.0 Development Team";
        //        pBody = pBody + "<br>(This is a system generated email. Please do not reponsed directly to this email. This is for your information only)";


        //        string pGmailEmail = "support@fps.edu.pk";
        //        string pGmailPassword = "fpsfps";

        //        MailMessage myMail = new MailMessage();

        //        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
        //        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "mail.fps.edu.pk");
        //        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "25");
        //        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
        //        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", pGmailEmail);
        //        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", pGmailPassword);
        //        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "false");

        //        myMail.From = "support@fps.edu.pk";
        //        myMail.To = System.Configuration.ConfigurationManager.AppSettings.Get("billEmail");

        //        //myMail.To = "basitbaig@fps.edu.pk";
        //        myMail.Cc = Request.Cookies["smsuser"]["brhEmail"].ToString();
        //        myMail.Bcc = "zahid.hussain@fps.edu.pk;basitbaig@fps.edu.pk";
        //        myMail.Subject = "Student Withdrawal Info";
        //        myMail.BodyFormat = MailFormat.Html;
        //        myMail.Body = pBody;

        //        SmtpMail.Send(myMail);

        //    }


        //    catch (Exception ex)
        //    {
        //        string errormsg = ex.Message;
        //        return;
        //    }

        //}




        #endregion

    }
}
