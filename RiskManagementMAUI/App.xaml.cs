namespace RiskManagementMAUI;

public partial class App : Application
{
    [Obsolete]
    public App()
    {
        InitializeComponent();

        // create if statement to check if user is on mobile or desktop
        if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
        {
            MainPage = new NavigationPage();
            MainPage.Navigation.PushAsync(new MainPage());
            MainPage.Navigation.PushAsync(new AuthCamPage());
        }
        else
        {
            MainPage = new NavigationPage(new MainPage());
        }
        
    }
}