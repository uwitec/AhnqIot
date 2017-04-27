#region Code File Comment
// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： 88ipCheck
// FILENAME   ： Server.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-11-16 21:50
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using NewLife.Net;

namespace _88ipCheck
{
    public class Server
    {
        public int Port { get; set; }
        public TcpServer NetServer;

        public Server(int port)
        {
            this.Port = port;
        }

        public void Start()
        {
            NetServer = new TcpServer(Port);
            NetServer.NewSession += NetServer_NewSession;
            NetServer.Start();
        }

        private void NetServer_NewSession(object sender, SessionEventArgs e)
        {
            e.Session.Received += Session_Received;
        }

        private void Session_Received(object sender, ReceivedEventArgs e)
        {
            e.Feedback = true;
        }
    }
}