using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace Beeuzer2.ViewModels
{
    public class CadastroViewModel
    {
        [Required(ErrorMessage = "Informe seu nome")]
        [MaxLength(255, ErrorMessage = "O nome deve conter no máximo 255 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Informe seu CPF")]
        [MaxLength(11, ErrorMessage = "O CPF deve conter 11 digitos")]
        public int Cpf { get; set; }

        [Required(ErrorMessage = "Informe seu CPF")]
        [MaxLength(9, ErrorMessage = "O CPF deve conter no máximo 9 digitos")]
        [MinLength(8, ErrorMessage = "O CPF deve conter no mínimo 8 digitos")]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Insira seu email")]
        [Remote("Action", "Autenticacao", ErrorMessage = "O Email já existe!")]
        [MaxLength(250, ErrorMessage = "O Email deve conter no máximo 250 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Tipo de acesso")]
        [MaxLength(50, ErrorMessage = "O tipo de acesso deve conter no máximo 50 caracteres")]
        [Required(ErrorMessage = "Informe seu tipo de acesso")]
        public string TipoAcesso { get; set; }

        [Required(ErrorMessage = "Insira o logradouro")]
        [MaxLength(255, ErrorMessage = "O logradouro deve conter no máximo 255 caracteres")]
        public string Logradouro { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "Informe seu CPF")]
        [MaxLength(8, ErrorMessage = "O CEP deve conter no máximo 8 digitos")]
        public int Cep { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Informe sua cidade")]
        [MaxLength(200, ErrorMessage = "O nome da cidade deve conter no máximo 200 caracteres")]
        public string NomeCidade { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Informe seu bairro")]
        [MaxLength(200, ErrorMessage = "O nome do bairro deve conter no máximo 200 caracteres")]
        public string NomeBairro { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "Informe o número de seu endereço")]
        public int NumEnd { get; set; }

        [Display(Name = "Complemento")]
        [MaxLength(50, ErrorMessage = "O complemento deve conter no máximo 50 caracteres")]
        public string CompleEnd { get; set; }

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