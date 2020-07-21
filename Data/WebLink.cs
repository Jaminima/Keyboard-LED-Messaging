using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Threading;
using System.Xml.Schema;
using System.Security.Policy;

namespace Keyboard_LED_Messaging
{
    public static class WebLink
    {
        static HttpListener listener;
        static Thread activeThread;

        public static void Start(int port = 8080)
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:" + port + "/");

            listener.Start();
            listener.BeginGetContext(Request, null);
        }

        private static void Request(IAsyncResult result)
        {
            HttpListenerContext cont = listener.EndGetContext(result);

            string query = cont.Request.Url.Query.TrimStart('?');
            string response = "Error";

            if (activeThread!=null && activeThread.IsAlive) { response = "Please wait, something is being displayed"; }
            else
            {
                try
                {
                    string[] seg = query.Split('&');
                    Dictionary<string, string> pms = seg.ToDictionary(x => x.Split('=')[0], x => x.Split('=')[1]);

                    if (pms.ContainsKey("message")) { activeThread = new Thread(() => Effects.ShowText(Uri.UnescapeDataString(pms["message"]))); activeThread.Start(); }

                    response = "Displayed Message";
                }
                catch (Exception e) { Console.WriteLine(e); }
            }

            StreamWriter stream = new StreamWriter(cont.Response.OutputStream);
            stream.Write(response);
            stream.Close();
            cont.Response.Close();

            listener.BeginGetContext(Request, null);
        }
    }
}
