using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace singleton_apirest.Controllers
{
    [ApiController]
    [Route("server")]
    public class server : ControllerBase
    {
        [HttpGet][Route("hello")]
        public dynamic hello()
        {
            return new
            {
                msg = Singleton.Instance.mensaje
            };
        }
        [HttpGet]
        [Route("time")]
        public dynamic time()
        {
            return new
            {
                datetime = Singleton.time
            };
        }
        [HttpPost]
        [Route("dirlist")]
        public dynamic dirlist([FromBody] string dirpath)
        {
            try
            {
                return new
                {
                    files = Singleton.dirlist(dirpath)
                };
            }
            catch (Exception e)
            {
                return new
                {
                    msg = e
                };
            }
        }
        [HttpGet]
        [Route("index")]
        public ContentResult index()
        {
            var html = System.IO.File.ReadAllText(@"./assets/index.html");
            html = html.Replace("{{saludo}}", Singleton.Instance.mensaje);
            html = html.Replace("{{fecha}}", Singleton.time);
            return base.Content(html, "text/html");
        }
    }
}
