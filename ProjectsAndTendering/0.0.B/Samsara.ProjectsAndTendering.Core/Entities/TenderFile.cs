
using Iesi.Collections.Generic;
using Samsara.Base.Core.Attributes;
using System;

namespace Samsara.ProjectsAndTendering.Core.Entities
{
    public class TenderFile
    {
        public TenderFile()
        {
            TenderFileId = -1;
        }

        [PrimaryKey]
        public virtual int TenderFileId
        {
            get;
            set;
        }

        public virtual int TenderId
        {
            get;
            set;
        }

        public virtual byte[] File
        {
            get;
            set;
        }

        public virtual string Filename
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual decimal? FileSize
        {
            get;
            set;
        }
    }
}