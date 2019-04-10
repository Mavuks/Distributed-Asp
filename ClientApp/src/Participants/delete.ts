import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IParticipant} from "../interfaces/IParticipant";
import {ParticipantService} from "../services/participant-service";



export var log = LogManager.getLogger('Participants.Delete');

@autoinject
export class Delete {

  private participant: IParticipant;
  
  constructor(
    private router: Router,
    private participantsService: ParticipantService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.participantsService.delete(this.participant.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("participantsIndex");
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
    this.participantsService.fetch(params.id).then(
      participant=> {
        log.debug('material', participant);
        this.participant = participant;
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
