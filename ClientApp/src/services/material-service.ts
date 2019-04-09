import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IMaterial} from "../interfaces/IMaterial";


export var log = LogManager.getLogger('MaterialsService');

@autoinject
export class MaterialsService extends BaseService<IMaterial> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Materials');
  }

}
