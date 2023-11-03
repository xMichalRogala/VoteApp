import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Candidate } from 'src/app/models/Candidate';
import { CandidateService } from 'src/app/services/candidate.service';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-candidates-view',
  templateUrl: './candidates-view.component.html',
  styleUrls: ['./candidates-view.component.scss'],
})
export class CandidatesViewComponent implements OnInit, AfterViewInit {
  constructor(private candidateService: CandidateService) {}
  candidates: Candidate[] = [];
  displayedColumns: string[] = ['name', 'votes'];
  dataSource = new MatTableDataSource<Candidate>(this.candidates);

  @ViewChild(MatPaginator) paginator = new MatPaginator(
    new MatPaginatorIntl(),
    ChangeDetectorRef.prototype
  );

  ngOnInit(): void {
    this.candidateService.getCandidates().subscribe((candidates) => {
      this.candidates = candidates;
      this.reloadTableData(this.candidates);
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  reloadTableData(data: Candidate[]): void {
    this.dataSource.data = data;
  }
}
