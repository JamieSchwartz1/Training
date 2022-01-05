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
            StoreLogic storeLogic = new StoreLogic();

            //act
            List<Customer> customersList = conn.GetCustomers();

            //assert
            Assert.Equal(3, customersList.Count);
        }
        [Fact]
        public void LogInCust_ReturnFalse()
        {
            MockDBAccess conn = new MockDBAccess();

            bool customersList = conn.badCust();

            Assert.False(false, customersList.ToString());

        }
        [Fact]
        public void ViewShoppingCart_ReturnPriceTotal()
        {
            //arrange
            MockDBAccess conn = new MockDBAccess();
            decimal totalPrice = 0;

            //act
            List<GetProduct> products = conn.GetShoppingCartItems();
            foreach(var p in products)
            {
                totalPrice += p.ProductPrice;
            }

            //assert
            Assert.Equal("209.97", totalPrice.ToString());
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
