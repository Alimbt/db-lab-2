using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private byte[] imageData;  
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string connectionString = "server=127.0.0.1;port=3306;database=db;uid=root;pwd=941383";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();    
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM book", connection); 
                DataTable dataTable = new DataTable();    
                adapter.Fill(dataTable);   
                dataGridView1.DataSource = dataTable; 
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                 
                imageData = System.IO.File.ReadAllBytes(openFileDialog.FileName);

                
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                MessageBox.Show($"Image size: {imageData.Length} bytes");

            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (imageData == null)
            {
                MessageBox.Show(" یک تصویر انتخاب کنید.");
                return;
            }

            string connectionString = "server=127.0.0.1;port=3306;database=db;uid=root;pwd=941383";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO  book(name,description, image) VALUES (@Name,@Description, @Image)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", textBox1.Text); 
                    command.Parameters.AddWithValue("@Description", textBox2.Text);
                    command.Parameters.AddWithValue("@Image", imageData); 

                    command.ExecuteNonQuery(); 
                     }
            }


            LoadData(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
