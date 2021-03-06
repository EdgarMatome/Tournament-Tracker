﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// This is the validation of the input boxes,
        /// It determines whether the entered value is vallid or not
        /// and sends an output message to the user 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    
                    placeNameValue.Text,
                    placeNumberValue.Text,
                    prizeamountValue.Text,
                    percentagePrizeValue.Text );

               
               GlobalConfig.Connecetion.CreatePrize(model);
                

                
                placeNameValue.Text = "";
                placeNumberValue.Text = "";
                prizeamountValue.Text = "0";
                percentagePrizeValue.Text = "0";

            }
            else
            {
                MessageBox.Show("This form has invalid information. Please check it and try again!");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out placeNumber);

            if (placeNumberValidNumber == false)
            {
                output = false;
            }

            if (placeNumber < 1)
            {
                output = false;
            }

            if (placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeamountValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(percentagePrizeValue.Text, out prizePercentage);


            if (prizeAmountValid == false || prizePercentageValid == false)
            {
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0 )
            {
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }
    }
}
