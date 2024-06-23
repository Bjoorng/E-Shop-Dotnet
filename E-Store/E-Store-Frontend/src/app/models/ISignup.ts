import { Guid } from "guid-typescript";

export interface ISignupRequest {
  email: string;
  username: string;
  password: string;
  role: string;
}

export interface ISignupResponse {
  id: Guid,
}
