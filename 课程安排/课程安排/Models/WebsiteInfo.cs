using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 课程安排.Models
{
    public class WebsiteInfo
    {

        public const string SiteName = "课程管理系统";
        public string CopyRight { get; set; }
        public List<ActionLink> ActionLinks { get; set; }
        public WebsiteInfo()
        {
            ActionLinks = new List<ActionLink>
            {
                new ActionLink{Name="主页",Controller="Home",Action="Index"},
                new ActionLink { Name = "关于", Controller = "Home", Action = "About" },
                new ActionLink { Name = "联系方式", Controller = "Home", Action = "Contact" }
        };
        }
    }
}