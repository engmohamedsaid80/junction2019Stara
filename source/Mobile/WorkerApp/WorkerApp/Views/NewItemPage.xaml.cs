using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using WorkerApp.Models;

namespace WorkerApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public ItemUpdate _itemUpdate { get; set; }
        private ItemDetailPage _detailsPage { get; set; }

        public NewItemPage(ItemDetailPage detailsPage, ItemUpdate itemUpdate)
        {
            InitializeComponent();

            _itemUpdate = itemUpdate;

            _detailsPage = detailsPage;

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "AddItem", Item);
            
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            _itemUpdate.wLatitude = _itemUpdate.item.WorkerLatitude;
            _itemUpdate.wLongitude = _itemUpdate.item.WorkerLongitude;
            _itemUpdate.comments = txtComment.Text;

            RestAPICaller caller = new RestAPICaller();
            string res = await caller.UpdateTaskAsync(_itemUpdate);

            if(res.Equals("OK"))
            {
                _detailsPage.ApplyCondition();
            }
            await Navigation.PopAsync();
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}