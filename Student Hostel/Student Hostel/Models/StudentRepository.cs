using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Hostel.Models;

namespace Student_Hostel.Models
{
    public class StudentRepository//实现对学生的增删改查
    {
       // List<Student> _studentList;
        public StudentRepository()
        {
            //_studentList = new List<student>();
            //Student s = new Student();
            //s.Id = 1;
            //s.Name = "Tom";
            //_studentList.Add(s);

            //_studentList = new List<Student> //实例化学生信息，将其放入实例之中
            //{
            //    new Student { Id = 1, Name = "Tom", ClassName = "One", Email = "123@qq.com" },
            //     new Student { Id = 2, Name = "John", ClassName = "Two", Email = "111@qq.com" },
            //      new Student {Id = 3, Name = "Smith", ClassName = "Three", Email = "222@qq.com" }
                  
            //    };
            
        }
        //public Student Add(string name, string className, string email)
        //{
        //    Student s = new Student { Name = name, ClassName = className, Email = email };
        //    _studentList.Add(s);
        //    return s;
        //}
        //public Student Add(Student student)
        //{
        //    _studentList.Add(student);
        //    return student;
        //}
        //public Student GetStudent(int id)
        //{
        //    Student student=null;

        //    //方法一
        //    for (int i = 0; i < _studentList.Count; i++)
        //    {
        //        if (_studentList[i].Id == id)
        //        {
        //            student = _studentList[i];
        //            break;
        //        }
        //    }
        //    //方法二
        //    //student = _studentList.FirstOrDefault(s => s.Id == id);//返回集合中的第一个元素
        //        return student;
                  
            //}
        }
    }

