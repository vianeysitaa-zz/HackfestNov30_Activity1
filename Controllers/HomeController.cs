using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;

namespace HackfestNov30_Activity1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        StorageServices storageServices = new StorageServices();
        public ActionResult Upload()
        {
            CloudBlobContainer blobContainer = storageServices.GetCloudBlobContainer();
            List<string> blobs = new List<string>();
            foreach (var blobItem in blobContainer.ListBlobs())
            {
                blobs.Add(blobItem.Uri.ToString());

            }
            return View(blobs);
        }

        [HttpPost]
        public ActionResult Upload(FormCollection image)
        {
            foreach (string item in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[item] as HttpPostedFileBase;
                if (file.ContentLength == 0)
                    continue;

                if (file.ContentLength > 0)
                {

                    CloudBlobContainer blobContainer = storageServices.GetCloudBlobContainer();
                    CloudBlockBlob blob = blobContainer.GetBlockBlobReference(file.FileName);
                    blob.UploadFromStream(file.InputStream);
                }
            }
            return RedirectToAction("Upload");
        }

        [HttpPost]
        public string DeleteImg(string Name)
        {
            Uri uri = new Uri(Name);
            string filename = System.IO.Path.GetFileName(uri.LocalPath);
            CloudBlobContainer blobContainer = storageServices.GetCloudBlobContainer();
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(filename);
            blob.Delete();
            return "File Successfully Deleted";

        }
    }
}