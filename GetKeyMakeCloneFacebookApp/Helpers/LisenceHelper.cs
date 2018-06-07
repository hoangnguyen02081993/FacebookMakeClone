using GetKeyMakeCloneFacebookApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetKeyMakeCloneFacebookApp.Helpers
{
    public class LisenceHelper
    {
        private const string URL_LISENSE = "http://decorbiz.vn";
        private const string UserName = "hoang";
        private const string Password = "pro";
        public GetAllKeyResult GetAllKey()
        {
            var request = (HttpWebRequest)WebRequest.Create(string.Format("{0}/lisence_getall.php",
                                                                           URL_LISENSE));
            GetAllKeyRequest getAllKeyRequest = new GetAllKeyRequest()
            {
                u = UserName,
                p = Password
            };
            byte[] data = Until.Create<GetAllKeyRequest>(getAllKeyRequest);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return JsonConvert.DeserializeObject<GetAllKeyResult>(responseString);
        }
        public KeyActionResult AddKey(Key key)
        {
            var request = (HttpWebRequest)WebRequest.Create(string.Format("{0}/lisence_key.php",
                                                                           URL_LISENSE));
            KeyActionRequest addKeyRequest = new KeyActionRequest()
            {
                u = UserName,
                p = Password,
                Key = key,
                Action = Common.KeyAction.Add
            };
            byte[] data = Until.Create<KeyActionRequest>(addKeyRequest);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return JsonConvert.DeserializeObject<KeyActionResult>(responseString);
        }
        public KeyActionResult EditActiveKey(Key key)
        {
            var request = (HttpWebRequest)WebRequest.Create(string.Format("{0}/lisence_key.php",
                                                                           URL_LISENSE));
            KeyActionRequest editKeyRequest = new KeyActionRequest()
            {
                u = UserName,
                p = Password,
                Key = key,
                Action = Common.KeyAction.ChangeAcitve
            };
            byte[] data = Until.Create<KeyActionRequest>(editKeyRequest);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return JsonConvert.DeserializeObject<KeyActionResult>(responseString);
        }
    }
}
