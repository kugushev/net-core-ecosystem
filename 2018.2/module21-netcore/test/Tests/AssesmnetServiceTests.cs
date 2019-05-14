using NUnit.Framework;
using Domain;

namespace Tests
{
    public class AssesmnetServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Asses_Miss_Returns0()
        {
            var service = new AssesmentService();
            int result = service.Asses(false, 2);
            Assert.AreEqual(0, result);
        }
    }
}