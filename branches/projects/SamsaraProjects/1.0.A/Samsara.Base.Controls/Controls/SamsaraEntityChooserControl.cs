
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using NUnit.Framework;
using Samsara.Base.Controls.Enums;
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
        private IList<T> values;
        private TService service;
        private SamsaraEntityChooserControlTypeEnum controlType;
        protected static string assemblyName = null;
        protected static string assemblyFormClassName = null;

        #endregion Attributes

        #region EventHandlers

        public event SamsaraEntityChooserValueChangedEventHandler<T> ValueChanged;
        public event SamsaraEntityChooserValuesChangedEventHandler<T> ValuesChanged;

        #endregion EventHandlers

        #region Properties

        public SamsaraEntityChooserControlTypeEnum ControlType
        {
            get
            {
                return controlType;
            }
            set
            {
                this.controlType = value;
                this.ControlTypeChanged();
                if (this.service != null)
                {
                    this.RefreshCombo();
                }
            }
        }

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
                    this.OnValueChanged(new SamsaraEntityChooserValueChangedEventArgs<T>(value));
                }
                this.value = value;
            }
        }

        public IList<T> Values
        {
            get
            {
                return values;
            }
            set
            {
                if (!EqualityComparer<IList<T>>.Default.Equals(this.values, value))
                {
                    this.OnValuesChanged(new SamsaraEntityChooserValuesChangedEventArgs<T>(value));
                }
                this.values = value;
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

        public void Clear()
        {
            this.values.Clear();
        }

        #endregion Public

        #region Protected

        protected virtual void OnValueChanged(SamsaraEntityChooserValueChangedEventArgs<T> e)
        {
            switch (this.controlType)
            {
                case SamsaraEntityChooserControlTypeEnum.Single:
                    if (e.NewValue != null)
                    {
                        this.suceEntities.Value = EntitiesUtil.GetPrimaryKeyPropertyValue<T>(e.NewValue);
                    }
                    else
                    {
                        this.suceEntities.Value = -1;
                    }
                    break;
                case SamsaraEntityChooserControlTypeEnum.Multiple:
                    this.suceEntities.Value = null;
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (this.ValueChanged != null)
                this.ValueChanged(this, e);
        }

        protected virtual void OnValuesChanged(SamsaraEntityChooserValuesChangedEventArgs<T> e)
        {
            switch (this.controlType)
            {
                case SamsaraEntityChooserControlTypeEnum.Single:
                    this.suceEntities.Value = null;
                    break;
                case SamsaraEntityChooserControlTypeEnum.Multiple:
                    if (e.NewValues.Count > 0)
                    {
                        this.suceEntities.Value = EntitiesUtil.GetPrimaryKeyPropertyValues<T>(e.NewValues);
                    }
                    else
                    {
                        this.suceEntities.Value = new object[] { -1 };
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (this.ValueChanged != null)
                this.ValuesChanged(this, e);
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
                this.DisplayMember, "Seleccione", this.controlType == SamsaraEntityChooserControlTypeEnum.Multiple);
        }

        private void ControlTypeChanged()
        {
            switch (this.controlType)
            {
                case SamsaraEntityChooserControlTypeEnum.Single:
                    this.suceEntities.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
                    this.suceEntities.CheckedListSettings.ItemCheckArea = ItemCheckArea.CheckBox;
                    this.suceEntities.CheckedListSettings.ListSeparator = string.Empty;
                    this.suceEntities.CheckedListSettings.CheckBoxStyle = CheckStyle.None;
                    break;
                case SamsaraEntityChooserControlTypeEnum.Multiple:
                    this.suceEntities.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.CheckedItems;
                    this.suceEntities.CheckedListSettings.ItemCheckArea = ItemCheckArea.CheckBox;
                    this.suceEntities.CheckedListSettings.ListSeparator = ", ";
                    this.suceEntities.CheckedListSettings.CheckBoxStyle = CheckStyle.CheckBox;
                    break;
                default:
                    throw new NotImplementedException();
            }
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
            switch (this.controlType)
            {
                case SamsaraEntityChooserControlTypeEnum.Single:
                    this.value = (this.service as GenericReadOnlyService<T, TId, TDao, TPmt>)
                        .GetById((TId)(Convert.ToInt32(suceEntities.Value) as object));
                        
                    this.OnValueChanged(new SamsaraEntityChooserValueChangedEventArgs<T>(this.value)); 
                    break;
                case SamsaraEntityChooserControlTypeEnum.Multiple:
                    this.values = new List<T>();

                    foreach (ValueListItem checkedItem in this.suceEntities.Items.ValueList.CheckedItems
                        .All.Cast<ValueListItem>().Where(x => Convert.ToInt32(x.DataValue) != -1))
                    {
                        T entityItem = (this.service as GenericReadOnlyService<T, TId, TDao, TPmt>)
                            .GetById((TId)(Convert.ToInt32(checkedItem.DataValue) as object));

                        if (entityItem != null)
                        {
                            this.values.Add(entityItem);
                        }
                    }

                    this.OnValuesChanged(new SamsaraEntityChooserValuesChangedEventArgs<T>(this.values)); 
                    break;
                default:
                    throw new NotImplementedException();
            }

        }

        #endregion Events

        #endregion Methods
    }
}
