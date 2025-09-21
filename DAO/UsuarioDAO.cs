using MySql.Data.MySqlClient;
using ConsciousbetApp.Model;
using ConsciousbetApp.Utils;
using System.Collections.Generic;
using System;

namespace ConsciousbetApp.DAO
{
    public class UsuarioDAO
    {
        // CREATE - Inserir novo usuário
        public void Inserir(Usuario u)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO Usuario (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", u.Nome);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Senha", PasswordHelper.HashPassword(u.Senha));
                cmd.ExecuteNonQuery();
            }
        }

        // READ - Listar todos os usuários
        public List<Usuario> Listar()
        {
            var lista = new List<Usuario>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Usuario ORDER BY Nome";
                var cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Usuario
                    {
                        Id = reader.GetInt32("Id"),
                        Nome = reader.GetString("Nome"),
                        Email = reader.GetString("Email"),
                        Senha = "***" // Por segurança
                    });
                }
            }
            return lista;
        }

        // READ - Buscar usuário por ID
        public Usuario BuscarPorId(int id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Usuario WHERE Id = @Id";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Usuario
                    {
                        Id = reader.GetInt32("Id"),
                        Nome = reader.GetString("Nome"),
                        Email = reader.GetString("Email"),
                        Senha = "***" // Por segurança
                    };
                }
            }
            return null;
        }

        // UPDATE - Atualizar dados do usuário
        public void Atualizar(Usuario u)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE Usuario SET Nome = @Nome, Email = @Email WHERE Id = @Id";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", u.Nome);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Id", u.Id);
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE - Atualizar senha separadamente
        public void AtualizarSenha(int usuarioId, string novaSenha)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE Usuario SET Senha = @Senha WHERE Id = @Id";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Senha", PasswordHelper.HashPassword(novaSenha));
                cmd.Parameters.AddWithValue("@Id", usuarioId);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE - Excluir usuário
        public void Deletar(int id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM Usuario WHERE Id = @Id";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // Método para autenticação
        public Usuario Autenticar(string email, string senha)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Id, Nome, Email, Senha FROM Usuario WHERE Email = @Email";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string senhaHasheada = reader.GetString("Senha");

                    if (PasswordHelper.VerifyPassword(senha, senhaHasheada))
                    {
                        return new Usuario
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Email = reader.GetString("Email"),
                            Senha = null
                        };
                    }
                }
            }
            return null;
        }

        // Verificar se email já existe
        public bool EmailJaExiste(string email, int? idExcluir = null)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Usuario WHERE Email = @Email";

                if (idExcluir.HasValue)
                {
                    sql += " AND Id != @IdExcluir";
                }

                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                if (idExcluir.HasValue)
                {
                    cmd.Parameters.AddWithValue("@IdExcluir", idExcluir.Value);
                }

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}