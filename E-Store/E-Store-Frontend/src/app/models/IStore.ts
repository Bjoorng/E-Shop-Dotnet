import { Guid } from "guid-typescript";
import { IProductGetAllResponse } from "./IProduct";

export interface IStoreIdRequest {
  Id: Guid;
}

export interface IStoreUpdateRequest {
  Id: Guid;
  Name: String;
}

export interface IStoreGetAllResponse {
  Id: Guid;
  Name: string;
}

export interface IStoreByIdResponse {
  Id:Guid;
  Name: string;
  UserId: Guid;
  Products: Array<IProductGetAllResponse>;
}

export interface IStoreUpdateResponse {
  Id: Guid;
  Name: string;
}
