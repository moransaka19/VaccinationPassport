import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

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
        return this.http.get<User>(`${environment.apiUrl}/auth/current`);
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

    register(user: Register) {
        const url = this.http.post(`${environment.apiUrl}/auth/registration`, user);
        return url;
    }

}