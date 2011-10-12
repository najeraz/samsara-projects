
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CCTVBrandSearchForm : GenericSearchForm<CCTVBrand>
    {
        public CCTVBrandSearchForm()
        {
            InitializeComponent();
        }

        public override CCTVBrand GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
