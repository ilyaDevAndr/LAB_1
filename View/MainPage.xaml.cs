using LAB_1.ViewModel;

namespace LAB_1;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();

        BindingContext = new SalonViewModel();
    }


}


