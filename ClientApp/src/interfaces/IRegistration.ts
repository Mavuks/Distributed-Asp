import {IBaseEntity} from "./IBaseEntity";
import {IBreed} from "./IBreed";
import {IDog} from "./IDog";
import {IParticipant} from "./IParticipant";
import {ICompetition} from "./ICompetition";
import {IShow} from "./IShow";
import {ISchooling} from "./ISchooling";

export interface IRegistration extends IBaseEntity{
  title: string,
  comment: string,
  dogId: number,
  dog: IDog,
  participantId: number,
  participant: IParticipant,
  competitionId: number,
  competition: ICompetition,
  showId: number,
  show: IShow,
  schoolingId: number,
  schooling: ISchooling
}
