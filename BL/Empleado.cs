using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LJLeenkedGroupEntities context = new DL.LJLeenkedGroupEntities())
                {

                    var query = (from Empleado in context.Empleadoes
                                 join CatEntidadFederativa in context.Empleadoes on Empleado.IdEstado equals CatEntidadFederativa.IdEstado
                                 select new
                                 {
                                     IdEmpleado = Empleado.IdEmpleado,
                                     NombreNomina = Empleado.NombreNomina,
                                     Nombre = Empleado.Nombre,
                                     ApellidoPaterno = Empleado.ApellidoPaterno,
                                     ApellidoMaterno = Empleado.ApellidoMaterno,
                                     IdEstado = Empleado.IdEstado,
                                     Estado = Empleado.CatEntidadFederativa.Estado
                                 });

                    result.Objects = new List<object>();



                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var item in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = item.IdEmpleado;
                            empleado.NombreNomina = item.NombreNomina;
                            empleado.Nombre = item.Nombre;
                            empleado.ApellidoPaterno = item.ApellidoPaterno;
                            empleado.ApellidoMaterno = item.ApellidoMaterno;
                            empleado.Entidad = new ML.EntidadFederativa();
                            empleado.Entidad.IdEstado = item.IdEstado.Value;
                            empleado.Entidad.Estado = item.Estado;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al mostrar los datos";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LJLeenkedGroupEntities context = new DL.LJLeenkedGroupEntities())
                {

                    var query = (from Empleado in context.Empleadoes
                                 join CatEntidadFederativa in context.Empleadoes on Empleado.IdEstado equals CatEntidadFederativa.IdEstado
                                 where Empleado.IdEstado == IdEmpleado
                                 select new
                                 {
                                     IdEmpleado = Empleado.IdEmpleado,
                                     NombreNomina = Empleado.NombreNomina,
                                     Nombre = Empleado.Nombre,
                                     ApellidoPaterno = Empleado.ApellidoPaterno,
                                     ApellidoMaterno = Empleado.ApellidoMaterno,
                                     IdEstado = Empleado.IdEstado,
                                     Estado = Empleado.CatEntidadFederativa.Estado
                                 }).First();

                    if (query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.NombreNomina = query.NombreNomina;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;
                        empleado.Entidad = new ML.EntidadFederativa();
                        empleado.Entidad.IdEstado = query.IdEstado.Value;
                        empleado.Entidad.Estado = query.Estado;
                        result.Object = empleado;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al mostrar los datos";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LJLeenkedGroupEntities context = new DL.LJLeenkedGroupEntities())
                {

                    DL.Empleado empleadoResult = new DL.Empleado();
                    empleadoResult.NombreNomina = empleado.NombreNomina;
                    empleadoResult.Nombre = empleado.Nombre;
                    empleadoResult.ApellidoPaterno = empleado.ApellidoPaterno;
                    empleadoResult.ApellidoMaterno = empleado.ApellidoMaterno;
                    empleadoResult.IdEstado = empleado.Entidad.IdEstado;
                    context.Empleadoes.Add(empleadoResult);
                    int filasAfectadas = context.SaveChanges();


                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se agrego el empleado";
                    }
                }
            }


            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LJLeenkedGroupEntities context = new DL.LJLeenkedGroupEntities())
                {


                    var query = (from Empleado in context.Empleadoes
                                 where Empleado.IdEmpleado == IdEmpleado
                                 select Empleado).Single();
                    context.Empleadoes.Remove(query);
                    int filasAfectadas = context.SaveChanges();

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar el empleado";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LJLeenkedGroupEntities context = new DL.LJLeenkedGroupEntities())
                {

                    var query = (from Empleado in context.Empleadoes
                                 where Empleado.IdEmpleado == empleado.IdEmpleado
                                 select Empleado).Single();
                    if (query != null)
                    {
                        query.NombreNomina = empleado.NombreNomina;
                        query.Nombre = empleado.Nombre;
                        query.ApellidoPaterno = empleado.ApellidoPaterno;
                        query.ApellidoMaterno = empleado.ApellidoMaterno;
                        query.IdEstado = empleado.Entidad.IdEstado;
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo el empleado";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
