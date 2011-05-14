using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using TechEdDemoMVC.Models;

namespace TechEdDemoMVC.Web.Services
{
    [ServiceContract]
    public interface ISessionService
    {
        [WebGet(UriTemplate = "/Sessions", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        SessionSummary[] GetData();
    }
}
