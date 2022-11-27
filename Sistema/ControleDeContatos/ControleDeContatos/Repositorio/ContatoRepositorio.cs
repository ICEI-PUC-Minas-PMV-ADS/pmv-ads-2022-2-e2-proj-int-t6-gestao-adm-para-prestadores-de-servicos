using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio 
    {
        private readonly BancoContext _context;

        public ContatoRepositorio(BancoContext bancoContext)
        {
           this._context = bancoContext;
        }
        public ContatoModel BuscarPorID(int id)
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _context.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();

            return contato;

        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarPorID(contato.Id);

            if (contatoDB == null) throw new SystemException("Houve um erro na atualização do cliente!");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _context.Contatos.Update(contatoDB);

            _context.SaveChanges();

            return contatoDB;

        }

        public bool Apagar(int Id)
        {
            ContatoModel contatoDB = BuscarPorID(Id);

            if (contatoDB == null) throw new SystemException("Houve um erro na deleção do cliente!");

            _context.Contatos.Remove(contatoDB);
            _context.SaveChanges();

            return true;
        }
    }
}

