using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TechEdDemoMVC.Models
{
    [DataContract(Namespace = "http://tempuri.org")]
    public class SessionSummary
    {
        [DataMember]
        public string Code;
        [DataMember]
        public string Title;
        [DataMember]
        public string PrimarySpeaker;
    }
}