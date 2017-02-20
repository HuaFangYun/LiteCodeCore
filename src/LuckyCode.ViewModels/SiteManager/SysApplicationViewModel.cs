using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiteCode.ViewModels.SiteManager
{
    public class SysApplicationViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "请填写名称")]
        public string ApplicationName { get; set; }
        public string ApplicationUrl { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}
