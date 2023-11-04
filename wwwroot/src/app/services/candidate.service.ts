import { HttpClient } from '@angular/common/http';
import { Candidate } from './../models/Candidate';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ServiceBase } from '../commons/web-api/service-base';
import { ConfigService } from '../commons/web-api/config.service';
import { CreateCandidate } from '../models/Commands/CreateCandidate';

@Injectable({
  providedIn: 'root',
})
export class CandidateService extends ServiceBase {
  constructor(http: HttpClient, configService: ConfigService) {
    super(configService, http);
  }

  apiControllerNameUrl: string = 'Candidate';

  getCandidates(): Observable<Candidate[]> {
    return this.getData<Candidate[]>(
      `${this.apiControllerNameUrl}/GetAll`,
      'Error while searching for a candidates'
    );
  }

  createCandidate(name: string): Observable<Candidate> {
    return this.postData<CreateCandidate>(
      `${this.apiControllerNameUrl}/AddCandidate`,
      {
        name: name,
      },
      'Error while adding new candidate'
    );
  }
}
