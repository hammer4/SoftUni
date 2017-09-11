export class AddCarModel {
  constructor (
    public make?: string,
    public model?: string,
    public year?: number,
    public engine?: string,
    public price?: number,
    public image?: string,
    public mileage?: number
  ) { }
}
