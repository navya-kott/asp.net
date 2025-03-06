using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependy
{
    class Messenger
    {
        private readonly IMessageService _messageService;

        public Messenger(IMessageService messageService)
        {
            _messageService = messageService;

        }

        public void sendEmail(string msg)
        {
            _messageService.sendMessage(msg);
        }
    }
}
