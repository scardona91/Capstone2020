﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
	/// Creator: Jaeho Kim
	/// Created: 2/27/2020
	/// Approver: Rasha Mohammed
    /// Interaction logic for ViewAllTransactions.xaml
	/// </summary>
    public partial class ViewAllTransactions : Page
    {
        ITransactionManager _transactionManager;

        TransactionVM _transactionVM;

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This is the default constructor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public ViewAllTransactions()
        {
            _transactionManager = new TransactionManager();
            //_transactionLineManager = new TransactionLineManager();
            InitializeComponent();
        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This method populates all of the products to the data grid.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void populateProductList()
        {
            _transactionVM = (TransactionVM)dgTransactionsList.SelectedItem;
            int transactionID = _transactionVM.TransactionID;
            dgProductList.ItemsSource = _transactionManager.RetrieveAllProductsByTransactionID(transactionID);

        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This method displays a single transaction details with double click.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgTransactionsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            canViewTransactions.Visibility = Visibility.Hidden;
            xTransactionDetails.Visibility = Visibility.Visible;
            _transactionVM = (TransactionVM)dgTransactionsList.SelectedItem;
            txtTransactionID.Text = _transactionVM.TransactionID.ToString();
            txtTransactionDate.Text = _transactionVM.TransactionDateTime.ToString();
            txtEmployeeID.Text = _transactionVM.EmployeeID.ToString();
            txtFirstName.Text = _transactionVM.FirstName.ToString();
            txtLastName.Text = _transactionVM.LastName.ToString();
            txtTransactionTypeID.Text = _transactionVM.TransactionTypeID.ToString();
            txtTransactionStatusID.Text = _transactionVM.TransactionStatusID.ToString();
            txtTransactionTaxRate.Text = _transactionVM.TaxRate.ToString();
            txtTransactionSubTotalTaxable.Text = _transactionVM.SubTotalTaxable.ToString();
            txtTransactionSubTotal.Text = _transactionVM.SubTotal.ToString();
            txtTransactionTotal.Text = _transactionVM.Total.ToString();

            populateProductList();

        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This simply takes the end user back to the View all transactions tab.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            canViewTransactions.Visibility = Visibility.Visible;
            xTransactionDetails.Visibility = Visibility.Hidden;
        }

        private void BtnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            TransactionVM transaction = (TransactionVM)dgProductList.SelectedItem;

            _transactionManager.DeleteItem(transaction.ProductID);

            if (true)
            {
                MessageBox.Show("Are You Sure? The item will be remove");
                TransactionVM _transaction = (TransactionVM)dgProductList.SelectedItem;
                populateProductList();

            }
        }




        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/07/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This event automatically adjusts the data grid whenever the window is loaded
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTransactionsList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgTransactionsList.Columns.RemoveAt(14);
            dgTransactionsList.Columns.RemoveAt(13);
            dgTransactionsList.Columns.RemoveAt(12);
            dgTransactionsList.Columns.RemoveAt(11);
            dgTransactionsList.Columns.RemoveAt(8);
            dgTransactionsList.Columns.RemoveAt(7);
            dgTransactionsList.Columns.RemoveAt(6);
            dgTransactionsList.Columns.RemoveAt(5);
            dgTransactionsList.Columns.RemoveAt(4);
            dgTransactionsList.Columns.RemoveAt(3);
            dgTransactionsList.Columns.RemoveAt(2);

        }


        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/07/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This event automatically adjusts the data grid whenever the window is loaded
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgProductList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgProductList.Columns.RemoveAt(17);
            dgProductList.Columns.RemoveAt(16);
            dgProductList.Columns.RemoveAt(15);
            dgProductList.Columns.RemoveAt(14);
            dgProductList.Columns.RemoveAt(13);
            dgProductList.Columns.RemoveAt(12);
            dgProductList.Columns.RemoveAt(11);
            dgProductList.Columns.RemoveAt(10);
            dgProductList.Columns.RemoveAt(9);
            dgProductList.Columns.RemoveAt(8);
            dgProductList.Columns.RemoveAt(2);
            dgProductList.Columns.RemoveAt(1);
            dgProductList.Columns.RemoveAt(0);
        }


        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/08/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Search Button for transaction by employee name
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransactionSearchByEmployeeName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = txtEmployeeFirstName.Text.ToString();

                string lastName = txtEmployeeLastName.Text.ToString();

                // Retrieve transactions
                dgTransactionsList.ItemsSource = _transactionManager.RetrieveTransactionByEmployeeName(firstName, lastName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }


        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/07/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This button searches through transaction with a given transaction date.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransactionSearchByDate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /**
                 * This logic defaults the date time picker to the current date 
                 * if the end user didn't pick a date.
                 */
                if (dtpTransaction.Value == null)
                {
                    dtpTransaction.Value = DateTime.Today;
                }



                //// Convert the date time picker object to string
                string td = dtpTransaction.Value.ToString();

                //// Parse the string into DateTime
                DateTime transactionDate = DateTime.Parse(td);

                //// Retrieve transactions
                dgTransactionsList.ItemsSource = _transactionManager.RetrieveTransactionByTransactionDate(transactionDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }


    }
}
