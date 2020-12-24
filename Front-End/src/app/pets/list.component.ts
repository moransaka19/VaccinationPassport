import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { OwnerService } from '../_services';

@Component({ templateUrl: 'list.component.html' })
export class ListComponent implements OnInit {
    users = null;

    constructor(private ownerService: OwnerService) {}

    ngOnInit() {
        this.ownerService.getAllOwners()
            .pipe(first())
            .subscribe(users => this.users = users);
    }
}