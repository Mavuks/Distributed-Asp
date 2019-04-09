import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IMaterial} from "../interfaces/IMaterial";
import {MaterialsService} from "../services/material-service";


export var log = LogManager.getLogger('Materials.Delete');

@autoinject
export class Delete {

  private material: IMaterial;
  
  constructor(
    private router: Router,
    private materialsService: MaterialsService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.materialsService.delete(this.material.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("materialsIndex");
      } else {
        log.debug('response', response);
      }
    });
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
