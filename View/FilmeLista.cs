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
    public partial class FilmeLista : Form
    {
        public FilmeLista()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void AtualizarTabela()
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
        
        private void btnApagar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            FilmeRepositorio repositorio = new FilmeRepositorio();
            repositorio.Apagar(id);
            dataGridView1.Rows.RemoveAt((dataGridView1.CurrentCell.RowIndex));
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FilmeCadastro cadastro = new FilmeCadastro();
            cadastro.ShowDialog();
        }

        private void FilmeLista_Activated(object sender, EventArgs e)
        {
            AtualizarTabela();
        }
    }
}
