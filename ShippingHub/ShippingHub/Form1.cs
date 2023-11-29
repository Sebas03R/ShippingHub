namespace ShippingHub
{
    public partial class Form1 : Form
    {
        private List<string> lstPackages = new List<string>();
        public Form1()
        {
            InitializeComponent();

            List<string> lstPackages = new List<string>();
            List<string> estados = new List<string>
            {
                "",
                "Alabama",
                "Florida",
                "Georgia",
                "Kentucky",
                "Mississippi",
                "North Carolina",
                "South Carolina",
                "Tennesee",
                "West Virginia",
                "Virginia"
            };
            comboBox2.DataSource = estados;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private int currentIndex = -1;

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstPackages.Count > 0)
            {
                currentIndex = (currentIndex + 1) % lstPackages.Count;

                string selectedPackage = lstPackages[currentIndex];

                string[] packageData = selectedPackage.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox5.Enabled = false;
                button5.Enabled = true;


                textBox6.Text = packageData[5].Trim();
                textBox1.Text = packageData[0].Trim();
                textBox2.Text = packageData[1].Trim();
                textBox3.Text = packageData[2].Trim();
                comboBox2.SelectedItem = packageData[3].Trim();
                textBox5.Text = packageData[4].Trim();


            }
            else
            {
                MessageBox.Show("La lista de paquetes está vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 5)
            {
                textBox5.Text = textBox5.Text.Substring(0, 5);
                textBox5.SelectionStart = textBox5.Text.Length;
            }
        }

        private void textBox5_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            textBox6.Text = DateTime.Now.ToString();


            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            textBox1.Text = new string(Enumerable.Repeat(chars, 16)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            textBox2.Enabled = true;
            textBox3.Enabled = true;
            comboBox2.Enabled = true;
            textBox5.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = false;
            button3.Visible = false;
            button4.Enabled = false;
            button4.Visible = false;
            button7.Enabled = true;
            button7.Visible = true;
            button8.Enabled = true;
            button8.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            comboBox2.Enabled = false;
            textBox5.Enabled = false;

            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox6.Text = string.Empty;
            comboBox2.SelectedIndex = -1;
            textBox5.Text = string.Empty;
            button7.Enabled = false;
            button7.Visible = false;
            button3.Enabled = true;
            button3.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) &&
                comboBox2.SelectedItem != null)
            {
                string packageData = $"{textBox1.Text} - {textBox2.Text}- {textBox3.Text}- {comboBox2.SelectedItem}- {textBox5.Text}- {textBox6.Text}";
                lstPackages.Add(packageData);


                UpdatePackagesListBox();
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                comboBox2.Enabled = false;
                textBox5.Enabled = false;
                button4.Enabled = false;
                button3.Enabled = true;
                button3.Visible = true;
                button4.Enabled = true;
                button4.Visible = true;
                button7.Enabled = false;
                button7.Visible = false;
                button8.Enabled = false;
                button8.Visible = false;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox6.Text = string.Empty;
                comboBox2.SelectedIndex = -1;
                textBox5.Text = string.Empty;
                button2.Enabled = true;
                button1.Enabled = true;
                button6.Enabled = true;
            }
            else
            {
                MessageBox.Show("Complete todos los campos antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePackagesListBox()
        {
            IstPackages.Items.Clear();  

            foreach (string package in lstPackages)
            {
                IstPackages.Items.Add(package);  
            }
        }



        private void IstPackages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0 && currentIndex < lstPackages.Count)
            {
                lstPackages.RemoveAt(currentIndex);

                currentIndex = Math.Min(currentIndex, lstPackages.Count - 1);

                UpdatePackagesListBox();

                if (lstPackages.Count == 0)
                {
                    ClearControls();
                }
                else
                {
                    ShowCurrentPackage();
                }
            }
            else
            {
                MessageBox.Show("No hay elementos para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearControls()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox2.SelectedIndex = -1;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
        }

        private void ShowCurrentPackage()
        {
            if (currentIndex >= 0 && currentIndex < lstPackages.Count)
            {
                string selectedPackage = lstPackages[currentIndex];
                string[] packageData = selectedPackage.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                textBox1.Text = packageData[0].Trim();
                textBox2.Text = packageData[1].Trim();
                textBox3.Text = packageData[2].Trim();
                comboBox2.SelectedItem = packageData[3].Trim();
                textBox5.Text = packageData[4].Trim();
                textBox6.Text = packageData[5].Trim();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdatePackagesListBox();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lstPackages.Count > 0)
            {
                currentIndex = (currentIndex - 1 + lstPackages.Count) % lstPackages.Count;

                string selectedPackage = lstPackages[currentIndex];

                string[] packageData = selectedPackage.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox5.Enabled = false;
                button5.Enabled = true;

                textBox6.Text = packageData[5].Trim();
                textBox1.Text = packageData[0].Trim();
                textBox2.Text = packageData[1].Trim();
                textBox3.Text = packageData[2].Trim();
                comboBox2.SelectedItem = packageData[3].Trim();
                textBox5.Text = packageData[4].Trim();

            }
            else
            {
                MessageBox.Show("La lista de paquetes está vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateCurrentPackage()
        {
            if (currentIndex >= 0 && currentIndex < lstPackages.Count)
            {
                string updatedPackage = $"{textBox1.Text.Trim()} - {textBox2.Text.Trim()}, {textBox3.Text.Trim()}, {comboBox2.SelectedItem}, {textBox5.Text.Trim()}, {textBox6.Text.Trim()}";

                lstPackages[currentIndex] = updatedPackage;

                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox5.Enabled = false;

                UpdatePackagesListBox();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            button9.Visible = true;
            button8.Visible = true;
            button8.Enabled = true;
            button4.Enabled = false;

            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox5.Enabled = true;
            comboBox2.Enabled = true;

            button2.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;


        }

        private void button9_Click(object sender, EventArgs e)
        {
            UpdateCurrentPackage();
            button9.Enabled = false;
            button9.Visible = false;
            button8.Enabled = false;
            button8.Visible = false;
            comboBox2.Enabled = false;

            button9.Enabled = false;
            button9.Visible = false;
            button8.Visible = false;
            button8.Enabled = false;
            button4.Enabled = Enabled;


            button2.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;

        }
    }
}
