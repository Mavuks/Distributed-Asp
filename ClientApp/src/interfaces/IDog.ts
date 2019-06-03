import {IBaseEntity} from "./IBaseEntity";
import DateTimeFormat = Intl.DateTimeFormat;
import {IBreed} from "./IBreed";
import {IAppUser} from "./IAppUser";
import {IRegistration} from "./IRegistration";

export interface IDog extends IBaseEntity{
  DogName: string,
  DateOfBirth: Date,
  DateOfDeath: Date,
  Sex: string,
  BreedId: number,
  Breed: IBreed,
  Owner: string,
  appUserId: number,
  appUser: IAppUser,
  registrations: IRegistration[]
}
