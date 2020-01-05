using System;
using Xunit;
using FUN;

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
    }
}
