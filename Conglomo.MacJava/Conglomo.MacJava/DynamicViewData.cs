// -----------------------------------------------------------------------
// <copyright file="DynamicViewData.cs" company="Peter Chapman">
// Copyright 2014 Peter Chapman. See http://macjava.codeplex.com/license for licence details.
// </copyright>
// -----------------------------------------------------------------------

namespace Conglomo.MacJava
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Dynamic;
    using System.Web.Mvc;

    /// <summary>
    /// The dynamic view data.
    /// </summary>
    public sealed class DynamicViewData : DynamicObject
    {
        /// <summary>
        /// The view data function
        /// </summary>
        private readonly Func<ViewDataDictionary> viewDataFunction;

        /// <summary>
        /// Initialises a new instance of the <see cref="DynamicViewData"/> class.
        /// </summary>
        /// <param name="viewDataFunction">The view data function.</param>
        public DynamicViewData(Func<ViewDataDictionary> viewDataFunction)
        {
            this.viewDataFunction = viewDataFunction;
        }

        /// <summary>
        /// Gets the view data.
        /// </summary>
        /// <value>
        /// The view data.
        /// </value>
        private ViewDataDictionary ViewData
        {
            get
            {
                return this.viewDataFunction();
            }
        }

        /// <summary>
        /// Returns the enumeration of all dynamic member names.
        /// </summary>
        /// <returns>
        /// A sequence that contains dynamic member names.
        /// </returns>
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return this.ViewData.Keys;
        }

        /// <summary>
        /// Provides the implementation for operations that get member values. Classes derived from the <see cref="T:System.Dynamic.DynamicObject" /> class can override this method to specify dynamic behaviour for operations such as getting a value for a property.
        /// </summary>
        /// <param name="binder">Provides information about the object that called the dynamic operation. The binder.Name property provides the name of the member on which the dynamic operation is performed. For example, for the Console.WriteLine(sampleObject.SampleProperty) statement, where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, binder.Name returns "SampleProperty". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
        /// <param name="result">The result of the get operation. For example, if the method is called for a property, you can assign the property value to <paramref name="result" />.</param>
        /// <returns>
        /// <c>true</c> if the operation is successful; otherwise, <c>false</c>. If this method returns false, the run-time binder of the language determines the behaviour. (In most cases, a run-time exception is thrown.)
        /// </returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (binder != default(GetMemberBinder))
            {
                result = this.ViewData[binder.Name];
                return true;
            }
            else
            {
                result = default(object);
                return false;
            }
        }

        /// <summary>
        /// Provides the implementation for operations that set member values. Classes derived from the <see cref="T:System.Dynamic.DynamicObject" /> class can override this method to specify dynamic behaviour for operations such as setting a value for a property.
        /// </summary>
        /// <param name="binder">Provides information about the object that called the dynamic operation. The binder.Name property provides the name of the member to which the value is being assigned. For example, for the statement sampleObject.SampleProperty = "Test", where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, binder.Name returns "SampleProperty". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
        /// <param name="value">The value to set to the member. For example, for sampleObject.SampleProperty = "Test", where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, the <paramref name="value" /> is "Test".</param>
        /// <returns>
        /// <c>true</c> if the operation is successful; otherwise, false. If this method returns <c>false</c>, the run-time binder of the language determines the behaviour. (In most cases, a language-specific run-time exception is thrown.)
        /// </returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (binder != default(SetMemberBinder))
            {
                this.ViewData[binder.Name] = value;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
