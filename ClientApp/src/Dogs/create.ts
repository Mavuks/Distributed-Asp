import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IDog} from "../interfaces/IDog";
import {DogsService} from "../services/dog-service";

export var log = LogManager.getLogger('Dogs.Create');

@autoinject
export class Create {

  private dog: IDog;
  
  constructor(
    private router: Router,
    private dogsService: DogsService
  ) {
    log.debug('constructor');
  }
  
  // ============ View methods ==============
  submit():void{
    log.debug('dog', this.dog);
    this.dogsService.post(this.dog).then(
      response => {
        if (response.status == 201){
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
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
