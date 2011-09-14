
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CommutatorTypeSearchForm : GenericSearchForm<CommutatorType>
    {
        public CommutatorTypeSearchForm()
        {
            InitializeComponent();
        }

        public override CommutatorType GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
