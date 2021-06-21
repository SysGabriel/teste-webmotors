using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMotors.Models;

namespace WebMotors.Repository
{
    public class AnuncioRepository
    {
        ConexaoSQL conexao = new ConexaoSQL("Data Source=127.0.0.1,1433;Initial Catalog=teste_webmotors;User ID=alpha;PWD=APL0108");
        public AnuncioRepository()
        {
            
        }

        public void AddAnuncio (Anuncio anuncio)
        {
            try
            {
                var sqlVerId = "SELECT Max(Id)+1 From teste_webmotors";
                var novoId = conexao.Query<int>(sqlVerId).FirstOrDefault();

                var sqlInsert = $"INSERT INTO tb_AnuncioWebmotors (Id,Marca,Modelo,Versao,Ano,Quilometragem,Observacao) VALUES ({novoId},'{anuncio.Marca}','{anuncio.Modelo}','{anuncio.Versao}',{anuncio.Ano},{anuncio.Quilometragem},{anuncio.Observacao})";
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
                var sqlUpdate = $"UPDATE tb_AnuncioWebmotors SET Marca='{anuncio.Marca}', Modelo='{anuncio.Modelo}', Versao='{anuncio.Versao}', Ano={anuncio.Ano}, Quilometragem={anuncio.Quilometragem}, Observacao='{anuncio.Observacao}'";
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
                var sqlDelete = $"DELETE FROM tb_AnuncioWebmotors WHERE Id={id}";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Anuncio GetAnuncio (int id)
        {
            try
            {
                var sqlSelect = $"SELECT * FROM tb_AnuncioWebmotors WHERE Id={id}";
                return conexao.Query<Anuncio>(sqlSelect).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<Anuncio> GetAnuncios()
        {
            try
            {
                var sqlSelect = $"SELECT * FROM tb_AnuncioWebmotors";
                return conexao.Query<Anuncio>(sqlSelect).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}