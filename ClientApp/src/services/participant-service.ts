import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IParticipant} from "../interfaces/IParticipant";



export var log = LogManager.getLogger('ParticipantService');

@autoinject
export class ParticipantService extends BaseService<IParticipant> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Participants');
  }

}
