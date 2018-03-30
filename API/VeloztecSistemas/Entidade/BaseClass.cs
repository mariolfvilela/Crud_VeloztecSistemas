using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    /// <summary>
    /// Classe Base para o domínio
    /// </summary>
    public abstract class BaseClass //: ICloneable
    {
        /// <summary>
        /// Campo chave
        /// </summary>
        public int Id { get; set; }
    }
}
