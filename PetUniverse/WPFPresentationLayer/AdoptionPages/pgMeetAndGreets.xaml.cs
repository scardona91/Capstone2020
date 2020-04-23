﻿using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.AdoptionPages
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/17/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This class is contains the code for the pgMeetAndGreets page
    /// </summary>
    /// <remarks>
    /// UPDATED BY: Austin Gee
    /// UPDATE DATE: 3/4/2020
    /// WHAT WAS CHANGED: _addModeNotes and _homeInspectorManager were added
    /// 
    /// </remarks>
    public partial class pgMeetAndGreets : Page
    {
        IAdoptionAppointmentManager _adoptionAppointmentManager;
        IInHomeInspectionAppointmentDecisionManager _homeInspectorManager;

        AdoptionAppointmentVM _adoptionAppointment;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/17/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This is the no-argeument constructor
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Austin Gee
        /// UPDATE DATE: 3/4/2020
        /// WHAT WAS CHANGED: _homeInspectorManager added.
        /// 
        /// </remarks>
        public pgMeetAndGreets()
        {

            InitializeComponent();
            _adoptionAppointmentManager = new AdoptionAppointmentManager();
            _homeInspectorManager = new InHomeInspectionAppointmentDecisionManager();
            populateAppointmentDataGrid();


        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/17/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This private method populates Appoinments data grid with the appropriate data
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Austin Gee
        /// UPDATE DATE: 3/4/2020
        /// WHAT WAS CHANGED: Try catch was added to prevent program crash in case of inability to access datat store
        /// 
        /// </remarks>
        private void populateAppointmentDataGrid()
        {
            try
            {
                dgAppointments.ItemsSource = _adoptionAppointmentManager.RetrieveAdoptionAppointmentsByActiveAndType(true, "Meet and Greet");
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Appoinment information cannot be found.\n\n" + ex.InnerException.Message);
            }

        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/17/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This event handler is fired when the dgAppointments data grid's columns are auto generated.
        /// At this point it formats the data grid to an appropriate, human readable form.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        private void dgAppointments_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgAppointments.Columns.RemoveAt(34);
            dgAppointments.Columns.RemoveAt(33);
            dgAppointments.Columns.RemoveAt(32);
            dgAppointments.Columns.RemoveAt(31);
            dgAppointments.Columns.RemoveAt(29);
            dgAppointments.Columns.RemoveAt(28);
            dgAppointments.Columns.RemoveAt(27);
            dgAppointments.Columns.RemoveAt(26);
            dgAppointments.Columns.RemoveAt(25);
            dgAppointments.Columns.RemoveAt(24);
            dgAppointments.Columns.RemoveAt(23);
            dgAppointments.Columns.RemoveAt(22);
            dgAppointments.Columns.RemoveAt(21);
            dgAppointments.Columns.RemoveAt(20);
            dgAppointments.Columns.RemoveAt(19);
            dgAppointments.Columns.RemoveAt(18);
            dgAppointments.Columns.RemoveAt(17);
            dgAppointments.Columns.RemoveAt(16);
            dgAppointments.Columns.RemoveAt(15);
            dgAppointments.Columns.RemoveAt(10);
            dgAppointments.Columns.RemoveAt(9);
            dgAppointments.Columns.RemoveAt(8);
            dgAppointments.Columns.RemoveAt(7);
            dgAppointments.Columns.RemoveAt(6);
            dgAppointments.Columns.RemoveAt(5);
            //dgAppointments.Columns.RemoveAt(4);
            dgAppointments.Columns.RemoveAt(3);
            dgAppointments.Columns.RemoveAt(2);
            dgAppointments.Columns.RemoveAt(1);
            dgAppointments.Columns.RemoveAt(0);




            dgAppointments.Columns[0].Header = "Location Name";
            dgAppointments.Columns[1].Header = "Customer First Name";
            dgAppointments.Columns[2].Header = "Customer Last Name";
            dgAppointments.Columns[3].Header = "Customer Phone Number";
            dgAppointments.Columns[4].Header = "Customer Email";
            dgAppointments.Columns[5].Header = "Appointment Time";

            dgAppointments.Columns[5].DisplayIndex = 0;

        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/17/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This event handler is fired when a row from the dgAppointments is double clicked. It then opens
        /// a new form containing the appointment details form
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        private void dgAppointments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectAppointmentDetails();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/17/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This private method displays all of the relevent AppointmentVM data in the
        /// respective text boxes.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// 
        /// </remarks>
        private void populateTextBoxes()
        {
            try
            {


                txtAppointmentID.Text = _adoptionAppointment.AppointmentID.ToString();
                txtAppointmentType.Text = _adoptionAppointment.AppointmentTypeID;
                dpAppointmentDate.SelectedDate = _adoptionAppointment.AppointmentDateTime;
                txtAppointmentTime.Text = _adoptionAppointment.AppointmentDateTime.ToShortTimeString();
                txtDecision.Text = _adoptionAppointment.Decision;
                txtLocationName.Text = _adoptionAppointment.LocationName;
                txtLocationAddress1.Text = _adoptionAppointment.LocationAddress1;
                txtLocationAddress2.Text = _adoptionAppointment.LocationAddress2;
                txtLocationCity.Text = _adoptionAppointment.LocationCity;
                txtLocationState.Text = _adoptionAppointment.LocationState;
                txtLocationZip.Text = _adoptionAppointment.LocationZip;
                txtCustomerFirstName.Text = _adoptionAppointment.CustomerFirstName;
                txtCustomerLastName.Text = _adoptionAppointment.CustomerLastName;
                txtCustomerPhoneNumber.Text = _adoptionAppointment.CustomerPhoneNumber;
                txtCustomerEmail.Text = _adoptionAppointment.CustomerEmail;
                txtAnimalName.Text = _adoptionAppointment.AnimalName;
                txtAnimalDob.Text = _adoptionAppointment.AnimalDob.ToShortDateString();
                txtAnimalSpecies.Text = _adoptionAppointment.AnimalSpeciesID;
                txtAnimalBreed.Text = _adoptionAppointment.AnimalBreed;

                if (txtDecision.Text == "")
                {
                    txtDecision.Text = "Undecided";
                }
            }
            catch (Exception)
            {
                WPFErrorHandler.ErrorMessage("You must select an item from the list");
            }
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/17/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This method is fired when the back button is clicked. It causes this form to be closed.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Austin Gee
        /// UPDATE DATE: 3/4/2020
        /// WHAT WAS CHANGED: Extracted helper method to just show meet and greet schedule
        /// 
        /// 
        /// </remarks>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            populateAppointmentDataGrid();
            showMeetAndGreetSchedule();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/17/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This method is fired when the page is loaded. It resets the view of the Meet and greet view.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Austin Gee
        /// UPDATE DATE: 3/4/2020
        /// WHAT WAS CHANGED: 
        /// - Added disable notes method
        /// - reset visibity of edit and save buttons for meet and greet notes page
        /// - included add mode set to false
        /// 
        /// </remarks>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            populateAppointmentDataGrid();
            showMeetAndGreetSchedule();
            disableNotes();

            btnEditNotes.Visibility = Visibility.Visible;
            btnSaveNotes.Visibility = Visibility.Hidden;
            cmbDecision.Items.Clear();


        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: 
        /// 
        /// Helper method that makes the meet and greet notes text box and the decision combo 
        /// box read only.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// 
        /// </remarks>
        private void disableNotes()
        {
            txtNotesMeetAndGreet.IsReadOnly = true;
            cmbDecision.IsEnabled = false;
            btnSendEmail.IsEnabled = true;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: 
        /// 
        /// Helper method that makes only the Meet And Greet Schedule page visible
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// 
        /// </remarks>
        private void showMeetAndGreetSchedule()
        {
            canAppointmentDetails.Visibility = Visibility.Hidden;
            canMeetAndGreetSchedule.Visibility = Visibility.Visible;
            canMeetAndGreetNotes.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: 
        /// 
        /// This event handler is fired when the notes button is clicked. it will then display a page which contains the notes for
        /// the displayed meet and greet. This will also be the place where a Facilitator can write notes about how the appointment went.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// 
        /// </remarks>
        private void btnNotes_Click(object sender, RoutedEventArgs e)
        {
            showMeetAndGreetNotes();

            populateNoteFields();

        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: 
        /// 
        /// Helper method that makes only the Meat And Greet Notes page visible
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// 
        /// </remarks>
        private void showMeetAndGreetNotes()
        {
            canAppointmentDetails.Visibility = Visibility.Hidden;
            canMeetAndGreetSchedule.Visibility = Visibility.Hidden;
            canMeetAndGreetNotes.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: 
        /// 
        /// Helper method that populates the fields on the notes page
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// 
        /// </remarks>
        private void populateNoteFields()
        {
            lblNotesTitle.Content = "Adoption Notes";
            txtNotesAnimalName.Text = _adoptionAppointment.AnimalName;
            txtNotesCustomerName.Text = _adoptionAppointment.CustomerFirstName + " " + _adoptionAppointment.CustomerLastName;
            txtNotesMeetAndGreet.Text = _adoptionAppointment.Notes;

            cmbDecision.Items.Add("Approved");
            cmbDecision.Items.Add("Denied");

            cmbDecision.SelectedItem = _adoptionAppointment.Decision;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: 
        /// 
        /// This event handler is fired when the editNotes button is clicked, it enables the notes and decicision
        /// section of the page so that they can be edited and then saved
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// 
        /// </remarks>
        private void btnEditNotes_Click(object sender, RoutedEventArgs e)
        {
            btnEditNotes.Visibility = Visibility.Hidden;
            btnSaveNotes.Visibility = Visibility.Visible;
            enableNotes();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: 
        /// 
        /// Helper method that makes the meet and greet notes text box and the decision combo 
        /// box not read only.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// 
        /// </remarks>
        private void enableNotes()
        {
            txtNotesMeetAndGreet.IsReadOnly = false;
            cmbDecision.IsEnabled = true;
            btnSendEmail.IsEnabled = true;
            btnSendEmail.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: 
        /// 
        /// This event handler is fired when the Notes Back button is clicked. It takes the user back to the Appointment
        /// details page.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// 
        /// </remarks>
        private void btnBackFromNotes_Click(object sender, RoutedEventArgs e)
        {

            showAppointmentDetails();
            cmbDecision.Items.Clear();
            disableNotes();
            btnEditNotes.Visibility = Visibility.Visible;
            btnSaveNotes.Visibility = Visibility.Hidden;
            btnSendEmail.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: 
        /// 
        /// Helper method that makes only the Meat And Greet Details page visible
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// 
        /// </remarks>
        private void showAppointmentDetails()
        {

            canAppointmentDetails.Visibility = Visibility.Visible;
            canMeetAndGreetSchedule.Visibility = Visibility.Hidden;
            canMeetAndGreetNotes.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: 
        /// 
        /// Event handler that is fired when the save button is clicked. validates input, then updates appointment decision and notes
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// 
        /// </remarks>
        private void btnSaveNotes_Click(object sender, RoutedEventArgs e)
        {

            if (!txtNotesMeetAndGreet.Text.IsValidString())
            {
                WPFErrorHandler.ErrorMessage("You must enter Valid notes.");
                txtNotesMeetAndGreet.Focus();
                return;
            }
            if (!cmbDecision.Text.IsValidString())
            {
                WPFErrorHandler.ErrorMessage("You Must enter a valid decision.");
                cmbDecision.Focus();
                return;
            }
            HomeInspectorAdoptionAppointmentDecision oldAppointment = new HomeInspectorAdoptionAppointmentDecision
            {
                Active = _adoptionAppointment.AppointmentActive,
                AdoptionApplicationID = _adoptionAppointment.AdoptionApplicationID,
                AppointmentID = _adoptionAppointment.AppointmentID,
                AppointmentTypeID = _adoptionAppointment.AppointmentTypeID,
                Decision = _adoptionAppointment.Decision,
                DateTime = _adoptionAppointment.AppointmentDateTime,
                LocationID = _adoptionAppointment.LocationID,
                Notes = _adoptionAppointment.Notes
            };
            HomeInspectorAdoptionAppointmentDecision newAppointment = new HomeInspectorAdoptionAppointmentDecision
            {
                Active = _adoptionAppointment.AppointmentActive,
                AdoptionApplicationID = _adoptionAppointment.AdoptionApplicationID,
                AppointmentID = _adoptionAppointment.AppointmentID,
                AppointmentTypeID = _adoptionAppointment.AppointmentTypeID,
                Decision = cmbDecision.SelectedItem.ToString(),
                DateTime = _adoptionAppointment.AppointmentDateTime,
                LocationID = _adoptionAppointment.LocationID,
                Notes = txtNotesMeetAndGreet.Text
            };
            try
            {
                _homeInspectorManager.EditAppointment(oldAppointment, newAppointment);
            }
            catch (Exception)
            {
                WPFErrorHandler.ErrorMessage("Appointment update failed");

            }
            dgAppointments.Items.Refresh();
            _adoptionAppointment = _adoptionAppointmentManager.RetrieveAdoptionAppointmentByAppointmentID(_adoptionAppointment.AppointmentID);
            populateNoteFields();
            populateTextBoxes();

            disableNotes();
            btnEditNotes.Visibility = Visibility.Visible;
            btnSaveNotes.Visibility = Visibility.Hidden;
            return;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/3/2020
        /// CHECKED BY: NA
        /// 
        /// This event handler is fired whenthe view button si clicked. It then opens
        /// a new form containing the appointment details form
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            selectAppointmentDetails();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/3/2020
        /// CHECKED BY: NA
        /// 
        /// Helper method that is responsible for what happens after an appoinment selection is made
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        private void selectAppointmentDetails()
        {
            showAppointmentDetails();
            AdoptionAppointmentVM adoptionAppointment = (AdoptionAppointmentVM)dgAppointments.SelectedItem;
            _adoptionAppointment = _adoptionAppointmentManager.RetrieveAdoptionAppointmentByAppointmentID(adoptionAppointment.AppointmentID);
            populateTextBoxes();
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 2020/03/10
        /// Approved By:  Awaab Elamin ,2020/03/13
        /// 
        /// This is a click event when send email button is clicked. It will send an email
        /// to the adoption application customer.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendEmai_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdoptionAppointmentVM selectedApplication =
                    (AdoptionAppointmentVM)dgAppointments.SelectedItem;
                if (selectedApplication == null)
                {
                    MessageBox.Show("Please select an application to notify the customer by email");
                    return;
                }

                var customerEmail =
                    _homeInspectorManager.
                        GetCustomerEmailByAdoptionApplicationID(selectedApplication.AdoptionApplicationID);

                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("pet@gmail.com");
                mail.To.Add(customerEmail);// get email address from the Database.
                mail.Subject = "Adoption Application Status";
                mail.Body = "Hello, your Application has been approved ";
                smtpServer.Port = 80;
                smtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                smtpServer.EnableSsl = true;
                //smtpServer.Send(mail);
                MessageBox.Show("Email has been sent Successfully to " + customerEmail);


            }
            catch (Exception ex)
            {

                MessageBox.Show("Couldn't send Email", ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/04/14
        /// Approver: Austin Gee , 2020/04/15 
        /// This is a click event when Welcome Basket button is clicked.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWelcomeBasket_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new pgWelcomeHomeBaskets());
        }
    }
}
