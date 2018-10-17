using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Models;
using Projeto.Models.Enums;

namespace Projeto.Data
{
    public class SeedingService
    {
        private ProjetoContext _context;

        public SeedingService( ProjetoContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Departamento.Any()||
               _context.Venda.Any() ||
               _context.Vendedor.Any())
            {
                return; // Banco de dados já foi populado.
            }

            Departamento d1 = new Departamento(1, "Eletronicos");
            Departamento d2 = new Departamento(2, "Vestuario");
            Departamento d3 = new Departamento(3, "Telefonia");
            Departamento d4 = new Departamento(4, "Livraria");

            Vendedor ven1 = new Vendedor(1, "Alex", "alex@loja.com", new DateTime(1993, 05, 26), 1000.0, d1);
            Vendedor ven2 = new Vendedor(2, "Alan", "alan@loja.com", new DateTime(1994, 04, 24), 1000.0, d2);
            Vendedor ven3 = new Vendedor(3, "Alef", "alef@loja.com", new DateTime(1993, 03, 23), 1000.0, d3);
            Vendedor ven4 = new Vendedor(4, "Airton", "airton@loja.com", new DateTime(1995, 05, 25), 1000.0, d4);

            Venda v1 = new Venda(1, new DateTime(2018, 10, 2), 2.0, VendaStatus.Faturado, ven4);
            Venda v2 = new Venda(2, new DateTime(2018, 10, 2), 2000.0, VendaStatus.Faturado, ven3);
            Venda v3 = new Venda(3, new DateTime(2018, 10, 2), 200.0, VendaStatus.Faturado, ven1);
            Venda v4 = new Venda(4, new DateTime(2018, 10, 2), 20.0, VendaStatus.Faturado, ven2);

            _context.Departamento.AddRange(d1, d2, d3, d4);
            _context.Vendedor.AddRange(ven1, ven2, ven3, ven4);
            _context.Venda.AddRange(v1, v2, v3, v4);

            _context.SaveChanges();
        }
    }
}
