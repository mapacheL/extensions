﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Extensions.Scheduler.Views
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
    
    #line 1 "..\..\Scheduler\Views\ScheduledTask.cshtml"
    using Signum.Engine;
    
    #line default
    #line hidden
    using Signum.Entities;
    
    #line 2 "..\..\Scheduler\Views\ScheduledTask.cshtml"
    using Signum.Entities.Scheduler;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Scheduler/Views/ScheduledTask.cshtml")]
    public partial class ScheduledTask : System.Web.Mvc.WebViewPage<dynamic>
    {
        public ScheduledTask()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Scheduler\Views\ScheduledTask.cshtml"
 using (var e = Html.TypeContext<ScheduledTaskDN>())
{
    
            
            #line default
            #line hidden
            
            #line 6 "..\..\Scheduler\Views\ScheduledTask.cshtml"
Write(Html.ValueLine(e, f => f.Suspended));

            
            #line default
            #line hidden
            
            #line 6 "..\..\Scheduler\Views\ScheduledTask.cshtml"
                                        
    
            
            #line default
            #line hidden
            
            #line 7 "..\..\Scheduler\Views\ScheduledTask.cshtml"
Write(Html.EntityLine(e, f => f.Task, vl=>vl.Create = false));

            
            #line default
            #line hidden
            
            #line 7 "..\..\Scheduler\Views\ScheduledTask.cshtml"
                                                           
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Scheduler\Views\ScheduledTask.cshtml"
Write(Html.EntityDetail(e, f => f.Rule));

            
            #line default
            #line hidden
            
            #line 8 "..\..\Scheduler\Views\ScheduledTask.cshtml"
                                      
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Scheduler\Views\ScheduledTask.cshtml"
Write(Html.ValueLine(e, f => f.MachineName));

            
            #line default
            #line hidden
            
            #line 9 "..\..\Scheduler\Views\ScheduledTask.cshtml"
                                          
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Scheduler\Views\ScheduledTask.cshtml"
Write(Html.ValueLine(e, f => f.ApplicationName));

            
            #line default
            #line hidden
            
            #line 10 "..\..\Scheduler\Views\ScheduledTask.cshtml"
                                              
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
