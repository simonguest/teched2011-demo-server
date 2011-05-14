using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using TechEdDemoMVC.Models;

namespace TechEdDemoMVC.Web.Services
{
    [ServiceContract]
    public interface ISOAP
    {
        [OperationContract]
        SessionSummary[] GetSessions();

        [OperationContract]
        string GetCurrentSessionCode();

        [OperationContract]
        string GetTitleForCode(string code);
    }
}
