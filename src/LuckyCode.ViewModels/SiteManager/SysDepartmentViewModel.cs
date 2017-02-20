using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LiteCode.Core.Utility;

namespace LiteCode.ViewModels.SiteManager
{
    public class SysDepartmentViewModel
    {
        public string Id { get; set; }
        [Display(Name = "部门名称")]
        [Required(ErrorMessage = "不能为空")]
        public string DepartmentName { get; set; }
        [Display(Name = "部门描述")]
        public string Description { get; set; }
        [Display(Name = "")]
        public int State { get; set; }
        [Display(Name = "")]
        public int Sort { get; set; }
        [Display(Name = "父级部门")]
        public string ParentId { get; set; }
        public List<ListItemEntity> ParentList { get; set; } = new List<ListItemEntity>();
    }
}
