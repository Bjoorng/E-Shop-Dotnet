import { Guid } from 'guid-typescript';

export interface ILoginRequest {
  username: string;
  password: string;
}

export interface ILoginResponse {
  id: Guid;
  username: string;
  role: string;
}

export interface ISessionUser {
  id: Guid;
  username: string;
  role: string;
}
