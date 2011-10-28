
using System.Windows.Forms;
using Samsara.Controls.Interfaces;

namespace Samsara.Base.Forms.Forms
{
    public abstract partial class GenericDialogForm : CatalogForm, IDialogForm
    {
        public GenericDialogForm()
        {
            InitializeComponent();
        }
    }
}
