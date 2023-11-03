import { CandidatesViewComponent } from './components/candidates-view/candidates-view.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { VotersViewComponent } from './components/voters-view/voters-view.component';
import { SubmitVoteComponent } from './components/submit-vote/submit-vote.component';
import { DataTableTestComponent } from './components/data-table-test/data-table-test.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ConfigService } from './commons/web-api/config.service';
import { CorsRequestInterceptor } from './commons/web-api/cors-request.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    NavbarComponent,
    CandidatesViewComponent,
    VotersViewComponent,
    SubmitVoteComponent,
    DataTableTestComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    NgbModule,
    HttpClientModule,
  ],
  providers: [
    ConfigService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CorsRequestInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
