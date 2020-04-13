﻿using System;
using System.Collections.Generic;
using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Rasha Mohammed
    /// Created: 4/8/2020
    /// Approver: Ethan Holmes
    /// 
    /// Holds tests for picture manager class.
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    [TestClass]
    public class PictureManagerTests
    {
        private IPictureAccessor _fakePictureAccessor;
        private PictureManager _pictureManager;

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/8/2020
        /// Approver: Ethan Holmes
        ///  
        ///  Constructor for instantiating FakePictureAccessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public PictureManagerTests()
        {
            _fakePictureAccessor = new FakePictureAccessor();
        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/8/2020
        /// Approver: Ethan Holmes
        /// 
        /// Load fake picture accessor for testing purposes
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakePictureAccessor = new FakePictureAccessor();
            _pictureManager = new PictureManager(_fakePictureAccessor);

        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/8/2020
        /// Approver: Ethan Holmes
        /// 
        /// Test method for retrieving all pictures
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllPictures()
        {
            //arrange
            List<Picture> pictures;

            IPictureManager pictureManager = new PictureManager(_fakePictureAccessor);

            //act
            pictures = pictureManager.RetrieveAllPictures();

            //assert
            Assert.AreEqual(2, pictures.Count);
        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/8/2020
        /// Approver: Ethan Holmes
        /// 
        /// Nullifies variables to set up for next run.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestCleanup]
        public void TestCleanup()
        {
            _fakePictureAccessor = null;
        }
    }
}
