using System;
using System.Collections.Generic;
using MySqlConnector;

namespace DestinoCerto.Models
{
    public class PacoteBanco
    {
        private const string DadosConexao = "Database=destinocerto; Data Source=localhost; User Id=root;";


        public List<Pacote> ListarPacote()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "SELECT * FROM PacoteTuristico";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Pacote> ListaPacote = new List<Pacote>();

            while (Reader.Read())
            {
                Pacote PacoteEncontrado = new Pacote();
               PacoteEncontrado.IdP = Reader.GetInt32("IdP");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    PacoteEncontrado.Nome = Reader.GetString("Nome");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Destino")))                    
                     PacoteEncontrado.Destino = Reader.GetString("Destino");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Origem")))                    
                     PacoteEncontrado.Origem = Reader.GetString("Origem");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))                    
                     PacoteEncontrado.Atrativos = Reader.GetString("Atrativos");                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Retorno")))
                    PacoteEncontrado.Retorno = Reader.GetDateTime("Retorno");  
                if(!Reader.IsDBNull(Reader.GetOrdinal("Saida")))
                    PacoteEncontrado.Saida = Reader.GetDateTime("Saida");

                PacoteEncontrado.Usuario = Reader.GetInt32("Usuario"); 

                ListaPacote.Add(PacoteEncontrado);
            }
            Conexao.Close();
            return ListaPacote;            
        }

        public void InserirPacote(Pacote pacote)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
    string Query = "INSERT INTO PacoteTuristico (Nome, Destino, Origem, Atrativos, Saida, Retorno, Usuario) VALUES (@Nome, @Destino, @Origem, @Atrativos, @Saida, @Retorno, @Usuario)";
           
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Nome", pacote.Nome);
            Comando.Parameters.AddWithValue("@Destino", pacote.Destino);
            Comando.Parameters.AddWithValue("@Origem", pacote.Origem);
            Comando.Parameters.AddWithValue("@Atrativos", pacote.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pacote.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", pacote.Usuario);
                     

            Comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public void AtualizarPacote(Pacote pacote)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "UPDATE PacoteTuristico SET Nome=@Nome, Origem=@Origem, Destino=@Destino,  Atrativos=@Atrativos, Saida=@Saida, Retorno=@Retorno, Usuario=@Usuario WHERE IdP=@IdP";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Nome", pacote.Nome);
            Comando.Parameters.AddWithValue("@Origem", pacote.Origem);
            Comando.Parameters.AddWithValue("@Destino", pacote.Destino);           
            Comando.Parameters.AddWithValue("@Atrativos", pacote.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pacote.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", pacote.Usuario);
            Comando.Parameters.AddWithValue("@IdP", pacote.IdP);
           
            Comando.ExecuteNonQuery();
            Conexao.Close();            
        }

        public void RemoverPacote(int IdP)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "DELETE FROM PacoteTuristico WHERE IdP=@IdP";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@IdP", IdP);
            Comando.ExecuteNonQuery();
            Conexao.Close();  
        }

        public Pacote BuscarPorIdPacote(int IdP)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "SELECT * FROM PacoteTuristico WHERE IdP=@IdP";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@IdP", IdP);
            MySqlDataReader Reader = Comando.ExecuteReader();

            Pacote PacoteEncontrado = new Pacote();

            if(Reader.Read())
            {
                PacoteEncontrado.IdP = Reader.GetInt32("IdP");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    PacoteEncontrado.Nome = Reader.GetString("Nome");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Destino")))                    
                     PacoteEncontrado.Destino = Reader.GetString("Destino");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Origem")))                    
                     PacoteEncontrado.Origem = Reader.GetString("Origem");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))                    
                     PacoteEncontrado.Atrativos = Reader.GetString("Atrativos");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Usuario")))                    
                    PacoteEncontrado.Retorno = Reader.GetDateTime("Retorno");  
                if(!Reader.IsDBNull(Reader.GetOrdinal("Saida")))
                    PacoteEncontrado.Saida = Reader.GetDateTime("Saida"); 

                 PacoteEncontrado.Usuario = Reader.GetInt32("Usuario");

            }
            Conexao.Close();
            return PacoteEncontrado;            
        }

    }
        }
        