import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { error } from 'protractor';
import { Observable } from 'rxjs';
import { first, timeout } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

import { Test, User } from '../_models';
import { CurrentUser } from '../_models/currentUser';
import { AccountService } from '../_services';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {

    constructor() {
        
    }
}