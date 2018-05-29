using MakeCloneFacebookApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeCloneFacebookApp.Helpers
{
    public static class JobConfigHelper
    {
        public static bool Save(this JobConfig jobConfig, string fileName)
        {
            try
            {
                string DataSave = JsonConvert.SerializeObject(jobConfig).StringEndcoder();
                File.WriteAllText(fileName, DataSave);
                return true;
            }
            catch (Exception ex)
            {
                ex.StackTrace.WriteLog();
                return false;
            }
        }
        public static bool Open(this JobConfig jobConfig, ref JobConfig output, string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    string DataString = File.ReadAllText(fileName).StringDecoder();
                    output = JsonConvert.DeserializeObject<JobConfig>(DataString);
                    return true;
                }
                catch (Exception ex)
                {
                    ex.StackTrace.WriteLog();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
