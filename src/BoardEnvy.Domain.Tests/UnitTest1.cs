using System.Collections.Generic;
using AutoFixture;
using BoardEnvy.Domain.Models;
using Xunit;

namespace BoardEnvy.Domain.Tests
{
    

    public class UnitTest1
    {
        private static readonly Fixture Fixture = new Fixture();

        [Theory, MemberData(nameof(SomeTestData))]
        public void Test(object value)
        {

        }


        public static IEnumerable<object[]> SomeTestData()
        {
            yield return new object[] { 1, new Backlog() };
            yield return new object[] { 2, new Backlog() };
        }
        public void Test1()
        {
        }

        [Theory, MemberData(nameof(SomeTestData))]
        public void IntroductoryTest(int expectedNumber, Backlog sut)
        {
            int result = sut.BacklogId = expectedNumber;
            Assert.Equal(expectedNumber, result);
        }

    }

}
