
using System;
using System.ComponentModel;

namespace Samsara.Controls
{
    public class SamsaraComponentResourceManager : ComponentResourceManager
    {
        public SamsaraComponentResourceManager(Type type, string resourceName)
            : base(type)
        {
            this.BaseNameField = resourceName;
        }
    }
}