using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.WebEncoders.Testing;

namespace LuckyCode.WebFrameWork.TagHelper.MVCPager
{
    public class PagerTagHelper:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        /// <summary>
        /// Paginated Meta data
        /// </summary>
        public PagerMetaModel Info { get; set; }

        /// <summary>
        /// Base route minus page value
        /// </summary>
        public string Route { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            BuildParent(output);
            AddPreviousPage(output);
            AddPageNodes(output);
            AddNextPage(output);
            
            output.PreElement.SetHtmlContent($"<ul class='pagination pull-right'><li><span> 共 {Info.Pages.Count}  条 </span></li> <li><span> 每页 2  条 </span></li> <li><span> 共 8 页 </span></li> <li><span> 当前第 1 页 </span></li></ul>");
            
        }

        /// <summary>
        /// Build parent tag (ul)
        /// </summary>
        private static void BuildParent(TagHelperOutput output)
        {
            output.TagName = "ul";

            output.Attributes.Add("class", "pagination");
            output.Attributes.Add("role", "navigation");
            output.Attributes.Add("aria-label", "Pagination");
            
        }

        /// <summary>
        /// Build previous page list item
        /// </summary>
        private void AddPreviousPage(TagHelperOutput output)
        {
            string html = "";
            if (Info.PreviousPage.Display)
            {
                html =
                    $@"<li >
    <a href=""{Route}/?pageIndex={Info.PreviousPage.PageNumber}"" aria-label=""上一页"">上一页 <span class=""show-for-sr""></span></a>
</li>";
            }
            else
            {
                html = $@"<li class='disabled'>
    <a   class='disabled'>上一页 </a>
</li>";
            }
            output.Content.SetHtmlContent(output.Content.GetContent() + html);
        }

        /// <summary>
        /// Build next page list item
        /// </summary>
        private void AddNextPage(TagHelperOutput output)
        {
            string html = "";
            if (Info.PreviousPage.Display)
            {
                html =
                    $@"<li >
    <a href=""{Route}/?pageIndex={Info.NextPage.PageNumber}"" >下一页 </a>
</li>";
            }
            else
            {
                html = $@"<li class='disabled'>
    <a class='disabled'>下一页 </a>
</li>";
            }
            output.Content.SetHtmlContent(output.Content.GetContent() + html);
        }

        private void AddPageNodes(TagHelperOutput output)
        {
            foreach (var infoPage in Info.Pages)
            {
                string html;
                if (infoPage.IsCurrent)
                {
                    html = $@"<li class=""active""><a> {infoPage.PageNumber}</a></li>";
                    output.Content.SetHtmlContent(output.Content.GetContent() + html);
                    continue;
                }
                html = $@"<li><a href=""{Route}/?pageIndex={infoPage.PageNumber}"" aria-label=""{infoPage.PageNumber}"">{infoPage.PageNumber}</a></li>";
                output.Content.SetHtmlContent(output.Content.GetContent() + html);
            }
        }
    }
}
