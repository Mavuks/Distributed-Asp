import {IBaseEntity} from "./IBaseEntity";
import {ICompetition} from "./ICompetition";
import {IShow} from "./IShow";

export interface ILocation extends IBaseEntity{
  locations: string;
  competitions: ICompetition[],
  show: IShow[],
}
