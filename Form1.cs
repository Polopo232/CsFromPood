using System.Data;
using System.Data.SqlClient;

namespace MinuEpood
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\MinuEpood\Database1.mdf;Integrated Security=True");

        SqlCommand command;

        SqlDataAdapter adapter_toode, adapter_kat;

        public Form1()
        {
            InitializeComponent();
        }

        private void NaitaKategooria()
        {
            connection.Open();
            adapter_kat = new SqlDataAdapter("SELECT Id, Kategooria_nimetus FROM Kategooria_table", connection);
            DataTable dt_kat = new DataTable();
            adapter_kat.Fill(dt_kat);
            foreach (DataRow row in dt_kat.Rows)
            {
                if (!kat_box.Items.Contains(row["Kategooria_nimetus"]))
                {
                    kat_box.Items.Add(row["Kategooria_nimetus"]);
                }

                else
                {
                    command = new SqlCommand("DELETE FROM Kategooria_table WHERE Id=@id", connection);
                }

            }
            connection.Close();
        }

        private void lisa_kat_btn_Click(object sender, EventArgs e)
        {
            bool on = false;
            foreach (var item in kat_box.Items)
            {
                if (item.ToString().ToLower() == kat_box.Text.ToLower())
                {
                    on = true;

                }
            }
            if (on == false)
            {
                command = new SqlCommand("INSERT INTO Kategooria_table (Kategooria_nimetus) VALUES (@kat)", connection);
                connection.Open();
                command.Parameters.AddWithValue("@kat", kat_box.Text);
                command.ExecuteNonQuery();
                connection.Close();
                kat_box.Items.Clear();
                NaitaKategooria();

            }
            else
            {
                MessageBox.Show("Kategooria on juba olemas või väli on tühi!");
            }
        }

        private void kus_kat_btn_Click(object sender, EventArgs e)
        {
            if (kat_box.SelectedItem != null)
            {
                connection.Open();
                string kal_val = kat_box.SelectedItem.ToString();
                command = new SqlCommand("DELETE FROM Kategooria_table WHERE Kategooria_nimetus=@kat", connection);
                command.Parameters.AddWithValue("@kat", kal_val);
                command.ExecuteNonQuery();
                connection.Close();
                kat_box.Items.Clear();
                NaitaKategooria();
            }
        }

        SaveFileDialog save;
        OpenFileDialog open;
        string extension = null;
        private void otsifail_btn_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:\Users\opilane\source\repos\MinuEpood\img";
            open.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            FileInfo open_info = new FileInfo(@"C:\Users\opilane\source\repos\MinuEpood\img" + open.FileName);
            if (open.ShowDialog() == DialogResult.OK && toode_txt.Text != null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\img");
                extension = Path.GetExtension(open.FileName);
                save.FileName = toode_txt.Text + Path.GetExtension(open.FileName);
                save.Filter = "Image" + Path.GetExtension(open.FileName) + "|" + Path.GetExtension(open.FileName);
                if (save.ShowDialog() == DialogResult.OK && toode_txt.Text != null)
                {
                    File.Copy(open.FileName, save.FileName);
                    toodePB.Image = Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Toode puudub!");
            }
        }
    }
}
