import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AccountService, AlertService } from '../_services';
import { Login } from '../_models';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    loginModel: Login;

    constructor(private accountService: AccountService, private router: Router){
      this.loginModel = new Login('', '');
    }

    ngOnInit() {
    }

    OnSubmit(){
      this.accountService.login(this.loginModel.login, this.loginModel.password)
      .subscribe(
        token => {
          console.log('Authorization success', localStorage.getItem('accessToken'));
          this.router.navigate(['/home']);
        }, 
        error => console.log('Error: ', error)
      );

    }
}
