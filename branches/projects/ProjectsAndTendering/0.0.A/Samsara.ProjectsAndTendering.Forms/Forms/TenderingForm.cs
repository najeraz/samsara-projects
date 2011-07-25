using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Core.Entities.Domain;
using Samsara.ProjectsAndTendering.Controls.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class TenderingForm : CatalogForm, ISearchForm<Tender>
    {
        #region Attributes

        private TenderingFormController ctrlTenderingForm;

        #endregion Attributes

        #region Properties

        public Tender SearchResult
        {
            get;
            set;
        }

        #endregion Properties

        #region Constructor

        public TenderingForm()
        {
            InitializeComponent();
            this.ctrlTenderingForm = new TenderingFormController(this);
        }

        #endregion Constructor
    }
}
