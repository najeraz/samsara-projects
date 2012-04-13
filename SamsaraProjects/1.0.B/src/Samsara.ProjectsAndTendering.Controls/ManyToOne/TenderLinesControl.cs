
using Samsara.ProjectsAndTendering.Controls.ManyToOne.Controllers;
using Samsara.ProjectsAndTendering.Controls.ManyToOne.Templates;
using Samsara.ProjectsAndTendering.Core.Entities;

namespace Samsara.ProjectsAndTendering.Controls.ManyToOne
{
    public partial class TenderLinesControl : TenderTenderLinesControl
    {
        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public Tender Tender
        {
            get
            {
                return (this.controller as TenderLinesControlController).Tender;
            }
            set
            {
                (this.controller as TenderLinesControlController).Tender = value;
            }
        }

        #endregion Properties

        #region Constructor

        public TenderLinesControl()
        {
            InitializeComponent();
            this.controller = new TenderLinesControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Public

        public void LoadControls()
        {
            (this.controller as TenderLinesControlController).LoadControls();
        }

        public void ClearControls()
        {
            (this.controller as TenderLinesControlController).ClearControls();
        }

        #endregion Public

        #endregion Methods
    }
}
