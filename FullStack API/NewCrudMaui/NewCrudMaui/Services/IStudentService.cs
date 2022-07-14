using NewCrudMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCrudMaui.Services
{
    public interface IStudentService
    {
        Task<List<StudentModel>> GetStudentList();
        Task<int> AddStudent(StudentModel studentModel);
        Task<int> DeleteStudent(StudentModel studentModel);
        Task<int> UpdateStudent(StudentModel studentModel);



    }
}
