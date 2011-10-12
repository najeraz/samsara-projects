
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CustomerSearchForm : GenericSearchForm<Customer>
    {
        public CustomerSearchForm()
        {
            InitializeComponent();
        }

        public override Customer GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
