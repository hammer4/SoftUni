export class RegisterUserModel {
  constructor(
    public name?: string,
    public email?: string,
    public password?: string,
    public confirmPassword?: string
  ) { }
}