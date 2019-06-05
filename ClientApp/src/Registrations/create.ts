import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IRegistration} from "../interfaces/IRegistration";
import {RegistrationService} from "../services/registration-service";



export var log = LogManager.getLogger('Registrations.Create');

@autoinject
export class Create {

  private registration: IRegistration;
  
  constructor(
    private router: Router,
    private registrationsService: RegistrationService
  ) {
    log.debug('constructor');
  }
  
  // ============ View methods ==============
  submit():void{
    log.debug('material', this.registration);
    this.registrationsService.post(this.registration).then(
      response => {
        if (response.status == 201){
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
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
