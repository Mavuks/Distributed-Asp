import {IBaseEntity} from "./IBaseEntity";
import {IMaterial} from "./IMaterial";
import {IRegistration} from "./IRegistration";

export interface ISchooling extends IBaseEntity{
  schoolingName: string,
  start: Date,
  materialId: number,
  material: IMaterial,
  registration: IRegistration[]
  
  
}
