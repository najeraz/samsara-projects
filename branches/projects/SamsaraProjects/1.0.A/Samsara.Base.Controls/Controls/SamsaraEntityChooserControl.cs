﻿
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using NUnit.Framework;
using Samsara.Base.Controls.EventsArgs;
using Samsara.Base.Controls.EventsHandlers;
using Samsara.Base.Core.Context;
using Samsara.Base.Dao.Interfaces;
using Samsara.Base.Service.Impl;
using Samsara.Support.Util;

namespace Samsara.Base.Controls.Controls
{
    public partial class SamsaraEntityChooserControl<T, TId, TService, TDao, TPmt> : SamsaraUserControl
        where TDao : IGenericReadOnlyDao<T, TId, TPmt> where TPmt : new()
    {
        #region Attributes

        private T value;
        private TService service;
        protected static string assemblyName = null;
        protected static string assemblyFormClassName = null;

        #endregion Attributes

        #region EventHandlers

        public event SamsaraEntityChooserValueChangedEventHandler<T> ValueChanged;

        #endregion EventHandlers

        #region Properties

        public bool ReadOnly
        {
            get
            {
                return this.suceEntities.ReadOnly;
            }
            set
            {
                this.suceEntities.ReadOnly = value;
                
                foreach (EditorButton buttonLeft in this.suceEntities.ButtonsLeft)
                {
                    buttonLeft.Enabled = !value;
                }
            }
        }
        
        public TPmt Parameters
        {
            get;
            set;
        }

        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                if (!EqualityComparer<T>.Default.Equals(this.value, value))
                {
                    OnValueChanged(new SamsaraEntityChooserValueChangedEventArgs<T>(value)); 
                }
                this.value = value;
            }
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
        }

        #endregion Public

        #region Protected

        protected virtual void OnValueChanged(SamsaraEntityChooserValueChangedEventArgs<T> e)
        {
            if (e.NewValue != null)
                this.suceEntities.Value = EntitiesUtil.GetPrimaryKeyPropertyValue(typeof(T), e.NewValue);
            else
                this.suceEntities.Value = -1;

            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        #endregion Protected

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
            IList<T> entityList = (this.service as GenericReadOnlyService<T, TId, TDao, TPmt>)
                .GetListByParameters(this.Parameters);

            this.suceEntities.DataSource = null;
            WindowsFormsUtil.LoadCombo<T>(this.suceEntities, entityList, this.ValueMember,
                this.DisplayMember, "Seleccione");
        }

        #endregion Private

        #region Events

        private void editorButtonAdd_Click(object sender, EditorButtonEventArgs e)
        {
            Assembly assembly = Assembly.LoadFile(Application.StartupPath + @"\" + assemblyName);
            Type formType = assembly.GetType(assemblyFormClassName);

            if (formType != null)
            {
                Form form = Activator.CreateInstance(formType) as Form;
                form.ShowDialog(this);
            }

            this.RefreshCombo();
        }

        private void suceEntities_ValueChanged(object sender, EventArgs e)
        {
            this.value = (this.service as GenericReadOnlyService<T, TId, TDao, TPmt>)
                .GetById((TId)(Convert.ToInt32(suceEntities.Value) as object));

            OnValueChanged(new SamsaraEntityChooserValueChangedEventArgs<T>(this.value)); 
        }

        #endregion Events

        #endregion Methods
    }
}
