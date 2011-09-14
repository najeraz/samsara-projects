
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class PersonalComputerTypeSearchForm : GenericSearchForm<PersonalComputerType>
    {
        public PersonalComputerTypeSearchForm()
        {
            InitializeComponent();
        }

        public override PersonalComputerType GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
