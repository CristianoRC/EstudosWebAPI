using System;
using System.Collections.Generic;
using Dapper;

namespace Cotacoes.Model
{
    internal class UsuarioRepository : GenericRepository
    {

        internal static Usuario Obter(string email)
        {
            try
            {
                AbrirConexao();
                var usuTemp = conexao.QueryFirst<Usuario>("select id,nome,email,administrador from usuarios where email = @EmailUsu",
                                                     new { EmailUsu = email });
                FecharConexao();

                return usuTemp;
            }
            catch
            {
                return new Usuario { ID = -1 };
            }
        }

        internal static void Adicionar(Usuario usuario)
        {
            var sql = @"Insert into usuarios (nome,email,senha,administrador)
                        values(@nome,@email,@senha,@administrador)";
            try
            {
                AbrirConexao();
                conexao.Execute(sql, usuario);
                FecharConexao();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("duplicar valor da chave viola a restrição de unicidade"))
                    throw new Exception("Email já cadastrado.");
                else
                    throw new Exception($"Erro ao cadastrar usuário: {e.Message}");
            }
        }

        internal static void Deletar(string email)
        {
            var sql = "delete from usuarios where email = @EmailUsuario";

            try
            {
                AbrirConexao();
                conexao.Execute(sql, new { EmailUsuario = email.ToLower() });
                FecharConexao();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao deletar usuário: {e.Message}");
            }
        }

        public static void Atualizar(Usuario usuario)
        {
            var sql = @"update usuarios set (nome,email,senha,administrador) =
                        (@nome,@email,@senha,@administrador) where email = @email";

            try
            {
                AbrirConexao();
                conexao.Execute(sql, usuario);
                FecharConexao();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("duplicar valor da chave viola a restrição de unicidade"))
                    throw new Exception("Email já cadastrado.");
                else
                    throw new Exception($"Erro ao cadastrar usuário: {e.Message}");
            }
        }
        internal static bool Autenticar(string email, string senha)
        {
            var sql = @"select AutenticarUsuario(@EmailUsuario, @SenhaUsuario)";

            try
            {
                AbrirConexao();
                var resultado = conexao.QueryFirst<bool>(sql, new { SenhaUsuario = senha, EmailUsuario = email });
                FecharConexao();

                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao autenticar usuário: {e.Message}");
            }
        }

        internal static string ObterNome(string email)
        {
            try
            {
                return conexao.QueryFirst<string>("select nome from usuarios where email = @EmailUsu",
                                                    new { EmailUsu = email });
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao buscar nome do usuário: {e.Message}");
            }
        }

        internal static IEnumerable<Usuario> Listar()
        {
            try
            {
                return conexao.Query<Usuario>("select ID, Nome, Email, Administrador from usuarios order by ID");
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao buscar nome do usuário: {e.Message}");
            }
        }
    }
}