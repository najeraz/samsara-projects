
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.Main.Core.Entities;
using Samsara.Main.Core.Parameters;
using Samsara.Main.Forms.Forms;
using Samsara.Main.Service.Interfaces;

namespace Samsara.Main.Forms.Controller
{
    public class SchemeFormController
    {
        #region Attributes

        private SchemeForm frmScheme;
        private Scheme Scheme;
        private ISchemeService srvScheme;

        #endregion Attributes

        #region Constructor

        public SchemeFormController(SchemeForm instance)
        {
            this.frmScheme = instance;
            this.srvScheme = SamsaraAppContext.Resolve<ISchemeService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            this.frmScheme.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmScheme.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmScheme.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmScheme.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmScheme.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmScheme.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmScheme.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmScheme.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmScheme.HiddenDetail(!show);
            if (show)
                this.frmScheme.tabPrincipal.SelectedTab = this.frmScheme.tabPrincipal.TabPages["New"];
            else
                this.frmScheme.tabPrincipal.SelectedTab = this.frmScheme.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmScheme.txtDetName.Text == null || 
                this.frmScheme.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Esquema.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmScheme.txtDetName.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.Scheme.Name = this.frmScheme.txtDetName.Text;
            //this.Scheme.Description = this.frmScheme.txtDetDescription.Text;

            this.Scheme.Activated = true;
            this.Scheme.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmScheme.txtDetName.Text = string.Empty;
            this.frmScheme.txtDetDescription.Text = string.Empty;
        }

        private void ClearSearchControls()
        {
            this.frmScheme.txtSchName.Text = string.Empty;
        }

        private void SaveScheme()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Esquema?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvScheme.SaveOrUpdate(this.Scheme);
                this.frmScheme.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditScheme(int SchemeId)
        {
            this.Scheme = this.srvScheme.GetById(SchemeId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmScheme.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmScheme.txtDetName.Text = this.Scheme.Name;
            //this.frmScheme.txtDetDescription.Text = this.Scheme.Description;
        }

        private void DeleteEntity(int SchemeId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Esquema?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.Scheme = this.srvScheme.GetById(SchemeId);
            this.Scheme.Activated = false;
            this.Scheme.Deleted = true;
            this.srvScheme.SaveOrUpdate(this.Scheme);
            this.Search();
        }

        private void Search()
        {
            SchemeParameters pmtScheme = new SchemeParameters();

            pmtScheme.Name = "%" + this.frmScheme.txtSchName.Text + "%";

            DataTable dtSchemes = srvScheme.SearchByParameters(pmtScheme);

            this.frmScheme.grdSchSearch.DataSource = null;
            this.frmScheme.grdSchSearch.DataSource = dtSchemes;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.Scheme = new Scheme();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveScheme();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmScheme.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditScheme(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmScheme.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmScheme.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
