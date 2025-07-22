using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Clase base para cualquier petición de mantenimiento
public abstract class mantenimientoRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime FechaSolicitud { get; set; } = DateTime.Now;
    public string RequestedBy { get; set; }
    public string RequestType { get; set; } //Reforma, mantenimiento, reparación
}

public class RenovationRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid MaintenanceRequestId { get; set; }
    public string RenovationDescrption { get; set; }
    public double Amount { get; set; }


}

public class AnnualMaintenanceRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid MaintenanceRequestId { get; set; }
    public Guid AnnualMaintenanceRequestId { get; set; }
    public double Amount { get; set; }
}

public class RepairRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid MaintenanceRequestId { get; set; }
    public double Amount { get; set; }
    public required string ItemToRepair { get; set; }
    public string ProblemDescription { get; set; }
    // public bool Reparado { get; set; }


}



