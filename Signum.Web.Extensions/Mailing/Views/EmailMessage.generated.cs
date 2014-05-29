﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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
    
    #line 1 "..\..\Mailing\Views\EmailMessage.cshtml"
    using Signum.Engine;
    
    #line default
    #line hidden
    using Signum.Entities;
    
    #line 2 "..\..\Mailing\Views\EmailMessage.cshtml"
    using Signum.Entities.Mailing;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    #line 4 "..\..\Mailing\Views\EmailMessage.cshtml"
    using Signum.Web.Files;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Mailing\Views\EmailMessage.cshtml"
    using Signum.Web.Mailing;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Mailing/Views/EmailMessage.cshtml")]
    public partial class EmailMessage : System.Web.Mvc.WebViewPage<dynamic>
    {
        public EmailMessage()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<style");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    .sf-email-message .sf-repeater-element\r\n    {\r\n        padding: 2px 10px;\r" +
"\n    }\r\n\r\n        .sf-email-message .sf-repeater-element legend\r\n        {\r\n    " +
"        float: left;\r\n            margin-right: 10px;\r\n        }\r\n</style>\r\n\r\n");

            
            #line 19 "..\..\Mailing\Views\EmailMessage.cshtml"
Write(Html.ScriptCss("~/Mailing/Content/Mailing.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n");

            
            #line 22 "..\..\Mailing\Views\EmailMessage.cshtml"
 using (var e = Html.TypeContext<EmailMessageDN>())
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"sf-email-message\"");

WriteLiteral(">\r\n\r\n");

            
            #line 26 "..\..\Mailing\Views\EmailMessage.cshtml"
        
            
            #line default
            #line hidden
            
            #line 26 "..\..\Mailing\Views\EmailMessage.cshtml"
         using (var tabs = Html.Tabs(e))
        {
            if (e.Value.State != EmailMessageState.Created)
            {
                e.ReadOnly = true;
            }


            tabs.Tab("sfEmailMessage", typeof(EmailMessageDN).NiceName(), 
            
            #line default
            #line hidden
item => new System.Web.WebPages.HelperResult(__razor_template_writer => {

WriteLiteralTo(__razor_template_writer, "\r\n\r\n\r\n            <div");

WriteLiteralTo(__razor_template_writer, " class=\"row\"");

WriteLiteralTo(__razor_template_writer, ">\r\n                <div");

WriteLiteralTo(__razor_template_writer, " class=\"repeater-inline form-inline col-sm-8\"");

WriteLiteralTo(__razor_template_writer, ">\r\n");

WriteLiteralTo(__razor_template_writer, "                    ");

            
            #line 39 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.EntityLineDetail(e, f => f.From));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "                    ");

            
            #line 40 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.EntityRepeater(e, f => f.Recipients));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "                    ");

            
            #line 41 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.EntityRepeater(e, f => f.Attachments));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n                </div>\r\n                <div");

WriteLiteralTo(__razor_template_writer, " class=\"col-sm-4\"");

WriteLiteralTo(__razor_template_writer, ">\r\n                    <fieldset>\r\n                        <legend>Properties</le" +
"gend>\r\n");

WriteLiteralTo(__razor_template_writer, "                        ");

            
            #line 46 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.ValueLine(e, f => f.State));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "                        ");

            
            #line 47 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.ValueLine(e, f => f.Sent));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "                        ");

            
            #line 48 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.EntityLine(e, f => f.Exception));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "                        ");

            
            #line 49 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.EntityLine(e, f => f.Template));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "                        ");

            
            #line 50 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.EntityLine(e, f => f.Package));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "                        ");

            
            #line 51 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.ValueLine(e, f => f.IsBodyHtml));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "                        ");

            
            #line 52 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.ValueLine(e, f => f.BodyHash));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n                    </fieldset>\r\n                </div>\r\n            </div>\r\n\r\n" +
"");

WriteLiteralTo(__razor_template_writer, "            ");

            
            #line 57 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.EntityLine(e, f => f.Target));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "            ");

            
            #line 58 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.ValueLine(e, f => f.Subject));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

            
            #line 59 "..\..\Mailing\Views\EmailMessage.cshtml"
            
            
            #line default
            #line hidden
            
            #line 59 "..\..\Mailing\Views\EmailMessage.cshtml"
             if (e.Value.State == EmailMessageState.Created)
            {
                
            
            #line default
            #line hidden
            
            #line 61 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.ValueLine(e, f => f.Body, vl =>
           {
               vl.ValueLineType = ValueLineType.TextArea;
               vl.ValueHtmlProps["style"] = "width:100%; height:180px;";
           }));

            
            #line default
            #line hidden
            
            #line 65 "..\..\Mailing\Views\EmailMessage.cshtml"
             


            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "<script>\r\n    $(function () {\r\n");

WriteLiteralTo(__razor_template_writer, "        ");

            
            #line 69 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, MailingClient.Module["initHtmlEditor"](e.Compose("Body")));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n    });\r\n                </script>\r\n");

            
            #line 72 "..\..\Mailing\Views\EmailMessage.cshtml"
            }
            else
            {
                var body = MailingClient.GetWebMailBody(e.Value.Body, new WebMailOptions
                {
                    Attachments = e.Value.Attachments,
                    UntrustedImage = null,
                    Url = Url,
                });

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "<h3>");

            
            #line 81 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, EmailMessageMessage.Message.NiceToString());

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, ":</h3>\r\n");

