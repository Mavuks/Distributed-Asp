import {IBaseEntity} from "./IBaseEntity";

export interface IMaterial extends IBaseEntity{
  materialName: string;
  materialCount: number;
}
