using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using NewCrudMaui.Models;
using NewCrudMaui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCrudMaui.ViewModels
{
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]
    public partial class AddUpdateStudentDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private StudentModel _studentDetail = new StudentModel();

        private readonly IStudentService _studentService;
        public AddUpdateStudentDetailViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

       
        //[ObservableProperty]
        //private string _firstName;

        //[ObservableProperty]
        //private string _lastName;

        //[ObservableProperty]
        //private string _email;

        [ICommand]
        public async void AddUpdateStudent()
        {
            int response = -1;
            if(StudentDetail.StudentId > 0)
            {
                response = await _studentService.UpdateStudent(StudentDetail);
            }
            else
            {
                 response = await _studentService.AddStudent(new Models.StudentModel
                {
                    Email = StudentDetail.Email,
                    FirstName = StudentDetail.FirstName,
                    LastName = StudentDetail.LastName
                });
            }

            if(response > 0)
            {
                await Shell.Current.DisplayAlert("Student Info Saved", "Record Saved ", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not Added", "Something went wrong while adding the record", "Ok");
            }
        }


    }
}
