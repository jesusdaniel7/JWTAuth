using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLogin.Models
{
    public class Message
    {
        public Message()
        {
            Person = "anonymous";
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Person { get; set; }
    }
}
