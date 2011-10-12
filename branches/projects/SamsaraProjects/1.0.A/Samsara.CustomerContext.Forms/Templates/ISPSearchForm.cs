
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class ISPSearchForm : GenericSearchForm<ISP>
    {
        public ISPSearchForm()
        {
            InitializeComponent();
        }

        public override ISP GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
