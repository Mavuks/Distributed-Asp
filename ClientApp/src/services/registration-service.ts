import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IRegistration} from "../interfaces/IRegistration";


export var log = LogManager.getLogger('RegistraionsService');

@autoinject
export class RegistrationService extends BaseService<IRegistration> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Registrations');
  }

}
