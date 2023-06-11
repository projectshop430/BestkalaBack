﻿using BestKalas.Services.Interface;
using Domain.Entitis.user;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BestKalas.Services.Implemention
{
    public class TokenServices : ITokenServices
    {
        private readonly SymmetricSecurityKey _key;

        

        public TokenServices(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokenkey"]));
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
           {
               new Claim(JwtRegisteredClaimNames.NameId, user.Username),
           };
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokendesciptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = cred,

            };
            var tokenhander = new JwtSecurityTokenHandler();
            var token = tokenhander.CreateToken(tokendesciptor);
            return tokenhander.WriteToken(token);
        }
    }
}
