using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2_2019AM606_2019LD601.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_2019AM606_2019LD601.Controllers
{
    public class registroController : Controller
    { 
     private readonly dbContext _contexto;

    public registroController( dbContext context)
    {
        this._contexto = context;
    }

    
        public ActionResult Index()
        {


            var lista = from m in _contexto.CasosReportados
                        join d in _contexto.Departamentos on m.ID_DEPARTAMENTOS equals d.ID
                        join g in _contexto.Generos on m.ID_GENEROS equals g.ID
                        select new CasosReportados
                        {
                            ID_CASOS_REPORTADOS = m.ID_CASOS_REPORTADOS,
                            CONFIRMADOS = m.CONFIRMADOS,
                            NOMBRE = d.NOMBRE,
                            NOMBRE_DEP = g.NOMBRE,
                            FALLECIDOS = m.FALLECIDOS,
                            RECUPERADOS = m.RECUPERADOS
                        };
 
            IEnumerable <CasosReportados> ie = from c in _contexto.CasosReportados select c;


            return View(lista);
        }
    }
}
