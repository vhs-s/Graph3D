using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_Chart_Graph
{
    internal class Logger
    {
        private readonly string logFileName;
        private readonly string logFilePath;

        public Logger(string logFileName)
        {
            this.logFileName = logFileName;
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.logFilePath = Path.Combine(documentsPath, logFileName);
        }

        public void CreateLogFile()
        {
            using (FileStream fs = File.Create(logFilePath))
            {
            }
        }

        public void WriteLog(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";

            using (StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.WriteLine(logEntry);
            }
        }
    }
}
