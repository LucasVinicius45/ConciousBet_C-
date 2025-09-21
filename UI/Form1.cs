using System;
using System.Windows.Forms;

namespace ConsciousbetApp.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            UsuariosForm formUsuarios = new UsuariosForm();
            formUsuarios.Show();
        }

        private void btnApostas_Click(object sender, EventArgs e)
        {
            ApostasForm formApostas = new ApostasForm();
            formApostas.Show();
        }
    }
}