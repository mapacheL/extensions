﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Signum.Entities;
    
    #line 1 "..\..\Mailing\Views\EmailPackage.cshtml"
    using Signum.Entities.Mailing;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Mailing/Views/EmailPackage.cshtml")]
    public partial class _Mailing_Views_EmailPackage_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Mailing_Views_EmailPackage_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Mailing\Views\EmailPackage.cshtml"
 using (var e = Html.TypeContext<EmailPackageEntity>())
{
    
            
            #line default
            #line hidden
            
            #line 5 "..\..\Mailing\Views\EmailPackage.cshtml"
Write(Html.ValueLine(e, f => f.Name, f => f.ReadOnly = true));

            
            #line default
            #line hidden
            
            #line 5 "..\..\Mailing\Views\EmailPackage.cshtml"
                                                           


            
            #line default
            #line hidden
WriteLiteral("<fieldset>\r\n    <legend>Lines</legend>\r\n");

WriteLiteral("    ");

            
            #line 9 "..\..\Mailing\Views\EmailPackage.cshtml"
Write(Html.SearchControl(new FindOptions(typeof(EmailMessageEntity), "Package", e.Value), e));

            
            #line default
            #line hidden
WriteLiteral("\r\n</fieldset>\r\n");

            
            #line 11 "..\..\Mailing\Views\EmailPackage.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
