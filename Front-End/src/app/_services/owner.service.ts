import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { User } from '../_models'

@Injectable({ providedIn: 'root' })
export class OwnerService {
    constructor( private http: HttpClient) {
    }

    getAllOwners(){
        return this.http.get<User[]>(`${environment.apiUrl}/owners`);  
    }
}