﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;


namespace SistemaVendas.Controllers
{
    public class VendaController : Controller
    {
        private IHttpContextAccessor httpContext; 
        //recebe o contexto HTTP via injeçao de dependencia
        public VendaController(IHttpContextAccessor HttpContextAcessor)
        {
            httpContext = HttpContextAcessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ListaVendas = new VendaModel().ListagemVendas();
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            CarregarDados();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(VendaModel venda)
        {
            //captura o id do vendedor logado no sistema 
            venda.Vendedor_Id = httpContext.HttpContext.Session.GetString("IdUsuarioLogado");
            venda.Inserir();
            CarregarDados();
            return View();
        }
        private void CarregarDados()
        {
            ViewBag.ListaClientes = new VendaModel().RetornarListaCLientes();
            ViewBag.ListaVendedores = new VendaModel().RetornarListaVendedores();
            ViewBag.ListaProdutos = new VendaModel().RetornarListaProdutos();
        }
    }
}
