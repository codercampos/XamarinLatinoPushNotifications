using Xamarin.Forms;
using Com.OneSignal;
using XamarinLatinoPushNotifications.Pages;

namespace XamarinLatinoPushNotifications
{
    public partial class App : Application
    {
        public static string MessageFromNotification = "";
        public App()
        {
            InitializeComponent();

            MainPage = new XamarinLatinoPushNotificationsPage();

            //Set OneSignal
            OneSignal.Current.StartInit("37064466-c9ad-4b6e-9e3c-6df406f13777").HandleNotificationOpened(OnHandleNotificationOpened).EndInit();

            MainPage.Appearing += (sender, e) => 
            {
                if(!string.IsNullOrEmpty(MessageFromNotification))
                {
                    var notificationPage = new NotificationPage
                    {
                        BindingContext = MessageFromNotification,
                        Title = "Notificacion de OneSignal"
                    };
                    var modalPage = new NavigationPage(notificationPage);
                    MainPage.Navigation.PushModalAsync(modalPage);
                    MessageFromNotification = "";
                }
            };
        }

        private void OnHandleNotificationOpened(Com.OneSignal.Abstractions.OSNotificationOpenedResult result)
        {
            if (result.notification.payload.additionalData.ContainsKey("additional_message"))
            {
                // Si el payload posee la key additional_message, ejecutar esta seccion de codigo
                MessageFromNotification = result.notification.payload.additionalData["additional_message"].ToString();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
