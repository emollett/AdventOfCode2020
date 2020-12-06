using System;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void Should_count_common_questions()
        {
            var customCustoms = new CustomCustoms();
            var questions = "abc ab abd";
            var commonQuestions = customCustoms.getDuplicateQuestionsForGroup(questions);
            Assert.Equal(2, commonQuestions.Count);
        }
    }
}
