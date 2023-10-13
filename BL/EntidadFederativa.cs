using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EntidadFederativa
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.LJLeenkedGroupEntities context = new DL.LJLeenkedGroupEntities())
                {
                    var query = (from CatEntidadFederativa in context.CatEntidadFederativas
                                 select new
                                 {
                                     IdEstado = CatEntidadFederativa.IdEstado,
                                     Estado = CatEntidadFederativa.Estado
                                 }
                    );
                    
                    result.Objects = new List<object>();

                    if(query != null && query.ToList().Count > 0)
                    {
                        foreach (var item in query)
                        {
                            ML.EntidadFederativa entidad = new ML.EntidadFederativa();
                            entidad.IdEstado = item.IdEstado;
                            entidad.Estado = item.Estado;

                            result.Objects.Add(entidad);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
