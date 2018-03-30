using Entidade;
using Indicador.Infra.Data.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Servico_
    {
        /// <summary>
        /// Método responsável por deletar um indicador
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        public Boolean delete(int id)
        {            
            return listar().Where(p => p.Id == id).Count() > 0;
        }
        /// <summary>
        /// Método responsável por importar um arquivo para a tabela Paciente.
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        public IndicadorModel save(IndicadorModel indicadorModel)
        {
            using (var indicadorModelRepositorio = new IndicadorModelRepositorio())
            {
                indicadorModel = indicadorModelRepositorio.save(indicadorModel);
            }
            return indicadorModel;
        }
        /// <summary>
        /// Método responsável por importar um arquivo para a tabela Paciente.
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        public dynamic getPorId(int id)
        {
            return IndicadorModelRepositorio.getRegristros().Where(p=>p.Id == id).FirstOrDefault();
        }
        /// <summary>
        /// Método responsável por importar um arquivo para a tabela Paciente.
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        public IEnumerable<IndicadorModel> listar()
        {
            IEnumerable<IndicadorModel> lista = new List<IndicadorModel>();
            lista = IndicadorModelRepositorio.getRegristros();
            //dynamic dados = new System.Dynamic.ExpandoObject();
            return lista;
        }
    }
}
