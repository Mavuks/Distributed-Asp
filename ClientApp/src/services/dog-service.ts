import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {IDog} from "../interfaces/IDog";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('DogsService');

@autoinject
export class DogsService extends BaseService<IDog> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Dogs');
  }

}
