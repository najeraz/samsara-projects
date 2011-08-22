
using Iesi.Collections.Generic;
using Samsara.ProjectsAndTendering.Core.Attributes;

namespace Samsara.ProjectsAndTendering.Core.Entities.Domain
{
    public class TenderFile
    {
        public TenderFile()
        {
            TenderFileId = -1;
        }

        [PrimaryKeyAttribute]
        public virtual int TenderFileId
        {
            get;
            set;
        }

        public virtual Tender Tender
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
    }
}