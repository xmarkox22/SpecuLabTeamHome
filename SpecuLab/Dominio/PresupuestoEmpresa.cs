using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    /// <summary>
    /// Presupuesto de Empresa
    /// </summary>
    public class PresupuestoEmpresa
    {
        public Guid Id { get; set; }
        public double TotalBudget { get; set; } 
        public DateTime LastActualization { get; set; } = DateTime.UtcNow;


        // La siguiente opción es buena para listar las transacciones hechas, una especie de historial

        public List<TransaccionPresupuesto> Historico { get; set; } = new();
    }
}
