using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Samsara.Controls.Controllers;

namespace Samsara.Controls.Controls
{
    public partial class ManyToOneLevel1Control : UserControl
    {
        #region Attributes

        internal ManyToOneLevel1ControlController ctrlManyToOneLevel1Control;

        #endregion Attributes

        #region Constructor

        public ManyToOneLevel1Control()
        {
            InitializeComponent();
            this.ctrlManyToOneLevel1Control = new ManyToOneLevel1ControlController(this);
        }

        #endregion Constructor

        #region Methods

        #region Private

        private void Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ctrlManyToOneLevel1Control.Click(sender);
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
