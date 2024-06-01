using System.Net.Sockets;

namespace NT106_project
{
    internal class User_connect
    {
        public string Userid { get; set; }
        public TcpClient client { get; set; }
        public string Lastconnected { get; set; }
    }
}