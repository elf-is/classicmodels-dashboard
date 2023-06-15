export class DataTablesResponse {
  constructor(
    public data: any[],
    public draw: number,
    public recordsFiltered: number,
    public recordsTotal: number,
  ) {
  }
}
