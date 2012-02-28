
using Samsara.Base.Forms.Forms;
using Samsara.Main.Core.Entities;

namespace Samsara.Main.Forms.Templates
{
    public partial class SamsaraFormSearchForm : GenericCatalogSearchForm<SamsaraForm>
    {
        public SamsaraFormSearchForm()
        {
            InitializeComponent();
        }

        public override SamsaraForm GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
