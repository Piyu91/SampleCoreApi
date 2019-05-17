using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DomainModels
{
   public sealed class Logger
    {

        private static Logger _logger;
        private StreamWriter sw;
        
        private Logger()
        {
            FileStream fs = new FileStream(@"C:\Users\SAMSUNG\log.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
        }

        public static Logger GetInstance()
        {
            if(_logger == null)
            {
                _logger = new Logger();
            }
            return _logger;
        }

        public void LogData(string str)
        {
            
            sw.WriteLineAsync(str);
        }

    }
}
