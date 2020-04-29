﻿using DataTransferObjects;
using LogicLayer;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// Creator: Jesse Tomash
    /// Created: 3/30/2020
    /// Approver: Brandyn T. Coverdill
    /// Approver: 
    ///
    /// Code-behind file for Viewing ORders.
    /// </summary>
    public partial class ViewOrders : Page
    {
        private OrderItemLineManager _orderItemLineManager;
        private OrderManager _orderManager;
        private Order _order;
        private List<Order> _orders;
        private List<Order> _currentOrders;

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Iconstructor  for ViewSpecialOrders.xaml
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        public ViewOrders()
        {
            InitializeComponent();
            _orderManager = new OrderManager();
            _orderItemLineManager = new OrderItemLineManager();
            dgOrders.Visibility = Visibility.Visible;
            btnAddOrder.Visibility = Visibility.Visible;
            btnDeleteOrder.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Opens Add Order on click
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ViewAddOrder());
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Formats the DG
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void dgOrders_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgOrders.Columns[0].Header = "Order ID";
            dgOrders.Columns[1].Header = "Employee ID";
            dgOrders.Columns[2].Visibility = Visibility.Hidden;
            foreach (var column in this.dgOrders.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Updates order list on gridload
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgOrders.ItemsSource = _orderManager.RetrieveOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: 
        /// Approver: 
        /// 
        /// Helper method that sets up view order
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void SetUpViewOrder()
        {
            try
            {
                _order = (Order)dgOrders.SelectedItem;
                this.NavigationService?.Navigate(new ViewAddOrder(_order));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/15/2020
        ///
        /// Approver: 
        /// Approver: 
        /// 
        /// Action to view order when an item on the datagrid is double clicked
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY: Brandyn T. Coverdill
        /// UPDATE DATE: 4/28/2020
        /// WHAT WAS CHANGED: Made it so that an error message displayed if no item was selected.
        /// </remarks>
        /// <returns></returns>
        private void btnViewOrder_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItem == null)
            {
                "Please Select an Order.".ErrorMessage();
            }
            else
            {
                SetUpViewOrder();
            }
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Action to view order when an item on the datagrid is double clicked
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void dgOrders_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetUpViewOrder();
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Action to delete order when an delete order is clicked
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY: Brandyn T. Coverdill
        /// UPDATE DATE: 4/28/2020
        /// WHAT WAS CHANGED: Changed the error message if no order was selected.
        /// </remarks>
        /// <returns></returns>
        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {

            if (dgOrders.SelectedItem != null)
            {
                try
                {
                    _order = (Order)dgOrders.SelectedItem;
                    _orderManager.DeleteOrder(_order.OrderID);
                    foreach (OrderItemLine line in _orderItemLineManager.SelectOrderItemLinesByOrderID(_order.OrderID))
                    {
                        _orderItemLineManager.DeleteOrderItemLineByItemID(line.ItemID);
                    }
                    dgOrders.ItemsSource = _orderManager.RetrieveOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                "Please select an Order.".ErrorMessage();
            }
        }
        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// button that takes you to a detailed view of an order
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnOrderDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _order = (Order)dgOrders.SelectedItem;
                this.NavigationService?.Navigate(new ViewOrderDetails(_order));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
