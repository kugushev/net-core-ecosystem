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
        


    }
}
