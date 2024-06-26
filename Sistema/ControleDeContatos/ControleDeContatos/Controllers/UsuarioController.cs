﻿using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {
            UsuarioModel usuario= _usuarioRepositorio.BuscarPorID(Id); 
            return View(usuario);
        }
        public IActionResult ApagarConfirmacao(int Id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorID(Id);
            return View(usuario);
        }


        public IActionResult Apagar(int Id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário deletado com sucesso";
                }

                else
                {
                    TempData["MensagemErro"] = "Não foi possivel deletar o usuário";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel deletar o usuário, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);

                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Opa, não foi possivel cadastrar o usuário, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {

            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil

                    };

                    usuario=_usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemSucesso"] = $"Opa, não foi possivel alterar os dados do usuário, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
