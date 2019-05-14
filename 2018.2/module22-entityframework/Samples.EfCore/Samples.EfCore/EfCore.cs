using Microsoft.EntityFrameworkCore;
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
                    Debug.WriteLine($"{student.Id}; {student.Name}");
                }
            }
        }

        [TestMethod]
        public void B_SimpleExampleLin()
        {
            using (var context = new SamplesContext())
            {
                foreach (var student in context.Students.Where(x => x.UniversityDegree))
                {
                    Debug.WriteLine($"{student.Id}; {student.Name}");
                }
            }
        }

        [TestMethod]
        public void B_ShadowProperty()
        {
            using (var context = new SamplesContext())
            {
                var result = context.Students
                    .Select(x => EF.Property<string>(x, "UniversityGovNum")).FirstOrDefault();
                Debug.WriteLine(result);
            }
        }



        [TestMethod]
        public void C_Add()
        {
            using (var context = new SamplesContext())
            {
                context.Add(new Lesson { Id = 21, Date = new DateTime(2018, 9, 13), Name = "Net Core" });
                context.Add(new Lesson { Id = 22, Date = new DateTime(2018, 9, 17), Name = "Entity Framework" });
                context.Add(new Lesson { Id = 23, Date = new DateTime(2018, 9, 20), Name = "Web API" });
                context.Add(new Lesson { Id = 24, Date = new DateTime(2018, 9, 24), Name = "Elasticsearch/Redis" });
                context.Add(new Lesson { Id = 25, Date = new DateTime(2018, 9, 28), Name = "Docker" });
                context.Add(new Lesson { Id = 26, Date = new DateTime(2018, 10, 1), Name = "Cloud" });
                context.Add(new Lesson { Id = 27, Date = new DateTime(2018, 10, 4), Name = "Cloud" });
                context.Add(new Lesson { Id = 28, Date = new DateTime(2018, 10, 5), 
                    Name = "How to become a millionaire" });

                context.Teachers.Add(new Teacher { Name = "Aleksandr Kugushev" });
                context.Teachers.Add(new Teacher { Name = "Natalia Tcvilikh" });

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void D_Update()
        {
            using (var context = new SamplesContext())
            {
                Lesson lesson = context.Lessons.Find(22);
                lesson.Date = DateTime.UtcNow;
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void E_Delete()
        {
            using (var context = new SamplesContext())
            {
                Lesson lesson = context.Lessons.Find(28);
                context.Lessons.Remove(lesson);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void F_Relations()
        {
            using (var context = new SamplesContext())
            {
                var lesson = new Lesson
                {
                    Id = 19,
                    Date = new DateTime(2018, 9, 10),
                    Name = "ADO NET",
                    LessonTeachers = new List<LessonTeacher>
                    {
                        new LessonTeacher
                        {
                            Teacher = new Teacher
                            {
                                Id  = 3,
                                Name = "Igor Pavlovskiy"
                            }
                        }
                    }
                };
                context.Add(lesson);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void F_RelationsEx()
        {
            using (var context = new SamplesContext())
            {
                var lessons = context.Lessons.Where(x => x.Id > 20);
                var alex = context.Teachers.Single(x => x.Name == "Aleksandr Kugushev");
                var natalia = context.Teachers.Single(x => x.Name == "Natalia Tcvilikh");

                foreach (var lesson in lessons)
                {
                    lesson.LessonTeachers = lesson.LessonTeachers ?? new List<LessonTeacher>();

                    lesson.LessonTeachers.Add(new LessonTeacher { Teacher = alex });
                    if (lesson.Name == "Cloud")
                        lesson.LessonTeachers.Add(new LessonTeacher { Teacher = natalia });
                }
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void F_RelationsWrong()
        {
            using (var context = new SamplesContext())
            {
                var lessons = context.Lessons.Where(x => x.Id > 20);
                var alex = new Teacher { Id = 1, Name = "Aleksandr Kugushev" };
                var natalia = new Teacher { Id = 2, Name = "Natalia Tcvilikh" };

                foreach (var lesson in lessons)
                {
                    lesson.LessonTeachers = lesson.LessonTeachers ?? new List<LessonTeacher>();

                    lesson.LessonTeachers.Add(new LessonTeacher { Teacher = alex });
                    if (lesson.Name == "Cloud")
                        lesson.LessonTeachers.Add(new LessonTeacher { Teacher = natalia });
                }
                // ERROR!!!
            }
        }


        [TestMethod]
        public void G_Transactions()
        {
            using (var context = new SamplesContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Lessons.Find(24).Date = new DateTime(2018, 10, 11);
                    context.SaveChanges();

                    context.Lessons.Find(25).Date = new DateTime(2018, 10, 12);
                    context.SaveChanges();

                    transaction.Commit();
                }
            }
        }

        [TestMethod]
        public void H_DisconnectedEntites()
        {
            using (var context = new SamplesContext())
            {
                var lesson = new Lesson { Id = 22, Date = DateTime.UtcNow, Name = "Entity Framework Core" };
                context.Update(lesson);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void H_DisconnectedEntitesEx()
        {
            using (var context = new SamplesContext())
            {
                var lesson = new Lesson { Id = 22, Date = DateTime.UtcNow, Name = "Entity Framework Hard Core" };
                var entry = context.Entry(lesson);
                entry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void I_OrderBy()
        {
            using (var context = new SamplesContext())
            {
                var lessons = context.Lessons.OrderByDescending(x => x.Date);
                foreach (var lesson in lessons)
                    Debug.WriteLine($"{lesson.Name}");
            }
        }


        [TestMethod]
        public void J_GroupBy()
        {
            using (var context = new SamplesContext())
            {
                var lessons = context.Lessons.GroupBy(x => x.Name);
                foreach (var group in lessons)
                    Debug.WriteLine($"{group.Key} {group.Count()}");
            }
        }


        [TestMethod]
        public void K_Include()
        {
            List<Lesson> lessons = null;
            using (var context = new SamplesContext())
            {
                lessons = context.Lessons
                    .Include(x => x.LessonTeachers)
                    .ThenInclude((LessonTeacher x) => x.Teacher)
                    .ToList();
            }
            foreach (var lesson in lessons)
                foreach (var lessonTeacher in lesson.LessonTeachers)
                    Debug.WriteLine($"{lesson.Name}: {lessonTeacher.Teacher.Name}");
        }


        [TestMethod]
        public void L_AsEnumerable()
        {
            using (var context = new SamplesContext())
            {
                var lessons = context.Lessons.Where(x => x.Date > DateTime.UtcNow)
                    .AsEnumerable()
                    .Where(x => x.Name.StartsWith("C"));
                foreach (var lesson in lessons)
                    Debug.WriteLine($"{lesson.Name}");
            }
        }


        [TestMethod]
        public void M_Tracking()
        {
            using (var context = new SamplesContext())
            {
                var lessons = context.Lessons.AsNoTracking().Where(x => x.Date < DateTime.UtcNow).ToList();
                foreach (var lesson in lessons)
                    lesson.Name = "Hello World";

                context.SaveChanges();
            }
        }


        [TestMethod]
        public void N_FromSql()
        {
            using (var context = new SamplesContext())
            {
                var lessons = context.Lessons.FromSql("SELECT * FROM \"Lesson\"");
                foreach (var lesson in lessons)
                    Debug.WriteLine($"{lesson.Name}");
            }
        }
    }
}
