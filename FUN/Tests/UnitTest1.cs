using System;
using Xunit;
using FUN;
using System.Collections.Generic;

namespace Tests
{
    public class UnitTest1
    {
        private FUN.FUN fun;
        public UnitTest1()
        {
            fun = new FUN.FUN();
        }
        [Fact]
        public void Test1()
        {
            string t = "hello world";
            Assert.Equal("Hello World", fun.LetterCapitalize(t));
        }

        [Fact]
        public void Test2()
        {
            string t = "i ran there";
            Assert.Equal("I Ran There", fun.LetterCapitalize(t));
        }

        [Fact]
        public void Test_sort_hoara()
        {
            List<int> a1 = new List<int> { 5,4,3,2,1 };
            List<int> a2 = new List<int> { 1,7,2,8,0,9,11 };
            fun.sort_hoara(ref a1);
            fun.sort_hoara(ref a2);

            bool test1 = "1,2,3,4,5" == string.Join(",", a1);
            bool test2 = "0,1,2,7,8,9,11" == string.Join(",", a2);
            Assert.True(test1 == test2);
        }
    }
}
