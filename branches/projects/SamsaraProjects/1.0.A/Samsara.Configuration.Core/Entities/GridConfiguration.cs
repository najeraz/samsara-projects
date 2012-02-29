﻿
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using Samsara.Base.Core.Entities;

namespace Samsara.Configuration.Core.Entities
{
    public class GridConfiguration : GenericEntity
    {
        private ISet<GridColumnConfiguration> gridColumnfigurations;

        public GridConfiguration()
        {
            GridConfigurationId = -1;
        }

        [PrimaryKey]
        public virtual int GridConfigurationId
        {
            get;
            set;
        }

        public virtual FormConfiguration FormConfiguration
        {
            get;
            set;
        }

        public virtual string GridName
        {
            get;
            set;
        }

        public virtual bool IgnoreConfiguration
        {
            get;
            set;
        }

        [PropagationAudit]
        public virtual ISet<GridColumnConfiguration> GridColumnConfigurations
        {
            get
            {
                if (this.gridColumnfigurations == null)
                    this.gridColumnfigurations = new HashedSet<GridColumnConfiguration>();

                return this.gridColumnfigurations;
            }
            set
            {
                this.gridColumnfigurations = value;
            }
        }
    }
}