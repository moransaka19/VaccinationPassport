import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, Subscription } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Test, User } from './_models';

import { AccountService, CookieService } from './_services';

@Component({ selector: 'app', templateUrl: 'app.component.html' })
export class AppComponent implements OnInit {
    user: Observable<User>;
    isAuthorized = false;

    constructor(private accountService: AccountService, private router: Router) {
        this.user = this.accountService.getCurrent();
    }

    ngOnInit(){
        this.user
        .subscribe(
            data => {
                this.isAuthorized = true;
                this.router.navigate(['/home']);
                console.log(data);
            },
            error => {
                console.log('Error: ', error);
                this.router.navigate(['/login']);
            }
        );
    }

    logout(){
        this.accountService.logout();
    }
}