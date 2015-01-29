// -----------------------------------------------------------------------
// <copyright file="TestAreaRegistration.cs" company="Peter Chapman">
// Copyright 2015 Peter Chapman. See http://macjava.codeplex.com/license for licence details.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.MacJava.Sample.Areas.Test
{
    using System.Web.Mvc;

    /// <summary>
    /// The test area registration.
    /// </summary>
    public class TestAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Gets the name of the area to register.
        /// </summary>
        /// <returns>The name of the area to register.</returns>
        public override string AreaName 
        {
            get 
            {
                return "Test";
            }
        }

        /// <summary>
        /// Registers an area in an ASP.NET MVC application using the specified area's context information.
        /// </summary>
        /// <param name="context">Encapsulates the information that is required in order to register the area.</param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Test_default",
                "Test/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}