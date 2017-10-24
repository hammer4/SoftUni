export interface IMessage {
  name?: string;
  message?: string;
  displayed?: boolean;
}

export interface ICoreState {
  message: string;
  errors: IMessage[];
}

export const initialState: ICoreState = {
  message: null,
  errors: []
};
