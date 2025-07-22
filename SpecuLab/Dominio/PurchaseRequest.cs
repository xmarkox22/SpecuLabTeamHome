using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PurchaseRequest
    {
        public Guid PurchaseRequestId { get; set; }
        public Guid PropertyId { get; set; }
        public DateTime PurchaseRequestDate { get; set; }
        public RequestStatus PurchaseRequestStatus { get; set; }
    }
}