WriteLiteralTo(__razor_template_writer, "<div>\r\n");

            
            #line 83 "..\..\Mailing\Views\EmailMessage.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 83 "..\..\Mailing\Views\EmailMessage.cshtml"
                         if (e.Value.IsBodyHtml)
                        {            

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "<iframe");

WriteAttributeTo(__razor_template_writer, "id", Tuple.Create(" id=\"", 2726), Tuple.Create("\"", 2751)
            
            #line 85 "..\..\Mailing\Views\EmailMessage.cshtml"
, Tuple.Create(Tuple.Create("", 2731), Tuple.Create<System.Object, System.Int32>(e.Compose("iframe")
            
            #line default
            #line hidden
, 2731), false)
);

WriteLiteralTo(__razor_template_writer, " style=\"width:90%\"");

WriteLiteralTo(__razor_template_writer, ">\r\n");

WriteLiteralTo(__razor_template_writer, "                                ");

            
            #line 86 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.Raw(body));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n                            </iframe>\r\n");

WriteLiteralTo(__razor_template_writer, "<script>\r\n    $(function () {\r\n        var iframe = $(\"");

            
            #line 90 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, e.Compose("iframe"));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\");\r\n");

WriteLiteralTo(__razor_template_writer, "        ");

            
            #line 91 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, MailingClient.Module["activateIFrame"](JsFunction.Literal("iframe")));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n    });\r\n                            </script>\r\n");

            
            #line 94 "..\..\Mailing\Views\EmailMessage.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "<pre>\r\n");

WriteLiteralTo(__razor_template_writer, "                            ");

            
            #line 98 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.Raw(HttpUtility.HtmlEncode(e.Value.Body)));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n                        </pre>\r\n");

            
            #line 100 "..\..\Mailing\Views\EmailMessage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "            </div>\r\n");

            
            #line 102 "..\..\Mailing\Views\EmailMessage.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "            ");

})
            
            #line 103 "..\..\Mailing\Views\EmailMessage.cshtml"
                   );



            if (e.Value.Mixins.OfType<EmailReceptionMixin>().Any() && e.Value.Mixin<EmailReceptionMixin>().ReceptionInfo != null)
            {
                using (var ri = e.SubContext(f => f.Mixin<EmailReceptionMixin>().ReceptionInfo))
                {
                    tabs.Tab("sfEmailReceptionInfo", ri.PropertyRoute.PropertyInfo.NiceName(), 
            
            #line default
            #line hidden
item => new System.Web.WebPages.HelperResult(__razor_template_writer => {

WriteLiteralTo(__razor_template_writer, "\r\n            <fieldset>\r\n                <legend>Properties</legend>\r\n\r\n");

WriteLiteralTo(__razor_template_writer, "                ");

            
            #line 115 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.EntityLine(ri, f => f.Reception));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "                ");

            
            #line 116 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.ValueLine(ri, f => f.UniqueId));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "                ");

            
            #line 117 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.ValueLine(ri, f => f.SentDate));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "                ");

            
            #line 118 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.ValueLine(ri, f => f.ReceivedDate));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n");

WriteLiteralTo(__razor_template_writer, "                ");

            
            #line 119 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, Html.ValueLine(ri, f => f.DeletionDate));

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "\r\n\r\n            </fieldset>\r\n\r\n            <pre>");

            
            #line 123 "..\..\Mailing\Views\EmailMessage.cshtml"
WriteTo(__razor_template_writer, ri.Value.RawContent);

            
            #line default
            #line hidden
WriteLiteralTo(__razor_template_writer, "</pre>\r\n            ");

})
            
            #line 124 "..\..\Mailing\Views\EmailMessage.cshtml"
                   );
                }
            }
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");

            
            #line 129 "..\..\Mailing\Views\EmailMessage.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
