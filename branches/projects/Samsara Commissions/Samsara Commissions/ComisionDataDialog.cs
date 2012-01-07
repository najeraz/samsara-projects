using System;
using System.Windows.Forms;

namespace SamsaraCommissions
{
    public partial class ComisionDataDialog : Form
    {
        public decimal Cuota
        {
            get
            {
                try
                {
                    return Convert.ToDecimal(this.txtCuota.Value);
                }
                catch
                {
                    return decimal.Zero;
                }
            }
            set
            {
                this.txtCuota.Value = value;
            }
        }

        public decimal Comision
        {
            get
            {
                try
                {
                    return Convert.ToDecimal(this.txtComision.Value.ToString().Replace("%", "")) / 100M;
                }
                catch
                {
                    return decimal.Zero;
                }
            }
            set
            {
                this.txtComision.Value = value;
            }
        }

        public ComisionTypeEnum? Tipo
        {
            get;
            private set;
        }
        public ComisionDataDialog()
        {
            InitializeComponent();
            this.rbtnMes.Checked = true;
        }
        
        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Tipo = this.rbtnMes.Checked ? ComisionTypeEnum.Mes : ComisionTypeEnum.Año;
        }

        private void rbtnMes_CheckedChanged(object sender, EventArgs e)
        {
            this.rbtnAño.Checked = !this.rbtnMes.Checked;
        }

        private void rbtnAño_CheckedChanged(object sender, EventArgs e)
        {
            this.rbtnMes.Checked = !this.rbtnAño.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Tipo = null;
        }
    }
}
