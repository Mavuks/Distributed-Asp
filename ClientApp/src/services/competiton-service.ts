import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {ICompetition} from "../interfaces/ICompetition";


export var log = LogManager.getLogger('CompetitionService');

@autoinject
export class CompetitionService extends BaseService<ICompetition> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Competitions');
  }

}
