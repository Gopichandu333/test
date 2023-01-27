using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DemoProject.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    //    [HttpPost]
        public IActionResult Registration(StudentModel Obj)
        {
            DataBaseModel dataBaseModel = new DataBaseModel();
            //   dataBaseModel.AddStudentRecord(Obj);
         String Store =  dataBaseModel.AddStudentRecord_SP(Obj);


            return View();
        }

        [HttpGet]
        public IActionResult Registration()

        {
            DataBaseModel dataBaseModel = new DataBaseModel();

            return View("Views/Student/Registration123.cshtml");
        }

        [HttpGet]
        public IActionResult Details( )
        {
            DataBaseModel dataBaseModel = new DataBaseModel();
        //    dataBaseModel.GetStudentList();
          DataSet details = dataBaseModel.GetStudentList();
            //   dataBaseModel.AddStudentRecord(Obj);
            //   String Store = dataBaseModel.AddStudentRecord_SP(Obj);
          //   IList<StudentModel> Rows = details.Tables[0].AsEnumerable().Select(x=>x.x).ToList ;

            List<StudentModel> list = new List<StudentModel>();
            list = (from DataRow row in details.Tables[0].Rows

                    select new StudentModel()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = row["Name"].ToString(),
                        Age = Convert.ToInt32(row["Age"]),
                        Class = row["Class"].ToString(),
                        Section = row["Section"].ToString(),
                        ParentName = row["ParentName"].ToString(),
                        MobileNumber = Convert.ToInt32(row["MobileNumber"]),
                        Hobbies = row["Hobbies"].ToString(),
                        City = row["City"].ToString(),
                        Gender = row["Gender"].ToString(),
                        Address = row["Address"].ToString(),
                    }).ToList();



            return View(list);
        }


       

    }
}
