using System;

namespace Dach.ElectionSystem.Models.Base
{
    /// <summary>
    /// Calse base para EventAdministratoro
    /// </summary>
    public abstract class EventAdministratorBase
    {
        
        /// <summary>
        /// Privilegios
        /// </summary>
        /// <value></value>
        public string Privileges { get; set; }
    }
}