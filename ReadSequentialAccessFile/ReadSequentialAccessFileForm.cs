using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BankLibrary;

namespace ReadSequentialAccessFile
{
    public partial class ReadSequentialAccessFileForm : BankUIForm
    {
        private StreamReader fileReader;  // Reads data from a text file

        public ReadSequentialAccessFileForm()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            // Create and show dialog box enabling user to open file
            DialogResult result;
            string fileName;

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

            // Ensure that the user clicked "OK"
            if (result == DialogResult.OK)
            {
                ClearTextBoxes();

                // Show error if user specified invalid form
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid file name", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        // Create FileStream to obtain read access to file
                        FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                        // Set file from where data is read
                        fileReader = new StreamReader(input);

                        openButton.Enabled = false;  // Disable Open File buttone
                        nextButton.Enabled = true;
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error reading from file.", "File error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get nest record available in the file
                var inputRecord = fileReader.ReadLine();

                if (inputRecord != null)
                {
                    string[] inputFields = inputRecord.Split(',');

                    // Copy string-array values to TextBox values
                    SetTextBoxValues(inputFields);
                }
                else
                {
                    // Close StreamReader and underlying file
                    fileReader.Close();
                    openButton.Enabled = true;
                    nextButton.Enabled = false;
                    ClearTextBoxes();

                    // Notify user if no records in file
                    MessageBox.Show("No more records in file.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error reading from file", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
