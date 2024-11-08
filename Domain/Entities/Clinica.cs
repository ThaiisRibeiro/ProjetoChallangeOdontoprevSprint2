﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Dotnet_Clinicas")]
    public class Clinica
    {
     
      


            [Key]
            // public int id { get; set; }
            public int id_clinica { get; set; }
            [Column("cnpj")]
            [Display(Name = "cnpj da clinica: ")]
            [Required(ErrorMessage = "Campo CPF ou CNPJ Obrigátorio", AllowEmptyStrings = false)]
        public string cnpj { get; set; }


            [Column("endereco ")]
            [Display(Name = "endereco  clinica: ")]
            [Required(ErrorMessage = "Campo Endereco Obrigátorio", AllowEmptyStrings = false)]
        public string endereco { get; set; }
            
            [Column("id_dentista ")]
            [Display(Name = "Endereco paciente: ")]
           
        public int id_dentista { get; set; }

           [Column("nome_clinica ")]
           [Display(Name = "nome da clinica: ")]
        [Required(ErrorMessage = "Campo Nome Obrigátorio", AllowEmptyStrings = false)]
        public string nome_clinica { get; set; }
    }
}
