using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteCode.Entity.OauthBase;

namespace LiteCode.Entity
{
    public class SysApplication
    {
        public string Id { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationUrl { get; set; }
        public System.DateTime CreateTime { get; set; }
        public virtual List<SysModules> Moduleses { get; set; }=new List<SysModules>();
    }
}
