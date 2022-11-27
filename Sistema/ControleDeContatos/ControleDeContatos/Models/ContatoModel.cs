using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o nome do e-mail do cliente")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o número de celular do cliente")]
        [Phone(ErrorMessage =" O celular não é valido!")]
        public string Celular { get; set; }


    }
}
