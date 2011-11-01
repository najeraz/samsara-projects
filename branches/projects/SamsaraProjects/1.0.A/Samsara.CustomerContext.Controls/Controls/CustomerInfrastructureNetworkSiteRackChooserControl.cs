﻿
using System.Reflection;
using Samsara.Base.Controls.Controls;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Core.Parameters;
using Samsara.CustomerContext.Dao.Interfaces;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Controls.Controls
{
    public partial class CustomerInfrastructureNetworkSiteRackChooserControl : SamsaraEntityChooserControl<CustomerInfrastructureNetworkSiteRack, int, ICustomerInfrastructureNetworkSiteRackService, ICustomerInfrastructureNetworkSiteRackDao, CustomerInfrastructureNetworkSiteRackParameters>
    {
        public CustomerInfrastructureNetworkSiteRackChooserControl()
        {
            string controlsSchemaNamespace = Assembly.GetExecutingAssembly().FullName.Substring(0,
                Assembly.GetExecutingAssembly().FullName.IndexOf(","));

            string schemaNamespace = controlsSchemaNamespace
                .Substring(0, controlsSchemaNamespace.LastIndexOf("."));

            AssemblyName = schemaNamespace + ".Forms.dll";
            AssemblyFormClassName = schemaNamespace + ".Forms.Forms.CustomerInfrastructureNetworkSiteRackForm";
            InitializeComponent();
        }
    }
}
