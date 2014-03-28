// -----------------------------------------------------------------------
// <copyright file="JavaScriptEnabledWebViewPage.cs" company="Peter Chapman">
// Copyright 2014 Peter Chapman. See http://macjava.codeplex.com/license for licence details.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.MacJava
{
    using System.Web.Mvc;

    /// <summary>
    /// Represents the properties and methods that are needed in order to render
    /// a JavaScript enabled view that uses ASP.NET Razor syntax.
    /// </summary>
    public abstract class JavaScriptEnabledWebViewPage : WebViewPage
    {
        /// <summary>
        /// Gets or sets the JavaScript helper.
        /// </summary>
        /// <value>
        /// The JavaScript helper.
        /// </value>
        public JavaScriptHelper<object> JavaScript { get; set; }

        /// <summary>
        /// Initializes the <see cref="T:System.Web.Mvc.AjaxHelper" />, <see cref="T:System.Web.Mvc.HtmlHelper" />, and <see cref="T:System.Web.Mvc.UrlHelper" /> classes.
        /// </summary>
        public override void InitHelpers()
        {
            this.JavaScript = new JavaScriptHelper<object>(this.ViewContext, this);
            base.InitHelpers();
        }
    }
}
