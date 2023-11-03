import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Voter } from 'src/app/models/Voter';
import { VoterService } from 'src/app/services/voter.service';

@Component({
  selector: 'app-voters-view',
  templateUrl: './voters-view.component.html',
  styleUrls: ['./voters-view.component.scss'],
})
export class VotersViewComponent implements OnInit, AfterViewInit {
  constructor(private voterService: VoterService) {}
  voters: Voter[] = [];
  displayedColumns: string[] = ['name', 'hasVoted'];
  dataSource = new MatTableDataSource<Voter>(this.voters);

  @ViewChild(MatPaginator) paginator = new MatPaginator(
    new MatPaginatorIntl(),
    ChangeDetectorRef.prototype
  );

  ngOnInit(): void {
    this.voterService.getVoters().subscribe((voters) => {
      this.voters = voters;
      this.reloadTableData(this.voters);
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  reloadTableData(data: Voter[]): void {
    this.dataSource.data = data;
  }
}
