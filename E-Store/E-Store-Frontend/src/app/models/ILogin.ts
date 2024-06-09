export interface ILoginRequest {
  username: string;
  password: string;
}
export interface ILoginResponse {
  username: string;
  role: string;

}
export interface ISessionUser {
  username: string;
  role: string;
}
