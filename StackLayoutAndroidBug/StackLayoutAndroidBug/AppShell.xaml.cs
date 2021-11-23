using System;
using Xamarin.Forms;

namespace StackLayoutAndroidBug
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ItemsPage");
        }
    }
}
