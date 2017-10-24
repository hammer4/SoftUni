export interface IStatsState {
  users: number,
  articles: number
}

export const initialState: IStatsState = {
  users: 0,
  articles: 0
}