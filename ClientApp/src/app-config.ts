import {LogManager, autoinject} from "aurelia-framework";
import {IBreed} from "./interfaces/IBreed";

export var log = LogManager.getLogger('AppConfig');

@autoinject
export class AppConfig {
  
  public apiUrl = 'https://localhost:5001/api/v1.0/';
  public jwt: string | null = null;

  constructor() {
    log.debug('constructor');
  }

}
