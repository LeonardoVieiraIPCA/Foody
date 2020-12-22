﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foody.Models;
using Foody.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foody.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class AdministradoresController : ControllerBase
    {
        // GET: api/<AdministradoresController>
        [HttpGet]
        public Administrador[] Get()
        {
            using (var db = new DbHelper())
            {
                return db.administradores.ToArray();
            }
        }

        // GET api/<AdministradoresController>/5
        [HttpGet("{idAdministrador}/{idCavalo}")]
         public Administrador Get(int id)
        {
            using (var db = new DbHelper())
            {
                return db.administradores.Find(id);
            }
        }
         

        // POST api/<AdministradoresController>
        [HttpPost]
        public string Post([FromBody] Administrador novoAdministrador)
        {
            using (var db = new DbHelper())
            {
                var administradores = db.administradores.ToArray();

                for (int i = 0; i < administradores.Length; i++)
                {
                    if (novoAdministrador.idAdministrador == administradores[i].idAdministrador)
                    {
                        return "Já existe";
                    }
                }

                db.administradores.Add(novoAdministrador);
                db.SaveChanges();

                return "Criado";
            }

        }
        // ou

        /*
        [HttpPost]
        public string Post([FromBody] Administrador novoAdministrador)
        {
            using (var db = new DbHelper())
            {
                Administrador.cod_cavaço = new Random().Next();
                db.administradores.Add(novoAdministrador);
                db.SaveChanges();
            }
        }
         */

        // PUT api/<AdministradoresController>/5
        [HttpPut("{idAdministrador}/{idCavalo}")]
        public void Put(int idAdministrador, [FromBody] Administrador administradorUpdate)
        {
            using (var db = new DbHelper())
            {
                var administradorDB = db.administradores.Find(idAdministrador);

                if (administradorDB == null)
                {
                    Post(administradorUpdate);
                }

                else
                {
                    administradorDB.idAdministrador = idAdministrador;

                    db.administradores.Update(administradorDB);
                    db.SaveChanges();
                }
            }

        }

        // DELETE api/<AdministradoresController>/5
        [HttpDelete("{idAdministrador}/{idCavalo}")]
        public string Delete(int idAdministrador, int idCavalo)
        {
            using (var db = new DbHelper())
            {
                var administradorDB = db.administradores.Find(idAdministrador, idCavalo);

                if (administradorDB != null)
                {
                    db.administradores.Remove(administradorDB);
                    db.SaveChanges();

                    return "Eliminado!";
                }
                else
                {
                    return "O Administrador com o id de prova: " + idAdministrador + 
                        " e o Cavalo com o id: " + idCavalo + " não foi encontrado";
                }
            }
        }
    }
}