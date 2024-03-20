﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WriterMessage
    {
        public int Id { get; set; }
        public string Sender { get; set; } //Gönderici
        public string SenderName { get; set; } //Gönderici
        public string Receiver { get; set; } //Alıcı
        public string ReceiverName { get; set; } //Alıcı
        public string Subject { get; set; } 
        public string MessageContent { get; set; }
        public DateTime Date { get; set; }

    }
}
