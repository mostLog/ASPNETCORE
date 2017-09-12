using L.Application.Dto;
using L.LCore.Infrastructure.Dependeny;
using L.LCore.Json;
using L.SpiderCore;
using L.SpiderCore.Crawler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L.Web.Hubs
{
    public class NotcieSocketHandler
    {
        public WebSocket Socket { get; set; }

        private NotcieSocketHandler(WebSocket socket)
        {
            this.Socket = socket;
        }

        private async Task RunTask()
        {
            var buffer = new byte[1024 * 4];
            var seg = new ArraySegment<byte>(buffer);
            while (this.Socket.State == WebSocketState.Open)
            {
                var input = await this.Socket.ReceiveAsync(seg, CancellationToken.None);

                string tmp = Encoding.UTF8.GetString(seg.Array, 0,
                        input.Count);
                if (!string.IsNullOrEmpty(tmp))
                {
                    var p = JsonHelper.ToObject<TaskRunOrStopInput>(tmp);
                    var spiderManager = ContainerManager.Resolve<SpiderManager>();
                    var config = new SpiderConfig()
                    {
                        CallBack = (msg) =>
                        {
                            Socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(msg)), WebSocketMessageType.Text, true, CancellationToken.None);
                        },
                        Uris = p.Uris
                    };
                    spiderManager.RunTask(p.SpiderId, config);
                }
            }
        }

        private async void SendMsg(string message)
        {
            var buffer = new byte[4096];
            var output = new ArraySegment<byte>(buffer, 0, message.Length);
            await this.Socket.SendAsync(output, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private static async Task Acceptor(HttpContext hc, Func<Task> n)
        {
            if (!hc.WebSockets.IsWebSocketRequest)
                return;
            var socket = await hc.WebSockets.AcceptWebSocketAsync();
            var h = new NotcieSocketHandler(socket);
            await h.RunTask();
        }

        /// <summary>
        /// 路由绑定处理
        /// </summary>
        /// <param name="app"></param>
        public static void Map(IApplicationBuilder app)
        {
            app.UseWebSockets();
            app.Use(NotcieSocketHandler.Acceptor);
        }
    }
}