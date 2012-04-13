
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Samsara.Base.Controls.ControlsControllers;
using Samsara.Base.Controls.EventsArgs;
using Samsara.Base.Controls.EventsHandlers;

namespace Samsara.Base.Controls.Controls
{
    public partial class ManyToOneLevel1Control<T> : SamsaraUserControl
    {
        #region Attributes

        private bool readOnly;
        public ManyToOneLevel1ControlController<T> controller;
        
        #endregion Attributes

        #region Properties

        public bool ReadOnly
        {
            get
            {
                return this.readOnly;
            }
            set
            {
                this.controller.SetReadOnlyButtons(value);
                this.readOnly = value;
            }
        }

        #endregion Properties

        #region EventHandlers

        public event ManyToOneLevel1EntityChangedEventHandler<T> EntityChanged;

        #endregion EventHandlers

        #region Constructor

        public ManyToOneLevel1Control()
        {
            this.readOnly = false;
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        #region Protected

        public virtual void OnEntityChanged(ManyToOneLevel1EntityChangedEventArgs<T> e)
        {
            if (EntityChanged != null && e.EntityChanged != null)
                EntityChanged(this, e);
        }

        #endregion Protected

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
