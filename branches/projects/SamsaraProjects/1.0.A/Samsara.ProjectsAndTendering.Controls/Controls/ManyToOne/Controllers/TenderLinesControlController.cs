
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Samsara.Base.Controls.Controllers;
using Samsara.Base.Core.Context;
using Samsara.Controls.Interfaces;
using Samsara.Operation.Core.Entities;
using Samsara.Operation.Service.Interfaces;
using Samsara.ProjectsAndTendering.Core.Entities;
using Samsara.ProjectsAndTendering.Core.Parameters;
using Samsara.ProjectsAndTendering.Service.Interfaces;
using Samsara.Support.Util;

namespace Samsara.ProjectsAndTendering.Controls.Controls.ManyToOne.Controllers
{
    public class TenderLinesControlController : ManyToOneLevel1ControlController<TenderLine>
    {
        #region Attributes

        private ITenderLineService srvTenderLine;
        private TenderLinesControl controlTenderLines;
        private TenderLine tenderLine;
        private ITenderService srvTender;
        private IProductService srvProduct;

        private DataTable dtTenderLines;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// La entidad padre
        /// </summary>
        public Tender Tender
        {
            get;
            set;
        }
        
        #endregion Properties
        
        #region Constructor

        public TenderLinesControlController(
            TenderLinesControl instance) : base(instance)  
        {
            this.controlTenderLines = instance;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.srvTenderLine = SamsaraAppContext.Resolve<ITenderLineService>();
                Assert.IsNotNull(this.srvTenderLine);
                this.srvTender = SamsaraAppContext.Resolve<ITenderService>();
                Assert.IsNotNull(this.srvTender);
                this.srvProduct = SamsaraAppContext.Resolve<IProductService>();
                Assert.IsNotNull(this.srvProduct);
            }

            this.InitializeControlControls();
        }

        #endregion Constructor

        #region Methods

        #region Private

        private void InitializeControlControls()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.controlTenderLines.grdRelations.InitializeLayout
                    += new InitializeLayoutEventHandler(grdRelations_InitializeLayout);

                this.controlTenderLines.pscProduct.DisplayMember = "Name";

