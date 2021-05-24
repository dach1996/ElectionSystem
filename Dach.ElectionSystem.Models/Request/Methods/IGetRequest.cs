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
        int Offset { get; set; }

        /// <summary>
        /// Orden
        /// </summary>
        /// <value></value>
        OrderBy? OrderBy { get; set; }
        
        /// <summary>
        /// Límite de Registros
        /// </summary>
        /// <value></value>
        int Limit { get; set; }        
    }
}