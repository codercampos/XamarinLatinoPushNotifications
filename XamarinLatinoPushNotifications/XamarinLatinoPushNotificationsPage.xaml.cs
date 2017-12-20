using System;
using Xamarin.Forms;
using Com.OneSignal;

namespace XamarinLatinoPushNotifications
{
    public partial class XamarinLatinoPushNotificationsPage : ContentPage
    {
        public XamarinLatinoPushNotificationsPage()
        {
            InitializeComponent();
        }

        private void ShowPlayerIdHandler(object sender, EventArgs e)
        {
            OneSignal.Current.IdsAvailable(new Com.OneSignal.Abstractions.IdsAvailableCallback((playerID, pushToken) =>
            {
                playerIdLabel.Text = $"Player ID de este device:\n{playerID}";
            }));
        }
    }
}
