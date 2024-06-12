import { Guid } from "guid-typescript";

export interface ILoginRequest {
  Username: string;
  Password: string;
}
export interface ILoginResponse {
  Id: Guid;
  Username: string;
  Role: string;

}
export interface ISessionUser {
  Username: string;
  Role: string;
}
