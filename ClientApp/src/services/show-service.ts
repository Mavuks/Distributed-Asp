import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IShow} from "../interfaces/IShow";


export var log = LogManager.getLogger('ShowService');

@autoinject
export class ShowService extends BaseService<IShow> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Shows');
  }

}
