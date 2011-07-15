


namespace Samsara.ProjectsAndTendering.Core.Entities.Configuration
{
    public class GridColumnConfiguration
    {
        public GridColumnConfiguration()
        {
        }

        public virtual string FormName
        {
            get;
            set;
        }

        public virtual string GridName
        {
            get;
            set;
        }

        public virtual string ColumnName
        {
            get;
            set;
        }

        public virtual string ColumnEndUserName
        {
            get;
            set;
        }

        public virtual bool Visible
        {
            get;
            set;
        }
    }
}