import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { Record} from '../_models';

@Injectable({ providedIn: 'root' })
export class RecordService {
    public record: Observable<Record>;

    constructor(
        private http: HttpClient
    ) {
        
    }
    
    getById(id) {
        return this.http.get<Record>(`${environment.apiUrl}/records/${id}`);
    }

    getAll(){
        return this.http.get<Record[]>(`${environment.apiUrl}/records`);
    }

    update(record){
        return this.http.post(`${environment.apiUrl}/records`, record);
    }

    delete(id){
        return this.http.delete(`${environment.apiUrl}/records`, id);
    }
}