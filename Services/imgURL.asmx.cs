using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;

namespace ISBNCover.Services
{
    /// <summary>
    /// Webservice checks in the covers.openlibrary.org wether the cover for ISBN exists
    /// If yes it returns the link of the image from that source
    /// Otherwise it checks it in amazon images and returns the cover of the book if found
    /// Or returns the 1x1 picture
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class imgURL : System.Web.Services.WebService
    {

        [WebMethod]
        public string ReturnImgURL(string isbn)
        {
            string imgLink = String.Format("http://covers.openlibrary.org/b/isbn/{0}-L.jpg?default=false", isbn);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imgLink);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                {
                    HttpWebResponse response = (HttpWebResponse)ex.Response;
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        imgLink = String.Format("http://images.amazon.com/images/P/{0}.jpg", isbn);
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            
            return imgLink;
        }
    }
}
