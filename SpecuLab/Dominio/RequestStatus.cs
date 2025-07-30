namespace Dominio
{

    /// <summary>
    /// Estados de petición:
    /// Received: Recibida
    /// Accepted: Aceptada
    /// Rected: Rechazada
    /// PendingReview: Pendiente de revisión
    /// </summary>
    public class RequestStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
