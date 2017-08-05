export class Owner {
  constructor (
    public id: number,
    public name: string,
    public image: string,
    public carsLength: number,
    public cars: Array<{}>
  ) {}
}