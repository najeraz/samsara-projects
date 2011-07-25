
using System;
using System.ComponentModel;

internal class SamsaraComponentResourceManager : ComponentResourceManager
{
    public SamsaraComponentResourceManager(Type type, string resourceName)
        : base(type)
    {
        this.BaseNameField = resourceName;
    }
}