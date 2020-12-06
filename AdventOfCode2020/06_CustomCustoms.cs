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

        public List<char> getDuplicateQuestionsForGroup(string questions)
        {
            var individualAnswers = questions.Split(' ');
            var numberOfMembers = individualAnswers.Length;

            var splitQuestions = questions.ToCharArray().Where(c => !Char.IsWhiteSpace(c));
            var duplicates = new List<char> { };
            foreach (var character in individualAnswers[0])
            {
                var count = splitQuestions.Count(x => x == character);
                if (count == numberOfMembers) duplicates.Add(character);
            }

            return duplicates;
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

        public int countDuplicateQuestionsForManyGroups(List<string> groupsAnswers)
        {
            var duplicateCount = 0;
            foreach (var group in groupsAnswers)
            {
                var duplicateQuestions = getDuplicateQuestionsForGroup(group);
                duplicateCount = duplicateCount + duplicateQuestions.Count;
            }
            return duplicateCount;
        }

        public int problem1()
        {
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\06_CustomCustoms.txt";
            var answers = inputReaders.readParagraphsToList(path);

            var uniqueCount = countUniqueQuestionsForManyGroups(answers);
            return uniqueCount;
        }

        public int problem2()
        {
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\06_CustomCustoms.txt";
            var answers = inputReaders.readParagraphsToList(path);

            var duplicateCount = countDuplicateQuestionsForManyGroups(answers);
            return duplicateCount;
        }
    }
}
