
using System;
using System.ComponentModel;

namespace Samsara.Controls
{
    internal class SamsaraComponentResourceManager : ComponentResourceManager
    {
        public SamsaraComponentResourceManager(Type type, string resourceName)
            : base(type)
        {
            this.BaseNameField = resourceName;
        }
    }
}