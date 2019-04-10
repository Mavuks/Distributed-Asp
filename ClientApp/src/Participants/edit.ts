import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IParticipant} from "../interfaces/IParticipant";
import {ParticipantService} from "../services/participant-service";

export var log = LogManager.getLogger('Participant.Edit');

@autoinject
export class Edit {

  private participant : IParticipant | null = null;

  constructor(
    private router: Router,
    private participantService: ParticipantService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('participant', this.participant);
    this.participantService.put(this.participant!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("participantsIndex");
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

    this.participantService.fetch(params.id).then(
      participant => {
        log.debug('participant', participant);
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
