using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace Beeuzer.ViewModel
{
    public class CadastroViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe seu nome")]
        [MaxLength(200, ErrorMessage = "O nome deve conter no máximo 200 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o login")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(55, ErrorMessage = "O login deve conter no máximo 55 caracteres")]
        [Remote("SelectLogin", "Autenticacao", ErrorMessage = "O login já existe!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe seu telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Informe seu Cpf")]
        [MaxLength(11, ErrorMessage = "O CPF deve conter no máximo 11 digitos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [MaxLength(100, ErrorMessage = "A senha deve conter no máximo 100 caracteres")]
        [MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirme a senha")]
        [Required(ErrorMessage = "Confirme a senha")]
        [DataType(DataType.Password)]
        [Compare(nameof(Senha), ErrorMessage = "As senhas são diferentes")]
        public string ConfirmarSenha { get; set; }
    }
}