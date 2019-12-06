using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WorkerApp.Helpers;
using WorkerApp.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;

namespace WorkerApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public ItemUpdate _itemUpdate { get; set; }
        private ItemDetailPage _detailsPage { get; set; }

        private MediaFile ImageFile { get; set; }

        public NewItemPage(ItemDetailPage detailsPage, ItemUpdate itemUpdate)
        {
            InitializeComponent();

            _itemUpdate = itemUpdate;

            _detailsPage = detailsPage;

            BindingContext = this;
        }

        //async void Save_Clicked(object sender, EventArgs e)
        //{
        //    //MessagingCenter.Send(this, "AddItem", Item);
            
        //}

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void ActIndicatorOn(bool on)
        {
            actInd.IsRunning = on;
            actInd.IsVisible = on;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            btnSave.IsEnabled = false;
            ActIndicatorOn(true);

            _itemUpdate.PictureUrl = await UploadPhoto();

            _itemUpdate.wLatitude = _itemUpdate.item.WorkerLatitude;
            _itemUpdate.wLongitude = _itemUpdate.item.WorkerLongitude;
            _itemUpdate.comments = txtComment.Text;

            RestAPICaller caller = new RestAPICaller();
            string res = await caller.UpdateTaskAsync(_itemUpdate);

            ActIndicatorOn(false);
            btnSave.IsEnabled = true;

            if (res.Equals("OK"))
            {
                _detailsPage.ApplyCondition();
            }
            await Navigation.PopAsync();
        }

        private async Task<string> UploadPhoto()
        {
            StorageManager storageManager = new StorageManager();

            return await storageManager.UploadImage(
                "worker_3_" + 
                _itemUpdate.item.Id + "_" + 
                _itemUpdate.item.Status + "_" + 
                DateTime.Now.ToString("yyyyMMddHHmmss"), 
                ImageFile.GetStream()
                );
        }
        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnPhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            ImageFile = await CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    
                    SaveToAlbum = true,
                    //Directory = "STARA",
                    //CompressionQuality = 75,
                    //CustomPhotoSize = 50,
                    //PhotoSize = PhotoSize.MaxWidthHeight,
                    //MaxWidthHeight = 2000,
                    //DefaultCamera = CameraDevice.Front
                });

            imgUpdate.Source = ImageFile.Path;
            //imgUpdate.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //});
        }
    }
}