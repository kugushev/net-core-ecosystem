using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Samples.EfCore
{
    [TestClass]
    public class EfCore
    {
        [TestMethod]
        public void A_SimpleExample()
        {
            using (var context = new SamplesContext())
            {
                foreach (var student in context.Students)
                {
                    Debug.WriteLine($"{student.Id}; {student.FullName}");
                }
            }
        }

        [TestMethod]
        public void B_AddAndGenerators()
        {
            using (var context = new SamplesContext())
            {
                var log1 = new Log();
                log1.Time = DateTime.UtcNow;
                log1.Description = "Something went wrong";
                context.Logs.Add(log1);

                var log2 = new Log();
                log2.Time = DateTime.UtcNow;
                log2.Description = "Something went wrong again";
                context.Add(log2);

                context.SaveChanges();
            }
        }





        [TestMethod]
        public void _()
        {
            using (var context = new SamplesContext())
            {
                
            }
        }



        [TestMethod]
        public void _ForeignKey()
        {
            using (var context = new SamplesContext())
            {
                foreach (var interview in context.Interviews)
                {
                    Student student = interview.Student;
                    Debug.WriteLine($"{student.FullName}: {interview.Score}");
                }
            }
        }
    }
}
