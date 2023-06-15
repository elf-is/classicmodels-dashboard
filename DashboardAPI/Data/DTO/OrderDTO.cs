namespace Dashboard.Data.DTO;

public class OrderDTO
{
    public int OrderNumber { get; set; }
    public DateOnly OrderDate { get; set; }
    public DateOnly RequiredDate { get; set; }
    public DateOnly? ShippedDate { get; set; }
    public string Status { get; set; } = null!;
}