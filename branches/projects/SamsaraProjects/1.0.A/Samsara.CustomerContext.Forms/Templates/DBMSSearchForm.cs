
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class DBMSSearchForm : GenericSearchForm<DBMS>
    {
        public DBMSSearchForm()
        {
            InitializeComponent();
        }

        public override DBMS GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
