using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;

namespace IPINFO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string ipAddressString = textBox1.Text;

            // Validate the IP address
            if (System.Net.IPAddress.TryParse(ipAddressString, out System.Net.IPAddress ipAddress))
            {
                // Get information from the ipinfo.io API
                string apiEndpoint = $"http://ipinfo.io/{ipAddressString}";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        string response = await client.GetStringAsync(apiEndpoint);

                        // Display information in the richTextBox1
                        richTextBox1.Text = response;
                    }
                    catch (HttpRequestException ex)
                    {
                        richTextBox1.Text = $"Error: {ex.Message}";
                    }
                }
            }
            else
            {
                // Invalid IP address entered
                richTextBox1.Text = "Invalid IP address. Please enter a valid IP.";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
