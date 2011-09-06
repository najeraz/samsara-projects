using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComisionesAgentes
{
    public partial class ComisionDataDialog : Form
    {
        public decimal Cuota
        {
            get
            {
                try
                {
                    return Convert.ToDecimal(this.mskCuota.Text);
                }
                catch
                {
                    return decimal.Zero;
                }
            }
            set
            {
                this.mskCuota.Text = value.ToString();
            }
        }

        public decimal Comision
        {
            get
            {
                try
                {
                    return Convert.ToDecimal(this.mskComision.Text);
                }
                catch
                {
                    return decimal.Zero;
                }
            }
            set
            {
                this.mskComision.Text = value.ToString();
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
