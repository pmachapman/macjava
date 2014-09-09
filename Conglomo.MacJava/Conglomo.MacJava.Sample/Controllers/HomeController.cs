// -----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Peter Chapman">
// Copyright 2014 Peter Chapman. See http://macjava.codeplex.com/license for licence details.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.MacJava.Sample.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: /Home/
        /// </summary>
        /// <returns>
        /// The index action result.
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// GET: /Home/About/
        /// </summary>
        /// <returns>
        /// The about action result.
        /// </returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        /// <summary>
        /// GET: /Home/Contact/
        /// </summary>
        /// <returns>
        /// The contact action result.
        /// </returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}