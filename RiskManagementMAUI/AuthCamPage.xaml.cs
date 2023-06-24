using System.Diagnostics;

namespace RiskManagementMAUI;

public partial class AuthCamPage : ContentPage
{
	public AuthCamPage()
	{
		InitializeComponent();
	}

	private void cameraView_CamerasLoaded(object sender, EventArgs e)
	{
        cameraView.BarcodeDetected += CameraView_BarcodeDetected;
        cameraView.BarCodeOptions = new Camera.MAUI.ZXingHelper.BarcodeDecodeOptions
        {
            AutoRotate = true,
            PossibleFormats = { ZXing.BarcodeFormat.QR_CODE },
            ReadMultipleCodes = false,
            TryHarder = true,
            TryInverted = true
        };
        cameraView.BarCodeDetectionFrameRate = 10;
        cameraView.BarCodeDetectionMaxThreads = 5;
        cameraView.ControlBarcodeResultDuplicate = true;
        cameraView.BarCodeDetectionEnabled = true;
    }

/*	private void Button_Clicked(object sender, EventArgs e)
	{
		image.Source = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
	}*/

	private void CameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
	{
        Debug.WriteLine("BarcodeText=" + args.Result[0].Text);
    }
}