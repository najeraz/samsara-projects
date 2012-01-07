
using System;
using System.Windows.Forms;

namespace SamsaraCommissions
{
    public partial class MinimalMarginDialog : Form
    {
        public bool Accepted
        {
            get;
            set;
        }

        public string ConceptName
        {
            get
            {
                return this.mskName.Text;
            }
            set
            {
                this.mskName.Text = value;
            }
        }

        public Nullable<decimal> MinimalMargin
        {
            get
            {
                try
                {
                    return Convert.ToDecimal(this.txtMargin.Value.ToString().Replace("%", ""));
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                this.txtMargin.Value = value;
            }
        }

        public MinimalMarginDialog()
        {
            InitializeComponent();
            this.Accepted = false;
        }
        
        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Accepted = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
