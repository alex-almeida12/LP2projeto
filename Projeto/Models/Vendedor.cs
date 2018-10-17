using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Aniversario { get; set; }
        public double Salario { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime aniversario, double salario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aniversario = aniversario;
            Salario = salario;
            Departamento = departamento;
        }

        public void AddVendas(Venda venda)
        {
            Vendas.Add(venda);
        }

        public void DelVendas ( Venda venda)
        {
            Vendas.Remove(venda);
        }

        public double TotalVendas ( DateTime Inicial , DateTime Final)
        {
            return Vendas.Where(venda => venda.Data >= Inicial && venda.Data <= Final).Sum(venda => venda.Valor);
        }
    }
}
