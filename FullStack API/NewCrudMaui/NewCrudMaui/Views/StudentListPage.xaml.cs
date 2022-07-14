using NewCrudMaui.ViewModels;

namespace NewCrudMaui.Views;

public partial class StudentListPage : ContentPage
{

	private StudentListPageViewModel _viewModel;

	public StudentListPage(StudentListPageViewModel viewModel)
	{ 
		InitializeComponent();
		this.BindingContext = viewModel;
		_viewModel = viewModel;
	}


	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.GetStudentListCommand.Execute(null);
	}
}