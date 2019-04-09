import {IBaseEntity} from "./IBaseEntity";

export interface IMaterial extends IBaseEntity{
  MaterialName: string;
  MaterialCount: number;
}
