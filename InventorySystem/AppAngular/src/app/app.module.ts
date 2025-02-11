import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {HttpClientModule} from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import {ModalModule} from "ngx-bootstrap/modal";

import {UsersService} from './users.service';
import {CommonModule} from '@angular/common';
import { UsersComponent } from './Components/users/users.component';


@NgModule({
  declarations: [
    AppComponent,
    UsersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  providers: [HttpClientModule, UsersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
