﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucky.ViewModels.Models.News
{
    public class NewsBannerViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "标题")]
        public string Title { get; set; }
        [Display(Name = "点击跳转的地址")]
        public string Url { get; set; }
        [Display(Name = "滚动顺序")]
        public int Sort { get; set; }
        [Display(Name = "图片地址")]
        public string ImageUrl { get; set; }
        [Display(Name = "是否删除")]
        public bool IsDeleted { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
