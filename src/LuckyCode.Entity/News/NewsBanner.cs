using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCode.Entity.News
{
    public class NewsBanner
    {
        public Guid Id { get; set; }
        [Description("标题")]
        public string Title { get; set; }
        [Description("点击跳转的地址")]
        public string Url { get; set; }
        [Description("滚动顺序")]
        public int Sort { get; set; }
        [Description("图片地址")]
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
