export class Employee {
  constructor(
    public employeeNumber: number,
    public lastName: string,
    public firstName: string,
    public extension: string,
    public email: string,
    public officeCode: string,
    public reportsTo: number,
    public jobTitle: string,
    public officeCodeNavigation: string,
    public reportsToNavigation: Employee,
    public customers: any[],
    public inverseReportsToNavigation: any[],
  ) {
  }
}
