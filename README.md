# Coin-or-Not:  Xamarin mobile app sample using real time image classification with TensorFlow for Android

This sample uses the Azure Custom Vision service in order to recognize if an image represents a coin or not.
the Azure Custom Vision service creates models that can be exported as Tensorflow (Android) models to do image classification.

This sample is made after uploading a set of images then add tags on each image so the Azure Custom Vision service training can be made. The next step is to download and use these models offline from inside a mobile app, using Tensorflow on Android with Xamarin.Forms

Main steps:

Uploading images to the Azure Custom Vision service, adding tags then start the training

<img src="https://github.com/zayenCh/Coin-or-Not-TensorFlow-Xamarin-real-time-image-classification/blob/master/img1.png" width="500">

Export then the Tensorflow models

<img src="https://github.com/zayenCh/Coin-or-Not-TensorFlow-Xamarin-real-time-image-classification/blob/master/img2.png" width="500">

in the app, if you take a picture of select one from the gallery, you'll get a prediction according to the training 
, the picture then is displayed with the tags name and its probability 

<img src="https://github.com/zayenCh/Coin-or-Not-TensorFlow-Xamarin-real-time-image-classification/blob/master/img3.png" width="250">
<img src="https://github.com/zayenCh/Coin-or-Not-TensorFlow-Xamarin-real-time-image-classification/blob/master/img4.png" width="250">
