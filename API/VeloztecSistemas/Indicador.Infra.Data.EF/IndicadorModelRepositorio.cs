using Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicador.Infra.Data.EF
{
    public class IndicadorModelRepositorio : IDisposable
    {
        /// <summary>
        /// Método responsável por importar um arquivo para a tabela Paciente.
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        public IndicadorModel save(IndicadorModel indicadorModel)
        {
            indicadorModel.Id = getRegristros().OrderByDescending(p => p.Id).Select(p => p.Id).FirstOrDefault() + 1;
            return indicadorModel;
        }
        /// <summary>
        /// Método responsável por inicializar lista de indicadores
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IndicadorModel> getRegristros()
        {
            var indicadorModels = new List<IndicadorModel>();
            for (int i = 1; i < 50; i++)
            {
                indicadorModels.Add(new IndicadorModel
                {
                    Id = i,
                    Nome = "Nome" + i,
                    FormulaCalculo = "FormulaCalculo" + i,
                    DataIntegracao = "DataIntegracao" + i,
                    DataUltAlteracao = "DataUltAlteracao" + i,
                    IdDrgIntegracao = "IdDrgIntegracao" + i,
                    IdentDirecaoSeta = "IdentDirecaoSeta" + i,
                    IdentPeriodicidade = "IdentPeriodicidade" + i,
                    IdentReferencial = "IdentReferencial" + i,
                    InformacoesAdicionais = "InformacoesAdicionais" + i,
                    NumDecimais = "NumDecimais" + i,
                    Objetivo = "Objetivo" + i,
                    Unidade = "Unidade" + i,
                    UsuarioUltAlteracao = "UsuarioUltAlteracao" + i,
                    Versao = "Versao" + i
                });
            }
            return indicadorModels;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
            // free native resources if there are any.
        }
    }
}
