using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using WorkerApp.Models;
using WorkerApp.ViewModels;

namespace WorkerApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        Item _item;

        public ItemDetailPage(ItemDetailViewModel viewModel, Item item)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            _item = item;

            //if (_item.Status == TaskStatus.Assigned)
            //{ btnStart btnPause btnResume}
            //else if (_item.Status == TaskStatus.Started)
            //{ }
            //else if (_item.Status == TaskStatus.Paused)
            //{ }
            //else if (_item.Status == TaskStatus.Completed)
            //{ }
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            _item = item;

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        private void btnStart_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Start", "Start clicked", "OK");
        }

        private void btnPause_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Pause", "Pause clicked", "OK");
        }

        private void btnEnd_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("End", "End clicked", "OK");
        }

        private void btnResume_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Resume", "Resume clicked", "OK");
        }
    }
}