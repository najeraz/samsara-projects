﻿
using Samsara.Base.Forms.Forms;
using Samsara.CustomerContext.Core.Entities;

namespace Samsara.CustomerContext.Forms.Templates
{
    public partial class UPSBrandSearchForm : GenericSearchForm<UPSBrand>
    {
        public UPSBrandSearchForm()
        {
            InitializeComponent();
        }

        public override UPSBrand GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
