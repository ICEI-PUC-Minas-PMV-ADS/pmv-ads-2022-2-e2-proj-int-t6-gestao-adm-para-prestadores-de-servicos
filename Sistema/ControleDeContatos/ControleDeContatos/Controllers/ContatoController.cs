using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarPorID(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int Id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarPorID(Id);
            return View(contato);
        }

        public IActionResult Apagar(int Id)
        {
            try
            {
               bool apagado = _contatoRepositorio.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente deletado com sucesso";
                } 

                else
                {
                    TempData["MensagemErro"] = "Não foi possivel deletar o cliente";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel deletar o cliente, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch(System.Exception erro)
            {
                TempData["MensagemSucesso"] = $"Opa, não foi possivel cadastrar o cliente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemSucesso"] = $"Opa, não foi possivel alterar os dados do cliente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
