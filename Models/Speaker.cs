using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechEdDemoMVC.Models
{
    public partial class Speaker
    {
        public Speaker()
        {
        }
        public Speaker(String name)
        {
            this.Name = name;
        }
    }
}