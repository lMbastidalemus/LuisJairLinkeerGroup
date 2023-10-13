using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/empleado")]
    public class EmpleadoController : ApiController
    {
        [Route("")]
        [HttpGet]
SLMetodos_Id_Add
        public IHttpActionResult GetById(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(IdEmpleado);

        public IHttpActionResult GetAll(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.GetAll();
 master
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

 SLMetodos_Id_Add
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);

        [Route("{IdEmpleado?}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(IdEmpleado);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("IdEmpleado?")]
        [HttpPut]
        public IHttpActionResult Update(int IdEmpleado, [FromBody] ML.Empleado empleado)
        {
            empleado.IdEmpleado = IdEmpleado;
            ML.Result result = BL.Empleado.Update(empleado);

master
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
