using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using WorkerApp.Models;
using WorkerApp.ViewModels;
using Xamarin.Essentials;

namespace WorkerApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            ApplyCondition();


        }

        private async void SendUpdate()
        {
            //ApplyCondition();
            UpdateTask();
            await Navigation.PushAsync(new NewItemPage(this,new ItemUpdate 
            { 
                item = viewModel.Item,
                taskId = viewModel.Item.Id, workerid="3" , Status = viewModel.Item.Status }));
        }
        public void ApplyCondition()
        {
            BindingContext = null;
            BindingContext = this.viewModel;
            if (viewModel.Item.Status == "Assigned")
            {
                btnStart.IsVisible = true;
                btnPause.IsVisible = false;
                btnResume.IsVisible = false;
                btnEnd.IsVisible = false;
            }
            else if (viewModel.Item.Status == "Started")
            {
                btnStart.IsVisible = false;
                btnPause.IsVisible = true;
                btnResume.IsVisible = false;
                btnEnd.IsVisible = true;
            }
            else if (viewModel.Item.Status == "Paused")
            {
                btnStart.IsVisible = false;
                btnPause.IsVisible = false;
                btnResume.IsVisible = true;
                btnEnd.IsVisible = false;
            }
            else if (viewModel.Item.Status == "Completed")
            {
                btnStart.IsVisible = false;
                btnPause.IsVisible = false;
                btnResume.IsVisible = false;
                btnEnd.IsVisible = false;
            }
        }

        private async void UpdateTask()
        {
            
            var location = await Geolocation.GetLocationAsync();
            viewModel.Item.WorkerLatitude = location.Latitude.ToString();
            viewModel.Item.WorkerLongitude = location.Longitude.ToString();
        }
        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        private async void btnStart_Clicked(object sender, EventArgs e)
        {
            viewModel.Item.Status = "Started";

            SendUpdate();
        }

        private void btnPause_Clicked(object sender, EventArgs e)
        {
            viewModel.Item.Status = "Paused";
            SendUpdate();
        }

        private void btnEnd_Clicked(object sender, EventArgs e)
        {
            viewModel.Item.Status = "Completed";
            SendUpdate();
        }

        private void btnResume_Clicked(object sender, EventArgs e)
        {
            viewModel.Item.Status = "Started";
            SendUpdate();

        }

        private async void btnMap_Clicked(object sender, EventArgs e)
        {
            // Navigation.PushAsync(new StoreLocation(_Store.Latitude, _Store.Longitude, _Store.EnglishName));
            var location = new Location(double.Parse(viewModel.Item.latitude), double.Parse(viewModel.Item.longitude));
            var options = new MapLaunchOptions { Name = viewModel.Item.Text };

            await Map.OpenAsync(location, options);
        }
    }
}