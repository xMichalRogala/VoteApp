import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ServiceBase } from '../commons/web-api/service-base';
import { ConfigService } from '../commons/web-api/config.service';
import { Voter } from '../models/Voter';
import { CreateVoter } from '../models/Commands/CreateVoter';

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

  createVoter(name: string): Observable<Voter> {
    return this.postData<CreateVoter>(
      `${this.apiControllerNameUrl}/AddVoter`,
      {
        name: name,
      },
      'Error while adding new voter'
    );
  }
}
