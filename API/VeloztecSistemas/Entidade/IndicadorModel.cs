using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class IndicadorModel : BaseClass
    {
        /// <summary>
        /// formulaCalculo.
        /// </summary>
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string FormulaCalculo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string DataIntegracao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string DataUltAlteracao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string IdDrgIntegracao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string IdentDirecaoSeta { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string IdentPeriodicidade { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string IdentReferencial { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string InformacoesAdicionais { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string NumDecimais { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Objetivo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Unidade { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string UsuarioUltAlteracao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Versao { get; set; }
        /*
         const IndicadorModel = {
          'id': null,
          'dataIntegracao': null,
          'dataUltAlteracao': null,
          'formulaCalculo': null,
          'idDrgIntegracao': null,
          'identDirecaoSeta': null,
          'identPeriodicidade': null,
          'identReferencial': null,
          'informacoesAdicionais': '',
          'nome': '',
          'numDecimais': null,
          'objetivo': '',
          'unidade': null,
          'usuarioUltAlteracao': null,
          'versao': null
            
         */
    }
}
