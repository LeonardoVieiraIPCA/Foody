﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Foody.Models;
using Foody.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foody.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class LoginController : ControllerBase
    {
        // POST api/<LoginController>
        [HttpPost]
        public IDictionary<string, string> Post([FromBody] Utilizador utilizador)
        {
            using (var db = new DbHelper())
            {
                var utilizadores = db.utilizadores.ToArray();

                for (int i = 0; i < utilizadores.Length; i++)
                {
                    if (utilizador.email == utilizadores[i].email &&
                        HashPassword.VerifyHash(utilizador.palavraPasse, utilizadores[i].palavraPasse))
                    {
                        Dictionary<string, string> token = new Dictionary<string, string> 
                        {
                            {"Token", TokenManager.GenerateToken(utilizador.email)},
                        };

                        return token;
                    }
                }

                return null;
            }
        }
        // ou

        /*
        [HttpPost]
        public string Post([FromBody] Utilizador utilizador)
        {
            using (var db = new DbHelper())
            {
                cavalo.cod_cavaço = new Random().Next();
                db.utilizadores.Add(utilizador);
                db.SaveChanges();
            }
        }
         */
    }
}
