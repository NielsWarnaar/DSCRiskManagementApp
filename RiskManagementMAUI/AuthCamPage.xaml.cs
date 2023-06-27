using System.Diagnostics;
using ZXing;
using static Camera.MAUI.CameraView;

namespace RiskManagementMAUI;

public partial class AuthCamPage : ContentPage
{
    /// Event launched every time a code is detected in the image if "BarCodeDetectionEnabled" is set to true.
    public event BarcodeResultHandler BarcodeDetected;
    /// It refresh each time a barcode is detected if BarCodeDetectionEnabled porperty is true
    public Result[] BarCodeResults;

    public AuthCamPage()
	{
		InitializeComponent();
	}

	private void cameraView_CamerasLoaded(object sender, EventArgs e)
	{
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

	private void CameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
	{
        MainThread.BeginInvokeOnMainThread(() =>
        {
            barcodeResult.Text = $"{args.Result[0].BarcodeFormat}: {args.Result[0].Text}";
            if (barcodeResult.Text == "QR_CODE: ThisIsThePassword")
            {
                barcodeResult.Text = "Correct password";
                Navigation.PopAsync();
                Navigation.PushAsync(new MainPage());
            }
        });
    }
}