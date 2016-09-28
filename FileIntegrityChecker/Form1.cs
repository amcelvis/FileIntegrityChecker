using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FileIntegrityChecker {
    public partial class Form1 : Form {
        //Global Variable Declaration and Initialization
        string md5, sha1, sha2, sha3, sha5;

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            getFilename();
        }

        private void enableDisable(TextBox t, Button b) {
            if (t.Text == "")
                b.Enabled = false;
            else
                b.Enabled = true;
        }

        private void getFilename() {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Select File";
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e) {
            if (textBox2.Text == "") {
                MessageBox.Show("Please Insert the Original hash that came with the file");
            }
            else {
                string hash = textBox2.Text.ToUpper();
                if (md5 != null)
                    if (hash == md5 || hash == sha1 || hash == sha2 || hash == sha3 || hash == sha5) {
                        label9.ForeColor = Color.Green;
                        label9.Text = "File matches the Original";
                    }
                    else {
                        label9.ForeColor = Color.Red;
                        label9.Text = "File integrity is Compromised!!!";
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            Clipboard.SetText(textBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e) {
            Clipboard.SetText(textBox4.Text);
        }

        private void button5_Click(object sender, EventArgs e) {
            Clipboard.SetText(textBox5.Text);
        }

        private void button6_Click(object sender, EventArgs e) {
            Clipboard.SetText(textBox6.Text);
        }

        private void button7_Click(object sender, EventArgs e) {
            Clipboard.SetText(textBox7.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            showHideHash(checkBox1,textBox3);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) {
            showHideHash(checkBox2, textBox4);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) {
            showHideHash(checkBox3, textBox5);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e) {
            showHideHash(checkBox4, textBox6);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e) {
            showHideHash(checkBox5, textBox7);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e) {
            textBox2.Text = Clipboard.GetText();
        }

        private void textBox3_TextChanged(object sender, EventArgs e) {
            enableDisable(textBox3, button2);
        }

        private void textBox4_TextChanged(object sender, EventArgs e) {
            enableDisable(textBox4, button4);
        }

        private void textBox5_TextChanged(object sender, EventArgs e) {
            enableDisable(textBox5, button5);
        }

        private void textBox6_TextChanged(object sender, EventArgs e) {
            enableDisable(textBox6, button6);
        }

        private void textBox7_TextChanged(object sender, EventArgs e) {
            enableDisable(textBox7, button7);
        }

        private void menuItem5_Click(object sender, EventArgs e) {
            AboutBox about = new AboutBox();
            about.Owner = this;
            about.Show();
        }

        private void menuItem2_Click(object sender, EventArgs e) {
            getFilename();
        }

        private void menuItem3_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e) {
            getFilename();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutBox about = new AboutBox();
            about.Owner = this;
            about.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            CheckBox[] check = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 };
            if (textBox1.Text != "") {
                foreach (CheckBox v in check)
                    v.Enabled = true;
            }else
                foreach (CheckBox v in check)
                    v.Enabled = false;
        }

        private void showHideHash(CheckBox checkbox, TextBox textbox) {
            string path = textBox1.Text.Replace("\"", string.Empty).Trim();
            if (File.Exists(path)) {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    md5 = Checksum.GetChecksum(path, 1);
                    sha1 = Checksum.GetChecksum(path, 2);
                    sha2 = Checksum.GetChecksum(path, 3);
                    sha3 = Checksum.GetChecksum(path, 4);
                    sha5 = Checksum.GetChecksum(path, 5);
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                    if (checkbox.Checked == true) {
                        if (checkbox == checkBox1)
                            textbox.Text = md5;
                        else if (checkbox == checkBox2)
                            textbox.Text = sha1;
                        else if (checkbox == checkBox3)
                            textbox.Text = sha2;
                        else if (checkbox == checkBox4)
                            textbox.Text = sha3;
                        else if (checkbox == checkBox5)
                            textbox.Text = sha5;
                    }
                    else
                        textbox.Text = "";
             }
             else {
                checkbox.Checked = false;
                MessageBox.Show("Please type in a valid filepath or use the Browse button", "File Does Not Exist");
            }
        }
    }
}
