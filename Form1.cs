using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void formToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string directoryPath = @"C:\"; 

                System.Diagnostics.Process.Start("explorer.exe", directoryPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening File Explorer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.DefaultExt = "txt";
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                    DialogResult result = saveFileDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        SaveTextToFile(filePath);

                        MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveTextToFile(string filePath)
        {
            string textToSave = "Hello, world!";

            System.IO.File.WriteAllText(filePath, textToSave);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                ExitApplication();
            }
        }

        private void ExitApplication()
        {

            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Save Changes", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                    }
                    else
                    {
                        return;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            richTextBox1.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                DialogResult result = MessageBox.Show("Do you want to save the current content?", "Save Changes", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                    }
                    else
                    {
                        return;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            richTextBox1.Clear();
            MessageBox.Show("New file created or other actions performed.", "New File", MessageBoxButtons.OK);
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    richTextBox1.Text = fileContent;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
