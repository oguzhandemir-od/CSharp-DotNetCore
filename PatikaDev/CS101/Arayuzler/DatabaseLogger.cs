using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arayuzler
{
    internal class DatabaseLogger:ILogger
    {
        public void WriteLog()
        {
            Console.WriteLine("Database'e log yazar");
        }
    }
}
