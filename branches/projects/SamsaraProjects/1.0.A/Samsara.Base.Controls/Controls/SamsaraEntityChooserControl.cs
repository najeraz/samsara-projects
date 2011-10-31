
using System.Collections.Generic;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using NUnit.Framework;
using Samsara.Base.Core.Context;
using Samsara.Base.Dao.Interfaces;
using Samsara.Base.Service.Impl;
using Samsara.Controls.Controls;
using Samsara.Support.Util;
using System;
using System.Reflection;

namespace Samsara.Base.Controls.Controls
{
    public partial class SamsaraEntityChooserControl<T, TId, TService, TDao, TPmt> : 
        SamsaraUserControl where TDao : IGenericDao<T, TId, TPmt> where TPmt : new()
    {
        #region Attributes

        private TService service;
        protected static string AssemblyName = null;
        protected static string AssemblyFormClassName = null;

        #endregion Attributes

        #region Properties
        
        public TPmt Parameters
        {
            get;
            set;
        }

        public T Value
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

        public override void Refresh()
        {
            base.Refresh();
            this.PrepareComponents();

            this.RefreshCombo();

            EditorButton editorButtonAdd = this.suceEntities.ButtonsLeft["Add"] as EditorButton;

            editorButtonAdd.Click -= new EditorButtonEventHandler(editorButtonAdd_Click);
            editorButtonAdd.Click += new EditorButtonEventHandler(editorButtonAdd_Click);

            EditorButton editorButtonRefresh = this.suceEntities.ButtonsLeft["Refresh"] as EditorButton;

            editorButtonRefresh.Click -= new EditorButtonEventHandler(editorButtonRefresh_Click);
            editorButtonRefresh.Click += new EditorButtonEventHandler(editorButtonRefresh_Click);
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

        private void RefreshCombo()
        {
            IList<T> entityList = (this.service as GenericService<T, TId, TDao, TPmt>)
                .GetListByParameters(this.Parameters);

            this.suceEntities.DataSource = null;
            WindowsFormsUtil.LoadCombo<T>(this.suceEntities, entityList, this.ValueMember,
                this.DisplayMember, "Seleccione");
        }

        #endregion Private

        #region Events

        private void editorButtonAdd_Click(object sender, EditorButtonEventArgs e)
        {
            Assembly assembly = Assembly.LoadFile(Application.StartupPath + @"\" + AssemblyName);
            Type formType = assembly.GetType(AssemblyFormClassName);
            Form form = Activator.CreateInstance(formType) as Form;
            form.ShowDialog(this);
            this.RefreshCombo();
        }

        private void editorButtonRefresh_Click(object sender, EditorButtonEventArgs e)
        {
            this.RefreshCombo();
        }

        #endregion Events

        #endregion Methods
    }
}
