﻿
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.CustomerContext.Core.Entities
{
    public class CustomerNetwork : GenericEntity
    {
        public CustomerNetwork()
        {
            CustomerNetworkId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int CustomerNetworkId
        {
            get;
            set;
        }

        public virtual Customer Customer
        {
            get;
            set;
        }

        public virtual CustomerNetworkSite CustomerNetworkSite
        {
            get;
            set;
        }

        public virtual CustomerNetworkSwitch CustomerNetworkSwitch
        {
            get;
            set;
        }

        public virtual CustomerNetworkCommutator CustomerNetworkCommutator
        {
            get;
            set;
        }

        public virtual CustomerNetworkCabling CustomerNetworkCabling
        {
            get;
            set;
        }

        public virtual CustomerNetworkRouter CustomerNetworkRouter
        {
            get;
            set;
        }

        public virtual CustomerNetworkFirewall CustomerNetworkFirewall
        {
            get;
            set;
        }

        public virtual CustomerNetworkWifi CustomerNetworkWifi
        {
            get;
            set;
        }
    }
}