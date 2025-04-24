using System;
using System.Collections.Generic;

namespace paymentAPI.Models;

public partial class Paymentdetail
{
    public int PaymentDetailId { get; set; }

    public string? CardOwnerName { get; set; }

    public string? CardNumber { get; set; }

    public string? ExpirationDate { get; set; }

    public string? SecurityCode { get; set; }
}
