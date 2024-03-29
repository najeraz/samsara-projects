﻿
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Samsara.Base.Core.Context;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Forms.Forms;
using Samsara.ProjectsAndTendering.Service.Interfaces;

namespace Samsara.ProjectsAndTendering.Forms.Controller
{
    public class BidderFormController
    {
        #region Attributes

        private BidderForm frmBidder;
        private Bidder bidder;
        private IBidderService srvBidder;
        private IBidderTypeService srvBidderType;

        #endregion Attributes

        #region Constructor

        public BidderFormController(BidderForm instance)
        {
            this.frmBidder = instance;
            this.srvBidder = SamsaraAppContext.Resolve<IBidderService>();
            this.srvBidderType = SamsaraAppContext.Resolve<IBidderTypeService>();
            this.InitializeFormControls();
        }

        #endregion Constructor
        
        #region Methods

        private void InitializeFormControls()
        {
            // BidderType
            BidderTypeParameters pmtBidderType = new BidderTypeParameters();

            this.frmBidder.btccDetBidderType.Parameters = pmtBidderType;
            this.frmBidder.btccDetBidderType.ValueMember = "BidderTypeId";
            this.frmBidder.btccDetBidderType.DisplayMember = "Name";
            this.frmBidder.btccDetBidderType.Refresh();

            this.frmBidder.btccSchBidderType.Parameters = pmtBidderType;
            this.frmBidder.btccSchBidderType.ValueMember = "BidderTypeId";
            this.frmBidder.btccSchBidderType.DisplayMember = "Name";
            this.frmBidder.btccSchBidderType.Refresh();

            this.frmBidder.btnSchEdit.Click += new EventHandler(btnSchEdit_Click);
            this.frmBidder.btnSchSearch.Click += new EventHandler(btnSchSearch_Click);
            this.frmBidder.btnSchCreate.Click += new EventHandler(btnSchCreate_Click);
            this.frmBidder.btnDetSave.Click += new EventHandler(btnDetSave_Click);
            this.frmBidder.btnDetCancel.Click += new EventHandler(btnDetCancel_Click);
            this.frmBidder.btnSchClear.Click += new EventHandler(btnSchClear_Click);
            this.frmBidder.btnSchDelete.Click += new EventHandler(this.btnSchDelete_Click);

            this.frmBidder.HiddenDetail(true);
            this.ClearSearchControls();
        }

        private void ShowDetail(bool show)
        {
            this.frmBidder.HiddenDetail(!show);
            if (show)
                this.frmBidder.tabPrincipal.SelectedTab = this.frmBidder.tabPrincipal.TabPages["New"];
            else
                this.frmBidder.tabPrincipal.SelectedTab = this.frmBidder.tabPrincipal.TabPages["Search"];
        }

        private bool ValidateFormInformation()
        {
            if (this.frmBidder.txtDetName.Text == null || 
                this.frmBidder.txtDetName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Favor de elegir un nombre para el Licitante.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmBidder.txtDetName.Focus();
                return false;
            }

            if (this.frmBidder.btccDetBidderType.Value == null)
            {
                MessageBox.Show("Favor de seleccionar el Tipo de Licitante.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmBidder.btccDetBidderType.Focus();
                return false;
            }

            return true;
        }

        private void LoadEntity()
        {
            this.bidder.BidderType = this.frmBidder.btccDetBidderType.Value;
            this.bidder.Name = this.frmBidder.txtDetName.Text;

            this.bidder.Activated = true;
            this.bidder.Deleted = false;
        }

        private void ClearDetailControls()
        {
            this.frmBidder.txtDetName.Text = string.Empty;
            this.frmBidder.btccDetBidderType.Value = null;
        }

        private void ClearSearchControls()
        {
            this.frmBidder.txtSchName.Text = string.Empty;
            this.frmBidder.btccSchBidderType.Value = null;
        }

        private void SaveBidder()
        {
            if (this.ValidateFormInformation())
            {
                if (MessageBox.Show("¿Esta seguro de guardar el Licitante?", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                this.LoadEntity();
                this.srvBidder.SaveOrUpdate(this.bidder);
                this.frmBidder.HiddenDetail(true);
                this.Search();
            }
        }

        private void EditBidder(int bidderId)
        {
            this.bidder = this.srvBidder.GetById(bidderId);

            this.ClearDetailControls();
            this.LoadFormFromEntity();
            this.frmBidder.HiddenDetail(false);
            this.ShowDetail(true);
        }

        private void LoadFormFromEntity()
        {
            this.frmBidder.txtDetName.Text = this.bidder.Name;
            this.frmBidder.btccDetBidderType.Value = this.bidder.BidderType;
        }

        private void DeleteEntity(int bidderId)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Licitante?", "Advertencia",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            this.bidder = this.srvBidder.GetById(bidderId);
            this.bidder.Activated = false;
            this.bidder.Deleted = true;
            this.srvBidder.SaveOrUpdate(this.bidder);
            this.Search();
        }

        private void Search()
        {
            BidderParameters pmtBidder = new BidderParameters();

            pmtBidder.Name = "%" + this.frmBidder.txtSchName.Text + "%";
            pmtBidder.BidderTypeId = this.frmBidder.btccSchBidderType.Value == null ?
                -1 : this.frmBidder.btccSchBidderType.Value.BidderTypeId;

            DataTable dtBidders = srvBidder.SearchByParameters(pmtBidder);

            this.frmBidder.grdSchSearch.DataSource = null;
            this.frmBidder.grdSchSearch.DataSource = dtBidders;
        }

        #endregion Methods
        
        #region Events
        
        private void btnSchSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void btnSchCreate_Click(object sender, EventArgs e)
        {
            this.bidder = new Bidder();
            this.ClearDetailControls();
            this.ShowDetail(true);
        }

        private void btnDetSave_Click(object sender, EventArgs e)
        {
            this.SaveBidder();
        }
        
        private void btnSchEdit_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmBidder.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.EditBidder(Convert.ToInt32(activeRow.Cells[0].Value));
        }

        private void btnDetCancel_Click(object sender, EventArgs e)
        {
            this.frmBidder.HiddenDetail(true);
        }

        private void btnSchClear_Click(object sender, EventArgs e)
        {
            this.ClearSearchControls();
        }

        private void btnSchDelete_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.frmBidder.grdSchSearch.ActiveRow;

            if (activeRow != null)
                this.DeleteEntity(Convert.ToInt32(activeRow.Cells[0].Value));
        }
        #endregion Events
    }
}
