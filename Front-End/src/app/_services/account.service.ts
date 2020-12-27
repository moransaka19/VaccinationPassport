import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { Register, User } from '../_models';

@Injectable({ providedIn: 'root' })
export class AccountService {
    public user: Observable<User>;
    private currentUser: User;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        
    }
    
    getCurrent() {
        const headers = {'Authorization': 'Bearer ' + localStorage.getItem('accessToken')};
        return this.http.get<User>(`${environment.apiUrl}/auth/current`, { headers });
    }

    login(login, password) {
        return this.http.post(`${environment.apiUrl}/auth/login`, { login, password })
        .pipe(tap(val => this.setSession(val)));
    }

    isLoginTaken(login){
        return this.http.post(`${environment.apiUrl}/auth/is-login-taken`, { login })
        .subscribe(res => this.setSession(res))
        .unsubscribe();
    }

    logout() {
        localStorage.removeItem('accessToken');
    }

    register(user: Register) {
        return this.http.post(`${environment.apiUrl}/auth/registration`, user)
        .pipe(tap(val => this.setSession(val)));
    }

    private setSession(authResult){
        localStorage.setItem('accessToken', authResult.token);
    }

}