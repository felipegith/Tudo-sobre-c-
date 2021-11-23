using application.Database;
using application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace application.Controllers
{
    [Route("api/palavras")]
    [ApiController]
    public class PalavrasController : ControllerBase
    {
        private readonly Context _context;
        public PalavrasController(Context context)
        {
            _context = context;
        }

        [Route("")]
        [HttpGet]
        public ActionResult ObterPalavras(DateTime? data)
        {
            var item = _context.Palavras.AsQueryable();

            if (data.HasValue)
            {
                item = item.Where(a => a.Criado > data.Value);
                
            }
            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult ObterPalavra(int id)
        {
            var obj = _context.Palavras.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [Route("")]
        [HttpPost]
        public ActionResult Cadastrar([FromBody] Palavra palavra)
        {
            _context.Palavras.Add(palavra);
            _context.SaveChanges();
            
            return StatusCode(201, "Cadastro realizado com sucesso!");
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult Atualizar(int id, Palavra palavra)
        {
            var obj = _context.Palavras.AsNoTracking().FirstOrDefault(a=>a.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            palavra.Id = id;
            _context.Palavras.Update(palavra);
            _context.SaveChanges();

            return StatusCode(200, "Atualização realizada com sucesso!");
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult Deletar(int id)
        {
            var obj = _context.Palavras.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _context.Palavras.Remove(_context.Palavras.Find(id));
            _context.SaveChanges();

            return StatusCode(204, "Deleção realizada com sucesso!");
        }
    }
}
