using System.Globalization;
using System.Windows.Controls;

namespace FeladatokKezelese
{
    internal class StringToIntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int i;
            if (int.TryParse(value.ToString(), out i)) return new ValidationResult(true, null);

            return new ValidationResult(false, "Csak egész szám lehet");
        }
    }
}
