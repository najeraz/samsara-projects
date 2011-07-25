using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samsara.ProjectsAndTendering.Controls.Interfaces
{
    public interface ISearchForm<T>
    {
        T SearchResult
        {
            get;
            set;
        }
    }
}
