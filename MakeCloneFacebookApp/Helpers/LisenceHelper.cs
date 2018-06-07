using MakeCloneFacebookApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MakeCloneFacebookApp.Helpers
{
    public class LisenceHelper<T>
    {
        private const string URL_LISENSE = "http://decorbiz.vn";
        private const string PRIVATE_KEY = "conga";
        public static T Information { private set; get; }

        public T GetLisenceResult()
        {
            string serial = SystemHelper.GetSerial();
            string randomKey = Until.GetRanDomHex(5);
            var request = (HttpWebRequest)WebRequest.Create(string.Format("{0}/lisence_check.php",
                                                                           URL_LISENSE));

            LisenceRequest lisenceRequest = new LisenceRequest()
            {
                Serial = serial.Encrypt3DES(randomKey),
                Hash = randomKey.Encrypt3DES(PRIVATE_KEY)
            };
            byte[] data = Until.Create<LisenceRequest>(lisenceRequest);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Information = JsonConvert.DeserializeObject<T>(responseString.Decrypt3DES(randomKey));
            return Information;
        }
        public T SetLisenceResult(string activekey)
        {
            string serial = SystemHelper.GetSerial();
            string randomKey = Until.GetRanDomHex(5);
            var request = (HttpWebRequest)WebRequest.Create(string.Format("{0}/lisence_active.php",
                                                                           URL_LISENSE));
            LisenceRequest lisenceRequest = new LisenceRequest()
            {
                Serial = serial.Encrypt3DES(randomKey),
                Hash = randomKey.Encrypt3DES(PRIVATE_KEY),
                Key = activekey.Encrypt3DES(randomKey)
            };
            byte[] data = Until.Create<LisenceRequest>(lisenceRequest);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return JsonConvert.DeserializeObject<T>(responseString.Decrypt3DES(randomKey));
        }
    }
}
