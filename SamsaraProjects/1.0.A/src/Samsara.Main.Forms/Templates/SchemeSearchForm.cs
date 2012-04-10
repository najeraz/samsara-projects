
using Samsara.Base.Forms.Forms;
using Samsara.Main.Core.Entities;

namespace Samsara.Main.Forms.Templates
{
    public partial class SchemeSearchForm : GenericCatalogSearchForm<Scheme>
    {
        public SchemeSearchForm()
        {
            InitializeComponent();
        }

        public override Scheme GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
