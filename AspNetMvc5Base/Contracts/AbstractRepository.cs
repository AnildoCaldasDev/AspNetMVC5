using System.Collections.Generic;
using System.Web.Configuration;

namespace AspNetMvc5Base.Contracts
{
    public abstract class AbstractRepository<TEntity, Tkey> where TEntity : class
    {
        protected string connectionString { get; } = WebConfigurationManager.ConnectionStrings["ProdutoDbContext"].ConnectionString;

        public abstract List<TEntity> GetAll();
        public abstract TEntity GetById(Tkey id);
        public abstract void Save(TEntity model);
        public abstract void Update(TEntity model);
        public abstract void Delete(TEntity model);
        public abstract void DeleteById(Tkey id);
    }
}