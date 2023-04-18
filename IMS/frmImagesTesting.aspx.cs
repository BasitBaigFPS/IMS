using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using SD = System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Configuration;
using BLL;

namespace IMS
{
    public partial class frmImagesTesting : System.Web.UI.Page
    {

        string strConnString = ConfigurationManager.ConnectionStrings["INVENTORY"].ConnectionString;

        String path = HttpContext.Current.Request.PhysicalApplicationPath + "images\\";
        
        protected void Page_Load(object sender, EventArgs e)
        {

     
                //If first time page is submitted and we have file in FileUpload control but not in session
                // Store the values to SEssion Object
                if (Session["FileUpload1"] == null && Upload.HasFile)
                {
                    Session["FileUpload1"] = Upload;
                    Label1.Text = Upload.FileName;
                }
                // Next time submit and Session has values but FileUpload is Blank
                // Return the values from session to FileUpload
                else if (Session["FileUpload1"] != null && (!Upload.HasFile))
                {
                    Upload = (FileUpload)Session["FileUpload1"];
                    Label1.Text = Upload.FileName;
                }
                // Now there could be another sictution when Session has File but user want to change the file
                // In this case we have to change the file in session object
                else if (Upload.HasFile)
                {
                    Session["FileUpload1"] = Upload;
                    Label1.Text = Upload.FileName;
                }
         

        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {

            Boolean FileOK = false;

            Boolean FileSaved = false;



            if (Upload.HasFile)
            {

                Session["WorkingImage"] = Upload.FileName;

                String FileExtension = Path.GetExtension(Session["WorkingImage"].ToString()).ToLower();

                String[] allowedExtensions = { ".png", ".jpeg", ".jpg", ".gif" };

                for (int i = 0; i < allowedExtensions.Length; i++)
                {

                    if (FileExtension == allowedExtensions[i])
                    {

                        FileOK = true;

                    }

                }

            }



            if (FileOK)
            {

                try
                {

                    Upload.PostedFile.SaveAs(path + Session["WorkingImage"]);

                    FileSaved = true;

                }

                catch (Exception ex)
                {

                    lblError.Text = "File could not be uploaded." + ex.Message.ToString();

                    lblError.Visible = true;

                    FileSaved = false;

                }

            }

            else
            {

                lblError.Text = "Cannot accept files of this type.";

                lblError.Visible = true;

            }



            if (FileSaved)
            {

                pnlUpload.Visible = false;

                pnlCrop.Visible = true;

                imgCrop.ImageUrl = "images/" + Session["WorkingImage"].ToString();

            }

        }

        protected void btnCrop_Click(object sender, EventArgs e)
        {

            string ImageName = Session["WorkingImage"].ToString();

            int w = Convert.ToInt32(W.Value);

            int h = Convert.ToInt32(H.Value);

            int x = Convert.ToInt32(X.Value);

            int y = Convert.ToInt32(Y.Value);

            

            byte[] CropImage = Crop(path + ImageName, w, h, x, y);

            using (MemoryStream ms = new MemoryStream(CropImage, 0, CropImage.Length))
            {

                ms.Write(CropImage, 0, CropImage.Length);

                using (SD.Image CroppedImage = SD.Image.FromStream(ms, true))
                {

                    string SaveTo = path + "crop" + ImageName;

                  //   Upload.SaveAs(path + "crop" + ImageName);
                    // btnUpload.Enabled = false;

                    
                    SaveImage(path + "crop" + ImageName, CropImage);

                    CroppedImage.Save(SaveTo, CroppedImage.RawFormat);

                    pnlCrop.Visible = false;

                    pnlCropped.Visible = true;

                    imgCropped.ImageUrl = "images/crop" + ImageName;

                }

            }

        }

        static byte[] Crop(string Img, int Width, int Height, int X, int Y)
        {

            try
            {

                using (SD.Image OriginalImage = SD.Image.FromFile(Img))
                {

                    using (SD.Bitmap bmp = new SD.Bitmap(Width, Height))
                    {

                        bmp.SetResolution(OriginalImage.HorizontalResolution, OriginalImage.VerticalResolution);

                        using (SD.Graphics Graphic = SD.Graphics.FromImage(bmp))
                        {

                            Graphic.SmoothingMode = SmoothingMode.AntiAlias;

                            Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                            Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;

                            Graphic.DrawImage(OriginalImage, new SD.Rectangle(0, 0, Width, Height), X, Y, Width, Height, SD.GraphicsUnit.Pixel);

                            MemoryStream ms = new MemoryStream();

                            bmp.Save(ms, OriginalImage.RawFormat);

                            return ms.GetBuffer();

                        }

                    }

                }

            }

            catch (Exception Ex)
            {

                throw (Ex);

            }

        }


        private void SaveImage(string s_Image_Name, byte[] CropImage_Size)
        {
             

            if (Upload.PostedFile != null && Upload.PostedFile.FileName != "")
            {


                byte[] n_Image_Size = new byte[CropImage_Size.Length];

              // byte[] n_Image_Size = new byte[Upload.PostedFile.ContentLength];

                HttpPostedFile Posted_Image = Upload.PostedFile;

                Posted_Image.InputStream.Read(n_Image_Size, 0, (int)n_Image_Size.Length);

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["INVENTORY"].ConnectionString);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO tblImages(Name,[Content],Size,Type)" +
                                  " VALUES (@Image_Name,@Image_Content,@Image_Size,@Image_Type)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                SqlParameter Image_Name = new SqlParameter("@Image_Name", SqlDbType.VarChar, 500);
                Image_Name.Value = s_Image_Name;
                cmd.Parameters.Add(Image_Name);

                SqlParameter Image_Content = new SqlParameter("@Image_Content", SqlDbType.Image, n_Image_Size.Length);
                Image_Content.Value = n_Image_Size;
                cmd.Parameters.Add(Image_Content);

                SqlParameter Image_Size = new SqlParameter("@Image_Size", SqlDbType.BigInt, 99999);
                Image_Size.Value = Upload.PostedFile.ContentLength;
                cmd.Parameters.Add(Image_Size);

                SqlParameter Image_Type = new SqlParameter("@Image_Type", SqlDbType.VarChar, 500);
                Image_Type.Value = Upload.PostedFile.ContentType;
                cmd.Parameters.Add(Image_Type);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
           }
        }


    }
}