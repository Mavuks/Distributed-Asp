import {IBaseEntity} from "./IBaseEntity";
import {IDog} from "./IDog";

export interface IBreed extends IBaseEntity{
  breedName: string,
  breedCount: number,
  dog: IDog[],
}
