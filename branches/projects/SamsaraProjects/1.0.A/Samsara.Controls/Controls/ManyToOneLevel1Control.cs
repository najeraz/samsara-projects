using System;
using System.Diagnostics;
using System.Windows.Forms;
using Samsara.Controls.Controllers;

namespace Samsara.Controls.Controls
{
    public partial class ManyToOneLevel1Control : UserControl
    {
        #region Attributes

        public ManyToOneLevel1ControlController controller;

        #endregion Attributes

        #region Constructor

        public ManyToOneLevel1Control()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        #region Private

        [DebuggerStepThrough]
        internal void Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.controller.ButtonClick(sender);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion Private

        #endregion Methods
    }
}
