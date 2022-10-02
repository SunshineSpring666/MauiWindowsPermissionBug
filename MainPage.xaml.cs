namespace MauApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		

	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        PermissionStatus status = await CheckAndRequestLocationPermission();
        LocationPermissionStatus = status.ToString();
    }

    public string LocationPermissionStatus { get; set; }

    public async Task<PermissionStatus> CheckAndRequestLocationPermission()
    {
        PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

        if (status == PermissionStatus.Granted)
            return status;

        if (status == PermissionStatus.Denied)
        {
            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status;
        }

        if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
        {
            // Prompt the user with additional information as to why the permission is needed
        }

        return status;
    }
}

