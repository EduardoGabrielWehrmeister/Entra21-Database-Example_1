using Model;
using Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FilmeRepositorio repositorio = new FilmeRepositorio();
            List<Filme> filmes = repositorio.ObterTodos();
            dataGridView1.Rows.Clear();

            for (int i = 0; i < filmes.Count; i++)
            {
                Filme filme = filmes[i];
                dataGridView1.Rows.Add(new object[] {filme.Id, filme.Nome, filme.Categoria
                    }
                   ); 

            }
        }
    }
}
