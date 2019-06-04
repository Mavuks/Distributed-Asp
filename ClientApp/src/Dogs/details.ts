import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {DogsService} from "../services/dog-service";
import {IDog} from "../interfaces/IDog";

export var log = LogManager.getLogger('Dogs.Details');

@autoinject
export class Details {

  private dog: IDog | null = null;

  constructor(
    private router: Router,
    private dogsService: DogsService
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
    log.debug('activate', params);
    this.dogsService.fetch(params.id).then(
      dog => {
        log.debug('dog', dog);
        this.dog = dog;
      }
    );

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
