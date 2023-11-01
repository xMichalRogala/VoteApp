import { QuoteService } from './../../services/quote.service';
import { Component, OnInit } from '@angular/core';
import { MatRadioChange } from '@angular/material/radio';
import { GroupedQuoteStatuses } from 'src/app/enums/GroupedQuoteStatus';
import { Quote } from 'src/app/models/Quote';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  constructor(private quoteService: QuoteService) {}

  actualRadioBtnFilter: string = '';
  radioBtnFilters: string[] = GroupedQuoteStatuses.map(
    (status) => status.groupedQuoteStatusEnum
  );
  hidden = false;
  displayedColumns: string[] = ['id', 'siteName', 'postCode', 'status'];
  quotes: Quote[] = [];

  ngOnInit(): void {
    this.quoteService.getQuotes().subscribe((quotes) => (this.quotes = quotes));
  }

  toggleBadgeVisibility() {
    this.hidden = !this.hidden;
  }

  onRadioFilterChanged($event: MatRadioChange) {
    //todo
  }

  radioBtnWasClicked($event: string) {
    if (this.actualRadioBtnFilter === $event) {
      this.actualRadioBtnFilter = '';
    }
  }
}
