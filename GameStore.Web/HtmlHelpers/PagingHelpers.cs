using System;
using System.IO;
using System.Text.Encodings.Web;
using GameStore.WebUI.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static HtmlString PageLinks(this IHtmlHelper htmlHelper, PagingInfo pagingInfo,
            Func<int, string> pageUrl)
        {
            var writer = new StringWriter();
            for (var i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml.Append(i.ToString());
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                tag.AddCssClass("btn btn-default");
                tag.WriteTo(writer, HtmlEncoder.Default);
            }

            return new HtmlString(writer.ToString());
        }
    }
}