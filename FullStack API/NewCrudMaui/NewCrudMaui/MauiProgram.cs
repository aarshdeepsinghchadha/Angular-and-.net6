using NewCrudMaui.Services;
using NewCrudMaui.ViewModels;
using NewCrudMaui.Views;

namespace NewCrudMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//Services
		builder.Services.AddSingleton<IStudentService, StudentService>();


		//View Registration
		builder.Services.AddSingleton<StudentListPage>();
		builder.Services.AddTransient<AddUpdateStudentDetail>();

		//view Models
		builder.Services.AddSingleton<StudentListPageViewModel>();
		builder.Services.AddTransient<AddUpdateStudentDetailViewModel>();

		return builder.Build();
	}
}
