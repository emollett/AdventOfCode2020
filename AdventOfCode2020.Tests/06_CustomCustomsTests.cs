using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class CustomCustomsTests
    {
        [Fact]
        public void Should_count_unique_questions()
        {
            var customCustoms = new CustomCustoms();
            var questions = "abcc";
            var uniqueQuestions = customCustoms.getUniqueQuestionsForGroup(questions);
            Assert.Equal(3, uniqueQuestions.Count);
        }

        [Fact]
        public void Should_count_unique_questions_with_spaces()
        {
            var customCustoms = new CustomCustoms();
            var questions = "abc abc abc";
            var uniqueQuestions = customCustoms.getUniqueQuestionsForGroup(questions);
            Assert.Equal(3, uniqueQuestions.Count);
        }
    }
}
