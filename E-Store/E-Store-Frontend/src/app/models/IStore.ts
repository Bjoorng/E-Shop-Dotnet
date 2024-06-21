import { Guid } from "guid-typescript";
import { IProductGetAllResponse } from "./IProduct";

export interface IStoreIdRequest {
  id: Guid;
}

export interface IStoreUpdateRequest {
  id: Guid;
  name: String;
}

export interface IStoreGetAllResponse {
  id: Guid;
  name: string;
}

export interface IStoreByIdResponse {
  id:Guid;
  name: string;
  userId: Guid;
  products: Array<IProductGetAllResponse>;
}

export interface IStoreUpdateResponse {
  id: Guid;
  name: string;
}
