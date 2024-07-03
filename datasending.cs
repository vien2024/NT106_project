using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT106_project
{
    internal class datasending
    {
        public string USerid1 { get; set; }

        public string USerid2 { get; set; }

        public string Message { get; set; }

        public bool Checkmessage { get; set; }
        public bool Checkloadmessage { get; set; }

        public datasending()
        {
        }

        public datasending(string userid1, string userid2, string message, bool checkmessage)
        {
            USerid1 = userid1;
            USerid2 = userid2;
            Message = message;
            Checkmessage = checkmessage;

        }
        public datasending(string userid1)
        {
            USerid1 = userid1;
        }
        public datasending( string message, bool checkloadmessage)
        {
            Message = message;
            Checkloadmessage = checkloadmessage;
        }


        public datasending(string userid1, string userid2, bool checkmessage, bool checkloadmessage)
        {
            USerid1 = userid1;
            USerid2 = userid2;
            Checkmessage = checkmessage;
            Checkloadmessage = checkloadmessage;
        }
        public datasending(string userid1, string userid2, string message, bool checkmessage, bool checkloadmessage)
        {
            USerid1 = userid1;
            USerid2 = userid2;
            Message = message;
            Checkmessage = checkmessage;
            Checkloadmessage = checkloadmessage;
        }
    }
}
