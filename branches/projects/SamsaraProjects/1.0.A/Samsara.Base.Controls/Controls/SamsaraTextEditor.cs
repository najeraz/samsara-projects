
using System;
using System.ComponentModel;
using Infragistics.Win;
using Infragistics.Win.UltraWinMaskedEdit;
using Samsara.System.Core.Enums;

namespace Samsara.Base.Controls.Controls
{
    public partial class SamsaraTextEditor : SamsaraUserControl
    {
        private static string phoneNumberMask = "(###)###-####";
        private static string integerMask = "-nnnnnnnnnnnn";
        private static string currencyMask = "-nnn,nnn,nnn,nnn.nn";
        private static string naturalQuantityMask = "nnnnnnnnnnnn";
        private static string realQuantityMask = "nnn,nnn,nnn,nnn.nnnn";
        private static string percentageMask = "nnn.nn %";
        private static string noLimitPercentageMask = "nnn,nnn,nnn,nnn.nn %";
        private static string rateMask = "{double:4.12}";

        private TextFormatEnum maskType;
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
        public TextFormatEnum MaskType
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
                    case TextFormatEnum.Currency:
                        result = this.sumeValue.Value.ToString();

                        if (decimal.TryParse(result, out decimalParser))
                            return decimalParser;
                            
                        return null;
                    case TextFormatEnum.FileSize:
                        result = this.sumeValue.Value.ToString().Replace(measurementFileUnit, "").Trim();

                        if (decimal.TryParse(result, out decimalParser))
                            return decimalParser;

                        return null;
                    case TextFormatEnum.NaturalQuantity:
                        result = this.sumeValue.Value.ToString().Replace(",", "").Trim();

                        if (int.TryParse(result, out integerParser))
                            return integerParser;

                        return null;
                    case TextFormatEnum.NoLimitPercentage:
                        result = this.sumeValue.Value.ToString().Replace("%", "").Trim();

                        if (decimal.TryParse(result, out decimalParser))
                            return decimalParser;

                        return null;
                    case TextFormatEnum.Percentage:
                        result = this.sumeValue.Value.ToString().Replace("%", "").Trim();

                        if (decimal.TryParse(result, out decimalParser))
                            return decimalParser;

                        return null;
                    case TextFormatEnum.Rate:
                        result = this.sumeValue.Value.ToString();

                        if (decimal.TryParse(result, out decimalParser))
                            return decimalParser;

                        return null;
                    case TextFormatEnum.RealQuantity:
                        result = this.sumeValue.Value.ToString();

                        if (int.TryParse(result, out integerParser))
                            return integerParser;

                        return null;
                    case TextFormatEnum.Integer:
                        result = this.sumeValue.Value.ToString();

                        if (int.TryParse(result, out integerParser))
                            return integerParser;

                        return null;
                    case TextFormatEnum.PhoneNumber:
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

        private void MaskTypeChanged(TextFormatEnum newMask)
        {
            this.SetMaskFormat(newMask);
        }

        private void SetMaskFormat(TextFormatEnum newMask)
        {
            switch (newMask)
            {
                case TextFormatEnum.Currency:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = currencyMask;
                    break;
                case TextFormatEnum.NaturalQuantity:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = naturalQuantityMask;
                    break;
                case TextFormatEnum.RealQuantity:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = realQuantityMask;
                    break;
                case TextFormatEnum.Rate:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = rateMask;
                    break;
                case TextFormatEnum.Percentage:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = percentageMask;
                    break;
                case TextFormatEnum.NoLimitPercentage:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = noLimitPercentageMask;
                    break;
                case TextFormatEnum.FileSize:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = this.fileSizeSubmask + this.measurementFileUnit;
                    break;
                case TextFormatEnum.Integer:
                    this.sumeValue.DisplayMode = MaskMode.IncludeBoth;
                    this.sumeValue.Appearance.TextHAlign = HAlign.Right;
                    this.sumeValue.InputMask = integerMask;
                    break;
                case TextFormatEnum.PhoneNumber:
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
