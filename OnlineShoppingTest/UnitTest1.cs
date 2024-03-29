﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShopping;
using System.Data;
using System.Collections.Generic;

namespace OnlineShoppingTest
{
    [TestClass]
    public class UnitTest1
    {
        //To test 6 products
        [TestMethod]
        public void TestProduct1()
        {
            DataTable dtTest = new DataTable();
            dtTest.Columns.Add("Id", typeof(int));
            dtTest.Columns.Add("ProductName", typeof(string));
            dtTest.Columns.Add("Price", typeof(int));
            dtTest.Columns.Add("Value", typeof(int));

            // Here we add datas.
            dtTest.Rows.Add(1, "P1", 3, 6);
            dtTest.Rows.Add(2, "P2", 2, 5);
            dtTest.Rows.Add(3, "P3", 1, 2);
            dtTest.Rows.Add(4, "P4", 3, 2);
            dtTest.Rows.Add(5, "P5", 4, 4);
            dtTest.Rows.Add(6, "P6", 3, 4);

            int budget = 5;

            Assert.AreEqual(11, Program.GetMaxValueProducts(budget, dtTest));
        }

        //To test 3 products
        [TestMethod]
        public void TestProduct2()
        {
            DataTable dtTest = new DataTable();
            dtTest.Columns.Add("Id", typeof(int));
            dtTest.Columns.Add("ProductName", typeof(string));
            dtTest.Columns.Add("Price", typeof(int));
            dtTest.Columns.Add("Value", typeof(int));

            // Here we add datas.
            dtTest.Rows.Add(1, "P1", 1, 3);
            dtTest.Rows.Add(2, "P2", 2, 5);
            dtTest.Rows.Add(3, "P3", 3, 6);

            int budget = 3;

            Assert.AreEqual(8, Program.GetMaxValueProducts(budget, dtTest));
        }

        //to test different combination of value and cost
        [TestMethod]
        public void TestProduct3()
        {
            DataTable dtTest = new DataTable();
            dtTest.Columns.Add("Id", typeof(int));
            dtTest.Columns.Add("ProductName", typeof(string));
            dtTest.Columns.Add("Price", typeof(int));
            dtTest.Columns.Add("Value", typeof(int));

            // Here we add Datas.
            dtTest.Rows.Add(1, "P1", 1, 3);
            dtTest.Rows.Add(2, "P2", 2, 5);
            dtTest.Rows.Add(3, "P3", 3, 6);
            dtTest.Rows.Add(4, "P4", 4, 16);

            int budget = 5;

            Assert.AreEqual(19, Program.GetMaxValueProducts(budget, dtTest));
        }

        //to test the budget with cost : 0 chf

        [TestMethod]
        public void TestProduct4()
        {
            DataTable dtTest = new DataTable();
            dtTest.Columns.Add("Id", typeof(int));
            dtTest.Columns.Add("ProductName", typeof(string));
            dtTest.Columns.Add("Price", typeof(int));
            dtTest.Columns.Add("Value", typeof(int));

            // Here we add datas.
            dtTest.Rows.Add(1, "P1", 1, 3);
            dtTest.Rows.Add(2, "P2", 2, 5);
            dtTest.Rows.Add(3, "P3", 3, 6);
            dtTest.Rows.Add(4, "P4", 4, 16);

            int budget = 0;

            Assert.AreEqual(0, Program.GetMaxValueProducts(budget, dtTest));
        }

        //To test with same cost of product and different values
        [TestMethod]
        public void TestProduct5()
        {
            DataTable dtTest = new DataTable();
            dtTest.Columns.Add("Id", typeof(int));
            dtTest.Columns.Add("ProductName", typeof(string));
            dtTest.Columns.Add("Price", typeof(int));
            dtTest.Columns.Add("Value", typeof(int));

            // Here we add datas.
            dtTest.Rows.Add(1, "P1", 1, 3);
            dtTest.Rows.Add(2, "P2", 1, 5);
            dtTest.Rows.Add(3, "P3", 1, 6);
            dtTest.Rows.Add(4, "P4", 1, 16);

            int budget = 1;

            Assert.AreEqual(16, Program.GetMaxValueProducts(budget, dtTest));
        }

