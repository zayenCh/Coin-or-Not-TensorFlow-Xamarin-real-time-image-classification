using System;
using System.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xam.Plugins.OnDeviceCustomVision;
using Xamarin.Forms;

namespace CoinorNot
{
    public partial class CoinorNotPage : ContentPage
    {
        public CoinorNotPage()
        {
            InitializeComponent();

        }

        MediaFile file;

       async void Picture_taken(object sender, System.EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await  DisplayAlert("No Camera", "No camera avaialble.", "OK");
                return;
            }

             file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front
            });

            if (file == null)
                return;

            try
            {
                var stream = file.GetStream();

                //tags is a list of ImageClassification instances, one per tag in the model with the probabilty that the image matches that tag. 

                var tags = await CrossImageClassifier.Current.ClassifyImage(stream);

                //Probabilities are doubles between 0 and 1, with 1 being 100% probability that the image matches the tag. 

                if (Math.Round((tags.ElementAt(0).Probability), 3)>0)
                {
                    await DisplayAlert("Success", "It's a coin" , "OK");
                }else
                {
                    await DisplayAlert("Success", "It's NOT a coin" , "OK");
                }

                //Display each tag and each Probability
                lbl1.Text = tags.ElementAt(0).Tag.ToString()+ " " + tags.ElementAt(1).Probability.ToString();
                lbl2.Text = tags.ElementAt(1).Tag.ToString()+ " " + tags.ElementAt(1).Probability.ToString();
                lbl3.Text = tags.ElementAt(2).Tag.ToString()+ " " + tags.ElementAt(2).Probability.ToString();

            }
            catch (System.Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "OK");
            }
            //display the image
            img.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

    }
}
