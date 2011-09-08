
using System;
using Spring.Context;
using Spring.Context.Support;

namespace Samsara.Common.Context
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
        private static SamsaraAppContext _AppContext;

        /// <summary>
        /// Object that gonna content the context of the app
        /// </summary>
        private IApplicationContext _SpringContext = null;

        [System.Diagnostics.DebuggerStepThrough]
        private SamsaraAppContext()
        {
            try
            {
                _SpringContext = ContextRegistry.GetContext();
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
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                //return _AppContext = _AppContext ?? new AppContext();
                if (_AppContext == null)
                {
                    _AppContext = new SamsaraAppContext();
                }

                return _AppContext;
            }
        }

        /// <summary>
        /// Return a instance of object in the context by a given name
        /// </summary>
        /// <param name="objectName">Name of the solicited object</param>
        /// <returns>A instance of the object, in other case an exception</returns>
        public static object Resolve(string objectName) {
            return Instance._SpringContext.GetObject(objectName);
        }

        public static T Resolve<T>(string objectName) {
            return (T) Instance._SpringContext.GetObject(objectName);
        }

        /// <summary>
        /// Return a instance that correspond with the interface
        /// </summary>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough]
        public static T Resolve<T>()
        {
            //Console.Out.WriteLine("type to resolve: " + typeof(T).Name);
            return (T) Instance._SpringContext.GetObject(typeof (T).Name);
        }
    }
}