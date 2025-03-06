using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependy
{
    class EmailService : IMessageService
    {
        public void sendMessage(string msg)
        {
            Console.WriteLine($"Email send {msg}");
        }
    }
}
