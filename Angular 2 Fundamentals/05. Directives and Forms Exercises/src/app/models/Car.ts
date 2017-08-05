export class Car {
  constructor (
    public id: number,
    public image: string,
    public make: string,
    public model: string,
    public description: string,
    public owner: number,
    public price: number,
    public engine: string,
    public date: string,
    public ownerName: string,
    public comments: Array<{}>
  ) {}
}