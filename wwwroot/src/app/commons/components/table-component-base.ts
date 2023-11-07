import {
  AfterViewInit,
  ChangeDetectorRef,
  Directive,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { IEntityBase } from 'src/app/models/IEntityBase';

@Directive()
export abstract class TableComponentBase<T extends IEntityBase>
  implements OnInit, AfterViewInit
{
  @Input() data!: T[];
  @Output() dataChange: EventEmitter<T[]> = new EventEmitter<T[]>();

  protected abstract displayedColumns: string[];
  protected dataSource = new MatTableDataSource<T>(this.data);

  @ViewChild(MatPaginator) paginator = new MatPaginator(
    new MatPaginatorIntl(),
    ChangeDetectorRef.prototype
  );

  ngOnInit(): void {
    this.getData().subscribe((data) => {
      this.data = data;
      this.reloadTableData(this.data);
    });
  }
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  createData(name: string) {
    this.createEntity(name).subscribe((entity) => {
      this.data.push(entity);
      this.reloadTableData(this.data);
    });
  }

  getDataNames(): string[] {
    return this.data.map((x) => x.name);
  }

  protected abstract getData(): Observable<T[]>;
  protected abstract createEntity(name: string): Observable<T>;

  private reloadTableData(data: T[]): void {
    this.dataSource.data = data;
    this.dataChange.emit(data);
  }
}
