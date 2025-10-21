using MotoAPP.ViewModels;

namespace MotoAPP.Views;

public partial class VisMotoView : ContentPage
{
	public VisMotoView()
	{
		InitializeComponent();

		BindingContext = new MotoVM();
	}
}