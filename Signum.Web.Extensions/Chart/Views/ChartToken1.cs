﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.237
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web.Caching;
    using System.Web.DynamicData;
    using System.Web.SessionState;
    using System.Web.Profile;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Xml.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using Signum.Utilities;
    using Signum.Entities;
    using Signum.Web;
    using Signum.Web.Extensions.Properties;
    using Signum.Entities.DynamicQuery;
    using Signum.Engine.DynamicQuery;
    using Signum.Entities.Reflection;
    using Signum.Entities.Chart;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MvcRazorClassGenerator", "1.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Chart/Views/ChartToken.cshtml")]
    public class _Page_Chart_Views_ChartToken_cshtml : System.Web.Mvc.WebViewPage<TypeContext<ChartTokenDN>>
    {


        public _Page_Chart_Views_ChartToken_cshtml()
        {
        }
        protected System.Web.HttpApplication ApplicationInstance
        {
            get
            {
                return ((System.Web.HttpApplication)(Context.ApplicationInstance));
            }
        }
        public override void Execute()
        {









WriteLiteral("\r\n");


 using (var tc = Html.TypeContext<ChartTokenDN>())
{

WriteLiteral("    <div class=\"sf-chart-token\">\r\n");


         using (Html.FieldInline())
        {

WriteLiteral("            <span class=\"sf-label-line\">PropertyLabel</span>\r\n");


            
       Write(Html.ValueLine(tc, ct => ct.Aggregate));

                                                   
            
       Write(Html.QueryTokenCombo(tc.Value.Token, tc));

                                                     

            
       Write(Html.ValueLine(tc, ct => ct.DisplayName));

                                                     
            
       Write(Html.ValueLine(tc, ct => ct.Format));

                                                
            
       Write(Html.ValueLine(tc, ct => ct.Unit));

                                              
            
       Write(Html.ValueLine(tc, ct => ct.OrderType));

                                                   
            
       Write(Html.ValueLine(tc, ct => ct.OrderPriority));

                                                       
        }

WriteLiteral("    </div>\r\n");


}

        }
    }
}
