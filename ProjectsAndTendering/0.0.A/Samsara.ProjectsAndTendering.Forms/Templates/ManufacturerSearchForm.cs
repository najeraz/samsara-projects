﻿
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Forms.Templates;

namespace Samsara.ProjectsAndTendering.Forms.Templates
{
    public partial class ManufacturerSearchForm : GenericSearchForm<Manufacturer>
    {
        public ManufacturerSearchForm()
        {
            InitializeComponent();
        }

        internal override Manufacturer GetSerchResult()
        {
            throw new System.NotImplementedException();
        }
    }
}
