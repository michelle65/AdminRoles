using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingApp.Models
{
    public class ReCaptchaClass
    {
        private string m_Success;

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private List<string> m_ErrorCodes;

        [JsonProperty("error-codes")]
        public List<string>ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }

        public static string Validate(string EncodedResponse)
        {
            var client = new System.Net.WebClient();
            string PrivateKey = "6LdOl1QUAAAAAERGzT5GzuwXOBvFUxk908Apk4vi";
            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", PrivateKey, EncodedResponse));
            var captchaResponse = JsonConvert.DeserializeObject<ReCaptchaClass>(reply);
            return captchaResponse.Success;
        }

    }
}