﻿using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dach.ElectionSystem.Models.Auth
{
    /// <summary>
    /// Clase modelo para Request de Login
    /// </summary>
    public class ForggotenPasswordRequest : IRequest<Unit>
    {
        /// <summary>
        /// Email del usuario
        /// </summary>
        [Required]
        public string Email { get; set; }
    }
}
