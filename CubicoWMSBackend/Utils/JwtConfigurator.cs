﻿using ControlNetBackend.DTO;
using CubicoWMSBackend.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CubicoWMSBackend.Utils
{
    public class JwtConfigurator
    {
        public static string GetToken(LoginDTO userinfo, IConfiguration config)
        {
            string SecretKey = config["Jwt:SecretKey"];
            string Issuer = config["Jwt:Issuer"];
            string Audience = config["Jwt:Audience"];
            var securityKeys = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credential = new SigningCredentials(securityKeys, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userinfo.NOM_USUARIO),
                new Claim("idUsuario",userinfo.ID_USER.ToString()),
                new Claim("Usuario",userinfo.usuario),
                new Claim("Sede",userinfo.DES_CENTRO_COSTO),
                new Claim("Respuesta",userinfo.RESPUESTA.ToString()),
                new Claim("Message",userinfo.MENSAJE)
            };

            var token = new JwtSecurityToken
            (   
                issuer:Issuer,
                audience: Audience,
                claims,
                expires:DateTime.Now.AddMinutes(60),
                signingCredentials:credential

            );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static int GetTokenIdUsuario(ClaimsIdentity identity)
        {
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                foreach( var claim in claims)
                {
                    if (claim.Type == "idUsuario")
                    {
                        return int.Parse(claim.Value);
                    }
                }

            }
            return 0;
        }

    }
}