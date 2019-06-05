import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IRegistration} from "../interfaces/IRegistration";
import {RegistrationService} from "../services/registration-service";

export var log = LogManager.getLogger('Participant.Edit');

@autoinject
export class Edit {

  private registration : IRegistration | null = null;

  constructor(
    private router: Router,
    private registrationService: RegistrationService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('registration', this.registration);
    this.registrationService.put(this.registration!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("registrationsIndex");
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

    this.registrationService.fetch(params.id).then(
      registration => {
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
