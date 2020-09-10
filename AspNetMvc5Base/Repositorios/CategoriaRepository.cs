
using AspNetMvc5Base.Contracts;
using AspNetMvc5Base.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AspNetMvc5Base.Repositorios
{
    public class CategoriaRepository : AbstractRepository<Categoria, int>
    {
        public override void Delete(Categoria model)
        {
            throw new System.NotImplementedException();
        }

        public override void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public override List<Categoria> GetAll()
        {
            string sql = @"Select CategoriaId, CategoriaNome from Categorias Order By CategoriaNome Asc";

            using (var conn = new SqlConnection(this.connectionString))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Categoria> categorias = new List<Categoria>();

                Categoria categoriaModel = null;

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            categoriaModel = new Categoria();
                            categoriaModel.CategoriaId = (int)reader["CategoriaId"];
                            categoriaModel.CategoriaNome = reader["CategoriaNome"].ToString();


                            categorias.Add(categoriaModel);
                        }
                    }

                }
                catch (Exception e)
                {
                    throw e;
                }
                return categorias;
            }
        }

        public override Categoria GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public override void Save(Categoria model)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(Categoria model)
        {
            throw new System.NotImplementedException();
        }
    }
}