import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { TableComponentBase } from 'src/app/commons/components/table-component-base';
import { Voter } from 'src/app/models/Voter';
import { VoterService } from 'src/app/services/voter.service';

@Component({
  selector: 'app-voters-view',
  templateUrl: './voters-view.component.html',
  styleUrls: ['./voters-view.component.scss'],
})
export class VotersViewComponent extends TableComponentBase<Voter> {
  constructor(private voterService: VoterService) {
    super();
  }
  displayedColumns: string[] = ['name', 'hasVoted'];

  protected override getData(): Observable<Voter[]> {
    return this.voterService.getVoters();
  }
  protected override createEntity(name: string): Observable<Voter> {
    return this.voterService.createVoter(name);
  }
}
