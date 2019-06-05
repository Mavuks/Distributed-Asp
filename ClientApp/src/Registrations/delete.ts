import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IRegistration} from "../interfaces/IRegistration";
import {RegistrationService} from "../services/registration-service";



export var log = LogManager.getLogger('Participants.Delete');

@autoinject
export class Delete {

  private registration: IRegistration;
  
  constructor(
    private router: Router,
    private registrationsService: RegistrationService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.registrationsService.delete(this.registration.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("registrationsIndex");
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
    this.registrationsService.fetch(params.id).then(
      registration=> {
        log.debug('registration', registration);
        this.registration = registration;
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
