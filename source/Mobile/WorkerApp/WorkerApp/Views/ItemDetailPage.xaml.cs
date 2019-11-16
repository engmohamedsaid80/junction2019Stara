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
            ApplyCondition();


        }

        private void ApplyCondition()
        {
            if (_item.Status == TaskStatus.Assigned)
            {
                btnStart.IsVisible = true;
                btnPause.IsVisible = false;
                btnResume.IsVisible = false;
                btnEnd.IsVisible = false;
            }
            else if (_item.Status == TaskStatus.Started)
            {
                btnStart.IsVisible = false;
                btnPause.IsVisible = true;
                btnResume.IsVisible = false;
                btnEnd.IsVisible = true;
            }
            else if (_item.Status == TaskStatus.Paused)
            {
                btnStart.IsVisible = false;
                btnPause.IsVisible = false;
                btnResume.IsVisible = true;
                btnEnd.IsVisible = false;
            }
            else if (_item.Status == TaskStatus.Completed)
            {
                btnStart.IsVisible = false;
                btnPause.IsVisible = false;
                btnResume.IsVisible = false;
                btnEnd.IsVisible = false;
            }
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
            //DisplayAlert("Start", "Start clicked", "OK");
            _item.Status = TaskStatus.Started;
            ApplyCondition();
        }

        private void btnPause_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("Pause", "Pause clicked", "OK");
            _item.Status = TaskStatus.Paused;
            ApplyCondition();
        }

        private void btnEnd_Clicked(object sender, EventArgs e)
        {
           // DisplayAlert("End", "End clicked", "OK");
            _item.Status = TaskStatus.Completed;
            ApplyCondition();
        }

        private void btnResume_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("Resume", "Resume clicked", "OK");
            _item.Status = TaskStatus.Started;
            ApplyCondition();
        }
    }
}