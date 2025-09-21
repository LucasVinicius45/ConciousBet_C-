using System;
using System.Windows.Forms;
using ConsciousbetApp.DAO;
using ConsciousbetApp.Model;
using System.Linq;

namespace ConsciousbetApp.UI
{
    public partial class ApostasForm : Form
    {
        private ApostaDAO apostaDAO;
        private UsuarioDAO usuarioDAO;
        private Aposta apostaSelecionada = null;

        public ApostasForm()
        {
            InitializeComponent();
            apostaDAO = new ApostaDAO();
            usuarioDAO = new UsuarioDAO();
            CarregarUsuarios();
            ListarApostas();
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dgvApostas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApostas.MultiSelect = false;
            dgvApostas.SelectionChanged += DgvApostas_SelectionChanged;
        }

        private void CarregarUsuarios()
        {
            var usuarios = usuarioDAO.Listar();
            cmbUsuario.DataSource = usuarios;
            cmbUsuario.DisplayMember = "Nome";
            cmbUsuario.ValueMember = "Id";
            cmbUsuario.SelectedIndex = -1;
        }

        private void DgvApostas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvApostas.SelectedRows.Count > 0)
            {
                var row = dgvApostas.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["Id"].Value);

                apostaSelecionada = apostaDAO.BuscarPorId(id);

                if (apostaSelecionada != null)
                {
                    PreencherCampos(apostaSelecionada);
                    HabilitarBotoesEdicao(true);
                }
            }
            else
            {
                apostaSelecionada = null;
                HabilitarBotoesEdicao(false);
            }
        }

        private void PreencherCampos(Aposta aposta)
        {
            txtValor.Text = aposta.Valor.ToString("F2");
            txtResultado.Text = aposta.Resultado;
            cmbUsuario.SelectedValue = aposta.UsuarioId;
        }

        private void HabilitarBotoesEdicao(bool habilitar)
        {
            btnAtualizar.Enabled = habilitar;
            btnExcluir.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                Aposta a = new Aposta
                {
                    Valor = decimal.Parse(txtValor.Text),
                    Resultado = txtResultado.Text.Trim(),
                    UsuarioId = (int)cmbUsuario.SelectedValue
                };

                apostaDAO.Inserir(a);
                MessageBox.Show("Aposta cadastrada com sucesso!");
                LimparCampos();
                ListarApostas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar aposta: " + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (apostaSelecionada == null)
                {
                    MessageBox.Show("Selecione uma aposta para atualizar!");
                    return;
                }

                if (!ValidarCampos()) return;

                apostaSelecionada.Valor = decimal.Parse(txtValor.Text);
                apostaSelecionada.Resultado = txtResultado.Text.Trim();
                apostaSelecionada.UsuarioId = (int)cmbUsuario.SelectedValue;

                apostaDAO.Atualizar(apostaSelecionada);
                MessageBox.Show("Aposta atualizada com sucesso!");
                LimparCampos();
                ListarApostas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar aposta: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (apostaSelecionada == null)
                {
                    MessageBox.Show("Selecione uma aposta para excluir!");
                    return;
                }

                var resultado = MessageBox.Show(
                    $"Deseja realmente excluir a aposta de R$ {apostaSelecionada.Valor:F2}?\n\nEsta ação não pode ser desfeita!",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    apostaDAO.Deletar(apostaSelecionada.Id);
                    MessageBox.Show("Aposta excluída com sucesso!");
                    LimparCampos();
                    ListarApostas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir aposta: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            dgvApostas.ClearSelection();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            dgvApostas.ClearSelection();
            txtValor.Focus();
        }

        private void btnEstatisticas_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedValue != null)
            {
                int usuarioId = (int)cmbUsuario.SelectedValue;
                var totalApostas = apostaDAO.CalcularTotalApostas(usuarioId);
                var quantidadeApostas = apostaDAO.ContarApostas(usuarioId);

                string nomeUsuario = cmbUsuario.Text;

                MessageBox.Show(
                    $"Estatísticas do usuário: {nomeUsuario}\n\n" +
                    $"Total apostado: R$ {totalApostas:F2}\n" +
                    $"Quantidade de apostas: {quantidadeApostas}",
                    "Estatísticas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show("Selecione um usuário para ver as estatísticas!");
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtValor.Text))
            {
                MessageBox.Show("Valor é obrigatório!");
                txtValor.Focus();
                return false;
            }

            if (!decimal.TryParse(txtValor.Text, out decimal valor) || valor <= 0)
            {
                MessageBox.Show("Digite um valor válido maior que zero!");
                txtValor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtResultado.Text))
            {
                MessageBox.Show("Resultado é obrigatório!");
                txtResultado.Focus();
                return false;
            }

            if (cmbUsuario.SelectedValue == null)
            {
                MessageBox.Show("Selecione um usuário!");
                cmbUsuario.Focus();
                return false;
            }

            return true;
        }

        private void ListarApostas()
        {
            dgvApostas.DataSource = null;
            dgvApostas.DataSource = apostaDAO.Listar();

            if (dgvApostas.Columns.Count > 0)
            {
                dgvApostas.Columns["Id"].Width = 50;
                dgvApostas.Columns["Valor"].Width = 100;
                dgvApostas.Columns["Resultado"].Width = 150;
                dgvApostas.Columns["UsuarioId"].Width = 80;

                // Formatação da coluna Valor
                dgvApostas.Columns["Valor"].DefaultCellStyle.Format = "C2";
                dgvApostas.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void LimparCampos()
        {
            txtValor.Text = "";
            txtResultado.Text = "";
            cmbUsuario.SelectedIndex = -1;
            apostaSelecionada = null;
            HabilitarBotoesEdicao(false);
        }
    }
}