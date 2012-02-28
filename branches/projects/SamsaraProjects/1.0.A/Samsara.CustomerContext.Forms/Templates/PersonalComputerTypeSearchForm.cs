
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class PersonalComputerTypeSearchForm : GenericCatalogSearchForm<PersonalComputerType>
    {
        public PersonalComputerTypeSearchForm()
        {
            InitializeComponent();
        }

        public override PersonalComputerType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
