using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMotors.Models;

namespace WebMotors.Repository
{
    public class AnuncioRepository
    {
        ConexaoSQL conexao;
        public AnuncioRepository()
        {
            
        }

        public void AddAnuncio (Anuncio anuncio)
        {
            try
            {
                var sqlVerId = "SELECT Max(Id)+1 From teste_webmotors";
                var novoId = conexao.Query<int>(sqlVerId).FirstOrDefault();

                var sqlInsert = $"INSERT INTO teste_webmotors (Id,Marca,Modelo,Versao,Ano,Quilometragem,Observacao) VALUES ({novoId},'{anuncio.Marca}','{anuncio.Modelo}','{anuncio.Versao}',{anuncio.Ano},{anuncio.Quilometragem},{anuncio.Observacao})";
                conexao.Executar(sqlInsert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateAnuncio (Anuncio anuncio)
        {
            try
            {
                var sqlUpdate = $"UPDATE teste_webmotors SET Marca='{anuncio.Marca}', Modelo='{anuncio.Modelo}', Versao='{anuncio.Versao}', Ano={anuncio.Ano}, Quilometragem={anuncio.Quilometragem}, Observacao='{anuncio.Observacao}'";
                conexao.Executar(sqlUpdate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void DeleteAnuncio(int id)
        {
            try
            {
                var sqlDelete = $"DELETE FROM teste_webmotors WHERE Id={id}";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Anuncio ConsultarAnuncio (int id)
        {
            try
            {
                var sqlSelect = $"SELECT * FROM teste_webmotors WHERE Id={id}";
                return conexao.Query<Anuncio>(sqlSelect).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<Anuncio> ConsultarTodosAnuncio()
        {
            try
            {
                var sqlSelect = $"SELECT * FROM teste_webmotors";
                return conexao.Query<Anuncio>(sqlSelect).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}