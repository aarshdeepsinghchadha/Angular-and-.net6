using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using NewCrudMaui.Models;
using NewCrudMaui.Services;
using NewCrudMaui.Views;
using System.Collections.ObjectModel;

namespace NewCrudMaui.ViewModels
{
    public partial class StudentListPageViewModel : ObservableObject
    {
        private readonly IStudentService _studentService;

        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();
        public StudentListPageViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }



        [ICommand]
        private async void GetStudentList()
        {
            var studentList = await _studentService.GetStudentList();
            if (studentList?.Count > 0)
            {

                Students.Clear();
                foreach (var student in studentList)
                {
                    Students.Add(student);
                }
            }
        }



        [ICommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail));
        }
        [ICommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", studentModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail),navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _studentService.DeleteStudent(studentModel);
                if (delResponse > 0)
                {
                    GetStudentList();
                }
            }

        }
    }
}
