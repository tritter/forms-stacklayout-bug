using StackLayoutAndroidBug.ViewModels;
using Xamarin.Forms;

namespace StackLayoutAndroidBug.Views
{
    public partial class ItemsPage : ContentPage
    {
        readonly ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.ExecuteLoadItemsCommand().ConfigureAwait(false);
        }
    }
}