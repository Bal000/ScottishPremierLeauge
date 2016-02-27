using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace ScottishPremierLeauge.Models
{
    public class ImageService:IImageService
    {
        private readonly string connectionstring = "Data Source=BODIL-DATOR\\SQLEXPRESS2014;Initial Catalog=FootballFactory;Integrated Security=True;";

        public int SaveImage(byte[] imageData, string name, string originalPath)
        {
            var result = 0;
            using (var con = new SqlConnection(connectionstring))
            {
                using (var cmd = new SqlCommand()) 
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"dbo.usp_PersistImage";

                    cmd.Parameters.AddWithValue("@ImageData", imageData);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@OriginalPath", originalPath);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            return result;
        }

        public ImageDbType ReadImage(int imageId) 
        {
            try
            {
                 using (var con = new SqlConnection(connectionstring))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"dbo.usp_FetchImage";

                    cmd.Parameters.AddWithValue("@ImageId", imageId);                  
                    con.Open();

                    ImageDbType image = new ImageDbType();

                    using (var reader = cmd.ExecuteReader()) 
                    {
                        if (reader.HasRows) 
                        {
                            while (reader.Read()) 
                            {
                                object binaries = reader["ImageData"];
                                image.ImageData = (byte[])binaries;
                                image.Name = reader["Name"].ToString();
                                image.OriginalPath = reader["OriginalPath"].ToString();
                            }
                        }

                        return image;
                    }                    
                }
                
            }

            return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    
    
    
    }    
}