// -----------------------------------------------------------------------
// <copyright file="JavaScript.cs" company="Peter Chapman">
// Copyright 2014 Peter Chapman. See http://macjava.codeplex.com/license for licence details.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.MacJava
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    /// <summary>
    /// JavaScript related routines.
    /// </summary>
    public static class JavaScript
    {
        /// <summary>
        /// Includes the specified JavaScript source files.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The HTML to include the JavaScript source file.</returns>
        public static MvcHtmlString Include(string source)
        {
            // If we have input
            if (!string.IsNullOrEmpty(source))
            {
                // Build and return the script tag
                TagBuilder tagBuilder = new TagBuilder("script");
                tagBuilder.MergeAttribute("type", "text/javascript");
                tagBuilder.MergeAttribute("src", source);
                return new MvcHtmlString(tagBuilder.ToString());
            }
            else
            {
                // Return an empty string
                return new MvcHtmlString(string.Empty);
            }
        }
    }
}
