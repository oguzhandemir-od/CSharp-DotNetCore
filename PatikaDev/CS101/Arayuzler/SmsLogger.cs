using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arayuzler
{
    internal class SmsLogger:ILogger
    {
        public void WriteLog()
        {
            Console.WriteLine("SMS olarak log yazar");
        }
    }
}
