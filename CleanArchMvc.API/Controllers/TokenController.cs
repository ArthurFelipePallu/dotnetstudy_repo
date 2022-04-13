using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArchMvc.API.Models;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;


        public TokenController(IAuthenticate authenticate,IConfiguration configuration)
        {
            _authenticate = authenticate??
                throw new ArgumentNullException(nameof(authenticate));
                _configuration=configuration;
        }
         [HttpPost("CreateUser")]
         [ApiExplorerSettings(IgnoreApi =true)]
       public async Task<ActionResult> CreateUser([FromBody] LoginModel userinfo)
       {
            var result = await _authenticate.RegisterUser(userinfo.Email,userinfo.Password);

            if(result)
            {
                return Ok($"User {userinfo.Email} was created successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty,"Invalid Login attempt");
                return BadRequest(ModelState);
            }

            



       }
       [AllowAnonymous]
       [HttpPost("LoginUser")]
       public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userinfo)
       {
           var result = await _authenticate.Authenticate(userinfo.Email,userinfo.Password);
           if(result)
           {
               return GenerateToken(userinfo);
               //return Ok($"User {userinfo.Email} logged successfully");
           }
           else
           {
               ModelState.AddModelError(string.Empty,"Invalid Login Attempt");
               return BadRequest(ModelState);
           }
       }

        private UserToken GenerateToken(LoginModel userinfo)
        {
            //Declaração do Usuário
            var claims = new[]
            {
                new Claim("email",userinfo.Email), 
                new Claim("meuvalor","o que voce quiser"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            //gerar chave privada para assinar o token
            var privatekey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( _configuration["Jwt:SecretKey"] ));

            //gerar a assinatura digital
            var credential = new SigningCredentials(privatekey, SecurityAlgorithms.HmacSha256);

            //definir tempo de validação do token
            var expiration = DateTime.UtcNow.AddMinutes(5);

            // gerar o token
            JwtSecurityToken token = new JwtSecurityToken(
                //emissor
                issuer:_configuration["Jwt:Issuer"],
                //audiencia
                audience:_configuration["Jwt:Audience"],
                //claims
                claims:claims,
                //data de expiração
                expires:expiration,
                //assinatura digital
                signingCredentials:credential
            );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}