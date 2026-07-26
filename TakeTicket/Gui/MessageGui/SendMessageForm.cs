using TakeTicket.Application.Services;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Domain.Enums;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.MessageGui
{
    public partial class SendMessageForm : Form
    {
        private readonly MessagingService messagingService;
        private CustomerService _customerService;
        private int _customerId;

        public SendMessageForm(CustomerService customerService, MessagingService messagingService)
        {
            InitializeComponent();

            ApplyLocalization();

            _customerService = customerService;
            this.messagingService = messagingService;
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            var customer = await _customerService.GetByIdAsync(_customerId);

            if (customer == null)
            {
                MessageBox.Show(localizer.Get("CustomerNotFound"));
                return;
            }

            MessageType type = (MessageType)((dynamic)comboBoxMessageType.SelectedItem).Value;

            await messagingService.SendAsync(customer, type);

            if (type == MessageType.Registration)
                customer.RegistrationMessageSent = true;
            else
                customer.ConfirmationMessageSent = true;

            await _customerService.UpdateCustomerAsync(
                customer,
                Properties.Settings.Default.UserName);

            if (type == MessageType.Registration)
                MessageCollections.ShowRegistrationMessageSentNotification();
            else
                MessageCollections.ShowConfirmationMessageSentNotification();
        }

        private void SendMessageForm_Load(object sender, EventArgs e)
        {
            comboBoxMessageType.DisplayMember = "Text";
            comboBoxMessageType.ValueMember = "Value";

            comboBoxMessageType.Items.Add(new
            {
                Text = localizer.Get("RegistrationMessage"),
                Value = MessageType.Registration
            });

            comboBoxMessageType.Items.Add(new
            {
                Text = localizer.Get("ConfirmationRegistration"),
                Value = MessageType.Confirmation
            });

            comboBoxMessageType.SelectedIndex = 0;

            comboBoxMethod.Items.Add(localizer.Get("WhatsappMethod"));
            comboBoxMethod.Items.Remove("Telegram");
            //comboBoxMethod.Items.Add("Telegram");
            comboBoxMethod.SelectedIndex = 0;
        }

        public void SetData(CustomerService customerService, int customerId)
        {
            _customerService = customerService;
            _customerId = customerId;
        }

        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.MessageLocal.SendMessageFormLocalization");

        private void ApplyLocalization()
        {
            buttonSend.Text =
                localizer.Get("ButtonSend");

            labelSendMethod.Text =
                localizer.Get("LabelSendMethod");

            labelTypeMessage.Text =
                localizer.Get("LabelTypeMessage");

            this.Text =
                localizer.Get("FormTitle");
        }
    }
}
