using NewCrudMaui.Views;

namespace NewCrudMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();


		Routing.RegisterRoute(nameof(AddUpdateStudentDetail),  typeof(AddUpdateStudentDetail));
	}
}
