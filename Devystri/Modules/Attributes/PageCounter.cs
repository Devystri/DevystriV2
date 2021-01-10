using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class PageCounterAttribute : Attribute
    {
    }
}
