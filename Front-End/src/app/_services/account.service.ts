import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { User } from '../_models';

@Injectable({ providedIn: 'root' })
export class AccountService {
    public user: Observable<User>;
    private currentUser: User;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        
    }
    
    getUserValue(){
        this.user = this.getCurrentDoctor();
        this.user.subscribe(u => this.currentUser = u).unsubscribe();

        return this.currentUser;
    }
    
    private getCurrentDoctor() {
        return this.http.get<User>(`${environment.apiUrl}/current`);
    }

    login(login, password) {
        return this.http.post(`${environment.apiUrl}/auth/login`, { login, password });
    }

    isLoginTaken(login){
        return this.http.post(`${environment.apiUrl}/auth/is-login-taken`, { login });
    }

    logout() {
        this.http.get(`${environment.apiUrl}/auth/logout`);
        this.router.navigate(['/account/login']);
    }

    register(user: User) {
        return this.http.post(`${environment.apiUrl}/auth/registration`, user);
    }

}