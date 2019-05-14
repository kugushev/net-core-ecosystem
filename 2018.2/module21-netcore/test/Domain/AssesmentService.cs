using System;

namespace Domain
{
    public class AssesmentService
    {
        public int Asses(bool visited, int homeworkQuality)
        {
            return visited ? homeworkQuality : 0;
        }

    }    
}