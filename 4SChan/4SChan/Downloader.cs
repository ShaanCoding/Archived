using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _4SChan
{
    public class Downloader
    {
        private const string API_URL = @"https://a.4cdn.org/";
        private const string API_IMG_URL = @"https://i.4cdn.org/";

        /*
         * Credits To: https://stackoverflow.com/questions/12079794/get-size-of-image-file-before-downloading-from-web
         * User: Ghost4Man
         */
        public static double GetFileSize(string url)
        {
            double result = 0;

            WebRequest req = WebRequest.Create(url);
            req.Method = "HEAD";
            using (WebResponse response = req.GetResponse())
            {
                if (long.TryParse(response.Headers.Get("Content-Length"), out long contentLength))
                {
                    result = contentLength;
                }
            }
            
            //Convert to KB with 2DP
            result = Math.Round((result / 1024.00), 2);

            return result;
        }

        public static List<ImagesClass> ViewThread(string threadURL)
        {
            //Return function
            List<ImagesClass> returnList = new List<ImagesClass>();

            try
            {
                if (threadURL.Split('/').Length > 5 && threadURL.Contains('.'))
                {
                    //Correctly formats thread url
                    string endpoint = string.Join("/", threadURL.Remove(0, threadURL.LastIndexOf('.')).Split('/'), 1, 3);
                    string board = string.Join("", threadURL.Remove(0, threadURL.LastIndexOf('.')).Split('/'), 1, 1);
                    string apiUrl = $"{API_URL}{endpoint}.json";

                    //View it
                    RootObject rootObject;

                    using (WebClient webClient = new WebClient())
                    {
                        var json = webClient.DownloadString(apiUrl);
                        rootObject = JsonConvert.DeserializeObject<RootObject>(json);
                    }

                    int localCount = 0;
                    //Allocates return dictionary
                    for (int i = 0; i < rootObject.posts.Count; i++)
                    {
                        //If DNE it ignores
                        if (rootObject.posts[i].tim != null && rootObject.posts[i].ext != null)
                        {
                            ImagesClass imgClass = new ImagesClass();
                            imgClass.setIsSelected(true);

                            string imageURL = API_IMG_URL + board + "/" + rootObject.posts[i].tim + rootObject.posts[i].ext;
                            imgClass.setURLOfImage(imageURL);

                            if (Properties.Settings.Default.saveWithOriginalFileName)
                            {
                                imgClass.setNameOfImage(rootObject.posts[i].tim.ToString());
                            }
                            else
                            {
                                imgClass.setNameOfImage(localCount.ToString());
                                localCount++;
                            }

                            imgClass.setFileTypeOfImage(rootObject.posts[i].ext);
                            imgClass.setDownloadSize(GetFileSize(imageURL));

                            returnList.Add(imgClass);
                        }
                    }

                    return returnList;
                }
                else
                {
                    return returnList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Cannot start until a valid thread is inputted.");
                return returnList;
            }
        }

        public static string DownloadImage(string URL, string nameOfImage, string fileType, string downloadDirectory)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string dlDirectory = string.Format(@"{0}\{1}{2}", downloadDirectory, nameOfImage, fileType);
                    client.DownloadFile(new Uri(URL), dlDirectory);
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                return "FAILED";
            }
        }
    }

    //Below is JSON structure can put into GSON

    public class Post
    {
        public int no { get; set; }
        public string now { get; set; }
        public string name { get; set; }
        public string com { get; set; }
        public string filename { get; set; }
        public string ext { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public int tn_w { get; set; }
        public int tn_h { get; set; }
        public object tim { get; set; }
        public int time { get; set; }
        public string md5 { get; set; }
        public int fsize { get; set; }
        public int resto { get; set; }
        public int bumplimit { get; set; }
        public int imagelimit { get; set; }
        public string semantic_url { get; set; }
        public int replies { get; set; }
        public int images { get; set; }
        public int unique_ips { get; set; }
        public int? filedeleted { get; set; }
    }

    public class RootObject
    {
        public List<Post> posts { get; set; }
    }
}
