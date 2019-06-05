import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IShow} from "../interfaces/IShow";
import {ShowService} from "../services/show-service";

export var log = LogManager.getLogger('Show.Index');

// automatically inject dependencies declared as private constructor parameters
// will be accessible as this.<variablename> in class
@autoinject
export class Index {

  private show: IShow[] = [];

  constructor(
    private showsService: ShowService
  ) {
    log.debug('constructor');
  }

  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
    this.showsService.fetchAll("").then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.show = jsonData;
      }
    );
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
