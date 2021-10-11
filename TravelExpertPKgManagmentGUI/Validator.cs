using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

/*
 Author:Sujani Wijesundera
Date:16/09/2021
Purpose: Validation handling for all the inputs
 */
namespace PackageManagement
{
    /// <summary>
    /// A repository of validation methods
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// checks if textbox has anything in it
        /// </summary>
        /// <param name="tb">text box to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsPresent(TextBox tb)
        {
            bool isValid = true;
            if(String.IsNullOrEmpty(tb.Text))// empty
            {
                MessageBox.Show(tb.Tag + " is required");
                tb.Focus(); 
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if textbox has anything in it, if no data then returns  true
        /// otherwise check for alphanumric
        /// </summary>
        /// <param name="tb">text box to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsPresentIfEntered(TextBox tb)
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(tb.Text))// empty
            {
                
                isValid = true;
            }
            else
            {
                isValid = IsNonAlphaNumeric(tb);
            }
            return isValid;
        }

        /// <summary>
        /// checks if user selected from combo box
        /// </summary>
        /// <param name="cb">combo box to validate</param>
        /// <returns>true is selected, and false if not</returns>
        public static bool IsSelected(ComboBox cb)
        {
            bool isValid = true;
            if (cb.SelectedIndex == -1)// no selection
            {
                MessageBox.Show(cb.Tag + " has to be selected");
                cb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains whole number that is greater than or equal to zero
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsNonNegativeInt(TextBox tb)
        {
            bool isValid = true;
            int value;
            if(!Int32.TryParse(tb.Text, out value)) // if the content cannot be  parsed as int
            {
                MessageBox.Show(tb.Tag + " has to be a whole number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if(value < 0 ) // int, but negative
            {
                MessageBox.Show(tb.Tag + " cannot be negative");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains whole number within range
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <param name="minValue">minimum value allowed</param>
        /// <param name="maxValue">maximum value allowed</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsIntInRange(TextBox tb, int minValue, int maxValue)
        {
            bool isValid = true;
            int value;
            if (!Int32.TryParse(tb.Text, out value)) // if the content cannot be  parsed as int
            {
                MessageBox.Show(tb.Tag + " has to be a whole number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if (value < minValue || value > maxValue) // int, but outside the range
            {
                MessageBox.Show(tb.Tag + $" has to be between {minValue} and {maxValue}");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains a number (possibly with decimal part)
        /// that is greater than or equal to zero
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsNonNegativeDouble(TextBox tb)
        {
            bool isValid = true;
            double value;
            if (!Double.TryParse(tb.Text, out value)) // if the content cannot be  parsed as double
            {
                MessageBox.Show(tb.Tag + " has to be a number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if (value < 0) // double, but negative
            {
                MessageBox.Show(tb.Tag + " cannot be negative");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }


        /// <summary>
        /// checks if a textbox contains a number (possibly with decimal part)
        /// that is greater than or equal to zero
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsNonNegativeDecimal(TextBox tb)
        {
            bool isValid = true;
            decimal value;
            if (!Decimal.TryParse(tb.Text, out value)) // if the content cannot be  parsed as double
            {
                MessageBox.Show(tb.Tag + " has to be a number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if (value < 0) // double, but negative
            {
                MessageBox.Show(tb.Tag + " cannot be negative");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains decimal number within range
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <param name="minValue">minimum value allowed</param>
        /// <param name="maxValue">maximum value allowed</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsDecimalInRange(TextBox tb, decimal minValue, decimal maxValue)
        {
            bool isValid = true;
            decimal value;
            if (!Decimal.TryParse(tb.Text, out value)) // if the content cannot be  parsed as decimal
            {
                MessageBox.Show(tb.Tag + " has to be a decimal number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if (value < minValue || value > maxValue) // int, but outside the range
            {
                MessageBox.Show(tb.Tag + $" has to be between {minValue} and {maxValue}");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains only numbers.
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsNonAlphaNumeric(TextBox tb)
        {
            bool isValid = true;
            int value;
            if (Int32.TryParse(tb.Text, out value)) // if the content can be  parsed as int
            {
                MessageBox.Show($" {tb.Tag} Has not to be a Whole Number .\n " +
                 $"Please Enter Correct Value with text or Alphanumeric", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //  MessageBox.Show(tb.Tag + " has to be a whole number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains only numbers or only text.
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsAlphaNumeric(TextBox tb)
        {

            bool isValid = true;
            System.Text.RegularExpressions.Regex numeric = new System.Text.RegularExpressions.Regex("^[0-9]+$");
            System.Text.RegularExpressions.Regex alphanemeric = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]*$");
            System.Text.RegularExpressions.Regex alphabets = new System.Text.RegularExpressions.Regex("^[A-z]+$");
            string IsAlphaNumericOrNumeric = string.Empty;
            if (numeric.IsMatch(tb.Text))
            {
                isValid = false;
                MessageBox.Show($" {tb.Tag} Has not to be a text+Number .\n " +
                $"Please Enter Correct Value with  Alphanumeric", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                if (alphabets.IsMatch(tb.Text))
                {
                    isValid = false;
                    MessageBox.Show($" {tb.Tag} Has not to be all Text.\n " +
                $"Please Enter Correct Value with  Alphanumeric value (String+Number)", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (alphanemeric.IsMatch(tb.Text))
                {
                    isValid = true;
                }

            }
            tb.SelectAll();
            tb.Focus();
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains only numbers.
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsValidDate(DateTimePicker dt)
        {
            bool isValid = true;
            
            if (dt.Value == DateTime.Now) // if the content can be  parsed as date
            {
                MessageBox.Show($" {dt.Tag} has not to be a past date!\n " +
                 $"Please select valid future release date", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //  MessageBox.Show(tb.Tag + " has to be a whole number");
              
                dt.Focus();
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains date.
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsValidEndDateIfPresent(DateTimePicker startDate, DateTimePicker endDate)
        {
            bool isValid = true;

            isValid =IsDatesSame(startDate, endDate);
            if (!isValid) 
            {
                if (startDate.Value >= endDate.Value) // if the start date less than end date
                {
                    MessageBox.Show($" {endDate.Tag} has not to be a past date than start date!\n " +
                     $"Please select valid future end date", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    endDate.Focus();
                    isValid = false;

                }
                else
                {
                    isValid = true;
                }
              
            }
            return isValid;    
        }


        /// <summary>
        /// checks if a textbox contains date.
        /// </summary>
        /// <param name="tb">start date and end date in default</param>
        /// <returns>true if both same return false and true if not</returns>
        public static bool IsDatesSame(DateTimePicker startDate, DateTimePicker endDate)
        {
            bool isValid = false;

            if (startDate.Value.ToString().Equals(endDate.Value.ToString())) // if the start date equals end date
            {
                //MessageBox.Show($" {endDate.Tag} {startDate.Value} {endDate.Value}has not to be a past date than end date!\n " +
                // $"Please select valid future end date", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //  MessageBox.Show(tb.Tag + " has to be a whole number");

               // startDate.Focus();
                isValid = true;

            }

            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains a number (possibly with decimal part)
        /// that is greater than or equal to zero
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsBasePriceGrater(TextBox basePrice,TextBox commision)
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(commision.Text))// empty
            {

                isValid = true;
            }
            else
            {
                isValid =  IsNonNegativeDecimal(commision);
                if (isValid)
                {
                    if (Convert.ToDecimal(basePrice.Text) <= Convert.ToDecimal(commision.Text))
                    {

                        MessageBox.Show($" {commision.Tag} has not to be a greater than or equal the {basePrice.Tag}!\n " +
                            $"Please select valid Price", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isValid = false;
                        commision.SelectAll();
                        commision.Focus();
                    }
                }
            }
            return isValid;
        }

    }
}
