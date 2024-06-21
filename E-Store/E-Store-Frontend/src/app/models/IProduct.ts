import { Guid } from "guid-typescript";

export interface IProductIdRequest{
  id: Guid;
}

export interface IProductCreateRequest{
  id: Guid;
  name: string;
  summary: string;
  quantity: number;
  price: number;
  category: string;
}

export interface IProductUpdateRequest{
  id: Guid;
  name: string;
  summary: string;
  description: string;
  quantity: number;
  price: number;
  category: string;
}

export interface IProductGetAllResponse{
  id: Guid;
  name: string;
  summary: string;
  quantity: number;
  price: number;
  category: string;
  storeId: Guid;
}

export interface IProductIdResponse{
  id: Guid;
  name: string;
  summary: string;
  description?: string;
  quantity: number;
  price: number;
  category: string;
  storeId: Guid;
}



