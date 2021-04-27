using Dach.ElectionSystem.Models.Enums;

namespace Dach.ElectionSystem.Models.Request.Methods
{
    /// <summary>
    /// Clase que erada los métodos get
    /// </summary>
    public interface IGetRequest
    {
        /// <summary>
        /// Paginación
        /// </summary>
        /// <value></value>
        public int Offset { get; set; }

        /// <summary>
        /// Orden
        /// </summary>
        /// <value></value>
        public OrderBy? OrderBy { get; set; }
        
        /// <summary>
        /// Límite de Registros
        /// </summary>
        /// <value></value>
        public int Limit { get; set; }        
    }
}