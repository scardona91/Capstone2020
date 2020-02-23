﻿using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
	/// <summary>
	/// Creator: Cash Carlson
	/// Created: 02/21/2020
	/// Approver: Zach Behrensmeyer
	///
	/// An interface for InventoryItems Logic Manager
	/// </summary>
	public interface IInventoryItemsManager
	{
		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 02/21/2020
		/// Approver: Zach Behrensmeyer
		///
		/// Interface for a method that gets a list of all InventoryItems from an accessor
		/// </summary>
		/// <returns>A list of Inventory Items</returns>
		List<InventoryItems> RetrieveInventoryItems();
	}
}
