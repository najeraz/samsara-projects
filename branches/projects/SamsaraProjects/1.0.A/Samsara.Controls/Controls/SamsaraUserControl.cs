using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Samsara.Controls.Controls
{
    public partial class SamsaraUserControl : UserControl
    {

        #region Properties

        /// <summary>
        /// Form o custom control padre
        /// </summary>
        [Description("Form o custom control padre")]
        public Control CustomParent
        {
            get;
            set;
        }

        #endregion Properties

        public SamsaraUserControl()
        {
            InitializeComponent();
        }
    }
}
