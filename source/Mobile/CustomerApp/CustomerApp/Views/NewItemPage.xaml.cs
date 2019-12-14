using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CustomerApp.Helpers;
using CustomerApp.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;

namespace CustomerApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public CustomerRequest _CustomerRequest { get; set; }
        
        private MediaFile ImageFile { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            _CustomerRequest = new CustomerRequest();

            BindingContext = this;
        }

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

            _CustomerRequest.PictureUrl = await UploadPhoto();

            _CustomerRequest.Title = txtTitle.Text;
            _CustomerRequest.Streetname = txtStreet.Text;
            _CustomerRequest.BuildingName = txtBuilding.Text;
            _CustomerRequest.Description = txtComment.Text;

            RestAPICaller caller = new RestAPICaller();
            string res = await caller.UpdateTaskAsync(_CustomerRequest);

            ActIndicatorOn(false);
            btnSave.IsEnabled = true;

            await Navigation.PopModalAsync();
        }

        private async Task<string> UploadPhoto()
        {
            StorageManager storageManager = new StorageManager();

            return await storageManager.UploadImage(
                "request_" +
                DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg",
                ImageFile.GetStream()
                );
        }
        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
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