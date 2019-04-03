import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IBreed} from "../interfaces/IBreed";
import {BreedsService} from "../services/breed-service";

export var log = LogManager.getLogger('Breeds.Create');

@autoinject
export class Create {

  private breed: IBreed;
  
  constructor(
    private router: Router,
    private breedsService: BreedsService
  ) {
    log.debug('constructor');
  }
  
  // ============ View methods ==============
  submit():void{
    log.debug('breed', this.breed);
    this.breedsService.post(this.breed).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("breedsIndex");
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
