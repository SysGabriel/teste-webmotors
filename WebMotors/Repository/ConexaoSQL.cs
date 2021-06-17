using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using WebMotors.Models;

namespace WebMotors.Repository
{
    public class ConexaoSQL
    {
        private string servidor;
        private string banco;
        private readonly string _;
        private readonly SqlConnection _sqlConexao;
        private SqlTransaction _sqlTransação;
        private SqlCommand _sqlComando;
        private bool _conexaoViaInternet;
        public int RegistrosAfetados { get; private set; }


        public ConexaoSQL(string strconexao)
        {
            _sqlConexao = new SqlConnection(strconexao);
        }

        //Metodos Dapper
        public List<TEntity> Query<TEntity>(string sql)
        {
            Abrir();
            return _sqlConexao.Query<TEntity>(sql).ToList();
        }

        public void Abrir()
        {
            try
            {
                if (_sqlConexao.State != ConnectionState.Closed) return;
                _sqlConexao.Open();
                EmTransacao = false;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível estabelecer conexão.\n" + ex.Message);
            }
        }
        public void Fechar()
        {
            EmTransacao = false;
            _sqlConexao.Close();
        }
        public bool Conectado
        {
            get
            {
                return _sqlConexao.State != ConnectionState.Closed
                    && _sqlConexao.State != ConnectionState.Broken
                        && _sqlConexao.State != ConnectionState.Connecting;
            }
        }

        public bool EmTransacao;

        public void BeginTransacao()
        {
            Abrir();

            _sqlTransação = _sqlConexao.BeginTransaction();

            EmTransacao = true;
        }

        public void CommitTransacao()
        {
            try
            {
                _sqlTransação.Commit();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                EmTransacao = false;
            }
        }

        public void RollbackTransacao()
        {
            try
            {
                if (_sqlConexao.State == ConnectionState.Open && EmTransacao)
                {
                    _sqlTransação.Rollback();
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                EmTransacao = false;
            }
        }
        //CONTROLE DE COMANDOS E CONSULTAS

        public int Executar(string comando)
        {
            Abrir();

            _sqlComando = EmTransacao ?
                new SqlCommand(comando, _sqlConexao, _sqlTransação) :
                new SqlCommand(comando, _sqlConexao);
            var alterados = _sqlComando.ExecuteNonQuery();
            return alterados;
        }

        public SqlDataReader Consultar(string comando)
        {
            if (_sqlConexao.State == ConnectionState.Open)
            {
                Fechar();
            }
            Abrir();
            SqlCommand _sqlComando = new SqlCommand(comando, _sqlConexao);
            return _sqlComando.ExecuteReader();
        }


        public void SetTimeOutComando(int valor)
        {
            _sqlComando.CommandTimeout = valor;
        }
    }
}    