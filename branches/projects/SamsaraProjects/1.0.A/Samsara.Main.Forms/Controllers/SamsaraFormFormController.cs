
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;
using Samsara.Main.Forms.Forms;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Main.Forms.Controller
{
    public class SamsaraFormFormController
    {
        #region Attributes

        private SamsaraFormForm frmSamsaraForm;
        private SamsaraForm SamsaraForm;
        private ISamsaraFormService srvSamsaraForm;

        #endregion Attributes

        #region Constructor

        public SamsaraFormFormController(SamsaraFormForm instance)
        {
            this.frmSamsaraForm = instance;
            this.srvSamsaraForm = SamsaraAppContext.Resolve<ISamsaraFormService>();
            Assert.IsNotNull(this.srvSamsaraForm);
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmSamsaraForm.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmSamsaraForm.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmSamsaraForm.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmSamsaraForm.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmSamsaraForm.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmSamsaraForm.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmSamsaraForm.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmSamsaraForm.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmSamsaraForm.HiddenDetail(!show);
            if (show)
                this.frmSamsaraForm.tabPrincipal.SelectedTab = this.frmSamsaraForm.tabPrincipal.TabPages["New"];
            else
                this.frmSamsaraForm.tabPrincipal.SelectedTab = this.frmSamsaraForm.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmSamsaraForm.txtDetName.Text == null || 
                this.frmSamsaraForm.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para la Competencia.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmSamsaraForm.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.SamsaraForm.Name = this.frmSamsaraForm.txtDetName.Text;
            //this.SamsaraForm.Description = this.frmSamsaraForm.txtDetDescription.Text;

            this.SamsaraForm.Activated = true;
            this.SamsaraForm.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmSamsaraForm.txtDetName.Text = string.Empty;
            this.frmSamsaraForm.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmSamsaraForm.txtSchName.Text = string.Empty;
        }

        private void SaveSamsaraForm()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el SamsaraForm?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvSamsaraForm.SaveOrUpdate(this.SamsaraForm);
                this.frmSamsaraForm.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditSamsaraForm(int SamsaraFormId)
        {
            this.SamsaraForm = this.srvSamsaraForm.GetById(SamsaraFormId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmSamsaraForm.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmSamsaraForm.txtDetName.Text = this.SamsaraForm.Name;
            //this.frmSamsaraForm.txtDetDescription.Text = this.SamsaraForm.Description;
        }

        private void DeleteEntity(int SamsaraFormId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar la Organización?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.SamsaraForm = this.srvSamsaraForm.GetById(SamsaraFormId);
            this.SamsaraForm.Activated = false;
            this.SamsaraForm.Deleted = true;
            this.srvSamsaraForm.SaveOrUpdate(this.SamsaraForm);
            this.Search();
        }

        private void Search()
        {
            SamsaraFormParameters pmtSamsaraForm = new SamsaraFormParameters();

            pmtSamsaraForm.Name = "%" + this.frmSamsaraForm.txtSchName.Text + "%";

            DataTable dtSamsaraForms = srvSamsaraForm.SearchByParameters(pmtSamsaraForm);

            this.frmSamsaraForm.grdSchSearch.DataSource = null;
            this.frmSamsaraForm.grdSchSearch.DataSource = dtSamsaraForms;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.SamsaraForm = new SamsaraForm();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveSamsaraForm();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmSamsaraForm.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditSamsaraForm(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmSamsaraForm.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmSamsaraForm.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
