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
    public partial class FilmeEditar : Form
    {
        public FilmeEditar()
        {
            InitializeComponent();
        }

        public FilmeEditar(Filme filme)
        {
            InitializeComponent();
            txtNome.Text = filme.Nome;
            txtCodigo.Text = filme.Id.ToString();
            txtAvaliacao.Text = Convert.ToString(filme.Avaliacao);
            txtDuracao.Text = filme.Duracao.ToString("yy-MM-dd hh:mm:ss");

            cbCategoria.SelectedItem = filme.Categoria;
            ckbTemSequencia.Checked = filme.TemSequencia;

            if (filme.Curtiu)
            {
                rbSim.Checked = true;
            }
            else
            {
                rbNao.Checked = true;
            }
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            filme.Nome = txtNome.Text;
            filme.Id = Convert.ToInt32(txtCodigo.Text);
            filme.Curtiu = rbSim.Checked;
            filme.TemSequencia = ckbTemSequencia.Checked;
            filme.Duracao = Convert.ToDateTime(txtDuracao.Text);
            filme.Avaliacao = Convert.ToDecimal(txtAvaliacao.Text);
            filme.Categoria = cbCategoria.SelectedItem.ToString();
            FilmeRepositorio repositorio = new FilmeRepositorio();
            repositorio.Atualizar(filme);

            MessageBox.Show("Editado com sucesso.");
            Close();
        }
    }
}
