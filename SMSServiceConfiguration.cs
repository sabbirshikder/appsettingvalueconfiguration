using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class SMSServiceConfiguration
    {
        public string  portnumber { get; set; }
        public string servicenumber { get; set; }
        public string serverip { get; set; }
        public string serverport { get; set; }
        public string databasename { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string folderpath { get; set; }
    }
}
