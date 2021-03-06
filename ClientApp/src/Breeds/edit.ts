import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {BreedsService} from "../services/breed-service";
import {IBreed} from "../interfaces/IBreed";

export var log = LogManager.getLogger('Breeds.Edit');

@autoinject
export class Edit {

  private breed : IBreed | null = null;
  
  constructor(
    private router: Router,
    private BreedsService: BreedsService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('breed', this.breed);
    this.BreedsService.put(this.breed!).then(
      response => {
        if (response.status == 204){
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
    log.debug('activate', params);

    this.BreedsService.fetch(params.id).then(
      breed => {
        log.debug('breed', breed);
        this.breed = breed;
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
