import { Guid } from "guid-typescript";

export interface IProductIdRequest{
  Id: Guid;
}

export interface IProductCreateRequest{
  Id: Guid;
  Name: string;
  Summary: string;
  Quantity: number;
  Price: number;
  Category: string;
}

export interface IProductUpdateRequest{
  Id: Guid;
  Name: string;
  Summary: string;
  Description: string;
  Quantity: number;
  Price: number;
  Category: string;
}

export interface IProductGetAllResponse{
  Id: Guid;
  Name: string;
  Summary: string;
  Quantity: number;
  Price: number;
  Category: string;
  StoreId: Guid;
}

export interface IProductIdResponse{
  Id: Guid;
  Name: string;
  Summary: string;
  Description?: string;
  Quantity: number;
  Price: number;
  Category: string;
  StoreId: Guid;
}



