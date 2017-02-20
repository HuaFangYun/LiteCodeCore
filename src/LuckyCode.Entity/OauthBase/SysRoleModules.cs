using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteCode.Entity.OauthBase
{
    public class SysRoleModules
    {
        public virtual string RoleId { get; set; }
        public virtual string ModuleId { get; set; }
        public string ApplicationId { get; set; }
        public string ControllerName { get; set; }
        public long PurviewSum { get; set; }
    }
}
