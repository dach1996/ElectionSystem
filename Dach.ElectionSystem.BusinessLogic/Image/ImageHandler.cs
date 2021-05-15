using AutoMapper;
using Dach.ElectionSystem.Models.Request.Image;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Image
{
    public class ImageHandler : IRequestHandler<ImageRequest, byte[]>
    {
        private readonly IConfiguration configuration;
        #region Constructor
        public ImageHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion
        #region Handler
        public async Task<byte[]> Handle(ImageRequest request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                byte[] byteImage = Array.Empty<byte>();
                if (string.IsNullOrEmpty(request.FullPath))
                    return byteImage;
                var pathEnviroment = configuration.GetSection("PathSaveImage").Value;
                var pathAbsolute = $"{pathEnviroment}/{request.FullPath}";
                var file = new FileInfo(pathAbsolute);
                if (!file.Exists)
                    return byteImage;
                byteImage = File.ReadAllBytes(pathAbsolute);
                return byteImage;
            });
        }
        #endregion
    }
}
