﻿
using Samsara.Base.Forms.Forms;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class WarrantyTypeSearchForm : GenericCatalogSearchForm<WarrantyType>
    {
        public WarrantyTypeSearchForm()
        {
            InitializeComponent();
        }

        public override WarrantyType GetSearchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
