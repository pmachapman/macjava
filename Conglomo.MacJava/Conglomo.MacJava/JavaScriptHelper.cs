// -----------------------------------------------------------------------
// <copyright file="JavaScriptHelper.cs" company="Peter Chapman">
// Copyright 2014 Peter Chapman. See http://macjava.codeplex.com/license for licence details.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.MacJava
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// The JavaScript helper functions.
    /// </summary>
    public class JavaScriptHelper
    {
        /// <summary>
        /// The dynamic view data.
        /// </summary>
        private DynamicViewData dynamicViewData;

        /// <summary>
        /// Initialises a new instance of the <see cref="JavaScriptHelper"/> class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <param name="viewDataContainer">The view data container.</param>
        public JavaScriptHelper(ViewContext viewContext, IViewDataContainer viewDataContainer)
            : this(viewContext, viewDataContainer, RouteTable.Routes)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="JavaScriptHelper" /> class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <param name="viewDataContainer">The view data container.</param>
        /// <param name="routeCollection">The route collection.</param>
        /// <exception cref="System.ArgumentNullException">
        /// viewContext;Missing view context
        /// or
        /// viewDataContainer;Missing view data container
        /// or
        /// routeCollection;Missing route collection
        /// </exception>
        public JavaScriptHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, RouteCollection routeCollection)
        {
            if (viewContext == default(ViewContext))
            {
                throw new ArgumentNullException("viewContext", "Missing view context");
            }
            else if (viewDataContainer == default(IViewDataContainer))
            {
                throw new ArgumentNullException("viewDataContainer", "Missing view data container");
            }
            else if (routeCollection == default(RouteCollection))
            {
                throw new ArgumentNullException("routeCollection", "Missing route collection");
            }

            this.ViewContext = viewContext;
            this.ViewDataContainer = viewDataContainer;
            this.RouteCollection = routeCollection;
        }

        /// <summary>
        /// Gets the route collection.
        /// </summary>
        /// <value>
        /// The route collection.
        /// </value>
        public RouteCollection RouteCollection { get; private set; }

        /// <summary>
        /// Gets the view bag.
        /// </summary>
        /// <value>
        /// The view bag.
        /// </value>
        public dynamic ViewBag
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
        /// Gets the view context.
        /// </summary>
        /// <value>
        /// The view context.
        /// </value>
        public ViewContext ViewContext { get; private set; }

        /// <summary>
        /// Gets the view data.
        /// </summary>
        /// <value>
        /// The view data.
        /// </value>
        public ViewDataDictionary ViewData
        {
            get
            {
                return this.ViewDataContainer.ViewData;
            }
        }

        /// <summary>
        /// Gets the view data container.
        /// </summary>
        /// <value>
        /// The view data container.
        /// </value>
        public IViewDataContainer ViewDataContainer { get; internal set; }
    }
}
