// -----------------------------------------------------------------------
// <copyright file="JavaScriptEnabledWebViewPage{TModel}.cs" company="Peter Chapman">
// Copyright 2015 Peter Chapman. See http://macjava.codeplex.com/license for licence details.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.MacJava
{
    using System.Web.Mvc;

    /// <summary>
    /// Represents the properties and methods that are needed in order to render
    /// a JavaScript enabled view that uses ASP.NET Razor syntax.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public abstract class JavaScriptEnabledWebViewPage<TModel> : WebViewPage<TModel>
    {
        /// <summary>
        /// Gets or sets the JavaScript helper.
        /// </summary>
        /// <value>
        /// The JavaScript helper.
        /// </value>
        public JavaScriptHelper<TModel> JavaScript { get; set; }

        /// <summary>
        /// Initializes the <see cref="T:System.Web.Mvc.AjaxHelper" />, <see cref="T:System.Web.Mvc.HtmlHelper" />, and <see cref="T:System.Web.Mvc.UrlHelper" /> classes.
        /// </summary>
        public override void InitHelpers()
        {
            this.JavaScript = new JavaScriptHelper<TModel>(this.ViewContext, this);
            base.InitHelpers();
        }
    }
}
