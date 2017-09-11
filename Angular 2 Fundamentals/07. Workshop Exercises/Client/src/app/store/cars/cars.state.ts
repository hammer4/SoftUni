export interface ICarsState {
  carAdded: boolean,
  carAddedId: number,
  allCars: Array<object>,
  carDetails: object,
  carReviews: Array<object>,
  myCars: Array<object>
}

export const initialState: ICarsState = {
  carAdded: false,
  carAddedId: null,
  allCars: [],
  carDetails: {},
  carReviews: [],
  myCars: []
}
