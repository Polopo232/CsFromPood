using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MinuEpood
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\CsFromPood\Database1.mdf;Integrated Security=True");

        SqlCommand command;

        SqlDataAdapter adapter_toode, adapter_kat;

        public bool managerSwitch = false;

        public Form1()
        {
            InitializeComponent();
            StartMessageBox();
            NaitaAndmed();
            NaitaKategooria();
        }

        private void StartMessageBox()
        {
            DialogResult start_quest = MessageBox.Show("Lülita sisse halduri režiim?", "Küsimus", MessageBoxButtons.YesNo);

            if (start_quest == DialogResult.Yes)
            {
                managerSwitch = true;
            }
            else
            {
                managerSwitch = false;
            }

            if (managerSwitch)
            {
                cartList.Visible = false;
                valin_btn.Visible = false;
                ostan_btn.Visible = false;
            }
            if (!managerSwitch)
            {
                kat_box.Visible = true;
                kat_box.Visible = false;
                otsifail_btn.Visible = false;
                puh_btn.Visible = false;
                uuenda_btn.Visible = false;
                kus_btn.Visible = false;
                lisa_btn.Visible = false;
                lisa_kat_btn.Visible = false;
                kus_kat_btn.Visible = false;
                hind_txt.Visible = false;
                toode_txt.Visible = false;
                kogus_txt.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
            }
        }

        private double UpdateCartTotal()
        {
            double total = 0;

            foreach (var item in cartList.Items)
            {
                string[] parts = item.ToString().Split(" - ");
                double price = Convert.ToDouble(parts[1].Replace("€", ""));
                total += price;
            }

            return total;
        }
        private void ostan_btn_Click(object sender, EventArgs e)
        {
            if (cartList.Items.Count == 0)
            {
                MessageBox.Show("Korv on tühi!");
                return;
            }

            double total = UpdateCartTotal();

            MessageBox.Show($"Aitäh ostu eest!\nKokku: {total}€");

            cartList.Items.Clear();
        }
        private void valin_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vali toode!");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string name = row.Cells["Toodenimetus"].Value.ToString();
            double price = Convert.ToDouble(row.Cells["Hind"].Value);

            cartList.Items.Add($"{name} - {price}€");

            UpdateCartTotal();
        }
        private void pood_btn_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1365, 660);
            TabControl kategooriad = new TabControl();
            kategooriad.Name = "Kategooriad";
            kategooriad.Width = 450;
            kategooriad.Height = Height;
            kategooriad.Location = new System.Drawing.Point(900, 0);
            connection.Open();
            adapter_kat = new SqlDataAdapter("SELECT Id, kategooria_nimetus FROM Kategooriatabel", connection);
            DataTable dt_kat = new DataTable();
            adapter_kat.Fill(dt_kat);
            ImageList iconsList = new ImageList();
            iconsList.ColorDepth = ColorDepth.Depth32Bit;
            iconsList.ImageSize = new Size(25, 25);
            int i = 0;
            foreach (DataRow row in dt_kat.Rows)
            {
                string name = row["kategooria_nimetus"].ToString();

                iconsList.Images.Add(SystemIcons.Application);

                kategooriad.TabPages.Add(name);
                kategooriad.TabPages[i].ImageIndex = i;

                i++;
                int kat_id = Convert.ToInt32(row["Id"]);
                var fail_list = Failid_KatId(kat_id);
                int r = 0;
                int c = 0;
                foreach (var fail in fail_list)
                {   
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(Path.Combine(@"..\..\..\img", fail));
                    pictureBox.Width = pictureBox.Height = 100;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Location = new System.Drawing.Point(c, r);
                    c = c + 100 + 2;
                    kategooriad.TabPages[i - 1].Controls.Add(pictureBox);
                }
            }

            kategooriad.ImageList = iconsList;
            connection.Close();
            this.Controls.Add(kategooriad);
        }
        private void puh_btn_Click(object sender, EventArgs e)
        {
            toode_txt.Text = "";
            kogus_txt.Text = "";
            hind_txt.Text = "";
            kat_box.SelectedItem = "";
            using (FileStream fs = new FileStream(Path.Combine(Path.GetFullPath(@"..\..\Images"), "peacock.png"), FileMode.Open, FileAccess.Read))
            {
                toodePB.Image = Image.FromStream(fs);
            }
        }
        private List<string> Failid_KatId(int katId)
        {
            List<string> failid = new List<string>();

            string query = "SELECT Pilt FROM Toodetabel WHERE Kategooriad = @katId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@katId", katId);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader["Pilt"] != DBNull.Value)
                {
                    failid.Add(reader["Pilt"].ToString());
                }
            }

            reader.Close();

            return failid;
        }
        private void NaitaAndmed()
        {
            connection.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter(
                "SELECT Toodetabel.Id, Toodetabel.Toodenimetus, Toodetabel.Kogus, " +
                "Toodetabel.Hind, Toodetabel.Pilt, Toodetabel.Bpilt, " +
                "Kategooriatabel.Kategooria_nimetus AS Kategooria_nimetus " +
                "FROM Toodetabel " +
                "INNER JOIN Kategooriatabel ON Toodetabel.Kategooriad = Kategooriatabel.Id", connection);

            adapter_toode.Fill(dt_toode);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt_toode;
            DataGridViewComboBoxColumn combo_kat = new DataGridViewComboBoxColumn();
            combo_kat.DataPropertyName = "Kategooria_nimetus";
            HashSet<string> keys = new HashSet<string>();
            foreach (DataRow item in dt_toode.Rows)
            {
                string kat_n = item["Kategooria_nimetus"].ToString();
                if (!keys.Contains(kat_n))
                {
                    keys.Add(kat_n);
                    combo_kat.Items.Add(kat_n);
                }
            }
            dataGridView1.Columns.Add(combo_kat);
            toodePB.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\..\img"), "Lidl.jpg"));
            connection.Close();
        }
        Form popupFrom;
        private void Loopilt(Image image, int r)
        {
            popupFrom = new Form();
            popupFrom.FormBorderStyle = FormBorderStyle.None;
            popupFrom.StartPosition = FormStartPosition.Manual;
            popupFrom.Size = new Size(200, 200);

            PictureBox pb = new PictureBox();
            pb.Image = image;
            pb.Dock = DockStyle.Fill;
            pb.SizeMode = PictureBoxSizeMode.Zoom;

            popupFrom.Controls.Add(pb);

            System.Drawing.Rectangle cellRectangle = dataGridView1.GetCellDisplayRectangle(4, r, true);
            System.Drawing.Point point = dataGridView1.PointToScreen(cellRectangle.Location);

            popupFrom.Location = new System.Drawing.Point(point.X + cellRectangle.Width, point.Y);
            popupFrom.Show();
        }
        private void NaitaKategooria()
        {
            connection.Open();
            adapter_kat = new SqlDataAdapter("SELECT Id, Kategooria_nimetus FROM Kategooriatabel", connection);
            DataTable dt_kat = new DataTable();
            adapter_kat.Fill(dt_kat);

            kat_box.Items.Clear();

            foreach (DataRow row in dt_kat.Rows)
            {
                kat_box.Items.Add(row["Kategooria_nimetus"].ToString());
            }

            connection.Close();
        }
        byte[] imageData;
        private void dataGridView1_CellMouseEnter1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 4)
                return;

            var imageData = dataGridView1.Rows[e.RowIndex].Cells["Bpilt"].Value as byte[];
            if (imageData == null)
                return;

            using (MemoryStream stream = new MemoryStream(imageData))
            {
                var image = Image.FromStream(stream);
                Loopilt(image, e.RowIndex);
            }
        }
        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (popupFrom != null && !popupFrom.IsDisposed)
            {
                popupFrom.Close();
            }
        }
        private void lisa_btn_Click(object sender, EventArgs e)
        {
            if (toode_txt.Text.Trim() != string.Empty &&
                kogus_txt.Text.Trim() != string.Empty &&
                hind_txt.Text.Trim() != string.Empty && kat_box.SelectedItem != null)
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("SELECT Id FROM Kategooriatabel WHERE Kategooria_nimetus=@kat", connection);
                    command.Parameters.AddWithValue("@kat", kat_box.Text);
                    command.ExecuteNonQuery();
                    var Id = Convert.ToInt32(command.ExecuteScalar());
                    command = new SqlCommand("INSERT INTO Toodetabel (Toodenimetus, Kogus, Hind, Pilt, Bpilt, Kategooriad) " +
                        "VALUES (@toode, @kogus, @hind, @pilt, @bpilt, @kat)", connection);
                    command.Parameters.AddWithValue("@toode", toode_txt.Text);
                    command.Parameters.AddWithValue("@kogus", kogus_txt.Text);
                    command.Parameters.AddWithValue("@hind", hind_txt.Text);
                    extension = Path.GetExtension(open.FileName);
                    command.Parameters.AddWithValue("@pilt", toode_txt.Text + extension);
                    imageData = File.ReadAllBytes(open.FileName);
                    command.Parameters.AddWithValue("@bpilt", imageData);
                    command.Parameters.AddWithValue("@kat", Id);
                    command.ExecuteNonQuery();
                    connection.Close();
                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
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
                command = new SqlCommand("INSERT INTO Kategooriatabel (Kategooria_nimetus) VALUES (@kat)", connection);
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
                command = new SqlCommand("DELETE FROM Kategooriatabel WHERE Kategooria_nimetus=@kat", connection);
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
        private void kus_btn_Click(object sender, EventArgs e)
        {
            var Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            MessageBox.Show(Id.ToString());
            if (Id != 0)
            {
                command = new SqlCommand("DELETE FROM Toode_table WHERE Id=@id", connection);
                connection.Open();
                command.Parameters.AddWithValue("@id", Id);
                command.ExecuteNonQuery();
                connection.Close();

                NaitaAndmed();
            }
            else
            {
                MessageBox.Show("Vali toode, mida kustutada soovid!");
            }
        }

        int Id = 0;
        private void uuenda_btn_Click(object sender, EventArgs e)
        {
            if (toode_txt.Text != "" && kogus_txt.Text != "" && hind_txt.Text != "" && toodePB.Image != null)
            {
                command = new SqlCommand("UPDATE Toodetabel SET Toodenimetus=@toode, Kogus=@kogus, Hind=@hind, Pilt=@pilt, Bpilt=@bpilt WHERE Id=@id", connection);
                connection.Open();
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@toode", toode_txt.Text);
                command.Parameters.AddWithValue("@kogus", kogus_txt.Text);
                command.Parameters.AddWithValue("@hind", hind_txt.Text.Replace(",", "."));
                string pilt = dataGridView1.SelectedRows[0].Cells["Pilt"].Value.ToString();
                string file_pilt = toode_txt.Text + extension;
                command.Parameters.AddWithValue("@pilt", file_pilt);
                command.ExecuteNonQuery();
                connection.Close();
                NaitaAndmed();
                MessageBox.Show("Toode uuendatu d!");
            }
            else
            {
                MessageBox.Show("Palun täida kõik väljad!");
            }
        }
    }
}