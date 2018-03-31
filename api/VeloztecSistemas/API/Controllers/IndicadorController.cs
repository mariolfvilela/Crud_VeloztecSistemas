using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Entidade;

namespace API.Controllers
{
    //VeloztecSistemas
    [RoutePrefix("api/indicador")]
    public class IndicadorController : ApiController
    {
        private readonly Servico_ _service;
        public IndicadorController()
        {
            this._service = new Servico_();
        }

        /// <summary>
        /// API responsável por gravar novo registro
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("save")]
        public async Task<IHttpActionResult> Save([FromBody]dynamic dados)
        {
            try
            {
                var indicadorModel = new IndicadorModel();
                if (((Newtonsoft.Json.Linq.JObject)dados) != null)
                    indicadorModel = ((Newtonsoft.Json.Linq.JObject)dados).ToObject<IndicadorModel>();
                var retorno = _service.save(indicadorModel);
                return this.Ok(retorno);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
                //return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// API responsável por gravar novo registro
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var retorno = _service.delete(id);
                return this.Ok(retorno);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
                //return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// API responsável por buscar por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public IndicadorModel getPorId(int id)
        {
            try
            {
                var retorno = _service.getPorId(id);
                return retorno;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex));
                //return this.BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// API responsável por listar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public IEnumerable<IndicadorModel> listar()
        {
            try
            {
                var retorno = _service.listar();
                return retorno;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex));
                //return this.BadRequest(ex.Message);
            }
        }
    }
}
