import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { CookieService } from '../_services';

@Component({ templateUrl: 'layout.component.html' })
export class LayoutComponent {
    constructor(
        private router: Router,
        private cookieService: CookieService
    ) {
        // redirect to home if already logged in
        if (!cookieService.isExist('accessToken')) {
            this.router.navigate(['/']);
        }
    }
}