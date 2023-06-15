import {Customer} from "./customer";

export class Payment {
  constructor(
    public customerNumber: number,
    public checkNumber: string,
    public paymentDate: string,
    public amount: number,
    public customerNumberNavigation: Customer,
  ) {
  }
}
