using MySql.Data.MySqlClient;
using ConsciousbetApp.Model;
using ConsciousbetApp.Utils;
using System.Collections.Generic;
using System;

namespace ConsciousbetApp.DAO
{
    public class ApostaDAO
    {
        // CREATE - Inserir nova aposta
        public void Inserir(Aposta a)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO Aposta (Valor, Resultado, UsuarioId) VALUES (@Valor, @Resultado, @UsuarioId)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Valor", a.Valor);
                cmd.Parameters.AddWithValue("@Resultado", a.Resultado);
                cmd.Parameters.AddWithValue("@UsuarioId", a.UsuarioId);
                cmd.ExecuteNonQuery();
            }
        }

        // READ - Listar todas as apostas
        public List<Aposta> Listar()
        {
            var lista = new List<Aposta>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT a.Id, a.Valor, a.Resultado, a.UsuarioId, u.Nome as NomeUsuario 
                              FROM Aposta a 
                              LEFT JOIN Usuario u ON a.UsuarioId = u.Id 
                              ORDER BY a.Id DESC";
                var cmd = new MySqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Aposta
                    {
                        Id = reader.GetInt32("Id"),
                        Valor = reader.GetDecimal("Valor"),
                        Resultado = reader.GetString("Resultado"),
                        UsuarioId = reader.GetInt32("UsuarioId")
                    });
                }
            }
            return lista;
        }

        // READ - Buscar aposta por ID
        public Aposta BuscarPorId(int id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Aposta WHERE Id = @Id";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Aposta
                    {
                        Id = reader.GetInt32("Id"),
                        Valor = reader.GetDecimal("Valor"),
                        Resultado = reader.GetString("Resultado"),
                        UsuarioId = reader.GetInt32("UsuarioId")
                    };
                }
            }
            return null;
        }

        // READ - Buscar apostas por usuário
        public List<Aposta> BuscarPorUsuario(int usuarioId)
        {
            var lista = new List<Aposta>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Aposta WHERE UsuarioId = @UsuarioId ORDER BY Id DESC";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Aposta
                    {
                        Id = reader.GetInt32("Id"),
                        Valor = reader.GetDecimal("Valor"),
                        Resultado = reader.GetString("Resultado"),
                        UsuarioId = reader.GetInt32("UsuarioId")
                    });
                }
            }
            return lista;
        }

        // UPDATE - Atualizar aposta
        public void Atualizar(Aposta a)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE Aposta SET Valor = @Valor, Resultado = @Resultado, UsuarioId = @UsuarioId WHERE Id = @Id";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Valor", a.Valor);
                cmd.Parameters.AddWithValue("@Resultado", a.Resultado);
                cmd.Parameters.AddWithValue("@UsuarioId", a.UsuarioId);
                cmd.Parameters.AddWithValue("@Id", a.Id);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE - Excluir aposta
        public void Deletar(int id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM Aposta WHERE Id = @Id";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // Métodos adicionais de consulta
        public decimal CalcularTotalApostas(int usuarioId)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COALESCE(SUM(Valor), 0) FROM Aposta WHERE UsuarioId = @UsuarioId";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        public int ContarApostas(int usuarioId)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Aposta WHERE UsuarioId = @UsuarioId";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}