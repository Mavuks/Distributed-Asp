import {IBaseEntity} from "./IBaseEntity";

export interface IBreed extends IBaseEntity{
  breedName: string;
  breedCount: number;
}
