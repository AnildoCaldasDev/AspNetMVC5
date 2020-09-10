using AspNetMvc5Base.Contracts;
using AspNetMvc5Base.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AspNetMvc5Base.Repositorios
{
    public class ProdutoRepository : AbstractRepository<Produto, int>
    {
        public override List<Produto> GetAll()
        {
            string sql = @"Select P.ProdutoId, P.Nome, P.Descricao, P.Preco, P.Imagem, P.CategoriaId, C.CategoriaNome
                           From Produtos P Inner Join Categorias C On C.CategoriaId = P.CategoriaId 
                           Order By Nome Asc";

            using (var conn = new SqlConnection(this.connectionString))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Produto> produtos = new List<Produto>();

                Produto produtoModel = null;

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            produtoModel = new Produto();
                            produtoModel.ProdutoId = (int)reader["ProdutoId"];
                            produtoModel.CategoriaId = (int)reader["CategoriaId"];
                            produtoModel.Nome = reader["Nome"].ToString();
                            produtoModel.Descricao = reader["Descricao"].ToString();
                            produtoModel.Preco = (decimal)reader["Preco"];
                            produtoModel.Imagem = reader["Imagem"].ToString();
                            produtoModel.Categoria = new Categoria();
                            produtoModel.Categoria.CategoriaId = produtoModel.CategoriaId;
                            produtoModel.Categoria.CategoriaNome = reader["CategoriaNome"].ToString();

                            produtos.Add(produtoModel);
                        }
                    }

                }
                catch (Exception e)
                {
                    throw e;
                }
                return produtos;
            }
        }

        public override Produto GetById(int id)
        {
            string sql = @"Select top 1 P.ProdutoId, P.Nome, P.Descricao, P.Preco, P.Imagem, P.CategoriaId, C.CategoriaNome
                           From Produtos P Inner Join Categorias C On C.CategoriaId = P.CategoriaId 
                           Where P.ProdutoId = @Id";

            using (var conn = new SqlConnection(this.connectionString))
            {
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                Produto produtoModel = null;

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            produtoModel = new Produto();
                            produtoModel.ProdutoId = (int)reader["ProdutoId"];
                            produtoModel.CategoriaId = (int)reader["CategoriaId"];
                            produtoModel.Nome = reader["Nome"].ToString();
                            produtoModel.Descricao = reader["Descricao"].ToString();
                            produtoModel.Preco = (decimal)reader["Preco"];
                            produtoModel.Imagem = reader["Imagem"].ToString();
                            produtoModel.Categoria = new Categoria();
                            produtoModel.Categoria.CategoriaId = produtoModel.CategoriaId;
                            produtoModel.Categoria.CategoriaNome = reader["CategoriaNome"].ToString();
                        }
                   }

                }
                catch (Exception e)
                {
                    throw e;
                }
                return produtoModel;
            }
        }

        public override void Save(Produto model)
        {
            throw new NotImplementedException();
        }

        public override void Update(Produto model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Produto model)
        {
            throw new NotImplementedException();
        }

        public override void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}