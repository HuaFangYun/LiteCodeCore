using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LuckyCode.Core.WebSocket;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LuckyCode.Core.WebSocketChat
{
    public class ChartHandler : WebSocketHandler
    {
        private ILogger _logger;
        public ChartHandler(ILogger<WebSocketHandler> logger) : base(logger)
        {
            _logger = logger;
        }

        protected override int BufferSize { get => 1024 * 4; }

        public override async Task<WebSocketConnection> OnConnected(HttpContext context)
        {
            var name = context.Request.Query["Name"];
            if (!string.IsNullOrEmpty(name))
            {
                var connection = Connections.FirstOrDefault(m => ((ChartConnection)m).NickName == name);

                if (connection == null)
                {
                    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    
                    connection = new ChartConnection(this)
                    {
                        NickName = name,
                        WebSocket = webSocket
                    };

                    Connections.Add(connection);
                }

                return connection;
            }

            return null;
        }
    }
}
