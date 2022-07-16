﻿using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wordle;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
       
        public static JuegoWordle Juego { get; set; }

        // GET: Wordle
        public ActionResult Index()
        {
            return View(new WordleGame());
        }

        [HttpPost]
        public ActionResult Game(string nombre, int errors, int difficulty)
        {
            JuegoWordle juegowordle = new JuegoWordle(nombre, errors, difficulty);

            WordleGame juego = new WordleGame
            {
                Nombre = juegowordle.nombre,
                ErroresPosibles = juegowordle.maxIntentos,
                Dificultad = juegowordle.dificultad,
                Palabra = juegowordle.palabra,
                PalabrasIntentadas = juegowordle.palabrasIntentadas,
            };

            return View(juego);
        }

        [Route("Game")]
        public ActionResult Game(WordleGame gameModel)
        {
            return View(gameModel);
        }
        
    }
}
