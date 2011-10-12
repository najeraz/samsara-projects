
using System;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.CustomerContext.Core.Entities;
using Samsara.CustomerContext.Forms.Controller;
using Samsara.CustomerContext.Forms.Templates;
using Samsara.CustomerContext.Service.Interfaces;

namespace Samsara.CustomerContext.Forms.Forms
{
    public partial class BackupSoftwareBrandForm : BackupSoftwareBrandSearchForm
    {
        #region Attributes

        private BackupSoftwareBrandFormController ctrlBackupSoftwareBrandForm;
        private IBackupSoftwareBrandService srvBackupSoftwareBrand;

        #endregion Attributes

        public BackupSoftwareBrandForm()
        {
            InitializeComponent();
            this.ctrlBackupSoftwareBrandForm = new BackupSoftwareBrandFormController(this);
            this.srvBackupSoftwareBrand = SamsaraAppContext.Resolve<IBackupSoftwareBrandService>();
            Assert.IsNotNull(this.srvBackupSoftwareBrand);
        }

        #region Methods

        public override BackupSoftwareBrand GetSearchResult()
        {
            BackupSoftwareBrand BackupSoftwareBrand = null;
            UltraGridRow activeRow = this.grdSchSearch.ActiveRow;

            if (activeRow != null)
            {
                int BackupSoftwareBrandId = Convert.ToInt32(activeRow.Cells[0].Value);
                BackupSoftwareBrand = this.srvBackupSoftwareBrand.GetById(BackupSoftwareBrandId);
            }

            return BackupSoftwareBrand;
        }

        #endregion Methods
    }
}
