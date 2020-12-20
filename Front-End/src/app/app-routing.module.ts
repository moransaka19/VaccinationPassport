import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';
import { AuthGuard } from './_helpers';

const ownerModule = () => import('./owners/owners.module').then(x => x.OwnersModule);
const petModule = () => import('./pets/pets.module').then(x => x.PetsModule);

const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'owners', loadChildren: ownerModule, canActivate: [AuthGuard] },
    { path: 'pets', loadChildren: petModule },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }