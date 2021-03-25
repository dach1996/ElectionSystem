﻿using AutoMapper;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Utils.Mapper.User
{
    public static class UserMapper
    {
        public static void Config(Profile profile)
        {
            //Mapper to User - User Create
            profile.CreateMap<UserCreateRequest, Models.Persitence.User>()
                .ForMember(
                destino => destino.Rol,
                origen => origen.MapFrom(u => (int)u.Role))
                .ForMember(
                destino => destino.RolName,
                origen => origen.MapFrom(u => u.Role.ToString())
                );
            profile.CreateMap<Models.Persitence.User, UserCreateResponse>()
                .ForMember(
                destino => destino.Role,
                origen => origen.MapFrom(u => u.Rol));

            //Mapper to User - User Update

           profile.CreateMap<UserUpdateRequest, Models.Persitence.User>()
              .ForMember(
              destino => destino.Rol,
              origen => origen.MapFrom(u => (int)u.Role))
              .ForMember(
              destino => destino.RolName,
              origen => origen.MapFrom(u => u.Role.ToString())
              );
           profile.CreateMap<Models.Persitence.User, UserUpdateResponse>()
                .ForMember(
                destino => destino.Role,
                origen => origen.MapFrom(u => u.Rol));
        }

    }
}
