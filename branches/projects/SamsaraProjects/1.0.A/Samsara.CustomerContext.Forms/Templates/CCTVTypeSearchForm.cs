﻿
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class CCTVTypeSearchForm : GenericSearchForm<CCTVType>
    {
        public CCTVTypeSearchForm()
        {
            InitializeComponent();
        }

        public override CCTVType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
