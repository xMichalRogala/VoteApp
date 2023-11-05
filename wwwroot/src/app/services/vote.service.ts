import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ServiceBase } from '../commons/web-api/service-base';
import { ConfigService } from '../commons/web-api/config.service';
import { Vote } from '../models/Vote';
import { CreateVote } from '../models/Commands/CreateVote';

@Injectable({
  providedIn: 'root',
})
export class VoteService extends ServiceBase {
  constructor(http: HttpClient, configService: ConfigService) {
    super(configService, http);
  }

  apiControllerNameUrl: string = 'Vote';

  createVote(vote: Vote): Observable<Vote> {
    return this.postData<CreateVote>(
      `${this.apiControllerNameUrl}/AddVote`,
      {
        voterId: vote.voter.id!,
        candidateId: vote.candidate.id!,
      },
      'Error while adding new voter'
    );
  }
}
