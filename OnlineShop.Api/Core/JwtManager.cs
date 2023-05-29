using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OnlineShop.Application.Requests.User;
using OnlineShop.DataAccess;
using OnlineShop.Implementation.Validators.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineShop.Api.Core
{
    public class JwtManager
    {
        private readonly OnlineShopContext _context;

        public JwtManager(OnlineShopContext context)
        {
            _context = context;
        }

        public string MakeToken(string username, string password)
        {
            var user = _context.Users.Include(x => x.UserUseCases)
                .FirstOrDefault(x => x.UserName == username && x.Password == password);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            //var useCases = _context.UserUseCase.Where(x => x.UserId == user.UserId).Select(x => x.UseCaseId);

            var actor = new JwtActor
            {
                Id = user.Id,
                AllowedUseCases = user.UserUseCases.Select(x => x.IdUseCase).ToList(),
                Identity = user.UserName,
                Username = user.UserName
            };

            var issuer = "AspIspit";
            var secret = "123ASDjfipoawopriqwop123124";

            var claims = new List<Claim> // Jti : "",
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("UseCases", JsonConvert.SerializeObject(actor.AllowedUseCases)),
                new Claim("Username", user.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(10000),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
