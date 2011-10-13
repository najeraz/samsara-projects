
using System.Collections.Generic;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Base.Dao.Interfaces;
using Samsara.Base.Service.Impl;
using Samsara.Support.Util;

namespace Samsara.Controls.Controls
{
    public partial class SamsaraEntityChooserControl<T, TId, TService, TDao, TPmt> : 
        SamsaraUserControl where TDao : IGenericDao<T, TId, TPmt> where TPmt : new()
    {
        #region Attributes

        private TService service;

        #endregion Attributes

        #region Properties

        public TPmt Parameters
        {
            get;
            set;
        }

        public T SelectedEntity
        {
            get;
            set;
        }

        public string ValueMember
        {
            get;
            set;
        }

        public string DisplayMember
        {
            get;
            set;
        }
        
        #endregion Properties

        #region Constructor

        public SamsaraEntityChooserControl()
        {
            InitializeComponent();

            this.ValueMember = typeof(T).Name + "Id";
            this.DisplayMember = "Name";
            this.Parameters = new TPmt();
        }

        #endregion Constructor

        #region Methods

        #region Public

        public virtual void RefreshEntities()
        {
            this.PrepareComponents();

            IList<T> entityList = (this.service as GenericService<T, TId, TDao, TPmt>)
                .GetListByParameters(this.Parameters);

            this.suceEntities.DataSource = null;
            WindowsFormsUtil.LoadCombo<T>(this.suceEntities, entityList, this.ValueMember,
                this.DisplayMember, "Seleccione");
        }

        #endregion Public

        #region Private

        private void PrepareComponents()
        {
            if (this.service == null)
            {
                this.service = SamsaraAppContext.Resolve<TService>();
                Assert.IsNotNull(this.service);
            }
        }

        #endregion Private

        #endregion Methods

    }
}
