import { Component, Input, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogOverviewExampleDialog } from './standalone/popup-dialog';

export interface DialogData {
  name: string;
  headerValue: string;
  labelValue: string;
}

@Component({
  selector: 'app-add-entity-dialog',
  templateUrl: './add-entity-dialog.component.html',
  styleUrls: ['./add-entity-dialog.component.scss'],
})
export class AddEntityDialogComponent {
  name: string = '';
  constructor(public dialog: MatDialog) {}
  @Input() headerValue: string = '';
  @Input() labelValue: string = '';
  @Input() existingNames: string[] = [];
  @Output() newEntityNameEvent = new EventEmitter<string>();

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogOverviewExampleDialog, {
      data: {
        name: this.name,
        headerValue: this.headerValue,
        labelValue: this.labelValue,
      },
    });

    dialogRef.afterClosed().subscribe((result: string) => {
      this.name = result;

      if (this.name.length !== 0 && !this.existingNames.includes(this.name)) {
        this.newEntityNameEvent.emit(this.name);
      }
    });
  }
}
