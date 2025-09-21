using System;
using System.Windows.Forms;
using ConsciousbetApp.DAO;
using ConsciousbetApp.Model;

namespace ConsciousbetApp.UI
{
    public partial class UsuariosForm : Form
    {
        private UsuarioDAO usuarioDAO;
        private Usuario usuarioSelecionado = null;

        public UsuariosForm()
        {
            InitializeComponent();
            usuarioDAO = new UsuarioDAO();
            ListarUsuarios();
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            // Configurar seleção de linha inteira
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;

            // Evento de seleção de linha
            dgvUsuarios.SelectionChanged += DgvUsuarios_SelectionChanged;
        }

        private void DgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var row = dgvUsuarios.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["Id"].Value);

                // Buscar dados completos do usuário
                usuarioSelecionado = usuarioDAO.BuscarPorId(id);

                if (usuarioSelecionado != null)
                {
                    PreencherCampos(usuarioSelecionado);
                    HabilitarBotoesEdicao(true);
                }
            }
            else
            {
                usuarioSelecionado = null;
                HabilitarBotoesEdicao(false);
            }
        }

        private void PreencherCampos(Usuario usuario)
        {
            txtNome.Text = usuario.Nome;
            txtEmail.Text = usuario.Email;
            txtSenha.Text = ""; // Sempre limpar o campo senha
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

                // Verificar se email já existe
                if (usuarioDAO.EmailJaExiste(txtEmail.Text))
                {
                    MessageBox.Show("Este email já está cadastrado!");
                    return;
                }

                Usuario u = new Usuario
                {
                    Nome = txtNome.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Senha = txtSenha.Text
                };

                usuarioDAO.Inserir(u);
                MessageBox.Show("Usuário cadastrado com sucesso!");
                LimparCampos();
                ListarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar usuário: " + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarioSelecionado == null)
                {
                    MessageBox.Show("Selecione um usuário para atualizar!");
                    return;
                }

                if (!ValidarCamposEdicao()) return;

                // Verificar se email já existe (excluindo o próprio usuário)
                if (usuarioDAO.EmailJaExiste(txtEmail.Text, usuarioSelecionado.Id))
                {
                    MessageBox.Show("Este email já está sendo usado por outro usuário!");
                    return;
                }

                usuarioSelecionado.Nome = txtNome.Text.Trim();
                usuarioSelecionado.Email = txtEmail.Text.Trim();

                usuarioDAO.Atualizar(usuarioSelecionado);

                // Se digitou nova senha, atualizar também
                if (!string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    usuarioDAO.AtualizarSenha(usuarioSelecionado.Id, txtSenha.Text);
                }

                MessageBox.Show("Usuário atualizado com sucesso!");
                LimparCampos();
                ListarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar usuário: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarioSelecionado == null)
                {
                    MessageBox.Show("Selecione um usuário para excluir!");
                    return;
                }

                var resultado = MessageBox.Show(
                    $"Deseja realmente excluir o usuário '{usuarioSelecionado.Nome}'?\n\nEsta ação não pode ser desfeita!",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    usuarioDAO.Deletar(usuarioSelecionado.Id);
                    MessageBox.Show("Usuário excluído com sucesso!");
                    LimparCampos();
                    ListarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir usuário: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            dgvUsuarios.ClearSelection();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            dgvUsuarios.ClearSelection();
            txtNome.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Nome é obrigatório!");
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email é obrigatório!");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Senha é obrigatória!");
                txtSenha.Focus();
                return false;
            }

            if (txtSenha.Text.Length < 4)
            {
                MessageBox.Show("Senha deve ter pelo menos 4 caracteres!");
                txtSenha.Focus();
                return false;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Digite um email válido!");
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarCamposEdicao()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Nome é obrigatório!");
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email é obrigatório!");
                txtEmail.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtSenha.Text) && txtSenha.Text.Length < 4)
            {
                MessageBox.Show("Se informada, a senha deve ter pelo menos 4 caracteres!");
                txtSenha.Focus();
                return false;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Digite um email válido!");
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private void ListarUsuarios()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarioDAO.Listar();

            // Configurar colunas
            if (dgvUsuarios.Columns.Count > 0)
            {
                dgvUsuarios.Columns["Id"].Width = 50;
                dgvUsuarios.Columns["Nome"].Width = 150;
                dgvUsuarios.Columns["Email"].Width = 200;
                dgvUsuarios.Columns["Senha"].Width = 100;
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            usuarioSelecionado = null;
            HabilitarBotoesEdicao(false);
        }
    }
}