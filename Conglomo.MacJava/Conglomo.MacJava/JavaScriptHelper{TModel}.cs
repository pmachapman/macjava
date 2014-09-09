// -----------------------------------------------------------------------
// <copyright file="JavaScriptHelper{TModel}.cs" company="Peter Chapman">
// Copyright 2014 Peter Chapman. See http://macjava.codeplex.com/license for licence details.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.MacJava
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// The JavaScript helper functions.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class JavaScriptHelper<TModel> : JavaScriptHelper
    {
        /// <summary>
        /// The dynamic view data.
        /// </summary>
        private DynamicViewData dynamicViewData;

        /// <summary>
        /// The view data.
        /// </summary>
        private ViewDataDictionary<TModel> viewData;

        /// <summary>
        /// Initialises a new instance of the <see cref="JavaScriptHelper{TModel}"/> class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <param name="viewDataContainer">The view data container.</param>
        public JavaScriptHelper(ViewContext viewContext, IViewDataContainer viewDataContainer)
            : this(viewContext, viewDataContainer, RouteTable.Routes)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="JavaScriptHelper{TModel}"/> class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <param name="viewDataContainer">The view data container.</param>
        /// <param name="routeCollection">The route collection.</param>
        public JavaScriptHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, RouteCollection routeCollection)
            : base(viewContext, viewDataContainer, routeCollection)
        {
            this.viewData = new ViewDataDictionary<TModel>(viewDataContainer.ViewData);
        }

        /// <summary>
        /// Gets the view bag.
        /// </summary>
        /// <value>
        /// The view bag.
        /// </value>
        public new dynamic ViewBag
        {
            get
            {
                if (this.dynamicViewData == default(DynamicViewData))
                {
                    this.dynamicViewData = new DynamicViewData(() => this.ViewData);
                }

                return this.dynamicViewData;
            }
        }

        /// <summary>
        /// Gets the view data.
        /// </summary>
        /// <value>
        /// The view data.
        /// </value>
        public new ViewDataDictionary<TModel> ViewData
        {
            get
            {
                return this.viewData;
            }
        }
    }
}
