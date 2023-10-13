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
        [MaxLength(55, ErrorMessage = "O login deve conter no máximo 55 caracteres")]
        [Remote("SelectLogin", "Autenticacao", ErrorMessage = "O login já existe!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe seu telefone")]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Informe seu CEP")]
        [MaxLength(8, ErrorMessage = "O CEP deve conter no máximo 8 digitos")]
        public int Cep { get; set; }

        [Display(Name = "Número do endereço")]
        [Required(ErrorMessage = "Informe o número do seu endereço")]
        public int NumEnd { get; set; }

        [Display(Name = "Complemento")]
        public string CompleEnd { get; set; }

        [Required(ErrorMessage = "Informe sua rua")]
        public string Logradouro { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Informe sua cidade")]
        public string NomeCidade { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Informe seu bairro")]
        public string NomeBairro { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Informe seu Cpf")]
        [MaxLength(11, ErrorMessage = "O CPF deve conter no máximo 11 digitos")]
        public int Cpf { get; set; }
        
        [Display(Name = "Tipo de acesso")]
        [MaxLength(50, ErrorMessage = "O tipo de acesso deve conter no máximo 50 caracteres")]
        [Required(ErrorMessage = "Informe seu tipo de acesso")]
        public string TipoAcesso { get; set; }

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