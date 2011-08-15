
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class CurrencySearchForm : GenericSearchForm<Currency>
    {
        public CurrencySearchForm()
        {
            InitializeComponent();
        }

        internal override Currency GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