                Assembly assembly = Assembly.LoadFile(Application.StartupPath + @"\" + "Samsara.Operation.Forms.dll");
                Type formType = assembly.GetType("Samsara.Operation.Forms.Forms.ProductForm");

                if (formType != null)
                {
                    ISearchForm<Product> formInstance = Activator.CreateInstance(formType) as ISearchForm<Product>;
                    this.controlTenderLines.pscProduct.SearchForm = formInstance;
                }
            }
        }

        #endregion Private

        #region Public

        public void LoadControls()
        {
            TenderLineParameters pmtTenderLine = new TenderLineParameters();
            pmtTenderLine.TenderId = ParameterConstants.IntNone;

            this.dtTenderLines = this.srvTenderLine.SearchByParameters(pmtTenderLine);

            this.controlTenderLines.grdRelations.DataSource = null;
            this.controlTenderLines.grdRelations.DataSource = this.dtTenderLines;

            if (this.Tender != null)
            {
                foreach (TenderLine tenderLine in this.Tender.TenderLines)
                {
                    DataRow row = this.dtTenderLines.NewRow();
                    this.dtTenderLines.Rows.Add(row);

                    row["TenderLineId"] = tenderLine.TenderLineId;
                    row["Name"] = tenderLine.Name;
                    row["Quantity"] = tenderLine.Quantity;
                    row["Description"] = tenderLine.Description;
                    if (tenderLine.Product == null)
                        row["ProductId"] = DBNull.Value;
                    else
                        row["ProductId"] = tenderLine.Product.ProductId;
                }
            }
        }

        #endregion Public

        #region Protected

        public override void ClearDetailControls()
        {
            base.ClearDetailControls();

            this.controlTenderLines.pscProduct.Value = null;
            this.controlTenderLines.txtName.Text = string.Empty;
            this.controlTenderLines.steQuantity.Value = null;
        }

        public override void ClearControls()
        {
            base.ClearControls();

            this.dtTenderLines.Rows.Clear();
            this.dtTenderLines.AcceptChanges();
        }

        protected override void CreateRelation()
        {
            base.CreateRelation();

            this.tenderLine = new TenderLine();

            this.tenderLine.Tender = this.Tender;
            this.tenderLine.Activated = true;
            this.tenderLine.Deleted = false;
        }

        protected override void DeleteEntity(int entityId)
        {
            base.DeleteEntity(entityId);

            if (entityId <= 0)
                this.tenderLine = this.Tender.TenderLines
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.tenderLine = this.Tender.TenderLines
                    .Single(x => x.TenderLineId == entityId);

            if (entityId <= 0)
                this.Tender.TenderLines.Remove(this.tenderLine);
            else
            {
                this.tenderLine.Activated = false;
                this.tenderLine.Deleted = true;
            }
        }

        protected override void LoadFromEntity(int entityId)
        {
            base.LoadFromEntity(entityId);

            if (entityId <= 0)
                this.tenderLine = this.Tender.TenderLines
                    .Single(x => -x.GetHashCode() == entityId);
            else
                this.tenderLine = this.Tender.TenderLines
                    .Single(x => x.TenderLineId == entityId);

            this.controlTenderLines.pscProduct.Value = this.tenderLine.Product;
            this.controlTenderLines.txtName.Text = this.tenderLine.Name;
            this.controlTenderLines.steQuantity.Value = this.tenderLine.Quantity;
        }

        protected override void LoadEntity()
        {
            base.LoadEntity();

            this.tenderLine.Product = this.controlTenderLines.pscProduct.Value;
            this.tenderLine.Description = this.tenderLine.Product.Name;
            this.tenderLine.Quantity = Convert.ToDecimal(this.controlTenderLines.steQuantity.Value);
            this.tenderLine.Name = this.controlTenderLines.txtName.Text;
        }

        protected override bool ValidateControlsData()
        {
            if (!base.ValidateControlsData())
                return false;

            if (this.controlTenderLines.pscProduct.Value == null)
            {
                MessageBox.Show("Favor de seleccionar el Producto.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlTenderLines.pscProduct.Focus();
                return false;
            }

            if (this.controlTenderLines.steQuantity.Value == null)
            {
                MessageBox.Show("Favor de agregar una Cantidad.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlTenderLines.pscProduct.Focus();
                return false;
            }

            if (this.controlTenderLines.txtName.Value == null)
            {
                MessageBox.Show("Favor de asignar un Nombre a la Partida.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.controlTenderLines.pscProduct.Focus();
                return false;
            }

            return true;
        }

        protected override void AddEntity()
        {
            DataRow row = null;

            base.AddEntity();

            if (this.tenderLine.TenderLineId == -1)
                row = this.dtTenderLines.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["TenderLineId"])
                       == -(this.tenderLine as object).GetHashCode());
            else
                row = this.dtTenderLines.AsEnumerable()
                    .SingleOrDefault(x => Convert.ToInt32(x["TenderLineId"])
                        == this.tenderLine.TenderLineId);

            if (row == null)
            {
                this.Tender.TenderLines.Add(this.tenderLine);

                row = this.dtTenderLines.NewRow();
                this.dtTenderLines.Rows.Add(row);
            }

            if (this.tenderLine.TenderLineId == -1)
                row["TenderLineId"] = -(this.tenderLine as object).GetHashCode();
            else
                row["TenderLineId"] = this.tenderLine.TenderLineId;

            row["ProductId"] = this.tenderLine.Product.ProductId;
            row["Name"] = this.tenderLine.Name;
            row["Quantity"] = this.tenderLine.Quantity;
            row["Description"] = this.tenderLine.Description;

            this.dtTenderLines.AcceptChanges();
        }

        protected override void EnabledDetailControls(bool enabled)
        {
            base.EnabledDetailControls(enabled);

            this.controlTenderLines.pscProduct.ReadOnly = !enabled;
            this.controlTenderLines.txtName.ReadOnly = !enabled;
            this.controlTenderLines.steQuantity.ReadOnly = !enabled;
        }

        #endregion Protected

        #endregion Methods

        #region Events

        private void grdRelations_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            UltraGridBand band = layout.Bands[0];

            band.Override.AllowUpdate = DefaultableBoolean.False;

            layout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
            band.Override.MinRowHeight = 3;
            band.Override.RowSizing = RowSizing.AutoFixed;
            band.Override.RowSizingAutoMaxLines = 5;

            band.Columns["TenderLineId"].CellActivation = Activation.ActivateOnly;
            band.Columns["Description"].CellMultiLine = DefaultableBoolean.True;
            band.Columns["Description"].VertScrollBar = true;

            WindowsFormsUtil.SetUltraColumnFormat(band.Columns["Quantity"],
                TextMaskFormatEnum.NaturalQuantity);
        }

        #endregion Events
    }
}
