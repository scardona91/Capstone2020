﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessInterfaces;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayerInterfaces;
using LogicLayer;

namespace LogicLayerTests
{

    /// /// <summary>
    /// NAME:Lane Sandburg
    /// DATE: 02/07/2019
    /// CHECKED BY:Alex Diers
    /// 
    /// Tests of the Shift ManagerClass Methods
    /// </summary>
    /// <remarks>
    /// UPDATED BY:NA
    /// UPDATED DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    [TestClass]
    public class ShiftTimeManagerTests
    {

        private IShiftTimeAccessor _shiftTimeAccessor;
        public ShiftTimeManagerTests()
        {
            _shiftTimeAccessor = new FakeShiftTimeAccessor();
        }


        /// /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// Test of the Shift Time insert Method
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestShiftTimeManagerInsertShiftTimeTests()
        {

            //arrange
            PetUniverseShiftTime shiftTime = new PetUniverseShiftTime();
            shiftTime.DepartmentID = "Shipping/Receiving";
            shiftTime.StartTime = "14:00:00";
            shiftTime.EndTime = "22:00:00";
            bool test;
            IShiftTimeManager shiftTimeManager = new ShiftTimeManager(_shiftTimeAccessor);

            //act
            test = shiftTimeManager.AddShiftTime(shiftTime);

            //assert
            Assert.IsTrue(test);
        }

        /// /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// Test of the Shift Time Edit Method
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void TestShiftTimeManagerEditShiftTimeTests()
        {

            //arrange
            PetUniverseShiftTime oldShiftTime = new PetUniverseShiftTime();
            oldShiftTime.DepartmentID = "Shipping/Receiving";
            oldShiftTime.StartTime = "14:00:00";
            oldShiftTime.EndTime = "22:00:00";

            PetUniverseShiftTime newShiftTime = new PetUniverseShiftTime();
            newShiftTime.DepartmentID = "Shipping/Receiving";
            newShiftTime.StartTime = "08:00:00";
            newShiftTime.EndTime = "16:00:00";
            bool test;
            IShiftTimeManager shiftTimeManager = new ShiftTimeManager(_shiftTimeAccessor);

            //act
            test = shiftTimeManager.EditShiftTime(oldShiftTime, newShiftTime);

            //assert
            Assert.IsTrue(test);
        }

        /// /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:Alex Diers
        /// 
        /// Test of the Shift Time Retrieve Method
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void TestShiftTimeManagerRetrieveShiftTimes()
        {
            //arrange
            List<PetUniverseShiftTime> shifTimes;
            IShiftTimeManager shiftTimeManager = new ShiftTimeManager(_shiftTimeAccessor);

            //act
            shifTimes = shiftTimeManager.RetrieveShiftTimes();

            //assert
            Assert.AreEqual(1, shifTimes.Count);
        }

    }
}
