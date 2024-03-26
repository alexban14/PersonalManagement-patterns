using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManagement.Services
{
    public interface ILogger
    {
        void LogCreation(string resourceName, string details);
        void LogEdit(string resourceName, string details);
        void LogDeletion(string resourceName, string details);
        void LogException(Exception ex);
    }
}
