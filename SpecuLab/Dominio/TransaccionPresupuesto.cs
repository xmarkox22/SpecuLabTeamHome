using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TransaccionPresupuesto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public double Amount { get; set; }
        public string Concept { get; set; } = string.Empty; // Ej: "Compra vivienda", "Mantenimiento", etc.
        public TransactionType Tipo { get; set; }
        public string? OrigenSolicitud { get; set; } = string.Empty; // "compras", "mantenimiento", "alquileres"
    }

    public enum TransactionType
    {
        Expenses,
        Incomes
    }

}
