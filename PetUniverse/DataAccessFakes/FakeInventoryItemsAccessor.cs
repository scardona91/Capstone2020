﻿using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Cash Carlson
    /// Created: 2020/02/21
    /// Approver: Zach Behrensmeyer
    ///
    /// Fake Accessor class for inventory items to use instead of calling from the database during testing
    /// </summary>
    public class FakeInventoryItemsAccessor : IInventoryItemsAccessor
	{
		private List<InventoryItems> inventoryItems;

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/02/21
        /// Approver: Zach Behrensmeyer
        ///
        /// List of fake Inventory Items to use instead of a database
        /// </summary>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        public FakeInventoryItemsAccessor()
		{
			inventoryItems = new List<InventoryItems>()
			{
				new InventoryItems()
				{
					ProductID = "100000",
					Name = "Fake",
					Brand = "Fake Brand",
					Category = "Fake Category",
					Type = "Fake Type",
					Price = 55.55M,
					Quantity = 10
				}
			};
		}

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/02/21
        /// Approver: Zach Behrensmeyer
        ///
        /// Returns all inventory items from the accessor
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        public List<InventoryItems> SelectAllInventory()
		{
			return inventoryItems;
		}
	}
}
