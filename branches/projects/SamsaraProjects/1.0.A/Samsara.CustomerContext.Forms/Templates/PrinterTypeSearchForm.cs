﻿
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class PrinterTypeSearchForm : GenericSearchForm<PrinterType>
    {
        public PrinterTypeSearchForm()
        {
            InitializeComponent();
        }

        public override PrinterType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
