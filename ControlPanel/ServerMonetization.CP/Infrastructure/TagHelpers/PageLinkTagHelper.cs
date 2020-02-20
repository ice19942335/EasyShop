using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Enums.CP.Pagination;
using EasyShop.Domain.ViewModels.ControlPanel.PageViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ServerMonetization.CP.Infrastructure.TagHelpers
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

        public PaginationTypeEnum Type { get; set; }

        public PageViewModel PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";

            TagBuilder tag = new TagBuilder("ul");
            tag.AddCssClass("pagination");

            //Create increment link
            TagBuilder decrement = CreateIncrementDecrementTag(PageModel.PageNumber, urlHelper, "decrement");
            tag.InnerHtml.AppendHtml(decrement);

            //Creating link for previous page if exist
            if (PageModel.HasPreviousPage)
            {
                TagBuilder prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                tag.InnerHtml.AppendHtml(prevItem);
            }

            //Current page
            TagBuilder currentItem = CreateTag(PageModel.PageNumber, urlHelper);
            tag.InnerHtml.AppendHtml(currentItem);

            //Creating link for next page if exist
            if (PageModel.HasNextPage)
            {
                TagBuilder nextItem = CreateTag(PageModel.PageNumber + 1, urlHelper);
                tag.InnerHtml.AppendHtml(nextItem);
            }

            //Create decrement link
            TagBuilder increment = CreateIncrementDecrementTag(PageModel.PageNumber, urlHelper, "increment");
            tag.InnerHtml.AppendHtml(increment);

            output.Content.AppendHtml(tag);
        }

        private TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            TagBuilder item = new TagBuilder("li");
            TagBuilder link = new TagBuilder("a");

            if (pageNumber == PageModel.PageNumber)
                item.AddCssClass("active");
            else
            {
                if (Type == PaginationTypeEnum.Notifications)
                {
                    link.Attributes["href"] = urlHelper.Action(
                        "NotificationList",
                        "Notification",
                        new { page = pageNumber },
                        ViewContext.HttpContext.Request.Scheme);
                }
                else if (Type == PaginationTypeEnum.DevBlog)
                {
                    link.Attributes["href"] = urlHelper.Action(
                        "PostsList",
                        "DevBlog",
                        new { page = pageNumber },
                        ViewContext.HttpContext.Request.Scheme);
                }
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

                if (PageModel.HasPreviousPage)
                {
                    if (Type == PaginationTypeEnum.Notifications)
                    {
                        link.Attributes["href"] = urlHelper.Action(
                            "NotificationList",
                            "Notification",
                            new { page = --pageNumber },
                            ViewContext.HttpContext.Request.Scheme);
                    }
                    else if (Type == PaginationTypeEnum.DevBlog)
                    {
                        link.Attributes["href"] = urlHelper.Action(
                            "PostsList",
                            "DevBlog",
                            new { page = --pageNumber },
                            ViewContext.HttpContext.Request.Scheme);
                    }
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

                if (PageModel.HasNextPage)
                {
                    if (Type == PaginationTypeEnum.Notifications)
                    {
                        link.Attributes["href"] = urlHelper.Action(
                            "NotificationList",
                            "Notification",
                            new { page = ++pageNumber },
                            ViewContext.HttpContext.Request.Scheme);
                    }
                    else if (Type == PaginationTypeEnum.DevBlog)
                    {
                        link.Attributes["href"] = urlHelper.Action(
                            "PostsList",
                            "DevBlog",
                            new { page = ++pageNumber },
                            ViewContext.HttpContext.Request.Scheme);
                    }
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
