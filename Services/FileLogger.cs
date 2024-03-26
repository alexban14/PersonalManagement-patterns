using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Services
{
    internal class FileLogger: ILogger
    {
        private readonly string logFileName;
        private readonly string logDirectory;

        public FileLogger(string fileNamePrepend)
        {
            // Get the root directory of the project
            string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Create a directory for logs if it doesn't exist
            logDirectory = Path.Combine(rootDirectory, "logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Create a log file name based on the current date
            this.logFileName = Path.Combine(logDirectory, $"{fileNamePrepend}_{DateTime.Now:yyyyMMdd}.txt");
        }
        
        public void Log(string message)
        {

            File.AppendAllText(logFileName, $"{DateTime.Now} - {message}\n");
        }

        public void LogCreation(string resourceName, string details)
        {
            Log($"Creation of {resourceName}: {details}");
        }

        public void LogEdit(string resourceName, string details)
        {
            Log($"Edit of {resourceName}: {details}");
        }

        public void LogDeletion(string resourceName, string details)
        {
            Log($"Deletion of {resourceName}: {details}");
        }

        public void LogException(Exception ex)
        {
            Log($"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");
        }
    }
}