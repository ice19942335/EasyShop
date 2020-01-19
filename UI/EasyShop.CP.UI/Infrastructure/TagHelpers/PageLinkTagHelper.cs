using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.CP.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EasyShop.CP.UI.Infrastructure.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            _urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public NotificationPageViewModel NotificationPageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";

            TagBuilder tag = new TagBuilder("ul");
            tag.AddCssClass("pagination");

            //Create increment link
            TagBuilder decrement = CreateIncrementDecrementTag(NotificationPageModel.PageNumber, urlHelper, "decrement");
            tag.InnerHtml.AppendHtml(decrement);

            //Creating link for previous page if exist
            if (NotificationPageModel.HasPreviousPage)
            {
                TagBuilder prevItem = CreateTag(NotificationPageModel.PageNumber - 1, urlHelper);
                tag.InnerHtml.AppendHtml(prevItem);
            }

            //Current page
            TagBuilder currentItem = CreateTag(NotificationPageModel.PageNumber, urlHelper);
            tag.InnerHtml.AppendHtml(currentItem);

            //Creating link for next page if exist
            if (NotificationPageModel.HasNextPage)
            {
                TagBuilder nextItem = CreateTag(NotificationPageModel.PageNumber + 1, urlHelper);
                tag.InnerHtml.AppendHtml(nextItem);
            }

            //Create decrement link
            TagBuilder increment = CreateIncrementDecrementTag(NotificationPageModel.PageNumber, urlHelper, "increment");
            tag.InnerHtml.AppendHtml(increment);

            output.Content.AppendHtml(tag);
        }

        private TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            TagBuilder item = new TagBuilder("li");
            TagBuilder link = new TagBuilder("a");

            if (pageNumber == NotificationPageModel.PageNumber)
                item.AddCssClass("active");
            else
            {
                link.Attributes["href"] = urlHelper.Action(
                    "NotificationList",
                    "Notification",
                    new { page = pageNumber },
                    ViewContext.HttpContext.Request.Scheme);
            }


            item.AddCssClass("paginate_button");
            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);
            return item;
        }

        private TagBuilder CreateIncrementDecrementTag(int pageNumber, IUrlHelper urlHelper, string key)
        {
            TagBuilder item = new TagBuilder("li");
            TagBuilder link = new TagBuilder("a");

            item.AddCssClass("paginate_button");

            if (key == "decrement")
            {
                item.AddCssClass("previous");

                if (NotificationPageModel.HasPreviousPage)
                {
                    link.Attributes["href"] = urlHelper.Action(
                        "NotificationList",
                        "Notification",
                        new { page = --pageNumber },
                        ViewContext.HttpContext.Request.Scheme);
                }
                else
                {
                    item.AddCssClass("disabled");
                }

                link.InnerHtml.Append("«");
            }


            if (key == "increment")
            {
                item.AddCssClass("next");

                if (NotificationPageModel.HasNextPage)
                {
                    link.Attributes["href"] = urlHelper.Action(
                        "NotificationList",
                        "Notification",
                        new { page = ++pageNumber },
                        ViewContext.HttpContext.Request.Scheme);
                }
                else
                {
                    item.AddCssClass("disabled");
                }

                link.InnerHtml.Append("»");
            }

            item.InnerHtml.AppendHtml(link);
            return item;
        }
    }

}
