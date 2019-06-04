import {IBaseEntity} from "./IBaseEntity";
import {ILocation} from "./ILocation";
import {IRegistration} from "./IRegistration";

export interface ICompetition extends IBaseEntity{
  title: string,
  comment: string,
  start: Date,
  end: Date,
  locationId: number,
  location: ILocation,
  registration: IRegistration[]
}
