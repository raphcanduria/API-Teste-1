using ControleProduto.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ControleProduto.Controllers
{

    public class ProdutosController : Controller
    {
        private readonly string apiUrl = "https://localhost:44346/api/produtos";
        public async Task<IActionResult> Index()
        {
            List<Produtos> listrprod = new List<Produtos>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listrprod = JsonConvert.DeserializeObject<List<Produtos>>(apiResponse);
                }
            }
            return View(listrprod);
        }

        public ViewResult GetProdutos() => View();

        [HttpPost]
        public async Task<IActionResult> GetProdutos(int codigo)
        {
            Produtos prods = new Produtos();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/" + codigo))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prods = JsonConvert.DeserializeObject<Produtos>(apiResponse);
                }
            }
            return View(prods);
        }

        public ViewResult AdicionaProdutos() => View();
        [HttpPost]
        public async Task<IActionResult> AdicionaProdutos(Produtos prod)
        {
            Produtos prodrec = new Produtos();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(prod),
                                                  Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prodrec = JsonConvert.DeserializeObject<Produtos>(apiResponse);
                }
            }
            return View(prodrec);
        }

        [HttpGet]
        public async Task<IActionResult> EditaProduto(int codigo)
        {
            Produtos prod = new Produtos();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/" + codigo))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prod = JsonConvert.DeserializeObject<Produtos>(apiResponse);
                }
            }
            return View(prod);
        }

        [HttpPost]
        public async Task<IActionResult> EditaProduto(Produtos prod)
        {
            Produtos prodrec = new Produtos();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(prod.Codigo.ToString()), "Codigo");
                content.Add(new StringContent(prod.Descricao), "Descricao");
                content.Add(new StringContent(prod.Estoque.ToString()), "Estoque");
                content.Add(new StringContent(prod.Preco.ToString()), "Preco");
                using (var response = await httpClient.PutAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Ok!";
                    prodrec = JsonConvert.DeserializeObject<Produtos>(apiResponse);
                }
            }
            return View(prodrec);
        }

        [HttpPost]
        public async Task<IActionResult> ApagaProduto(int codigo)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(apiUrl + "/" + codigo))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }





    }
}
