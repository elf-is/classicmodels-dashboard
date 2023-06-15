export class Order {
  constructor(
    public orderNumber: number,
    public orderDate: string,
    public shippedDate: string | null,
    public requiredDate: string,
    public status: string,
  ) {
  }
}
