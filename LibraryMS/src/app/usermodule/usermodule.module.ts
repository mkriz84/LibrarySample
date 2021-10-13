import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsermoduleComponent } from './usermodule.component';
import { RouterModule } from '@angular/router';
import { GensharedModule } from '../genshared/genshared.module';
import { FullwidthuserModule } from '../layouts/fullwidthuser/fullwidthuser.module';
import { HttpClientModule } from '@angular/common/http';
import { OwnedComponent } from './owned/owned/owned.component';
import { BorrowComponent } from './borrow/borrow/borrow.component';
import { ProfileComponent } from './profile/profile.component';
import { Profile1Component } from './profile1/profile1.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BorrowSearchPipe } from '../customPipes/borrow-search.pipe';
import { DemoComponent } from './demo/demo.component';



@NgModule({
  declarations: [
    UsermoduleComponent,
    OwnedComponent,
    BorrowComponent,
    ProfileComponent,
    Profile1Component,
    BorrowSearchPipe,
    DemoComponent

  ],
  imports: [
    CommonModule,
    RouterModule,
    GensharedModule,
    FullwidthuserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule

  ],
  exports: [
    UsermoduleComponent,
    OwnedComponent,
    BorrowComponent,
    ProfileComponent,
    Profile1Component
  ]
})
export class UsermoduleModule { }
