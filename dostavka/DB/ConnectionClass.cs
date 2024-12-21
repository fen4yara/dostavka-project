using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace dostavka.DB
{
    internal class ConnectionClass
    {
        public static DostavkaEntities connect = new DostavkaEntities();
        public static User user;
        public static Orders orders;
    }
}
