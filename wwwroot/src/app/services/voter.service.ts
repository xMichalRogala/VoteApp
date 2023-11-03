import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ServiceBase } from '../commons/web-api/service-base';
import { ConfigService } from '../commons/web-api/config.service';
import { Voter } from '../models/Voter';

@Injectable({
  providedIn: 'root',
})
export class VoterService extends ServiceBase {
  constructor(http: HttpClient, configService: ConfigService) {
    super(configService, http);
  }

  apiControllerNameUrl: string = 'Voter';

  getVoters(): Observable<Voter[]> {
    return this.getData<Voter[]>(
      `${this.apiControllerNameUrl}/GetAll`,
      'Error while searching for a voters'
    );
  }
}
