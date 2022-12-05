using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServerExample.Interfaces
{
    //strongly type hubs özelliği. Clientta kullanılacak func isimlerini interfacede belirtiyoruz ki yazarken yanlışlık olmasın
    public interface IMessageClient
    {
        Task Clients(List<string> clients);
        Task UserJoined(string connectionId);
        Task UserLeaved(string connectionId);

    }
}
