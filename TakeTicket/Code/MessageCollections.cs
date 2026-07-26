using TakeTicket.Gui.NotificationGui;
using TakeTicket.Shared.Common.Logging;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Infrastructure.Helper
{
    public static class MessageCollections
    {
        private static NotificationForm currentNotification;

        // Message
        public static void ShowEmptyDataMessage()
        {
            MessageBox.Show(
                _localizer.Get("EmptyMessageText"),
                _localizer.Get("EmptyMessageCaption"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static void ShowErrorServer()
        {
            MessageBox.Show(
                _localizer.Get("ServerErrorText"),
                _localizer.Get("ServerErrorCaption"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static void ShowFieldsRequired()
        {
            MessageBox.Show(
                _localizer.Get("FieldsReqText"),
                _localizer.Get("FieldReqCaption"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static void ShowRequiredDeleteRow()
        {
            MessageBox.Show(
                _localizer.Get("ShowReDeleteFiledText"),
                _localizer.Get("ShowReDeleteFiledCaption"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Dialog
        public static bool ShowDeleteDialog()
        {
            var result = MessageBox.Show(
                _localizer.Get("DeleteDialogText"),
                _localizer.Get("DeleteDialogCaption"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static readonly Localizer _localizer = new Localizer(
        "TakeTicket.Shared.Localization.MessagesLocal");

        // Notifications

        public static void ShowAddNotification()
        {
            ShowNotification(_localizer.Get("AddSuccess"));
        }

        public static void ShowUpdateNotification()
        {
            ShowNotification(_localizer.Get("EditSuccess"));
        }

        public static void ShowDeleteNotification()
        {
            ShowNotification(_localizer.Get("DeleteSuccess"));
        }
        public static void ShowConfirmationMessageSentNotification()
        {
            ShowNotification(_localizer.Get("ConfirmMessageSuccess"));
        }

        public static void ShowRegistrationMessageSentNotification()
        {
            ShowNotification(_localizer.Get("RegistrationMessageSuccess"));
        }


        public static void ShowNotification(string message, Form owner = null)
        {
            if (currentNotification != null && !currentNotification.IsDisposed)
            {
                currentNotification.Close();
            }

            currentNotification = new NotificationForm();
            currentNotification.labelTitle.Text = message;

            if (owner != null)
                currentNotification.Show(owner);
            else
                currentNotification.Show();
        }

        public static void ShowException(Exception ex, string operation = "")
        {
            Logger.Log(ex, operation);

            MessageBox.Show(
                _localizer.Get("ErrorGeneralMessage"),
                _localizer.Get("ErrorTitle"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static void ShowWarning(string text)
        {
            MessageBox.Show(
                text,
                _localizer.Get("WarningTitle"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        public static void ShowInfo(string text)
        {
            MessageBox.Show(
                text,
                _localizer.Get("InfoTitle"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static void ShowError(string text)
        {
            MessageBox.Show(
                text,
                _localizer.Get("ErrorTitle"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static async Task ShowCountdownNotification(
            string format,
            int seconds,
            Form owner = null)
        {
            if (currentNotification != null &&
                !currentNotification.IsDisposed)
            {
                currentNotification.Close();
            }

            currentNotification = new NotificationForm();

            if (owner != null)
                currentNotification.Show(owner);
            else
                currentNotification.Show();

            while (seconds > 0 &&
                   currentNotification != null &&
                   !currentNotification.IsDisposed)
            {
                currentNotification.labelTitle.Text =
                    string.Format(format, seconds);

                await Task.Delay(1000);

                seconds--;
            }

            if (currentNotification != null &&
                !currentNotification.IsDisposed)
            {
                currentNotification.Close();
            }
        }
    }
}
