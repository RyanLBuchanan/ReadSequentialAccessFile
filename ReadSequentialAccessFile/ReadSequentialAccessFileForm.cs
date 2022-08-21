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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ReadSequentialAccessFile
{
    public partial class ReadSequentialAccessFileForm : BankUIForm
    {
        private BinaryFormatter reader = new BinaryFormatter();
        private FileStream input;  // Reads data from a text file

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
                   
                        // Create FileStream to obtain read access to file
                        input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                        openButton.Enabled = false;  // Disable Open File buttone
                        nextButton.Enabled = true;
                    
                }
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            // Deserialize RecordSerializable and store data in file
            try
            {
                // Get next RecordSerializable available from file
                RecordSerializable record = (RecordSerializable)reader.Deserialize(input);

                // Store values in temporary string array
                var values = new string[]
                {
                    record.Account.ToString(),
                    record.FirstName.ToString(),
                    record.LastName.ToString(),
                    record.Balance.ToString()
                };

                // Copy string-array values to textbox values
                SetTextBoxValues(values);
            }
            catch (SerializationException)
            {
                input?.Close();
                openButton.Enabled = true;
                nextButton.Enabled = false;

                ClearTextBoxes();

                // Notify user if no serializables in file
                MessageBox.Show("No more records in file", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
