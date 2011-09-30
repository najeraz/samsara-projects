
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinMaskedEdit;
using Samsara.Support.Util;

namespace Samsara.Controls.Controls
{
    public partial class SamsaraTextEditor : UserControl
    {
        private static string currencyMask = "-nnn,nnn,nnn,nnn.nn";
        private static string naturalQuantityMask = "nnn,nnn,nnn,nnn";
        private static string realQuantityMask = "nnn,nnn,nnn,nnn.nnnn";
        private static string percentageMask = "nnn.nn %";
        private static string noLimitPercentageMask = "nnn,nnn,nnn,nnn.nn %";
        private static string fileSizeMask = "nnn,nnn,nnn,nnn.nn MB";
        private static string rateMask = "{double:4.12}";
        private TextMaskFormatEnum maskType;

        [Description("Mascara del editor de texto")]
        public TextMaskFormatEnum MaskType
        {
            get
            {
                return this.maskType;
            }
            set
            {
                if (value != this.maskType)
                    this.MaskTypeChanged(value);

                this.maskType = value;
            }
        }

        [Description("Valor del control")]
        public object Value
        {
            get
            {
                return this.sumeValue.Value;
            }
            set
            {
                this.sumeValue.Value = value;
            }
        }

        [Description("Solo lectura")]
        public bool ReadOnly
        {
            get
            {
                return this.sumeValue.ReadOnly;
            }
            set
            {
                this.sumeValue.ReadOnly = value;
            }
        }

        public SamsaraTextEditor()
        {
            InitializeComponent();
        }

        private void MaskTypeChanged(TextMaskFormatEnum newValue)
        {
            this.SetMaskFormat(newValue);
        }

        private void SetMaskFormat(TextMaskFormatEnum newValue)
        {
            switch (newValue)
            {
                case TextMaskFormatEnum.Currency:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = currencyMask;
                    break;
                case TextMaskFormatEnum.NaturalQuantity:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = naturalQuantityMask;
                    break;
                case TextMaskFormatEnum.RealQuantity:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = realQuantityMask;
                    break;
                case TextMaskFormatEnum.Rate:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = rateMask;
                    break;
                case TextMaskFormatEnum.Percentage:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = percentageMask;
                    break;
                case TextMaskFormatEnum.NoLimitPercentage:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = noLimitPercentageMask;
                    break;
                case TextMaskFormatEnum.FileSize:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = fileSizeMask;
                    break;
                default:
                    break;
            }
        }
    }
}
