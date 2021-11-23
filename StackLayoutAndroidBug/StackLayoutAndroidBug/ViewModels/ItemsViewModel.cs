using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using StackLayoutAndroidBug.Models;
using Xamarin.Forms;

namespace StackLayoutAndroidBug.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; }
        public Command AddItemCommand { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            
            AddItemCommand = new Command(OnAddItem);
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        
        private void OnAddItem(object obj)
        {
            var newItem = new Item { Id = Guid.NewGuid().ToString(), Text = $"{Items.Count + 1} item", Description = "This is an item description." };
            Items.Add(newItem);
        }
    }
}