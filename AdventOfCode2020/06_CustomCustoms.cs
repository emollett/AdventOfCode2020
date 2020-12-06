using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class CustomCustoms
    {
        public HashSet<char> getUniqueQuestionsForGroup(string questions)
        {
            var splitQuestions = questions.ToCharArray().Where(c => !Char.IsWhiteSpace(c));
            var uniqueQuestions = new HashSet<char>(splitQuestions);
            return uniqueQuestions;
        }

        public int countUniqueQuestionsForManyGroups(List<string> groupsAnswers)
        {
            var uniqueCount = 0;
            foreach (var group in groupsAnswers)
            {
                var uniqueQuestions = getUniqueQuestionsForGroup(group);
                uniqueCount = uniqueCount + uniqueQuestions.Count;
            }
            return uniqueCount;
        }

        public int problem1()
        {
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\06_CustomCustoms.txt";
            var answers = inputReaders.readParagraphsToList(path);

            var uniqueCount = countUniqueQuestionsForManyGroups(answers);
            return uniqueCount;
        }
    }
}
