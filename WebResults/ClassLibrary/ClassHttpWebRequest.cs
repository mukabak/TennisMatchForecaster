using System.IO;
using System.Net;

namespace WebResults
{
    public class ClassHttpWebRequest
    {
        public static string source(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sReader = new StreamReader(response.GetResponseStream());
            string sourceCode = sReader.ReadToEnd();
            sReader.Close();
            response.Close();
            return sourceCode;
        }
    }
}
