namespace MauiAppHotel2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(
    nameof(MauiAppHotel2.Views.Sobre),
    typeof(MauiAppHotel2.Views.Sobre));
        }
    }
}
