
using System;
using System.ComponentModel;
using Infragistics.Win;
using Infragistics.Win.UltraWinMaskedEdit;
using Samsara.Support.Util;

namespace Samsara.Base.Controls.Controls
{
    public partial class SamsaraTextEditor : SamsaraUserControl
    {
        private static string phoneNumberMask = "(###)###-####";
        private static string integerMask = "-nnnnnnnnnnnn";
        private static string currencyMask = "-nnn,nnn,nnn,nnn.nn";
        private static string naturalQuantityMask = "nnn,nnn,nnn,nnn";
        private static string realQuantityMask = "nnn,nnn,nnn,nnn.nnnn";
        private static string percentageMask = "nnn.nn %";
        private static string noLimitPercentageMask = "nnn,nnn,nnn,nnn.nn %";
        private static string rateMask = "{double:4.12}";

        private TextMaskFormatEnum maskType;
        private string measurementFileUnit = "MB";
        private string fileSizeSubmask = "nnn,nnn,nnn,nnn.nn ";

        [Description("Unidad de medida para marcara de archivos")]
        public string MeasurementFileUnit
        {
            get
            {
                return measurementFileUnit;
            }
            set
            {
                measurementFileUnit = value;
                this.MaskTypeChanged(this.maskType);
            }
        }

        [Description("Mascara del editor de texto")]
        public TextMaskFormatEnum MaskType
        {
            get
            {
                return this.maskType;
            }
            set
            {
                this.MaskTypeChanged(value);
                this.maskType = value;
            }
        }

        [Description("Valor del control")]
        public object Value
        {
            get
            {
                string result = null;
                decimal decimalParser;
                int integerParser;

                if (this.sumeValue.Value == null)
                    return null;
                if (string.IsNullOrWhiteSpace(this.sumeValue.Value.ToString()))
                    return this.sumeValue.Value;

                switch (this.maskType)
                {
                    case TextMaskFormatEnum.Currency:
                        result = this.sumeValue.Value.ToString();

                        if (decimal.TryParse(result, out decimalParser))
                            return decimalParser;
                            
                        return null;
                    case TextMaskFormatEnum.FileSize:
                        result = this.sumeValue.Value.ToString().Replace(measurementFileUnit, "").Trim();

                        if (decimal.TryParse(result, out decimalParser))
                            return decimalParser;

                        return null;
                    case TextMaskFormatEnum.NaturalQuantity:
                        result = this.sumeValue.Value.ToString().Replace(",", "").Trim();

                        if (int.TryParse(result, out integerParser))
                            return integerParser;

                        return null;
                    case TextMaskFormatEnum.NoLimitPercentage:
                        result = this.sumeValue.Value.ToString().Replace("%", "").Trim();

                        if (decimal.TryParse(result, out decimalParser))
                            return decimalParser;

                        return null;
                    case TextMaskFormatEnum.Percentage:
                        result = this.sumeValue.Value.ToString().Replace("%", "").Trim();

                        if (decimal.TryParse(result, out decimalParser))
                            return decimalParser;

                        return null;
                    case TextMaskFormatEnum.Rate:
                        result = this.sumeValue.Value.ToString();

                        if (decimal.TryParse(result, out decimalParser))
                            return decimalParser;

                        return null;
                    case TextMaskFormatEnum.RealQuantity:
                        result = this.sumeValue.Value.ToString();

                        if (int.TryParse(result, out integerParser))
                            return integerParser;

                        return null;
                    case TextMaskFormatEnum.Integer:
                        result = this.sumeValue.Value.ToString();

                        if (int.TryParse(result, out integerParser))
                            return integerParser;

                        return null;
                    case TextMaskFormatEnum.PhoneNumber:
                        result = this.sumeValue.Value.ToString();

                        return result;
                    default:
                        throw new NotImplementedException();
                }
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

        private void MaskTypeChanged(TextMaskFormatEnum newMask)
        {
            this.SetMaskFormat(newMask);
        }

        private void SetMaskFormat(TextMaskFormatEnum newMask)
        {
            switch (newMask)
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
                    this.sumeValue.InputMask = this.fileSizeSubmask + this.measurementFileUnit;
                    break;
                case TextMaskFormatEnum.Integer:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = integerMask;
                    break;
                case TextMaskFormatEnum.PhoneNumber:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Left;
                    this.sumeValue.InputMask = phoneNumberMask;
                    break;
                default:
                    break;
            }
        }
    }
}
