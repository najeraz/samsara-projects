
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class OperativeSystemTypeSearchForm : GenericSearchForm<OperativeSystemType>
    {
        public OperativeSystemTypeSearchForm()
        {
            InitializeComponent();
        }

        public override OperativeSystemType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
