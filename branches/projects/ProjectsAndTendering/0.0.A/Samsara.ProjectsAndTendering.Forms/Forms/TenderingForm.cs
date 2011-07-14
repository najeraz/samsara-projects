using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Samsara.ProjectsAndTendering.Forms.Controller;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class TenderingForm : CatalogForm
    {
        #region Attributes

        private TenderingFormController ctrlTenderingForm;

        #endregion Attributes

        #region Constructor

        public TenderingForm()
        {
            InitializeComponent();
            this.ctrlTenderingForm = new TenderingFormController(this);
        }

        #endregion Constructor
    }
}
