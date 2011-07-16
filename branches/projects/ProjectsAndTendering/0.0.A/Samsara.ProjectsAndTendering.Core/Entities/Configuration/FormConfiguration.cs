﻿
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Iesi.Collections;

namespace Samsara.ProjectsAndTendering.Core.Entities.Configuration
{
    public class FormConfiguration
    {
        public FormConfiguration()
        {
            FormConfigurationId = -1;
        }

        public virtual int FormConfigurationId
        {
            get;
            set;
        }

        public virtual string FormName
        {
            get;
            set;
        }

        public virtual ISet GridConfigurations
        {
            get;
            set;
        }
    }
}