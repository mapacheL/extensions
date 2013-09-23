﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Extensions.Mailing.Views
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
    
    #line 5 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
    using Signum.Engine;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
    using Signum.Engine.Translation;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
    using Signum.Entities;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
    using Signum.Entities.DynamicQuery;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
    using Signum.Entities.Mailing;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
    using Signum.Entities.Translation;
    
    #line default
    #line hidden
    using Signum.Utilities;
    
    #line 6 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
    using Signum.Web;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
    using Signum.Web.Mailing;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Mailing/Views/EmailTemplateMessage.cshtml")]
    public partial class EmailTemplateMessage : System.Web.Mvc.WebViewPage<dynamic>
    {
        public EmailTemplateMessage()
        {
        }
        public override void Execute()
        {









            
            #line 9 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
 using (var ec = Html.TypeContext<EmailTemplateMessageDN>())
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"sf-email-template-message\">\r\n        <input type=\"hidden\" class=\"" +
"sf-tab-title\" value=\"");


            
            #line 12 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
                                                     Write(ec.Value.CultureInfo.TryToString());

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n        ");


            
            #line 13 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
   Write(Html.EntityCombo(ec, e => e.CultureInfo, vl =>
        {
            vl.LabelText = EmailTemplateViewMessage.Language.NiceToString();
        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div class=\"sf-template-message-insert-container\">\r\n            ");


            
            #line 18 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
       Write(Html.MailingInsertQueryTokenBuilder(null, ec, (QueryDescription)ViewData[ViewDataKeys.QueryDescription]));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <input type=\"button\" class=\"sf-button sf-email-inserttoken sf-email" +
"-inserttoken-basic sf-disabled\" data-prefix=\"");


            
            #line 19 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
                                                                                                                       Write(ec.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\" value=\"");


            
            #line 19 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
                                                                                                                                              Write(EmailTemplateViewMessage.Insert.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n            <input type=\"button\" class=\"sf-button sf-email-inserttoken sf-e" +
"mail-inserttoken-if sf-disabled\" data-prefix=\"");


            
            #line 20 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
                                                                                                                    Write(ec.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\" data-block=\"if\" value=\"if\" />\r\n            <input type=\"button\" class=\"sf-butto" +
"n sf-email-inserttoken sf-email-inserttoken-foreach sf-disabled\" data-prefix=\"");


            
            #line 21 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
                                                                                                                         Write(ec.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\" data-block=\"foreach\" value=\"foreach\" />\r\n            <input type=\"button\" class" +
"=\"sf-button sf-email-inserttoken sf-email-inserttoken-any sf-disabled\" data-pref" +
"ix=\"");


            
            #line 22 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
                                                                                                                     Write(ec.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\" data-block=\"any\" value=\"any\" />\r\n        </div>\r\n        ");


            
            #line 24 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
   Write(Html.ValueLine(ec, e => e.Subject, vl => 
        {
            vl.LabelHtmlProps["style"] = "width:100px";
            vl.ValueHtmlProps["class"] = "sf-email-inserttoken-target sf-email-template-message-subject";
        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        ");


            
            #line 29 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
   Write(Html.ValueLine(ec, e => e.Text, vl =>
        {
            vl.LabelVisible = false;
            vl.ValueLineType = ValueLineType.TextArea;
            vl.ValueHtmlProps["style"] = "width:100%; height:180px;";
            vl.ValueHtmlProps["class"] = "sf-rich-text-editor sf-email-template-message-text";
        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        \r\n        <script>\r\n            $(function () {\r\n                SF.Mai" +
"ling.initHtmlEditorWithTokens(\"");


            
            #line 39 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
                                                Write(ec.SubContext(e => e.Text).ControlID);

            
            #line default
            #line hidden
WriteLiteral("\");\r\n            });\r\n        </script>\r\n    </div>\r\n");


            
            #line 43 "..\..\Mailing\Views\EmailTemplateMessage.cshtml"
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591