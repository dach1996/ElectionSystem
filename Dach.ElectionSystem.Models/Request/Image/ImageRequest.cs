using System;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Image
{
    /// <summary>
    /// Request para conseguir imágen
    /// </summary>
    public class ImageRequest : IRequest<byte[]>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fromResource"></param>
        /// <param name="id"></param>
        /// <param name="image"></param>
        public ImageRequest(string fromResource, string id, string image)
        {
            FromResource = fromResource;
            Id = id;
            Image = image;
        }

        /// <summary>
        /// Tipo de recurso Ejemplo (Candidate, Event)
        /// </summary>
        /// <value></value>
        public string FromResource { get; set; }

        /// <summary>
        /// Id de recursos
        /// </summary>
        /// <value></value>
        public string Id { get; set; }

        /// <summary>
        /// Nombre de recurso
        /// </summary>
        /// <value></value>
        public string Image { get; set; }

        /// <summary>
        /// Ruta completa de la imagen
        /// </summary>
        /// <value></value>
        public string FullPath { get => $"{FromResource}/{Id}/{Image}"; }


    }
}