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
  @Input() candidates!: Candidate[];
  @Output() candidatesChange: EventEmitter<Candidate[]> = new EventEmitter<
    Candidate[]
  >();

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

  createCandidate(name: string) {
    this.candidateService.createCandidate(name).subscribe((candidate) => {
      this.candidates.push(candidate);
      this.reloadTableData(this.candidates);
    });
  }

  reloadTableData(data: Candidate[]): void {
    this.dataSource.data = data;
    this.candidatesChange.emit(data);
  }

  getCandidateNames(): string[] {
    return this.candidates.map((x) => x.name);
  }
}
