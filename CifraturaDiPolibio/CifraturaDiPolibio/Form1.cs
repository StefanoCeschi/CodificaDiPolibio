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
using CifraturaDiPolibio.Models;

namespace CifraturaDiPolibio
{
    public partial class Form1 : Form
    {
        Polibio p;
        public Form1()
        {
            InitializeComponent();
            p = new Polibio();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 5;
            dataGridView1.ColumnCount = 5;
            string[,] alph = p.GetMap('i');
            for(int i = 0; i < alph.GetLength(0); i++)
            {
                for(int j = 0; j < alph.GetLength(1); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = alph[i, j];
                }
            }
        }

        private void UpdateGrid(string[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = map[i, j];
                }
            }
        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox2.Text = p.Encode(guna2TextBox1.Text);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string skp;
            string[,] map = new string[5, 5];
            int[] coords = new int[2];
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[j].Value).Contains(','))
                    {
                        skp = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value).Split(',')[0];
                        p.skip = Convert.ToChar(skp);
                        coords[1] = i+1;
                        coords[0] = j+1;
                        p.DoubleCharCoords = coords;
                    }
                    map[i, j] = dataGridView1.Rows[i].Cells[j].Value + "";
                }
            }
            p.UpdateMap(map);
            guna2Button1.FillColor = Color.Green;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2Button1.FillColor = Color.CornflowerBlue;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            guna2Button1.FillColor = Color.CornflowerBlue;
        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2RadioButton2.Checked)
            {
                MessageBox.Show("Decodifica non ancora disponibile!");
                guna2RadioButton2.Checked = false;
                guna2RadioButton1.Checked = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter =
                    "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.ShowDialog();
                File.WriteAllText(saveFileDialog1.FileName, guna2TextBox2.Text);
                if (File.Exists(saveFileDialog1.FileName))
                {
                    guna2Button2.Text = "Salvataggio..";
                    guna2Button2.FillColor = Color.Green;
                }
                else
                {
                    guna2Button2.FillColor = Color.Red;
                }
                guna2Button2.Text = "Salva File TXT";
            }
            catch(Exception ex)
            {
                guna2Button2.FillColor = Color.Red;
                MessageBox.Show("Un errore non specifico ha impedito la creazione del" +
                    " file. Riferimento:\r\n" + ex.Message);
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            guna2Button2.FillColor = Color.CornflowerBlue;
        }
    }
}
