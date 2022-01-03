using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using Xunit;
using P0;

namespace P0Testing
{
    public class UnitTest1
    {
        //[Fact]
        //public void methodName()
        //{
        //    //arrange
        //      create connection
        //    //act
        //      do the method
        //    //assert (expected, actual)
        //}



        public static readonly IEnumerable<object[]> _testArrays = new List<object[]>{
            new object[] {new int[]{ 1, 1}},
            new object[] {new int[]{ 2, 1}},
            new object[] {new int[]{ 3, 1}},
            new object[] {new int[]{ 4, 1}}
        };
        public static readonly IEnumerable<object[]> _testStringList = new List<object[]>{
            new object[] {new List<string>(){"test1", "test1" }},
            new object[] {new List<string>(){"test2", "test2" }},
            new object[] {new List<string>(){"test3", "test3" }}
        };

        [Fact]
        public void LogInCust_ReturnThreeCreated()
        {
            //arrange
            MockDBAccess conn = new MockDBAccess();

            //act
            List<Customer> customersList = conn.GetCustomers();

            //assert
            Assert.Equal(3, customersList.Count);
        }
        [Fact]
        public void CreateNewCart_ReturnIntCartID(int[] input)
        {
            //arrange
            MockDBAccess conn = new MockDBAccess();

            //act
            int result = newCart.NewCart(1, 1);
            
            //assert
            Assert.Equal();
        }
        //public void methodName()
        //{
        //    //arrange
        //    //act
        //    //assert
        //}
        //public void methodName()
        //{
        //    //arrange
        //    //act
        //    //assert
        //}
        //public void methodName()
        //{
        //    //arrange
        //    //act
        //    //assert
        //}
        //public void methodName()
        //{
        //    //arrange
        //    //act
        //    //assert
        //}
        //public void methodName()
        //{
        //    //arrange
        //    //act
        //    //assert
        //}
        //public void methodName()
        //{
        //    //arrange
        //    //act
        //    //assert
        //}
        //public void methodName()
        //{
        //    //arrange
        //    //act
        //    //assert
        //}

    }
}
