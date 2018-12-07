using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BehaveTherapy.Controllers
{
    public class VideoFilesController : Controller
    {
        // GET: VideoFiles
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult UploadVideo()
        //{
        //    List<VideoFiles> videolist = new List<VideoFiles>();
        //    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(CS))
        //    {
        //        SqlCommand cmd = new SqlCommand("spGetAllVideoFile", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            VideoFiles video = new VideoFiles();
        //            video.ID = Convert.ToInt32(rdr["ID"]);
        //            video.Name = rdr["Name"].ToString();
        //            video.FileSize = Convert.ToInt32(rdr["FileSize"]);
        //            video.FilePath = rdr["FilePath"].ToString();

        //            videolist.Add(video);
        //        }
        //    }
        //    return View(videolist);
        //}



    }
}