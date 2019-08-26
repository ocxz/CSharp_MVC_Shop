using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sunny.Mvc.ShopCNM.Common
{
    public static class MyHtmlHelper
    {
        // 分页的首页
        private static int FirstPageIndex = 1;
        /// <summary>
        /// 添加分页处理导航条，需要bootstrap
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="currPage">当前页</param>
        /// <param name="pageSize">页面条数</param>
        /// <param name="totalPage">页面总数</param>
        /// <param name="navCount">导航块数，如1 2 3 4</param>
        /// <returns>处理后的导航mvcHtml</returns>
        public static MvcHtmlString AddPageNav(this HtmlHelper helper, int currPage, int pageSize, int totalPage, int navCount, params Object[] urlParams)
        {
            string urlPar = "";
            if (urlParams != null && urlParams.Length != 0)
            {
                foreach (var urlParam in urlParams)
                {
                    if (urlParam != null)
                    {
                        foreach (var prop in urlParam.GetType().GetProperties())
                        {
                            urlPar += prop.Name + "=" + prop.GetValue(urlParam) + "&";
                        }
                    }
                }
            }
            totalPage = totalPage % pageSize == 0 ? totalPage / pageSize : totalPage / pageSize + 1;

            // 获得请求过来的url（不包括参数）
            var url = helper.ViewContext.RequestContext.HttpContext.Request.Url.AbsolutePath;

            StringBuilder output = new StringBuilder();
            output.Append("<br/><br/><div class=\"center\"><ul class=\"pagination\">");

            // 处理上一页链接
            // 如当前页是首页 
            string last = "<li>";
            int lastIndex = currPage;
            if (currPage == FirstPageIndex)
            {
                // 如果当前页是首页且首页是第一页  禁用上一页按钮
                if (currPage == 1)
                {
                    FirstPageIndex = 1;
                    last = "<li class=\"disabled\">";
                }
                else   // 如果首页不是第一页 首页减一
                {
                    FirstPageIndex -= 1;
                }

                lastIndex = FirstPageIndex + 1;
            }

            // 这是上一页的链接
            output.Append(last);
            output.AppendFormat("<a href = \"{0}?" + urlPar + "pageIndex={1}&pageSize={2}\" >上一页</a></li>", url, lastIndex - 1 <= 0 ? 1 : lastIndex - 1, pageSize);

            // 展示中间链接
            for (int i = FirstPageIndex; i < FirstPageIndex + navCount; i++)
            {
                string h = i == currPage ? "<li><a class=\"active\" href=" : "<li><a href=";
                output.Append(h);
                output.AppendFormat("\"{0}?" + urlPar + "pageIndex={1}&pageSize={2}\">{1}</a></li>", url, i, pageSize);
            }

            string next = "<li>";
            int nextIndex = currPage;
            if (currPage == FirstPageIndex + navCount - 1)
            {
                // 如果当前页是首页且首页是第一页  禁用上一页按钮
                if (FirstPageIndex + navCount - 1 == totalPage)
                {
                    next = "<li class=\"disabled\">";
                }
                else   // 如果首页不是第一页 首页减一
                {
                    FirstPageIndex += 1;
                }

                nextIndex = FirstPageIndex + navCount - 1 - 1;
            }

            output.Append(next);
            var pageIndex = nextIndex + 1 >= totalPage ? totalPage : nextIndex + 1;
            output.AppendFormat("<a href = \"{0}?" + urlPar + "pageIndex={1}&pageSize={2}\">下一页</a></li></ul></div>", url, pageIndex == 0 ? 1 : pageIndex, pageSize);

            return new MvcHtmlString(output.ToString());
        }
    }
}
