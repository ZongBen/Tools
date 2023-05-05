using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogUtility
{
    public class LogHelper
    {
        private string FolderPath { get; }
        public LogHelper(string FolderPath)
        {
            this.FolderPath = FolderPath;
        }

        public void SaveErrLog(Exception ex)
        {
            DateTime dtNow = DateTime.Now;
            string FilePath = FolderPath + $"\\errLog\\errLog_{dtNow.Year}{dtNow.Month}{dtNow.Day}.txt";
            if (Directory.Exists(FolderPath))
            {
                var stream = File.AppendText(FilePath);
                stream.WriteLine($"{dtNow:HH:mm:ss}");
                stream.WriteLine($"位置：{ex.InnerException?.StackTrace.Trim() ?? ex.StackTrace.Trim()}");
                stream.WriteLine($"訊息：{ex.InnerException?.Message.Trim() ?? ex.Message.Trim()}");
                stream.WriteLine("---------------------------");
                stream.Flush();
                stream.Close();
            }
        }
    }
}
