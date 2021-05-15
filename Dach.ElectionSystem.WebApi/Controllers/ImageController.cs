using Dach.ElectionSystem.Models.Request.Image;
using Dach.ElectionSystem.Models.ResponseBase;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.WebApi.Properties
{
    /// <summary>
    /// Controlador Autorizador mediante Token JWT
    /// </summary>
    [Route("images")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ImageController : ApiControllerBase
    {
        #region Constructor
        private readonly IMediator _mediator;
        public ImageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods Controller
        /// <summary>
        /// Consultar Imágenes del servidor
        /// </summary>
        /// <returns></returns>
        [Route("{type}/{id}/{resource}")]
        public async Task<IActionResult> GetImages([FromRoute] string type, [FromRoute] string id, [FromRoute] string resource)
            =>  File(await _mediator.Send(new ImageRequest(type, id, resource)), "image/jpeg");

        #endregion
    }
}
