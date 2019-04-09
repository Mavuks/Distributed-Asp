import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {MaterialsService} from "../services/material-service";
import {IMaterial} from "../interfaces/Imaterial";

export var log = LogManager.getLogger('Materials.Edit');

@autoinject
export class Edit {

  private material : IMaterial | null = null;
  
  constructor(
    private router: Router,
    private materialsService: MaterialsService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('material', this.material);
    this.materialsService.put(this.material!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("materialsIndex");
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

    this.materialsService.fetch(params.id).then(
      material => {
        log.debug('material', material);
        this.material = material;
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
