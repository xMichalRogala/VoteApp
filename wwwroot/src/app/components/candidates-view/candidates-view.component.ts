import { Component } from '@angular/core';
import { Candidate } from 'src/app/models/Candidate';
import { CandidateService } from 'src/app/services/candidate.service';
import { TableComponentBase } from 'src/app/commons/components/table-component-base';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-candidates-view',
  templateUrl: './candidates-view.component.html',
  styleUrls: ['./candidates-view.component.scss'],
})
export class CandidatesViewComponent extends TableComponentBase<Candidate> {
  constructor(private candidateService: CandidateService) {
    super();
  }
  displayedColumns: string[] = ['name', 'votes'];
  protected override getData(): Observable<Candidate[]> {
    return this.candidateService.getCandidates();
  }
  protected override createEntity(name: string): Observable<Candidate> {
    return this.candidateService.createCandidate(name);
  }
}
