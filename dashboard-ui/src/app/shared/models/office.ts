import {Employee} from "./employee";

export class Office {
  constructor(
    public officeCode: string,
    public city: string,
    public phone: string,
    public addressLine1: string,
    public addressLine2: string,
    public state: string,
    public country: string,
    public postalCode: string,
    public territory: string,
    public employees: Employee[],
  ) {
  }
}
