
using Samsara.ProjectsAndTendering.Forms.Templates;
using Samsara.ProjectsAndTendering.Forms.Controller;
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.Common.Context;
using NUnit.Framework;
using Samsara.ProjectsAndTendering.Core.Entities;
using Infragistics.Win.UltraWinGrid;
using System;

namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    public partial class DocumentTypeWarrantyForm : DocumentTypeWarrantySearchForm
    {
        #region Attributes

        private DocumentTypeWarrantyFormController ctrlDocumentTypeWarrantyForm;
        private IDocumentTypeWarrantyService srvDocumentTypeWarranty;

        #endregion Attributes

        public DocumentTypeWarrantyForm()
        {
            InitializeComponent();
            this.ctrlDocumentTypeWarrantyForm = new DocumentTypeWarrantyFormController(this);
            this.srvDocumentTypeWarranty = SamsaraAppContext.Resolve<IDocumentTypeWarrantyService>();
            Assert.IsNotNull(this.srvDocumentTypeWarranty);
        }

        #region Methods

        internal override DocumentTypeWarranty GetSerchResult()
        {
            DocumentTypeWarranty DocumentTypeWarranty = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int DocumentTypeWarrantyId = Convert.ToInt32(activeRow.Cells[0].Value);
                DocumentTypeWarranty = this.srvDocumentTypeWarranty.GetById(DocumentTypeWarrantyId);
            }

            return DocumentTypeWarranty;
        }

        #endregion Methods
    }
}
