
using System.Windows.Forms;

namespace Samsara.ProjectsAndTendering.Controls.Interfaces
{
    public interface ISearchForm<T>
    {
        T SearchResult
        {
            get;
            set;
        }

        Form ParentSearchForm
        {
            get;
            set;
        }

        void PrepareSearchControls();
    }
}
