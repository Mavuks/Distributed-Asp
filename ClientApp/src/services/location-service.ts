import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {ILocation} from "../interfaces/ILocation";


export var log = LogManager.getLogger('LocationsService');

@autoinject
export class LocationService extends BaseService<ILocation> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Locations');
  }

}
