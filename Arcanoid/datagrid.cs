using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Arcanoid
{
    public partial class datagrid : Form
    {

        Player player;

        public string playerName = null;
        string db_name = @"C:\Users\Sulpa\Downloads\BASD.db";
        public object DataSource { get; set; }

        public datagrid()
        {
            InitializeComponent();
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Установка изображения в PictureBox
            pictureBox1.Image = Image.FromFile("C:\\Users\\Sulpa\\Downloads\\назв.png");
            this.BackColor = Color.CadetBlue;

            // Добавление PictureBox на форму
            this.Controls.Add(pictureBox1);
            DisplayHighScores(LoadHighScores());
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                string playerName = NameTextBox.Text;
                Form1 Form = new Form1(playerName); 
                Form.ShowDialog(); 
                                   //Application.Exit();
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите ваше имя перед началом игры.");
            }
        }

        private void SaveGameResult(bool isWinner)
        {
            if (isWinner)
            {
                Result result = new Result
                {
                    NAME = playerName,
                    RESULT = player.score,
                };

                List<Result> highScores = LoadHighScores();
                highScores.Add(result);
                highScores = highScores.OrderByDescending(r => r.RESULT).Take(10).ToList();

                SaveHighScores(highScores);
                DisplayHighScores(highScores);
            }
        }

        private List<Result> LoadHighScores()
        {
            List<Result> highScores = new List<Result>();

            using (SQLiteConnection con1 = new SQLiteConnection("Data Source=" + db_name + ";Version=3;"))
            {
                con1.Open();
                string sql = "SELECT * FROM RESULTAT";
                using (SQLiteCommand command = new SQLiteCommand(sql, con1))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Result result = new Result
                        {
                            NAME = reader["NAME"].ToString(),
                            RESULT = Convert.ToInt32(reader["RESULT"]),
                        };
                        highScores.Add(result);
                    }
                }
            }

            return highScores;
        }

        private void SaveHighScores(List<Result> highScores)
        {
            using (SQLiteConnection con1 = new SQLiteConnection("Data Source=" + db_name + ";Version=3;"))
            {
                con1.Open();
                using (SQLiteCommand clearCommand = new SQLiteCommand("DELETE FROM RESULTAT", con1))
                {
                    clearCommand.ExecuteNonQuery();
                }

                foreach (var result in highScores)
                {
                    using (SQLiteCommand insertCommand = new SQLiteCommand("INSERT INTO RESULTAT (NAME, RESULT) VALUES (@Name, @Result)", con1))
                    {
                        insertCommand.Parameters.AddWithValue("@Name", result.NAME);
                        insertCommand.Parameters.AddWithValue("@Result", result.RESULT);
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private void DisplayHighScores(List<Result> highScores)
        {
            dataGridView1.DataSource = highScores;
        }
    }
}
