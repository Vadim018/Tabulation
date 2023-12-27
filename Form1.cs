using System;
using System.IO;
using System.Windows.Forms;

namespace mkr_2
{
    public partial class Form1 : Form
    {
        private string currentFilePath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double startX) ||
                !double.TryParse(textBox2.Text, out double endX) ||
                !double.TryParse(textBox3.Text, out double step))
            {
                richTextBox1.Text = "Будь ласка, введіть коректні числові значення!";
                return;
            }
            richTextBox1.Clear();
            richTextBox1.AppendText("X\tY\n");

            for (double x = startX; x <= endX; x += step)
            {
                double y = YourFunction(x);
                richTextBox1.AppendText($"{x}\t{y}\n");
            }
        }

        private double YourFunction(double x)
        {
            if (double.IsNaN(x) || double.IsInfinity(x))
            {
                return 0;
            }
            return Math.Sin(x);
        }

        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Встановлення фільтру для допоміжних файлів
            saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*";

            saveFileDialog.Title = "Створення файлу";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = saveFileDialog.FileName;
                File.WriteAllText(currentFilePath, richTextBox1.Text);
            }
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Встановлення фільтру для допоміжних файлів
            saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = saveFileDialog.FileName;
                File.WriteAllText(currentFilePath, richTextBox1.Text);
            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Встановлення фільтру для допоміжних файлів
            openFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                richTextBox1.Text = File.ReadAllText(currentFilePath);
            }
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}