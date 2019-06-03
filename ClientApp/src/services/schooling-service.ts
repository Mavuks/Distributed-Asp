import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {ISchooling} from "../interfaces/ISchooling";


export var log = LogManager.getLogger('SchoolingsService');

@autoinject
export class SchoolingService extends BaseService<ISchooling> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Schoolings');
  }

}
