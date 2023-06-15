namespace Dashboard.Data.DTO;

public class CustomerDTO
{
    public int CustomerNumber { get; set; }
    public string CustomerName { get; set; } = null!;
    public string ContactName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public decimal? CreditLimit { get; set; }
}