using Xamarin.Forms;
using Com.OneSignal;

namespace XamarinLatinoPushNotifications
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new XamarinLatinoPushNotificationsPage();

            //Setting OneSignal
            OneSignal.Current.StartInit("{INSERT YOUR ONESIGNAL ID HERE}").EndInit();
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
