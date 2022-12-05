using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        public async Task SendMessageAsync(string message, string groupName)
        {
            #region Caller
            //Sadece servera bildirim gönderen clientla iletişim kurar
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion
            #region All
            //hepsi
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion
            #region Others
            //o hariç diğerleri
            //await Clients.Others.SendAsync("receiveMessage", message); // All, Caller, Others => client türleri
            #endregion

            #region Hub Clients Metodları
            #region AllExcept
            //Belirtilen clientlar hariç servera bağlı olan tüm clientlara bildiride bulunur.
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage",message);
            #endregion
            #region Client
            //sadece belirli olan birine
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage",message);
            #endregion
            #region Clients
            //sadece belirtilenLERe
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage",message);
            #endregion
            #region Group
            //Belirtilen gruptaki clientlara
            //önce gruplar oluşturulmalı sonra clientlar gruplara subs olmalı
            //await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion
            #region GroupExcept
            //belirtilen gruptaki belirtilen clientlar dışındaki tüm clientlara
            #endregion
            #region Groups
            //birden çok gruptaki clientlara bildiride bulunmamızı sağlayan 
            #endregion
            #region OthersInGroup
            //bildiride bulunan client haricinde gruptaki tüm clientlara bildiride bulunan fonk
            #endregion
            #region User

            #endregion
            #region Users

            #endregion
            #endregion
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
