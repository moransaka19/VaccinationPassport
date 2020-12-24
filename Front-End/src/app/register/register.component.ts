import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AccountService, AlertService } from '../_services';
import { Register } from '../_models';

@Component({ templateUrl: 'register.component.html' })
export class RegisterComponent implements OnInit {
   registerModel: Register;

    constructor(private accountService: AccountService, private router: Router) {
        this.registerModel = new Register('', '', '');
    }
   
    ngOnInit() {}

    OnSubmit() {
        this.accountService.register(this.registerModel)
        .subscribe(
            data => console.log('Success: ', data),
            error => console.log('Error: ', error)
        );
        
        this.router.navigate(['']);
    }
}