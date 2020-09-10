using AspNetMvc5Base.Models;
using AspNetMvc5Base.Repositorios;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AspNetMvc5Base.Controllers
{
    public class ProdutosADOController : Controller
    {
        ProdutoRepository _produtoRepository;
        CategoriaRepository _categoriaRepository;


        public ProdutosADOController()
        {
            _produtoRepository = new ProdutoRepository();
            _categoriaRepository = new CategoriaRepository();
        }


        // GET: Produtos
        public ActionResult Index()
        {
            var listProds = _produtoRepository.GetAll();
            return View(listProds);
        }

        //Continuar CRUD daqui......


        //public ActionResult Create()
        //{
        //    ViewBag.Categorias = db.Categorias.ToList();
        //    var model = new ProdutoViewModel();

        //    return View(model);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(ProdutoViewModel model)
        //{
        //    var imageTypes = new string[]{
        //                                    "image/gif",
        //                                    "image/jpeg",
        //                                    "image/pjpeg",
        //                                    "image/png"
        //                                };



        //    if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
        //    {
        //        ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
        //    }
        //    else if (!imageTypes.Contains(model.ImageUpload.ContentType))
        //    {
        //        ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        var produto = new Produto();
        //        produto.Nome = model.Nome;
        //        produto.Preco = model.Preco;
        //        produto.Descricao = model.Descricao;
        //        produto.CategoriaId = model.CategoriaId;

        //        // Salvar a imagem para a pasta e pega o caminho
        //        var imagemNome = String.Format("{0:yyyyMMdd-HHmmssfff}", DateTime.Now);
        //        var extensao = System.IO.Path.GetExtension(model.ImageUpload.FileName).ToLower();
        //        using (var img = System.Drawing.Image.FromStream(model.ImageUpload.InputStream))
        //        {
        //            produto.Imagem = String.Format("/ProdutosImagens/{0}{1}", imagemNome, extensao);
        //            // Salva imagem
        //            SalvarNaPasta(img, produto.Imagem);
        //        }

        //        db.Produtos.Add(produto);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    // Se ocorrer um erro retorna para pagina
        //    ViewBag.Categorias = db.Categorias;
        //    return View(model);
        //}


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Produto produto = _produtoRepository.GetById((int)id);

            if (produto == null)
                return HttpNotFound();

            ViewBag.Categorias = _categoriaRepository.GetAll();

            return View(produto);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Produto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var produto = db.Produtos.Find(model.ProdutoId);
        //        if (produto == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        produto.Nome = model.Nome;
        //        produto.Preco = model.Preco;
        //        produto.CategoriaId = model.CategoriaId;

        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Categorias = db.Categorias;
        //    return View(model);
        //}


        //// GET: Produtos/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    Produto produto = db.Produtos
        //                        .Where(x => x.ProdutoId == id)
        //                        .Include(x => x.Categoria)
        //                        .FirstOrDefault();

        //    if (produto == null)
        //        return HttpNotFound();

        //    //ViewBag.Categoria = db.Categorias.Find(produto.CategoriaId).CategoriaNome;

        //    return View(produto);
        //}

        //// POST: Produtos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Produto produto = db.Produtos.Find(id);

        //    if (produto == null)
        //        return HttpNotFound();

        //    db.Produtos.Remove(produto);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    Produto prod = db.Produtos.Where(x => x.ProdutoId == id).Include(c => c.Categoria).FirstOrDefault();

        //    if (prod == null)
        //        return HttpNotFound();

        //    return View(prod);
        //}

        //private void SalvarNaPasta(Image img, string caminho)
        //{
        //    using (System.Drawing.Image novaImagem = new Bitmap(img))
        //    {
        //        novaImagem.Save(Server.MapPath(caminho), img.RawFormat);
        //    }
        //}
    }
}