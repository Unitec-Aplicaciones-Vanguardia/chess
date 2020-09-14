using System;
using System.Collections.Generic;
using System.Text;
using Chess.Core.Interfaces;

namespace Chess.Infrastructure.Loggers
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] - {message}");
        }
    }
}
