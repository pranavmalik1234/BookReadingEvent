using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BufferOverflow.Controllers
{
    public class UploadFileApiController : ApiController
    {
        [Route("api/UploadFileApi")]
        [HttpPost]
        public string UploadJsonFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            HttpPostedFile postedFile;
            if (httpRequest.Files.Count > 0)
            {
                postedFile = httpRequest.Files[0];
                var filePath = HttpContext.Current.Server.MapPath("~/images/" + postedFile.FileName);
                postedFile.SaveAs(filePath);
                return postedFile.FileName;

            }
            return null;
        }
    }
}
