
using System;
using System.Diagnostics;
using NUnit.Framework;
using Spring.Context;
using Spring.Context.Support;

namespace Samsara.Base.Core.Context
{
    /// <summary>
    /// AppContext it's a easy-simple-helper class that implement a singleton,
    /// and help to get the objects for the application making IoC with Spring.Net
    /// The methods wrapps the singleton.
    /// </summary>
    public class SamsaraAppContext
    {
        /// <summary>
        /// Needed recursive declaration to implement a singleton
        /// </summary>
        private static SamsaraAppContext context;

        /// <summary>
        /// Object that gonna content the context of the app
        /// </summary>
        private IApplicationContext applicationContext = null;

        [DebuggerStepThrough]
        private SamsaraAppContext()
        {
            try
            {
                applicationContext = ContextRegistry.GetContext();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't get the context of the Application", ex);
            }
        }

        /// <summary>
        /// Provide a Unique instance of AppContext
        /// </summary>
        private static SamsaraAppContext Instance
        {
            [DebuggerStepThrough]
            get
            {
                return context = context ?? new SamsaraAppContext();
            }
        }

        /// <summary>
        /// Return a instance of object in the context by a given name
        /// </summary>
        /// <param name="objectName">Name of the solicited object</param>
        /// <returns>A instance of the object, in other case an exception</returns>
        [DebuggerStepThrough]
        public static T Resolve<T>(string objectName)
        {
            T value = (T)Instance.applicationContext.GetObject(objectName);
            Assert.IsNotNull(value);

            return value;
        }

        /// <summary>
        /// Return a instance that correspond with the interface
        /// </summary>
        /// <returns>A instance of the object, in other case an exception</returns>
        [DebuggerStepThrough]
        public static T Resolve<T>()
        {
            T value = (T)Instance.applicationContext.GetObject(typeof(T).Name);
            Assert.IsNotNull(value);

            return value;
        }
    }
}