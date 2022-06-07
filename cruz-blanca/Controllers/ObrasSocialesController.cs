﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cruz_blanca.Data;
using cruz_blanca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cruz_blanca.Controllers
{
    public class ObrasSocialesController : Controller
    {
        private readonly CruzBlancaDBContext _context; 

        public ObrasSocialesController(CruzBlancaDBContext context)
        {
            this._context = context; 
        }

        public IActionResult Index()
        {
            List<ObraSocial> obrasSociales = this._context.ObrasSociales.ToList();
            return View(obrasSociales);
        }

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            ObraSocial obraSocial = this._context.ObrasSociales.Where(p => p.Id == int.Parse(Id)).FirstOrDefault();
            return View(obraSocial);
        }

        [HttpPost]
        public IActionResult Edit(ObraSocial obraSocial)
        {
            this._context.Attach(obraSocial);
            this._context.Entry(obraSocial).State = EntityState.Modified;
            this._context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
