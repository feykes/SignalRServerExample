using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServerExample.Business
{
    public class MyBusiness
    {
        readonly IHubContext<MyHub> _hubContext; //normal bir classta websocket işlemlerini gerçekleştirebilmek için kullandığımız bir interface

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage", message); //MyHubtaki classı buraya aldık. Başına _hubContexti ekleyince yine aynı şekilde çalışıyor
        }
    }
}
