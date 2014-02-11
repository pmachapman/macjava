// -----------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="Peter Chapman">
// Copyright 2014 Peter Chapman. See http://macjava.codeplex.com/license for licence details.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.MacJava.Sample
{
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Filter configuration.
    /// </summary>
    public static class FilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters != default(GlobalFilterCollection))
            {
                filters.Add(new HandleErrorAttribute());
            }
        }
    }
}