        //To test the product with same values
        [TestMethod]
        public void TestProduct6()
        {
            DataTable dtTest = new DataTable();
            dtTest.Columns.Add("Id", typeof(int));
            dtTest.Columns.Add("ProductName", typeof(string));
            dtTest.Columns.Add("Price", typeof(int));
            dtTest.Columns.Add("Value", typeof(int));

            //  Here we add datas.
            dtTest.Rows.Add(1, "P1", 1, 3);
            dtTest.Rows.Add(2, "P2", 2, 3);
            dtTest.Rows.Add(3, "P3", 3, 3);
            dtTest.Rows.Add(4, "P4", 4, 3);

            int budget = 4;

            Assert.AreEqual(6, Program.GetMaxValueProducts(budget, dtTest));
        }

        //To test without data or product
        [TestMethod]
        public void TestProduct7()
        {
            DataTable dtTest = new DataTable();
            dtTest.Columns.Add("Id", typeof(int));
            dtTest.Columns.Add("ProductName", typeof(string));
            dtTest.Columns.Add("Price", typeof(int));
            dtTest.Columns.Add("Value", typeof(int));

            int budget = 4;

            Assert.AreEqual(0, Program.GetMaxValueProducts(budget, dtTest));

        }

        //to test with same cost and same value for all products
        [TestMethod]
        public void TestProduct8()
        {
            DataTable dtTest = new DataTable();
            dtTest.Columns.Add("Id", typeof(int));
            dtTest.Columns.Add("ProductName", typeof(string));
            dtTest.Columns.Add("Price", typeof(int));
            dtTest.Columns.Add("Value", typeof(int));

            // Here we add datas.
            dtTest.Rows.Add(1, "P1", 1, 1);
            dtTest.Rows.Add(2, "P2", 1, 1);
            dtTest.Rows.Add(3, "P3", 1, 1);
            dtTest.Rows.Add(4, "P4", 1, 1);

            int budget = 1;

            Assert.AreEqual(1, Program.GetMaxValueProducts(budget, dtTest));
        }

        //To test with 1 product cost 0 and Value 0
        [TestMethod]
        public void TestProduct9()
        {
            DataTable dtTest = new DataTable();
            dtTest.Columns.Add("Id", typeof(int));
            dtTest.Columns.Add("ProductName", typeof(string));
            dtTest.Columns.Add("Price", typeof(int));
            dtTest.Columns.Add("Value", typeof(int));

            // Here we add five DataRows.
            dtTest.Rows.Add(1, "P1", 0, 0);

            int budget = 1;

            Assert.AreEqual(0, Program.GetMaxValueProducts(budget, dtTest));
        }

        //to test product with cost 0chf
        [TestMethod]
        public void TestProduct10()
        {
            DataTable dtTest = new DataTable();
            dtTest.Columns.Add("Id", typeof(int));
            dtTest.Columns.Add("ProductName", typeof(string));
            dtTest.Columns.Add("Price", typeof(int));
            dtTest.Columns.Add("Value", typeof(int));

            // Here we add datas.
            dtTest.Rows.Add(1, "P11", 0, 110);

            int budget = 1;

            Assert.AreEqual(110, Program.GetMaxValueProducts(budget, dtTest));
        }

        //to test product with Value 0
        [TestMethod]
        public void TestProduct11()
        {
            DataTable dtTest = new DataTable();
            dtTest.Columns.Add("Id", typeof(int));
            dtTest.Columns.Add("ProductName", typeof(string));
            dtTest.Columns.Add("Price", typeof(int));
            dtTest.Columns.Add("Value", typeof(int));

            // Here we add datas.
            dtTest.Rows.Add(1, "P11", 1, 0);

            int budget = 1;

            Assert.AreEqual(0, Program.GetMaxValueProducts(budget, dtTest));
        }

        // Test should fail : Failure test case
        [TestMethod]
        public void TestProduct12()
        {
            DataTable dtTest = new DataTable();
            dtTest.Columns.Add("Id", typeof(int));
            dtTest.Columns.Add("ProductName", typeof(string));
            dtTest.Columns.Add("Price", typeof(int));
            dtTest.Columns.Add("Value", typeof(int));

            // Here we add datas.
            dtTest.Rows.Add(1, "P11", 0, 110);

            int budget = 1;

            Assert.AreEqual(0, Program.GetMaxValueProducts(budget, dtTest));
        }
    }
}
