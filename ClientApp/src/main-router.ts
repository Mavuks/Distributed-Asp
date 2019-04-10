import {PLATFORM, LogManager, autoinject} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";
import { AppConfig } from "app-config";

export var log = LogManager.getLogger('MainRouter');

@autoinject
export class MainRouter {
  
  public router: Router;
  
  constructor(private appConfig: AppConfig){
    log.debug('constructor');
  }
  
  configureRouter(config: RouterConfiguration, router: Router):void {
    log.debug('configureRouter');
    
    this.router = router;
    config.title = "Contact App - Aurelia";
    config.map(
      [
        {route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home'), nav: true, title: 'Home'},

        {route: 'identity/login', name: 'identity' + 'Login', moduleId: PLATFORM.moduleName('identity/login'), nav: false, title: 'Login'},
        {route: 'identity/register', name: 'identity' + 'Register', moduleId: PLATFORM.moduleName('identity/register'), nav: false, title: 'Register'},
        {route: 'identity/logout', name: 'identity' + 'Logout', moduleId: PLATFORM.moduleName('identity/logout'), nav: false, title: 'Logout'},


        {route: ['breeds','breeds/index'], name: 'breeds' + 'Index', moduleId: PLATFORM.moduleName('breeds/index'), nav: true, title: 'Breeds'},
        {route: 'breeds/create', name: 'breeds' + 'Create', moduleId: PLATFORM.moduleName('breeds/create'), nav: false, title: 'Breeds Create'},
        {route: 'breeds/edit/:id', name: 'breeds' + 'Edit', moduleId: PLATFORM.moduleName('breeds/edit'), nav: false, title: 'Breeds Edit'},
        {route: 'breeds/delete/:id', name: 'breeds' + 'Delete', moduleId: PLATFORM.moduleName('breeds/delete'), nav: false, title: 'Breeds Delete'},
        {route: 'breeds/details/:id', name: 'breeds' + 'Details', moduleId: PLATFORM.moduleName('breeds/details'), nav: false, title: 'Breeds Details'},

        {route: ['materials','material/index'], name: 'materials' + 'Index', moduleId: PLATFORM.moduleName('materials/index'), nav: true, title: 'Materials'},
        {route: 'materials/create', name: 'materials' + 'Create', moduleId: PLATFORM.moduleName('materials/create'), nav: false, title: 'Materials Create'},
        {route: 'materials/edit/:id', name: 'materials' + 'Edit', moduleId: PLATFORM.moduleName('materials/edit'), nav: false, title: 'Materials Edit'},
        {route: 'materials/delete/:id', name: 'materials' + 'Delete', moduleId: PLATFORM.moduleName('materials/delete'), nav: false, title: 'Materials Delete'},
        {route: 'materials/details/:id', name: 'materials' + 'Details', moduleId: PLATFORM.moduleName('materials/details'), nav: false, title: 'Materials Details'},

        {route: ['participants','participant/index'], name: 'participants' + 'Index', moduleId: PLATFORM.moduleName('participants/index'), nav: true, title: 'Participants'},
        {route: 'participants/create', name: 'participants' + 'Create', moduleId: PLATFORM.moduleName('participants/create'), nav: false, title: 'Participants Create'},
        {route: 'participants/edit/:id', name: 'participants' + 'Edit', moduleId: PLATFORM.moduleName('participants/edit'), nav: false, title: 'Participants Edit'},
        {route: 'participants/delete/:id', name: 'participants' + 'Delete', moduleId: PLATFORM.moduleName('participants/delete'), nav: false, title: 'Participants Delete'},
        {route: 'participants/details/:id', name: 'participants' + 'Details', moduleId: PLATFORM.moduleName('participants/details'), nav: false, title: 'Participants Details'},
      ]
    );
    // {route: 'identity/login', name: 'identity' + 'Login', moduleId: PLATFORM.moduleName('identity/login'), nav: false, title: 'Login'},
    // {route: 'identity/register', name: 'identity' + 'Register', moduleId: PLATFORM.moduleName('identity/register'), nav: false, title: 'Register'},
    // {route: 'identity/logout', name: 'identity' + 'Logout', moduleId: PLATFORM.moduleName('identity/logout'), nav: false, title: 'Logout'},
    //{route: '', name: '', moduleId: PLATFORM.moduleName(''), nav: true, title: ''},
    //
    // {route: ['contacts','contacts/index'], name: 'contacts' + 'Index', moduleId: PLATFORM.moduleName('contacts/index'), nav: true, title: 'Contacts'},
    // {route: 'contacts/create', name: 'contacts' + 'Create', moduleId: PLATFORM.moduleName('contacts/create'), nav: false, title: 'Contacts Create'},
    // {route: 'contacts/edit/:id', name: 'contacts' + 'Edit', moduleId: PLATFORM.moduleName('contacts/edit'), nav: false, title: 'Contacts Edit'},
    // {route: 'contacts/delete/:id', name: 'contacts' + 'Delete', moduleId: PLATFORM.moduleName('contacts/delete'), nav: false, title: 'Contacts Delete'},
    // {route: 'contacts/details/:id', name: 'contacts' + 'Details', moduleId: PLATFORM.moduleName('contacts/details'), nav: false, title: 'Contacts Details'},
    //
    // {route: ['contacttypes','contacttypes/index'], name: 'contacttypes' + 'Index', moduleId: PLATFORM.moduleName('contacttypes/index'), nav: true, title: 'ContactTypes'},
    // {route: 'contacttypes/create', name: 'contacttypes' + 'Create', moduleId: PLATFORM.moduleName('contacttypes/create'), nav: false, title: 'ContactTypes Create'},
    // {route: 'contacttypes/edit/:id', name: 'contacttypes' + 'Edit', moduleId: PLATFORM.moduleName('contacttypes/edit'), nav: false, title: 'ContactTypes Edit'},
    // {route: 'contacttypes/delete/:id', name: 'contacttypes' + 'Delete', moduleId: PLATFORM.moduleName('contacttypes/delete'), nav: false, title: 'ContactTypes Delete'},
    // {route: 'contacttypes/details/:id', name: 'contacttypes' + 'Details', moduleId: PLATFORM.moduleName('contacttypes/details'), nav: false, title: 'ContactTypes Details'},
    
  } 
  
}
