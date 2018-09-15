using System;

namespace Domain
{
    public class AssesmentService
    {
        public int Asses(bool miss, int homeworkQuality)
        {
            return miss ? 0 : homeworkQuality;
        }
    }
}
