using System.Text.RegularExpressions;

namespace TakeTicket.Infrastructure.Validation
{
    public static class Validator
    {
        public static bool Required(Control control, ErrorProvider errorProvider, string message)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                errorProvider.SetError(control, message);
                return false;
            }

            errorProvider.SetError(control, "");
            return true;
        }

        public static bool MinLength(TextBox textBox, ErrorProvider errorProvider, int length, string message)
        {
            if (textBox.Text.Trim().Length < length)
            {
                errorProvider.SetError(textBox, message);
                return false;
            }

            errorProvider.SetError(textBox, "");
            return true;
        }

        public static bool NumberOnly(TextBox textBox, ErrorProvider errorProvider, string message)
        {
            if (!Regex.IsMatch(textBox.Text, @"^\d+$"))
            {
                errorProvider.SetError(textBox, message);
                return false;
            }

            errorProvider.SetError(textBox, "");
            return true;
        }

        public static bool Phone(TextBox textBox, ErrorProvider errorProvider, string message)
        {
            if (!Regex.IsMatch(textBox.Text, @"^\+?\d{8,15}$"))
            {
                errorProvider.SetError(textBox, message);
                return false;
            }

            errorProvider.SetError(textBox, "");
            return true;
        }

        public static bool DateRange(DateTimePicker start, DateTimePicker end, ErrorProvider errorProvider, string message)
        {
            if (end.Value.Date < start.Value.Date)
            {
                errorProvider.SetError(end, message);
                return false;
            }

            errorProvider.SetError(end, "");
            return true;
        }
    }
}
