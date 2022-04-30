using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            IEnumerable<Departamentos> datosDept = from d in _contexto.Departamentos
                                                   select d;
            List<SelectListItem> ComboDeptValores = new List<SelectListItem>();
            foreach (Departamentos dept in datosDept)
            {
                SelectListItem miOpcion = new SelectListItem
                {
                    Text = dept.NOMBRE,
                    Value = dept.ID.ToString()
                };
                ComboDeptValores.Add(miOpcion);
            }

            IEnumerable<Generos> datosGenero = from g in _contexto.Generos
                                               select g;
            List<SelectListItem> ComboGenValores = new List<SelectListItem>();
            foreach (Generos gen in datosGenero)
            {
                SelectListItem miOpcion = new SelectListItem
                {
                    Text = gen.NOMBRE,
                    Value = gen.ID.ToString()
                };
                ComboGenValores.Add(miOpcion);
            }

            ViewBag.ComboDeptValores = ComboDeptValores;
            ViewBag.ComboGenValores = ComboGenValores;

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

            IEnumerable<CasosReportados> ie = from c in _contexto.CasosReportados select c;


            return View(lista);
        }
        public IActionResult guardarRegistro(string DepartamentoSeleccionado, string GeneroSeleccionado, string Conf, string Recup, string Falle)
        {
            CasosReportados nuevoRegistro = new CasosReportados();
            nuevoRegistro.ID_DEPARTAMENTOS = Int32.Parse(DepartamentoSeleccionado);
            nuevoRegistro.ID_GENEROS = Int32.Parse(GeneroSeleccionado);
            nuevoRegistro.CONFIRMADOS = Int32.Parse(Conf);
            nuevoRegistro.RECUPERADOS = Int32.Parse(Recup);
            nuevoRegistro.FALLECIDOS = Int32.Parse(Falle);

            _contexto.CasosReportados.Add(nuevoRegistro);
            _contexto.SaveChanges();

            IEnumerable<Departamentos> datosDept = from d in _contexto.Departamentos
                                                   select d;
            List<SelectListItem> ComboDeptValores = new List<SelectListItem>();
            foreach (Departamentos dept in datosDept)
            {
                SelectListItem miOpcion = new SelectListItem
                {
                    Text = dept.NOMBRE,
                    Value = dept.ID.ToString()
                };
                ComboDeptValores.Add(miOpcion);
            }

            IEnumerable<Generos> datosGenero = from g in _contexto.Generos
                                               select g;
            List<SelectListItem> ComboGenValores = new List<SelectListItem>();
            foreach (Generos gen in datosGenero)
            {
                SelectListItem miOpcion = new SelectListItem
                {
                    Text = gen.NOMBRE,
                    Value = gen.ID.ToString()
                };
                ComboGenValores.Add(miOpcion);
            }

            ViewBag.ComboDeptValores = ComboDeptValores;
            ViewBag.ComboGenValores = ComboGenValores;

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
            return View(lista);
        }


    }
}
