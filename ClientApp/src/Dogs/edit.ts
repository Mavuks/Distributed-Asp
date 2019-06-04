import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {DogsService} from "../services/dog-service";
import {IDog} from "../interfaces/iDog";

export var log = LogManager.getLogger('Dogs.Edit');

@autoinject
export class Edit {

  private dog : IDog | null = null;
  
  constructor(
    private router: Router,
    private DogsService: DogsService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('dog', this.dog);
    this.DogsService.put(this.dog!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("dogsIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    );
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

    this.DogsService.fetch(params.id).then(
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
