import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Quote } from '../models/Quote';
import { QUOTES } from '../dataMocks/mock-quotes';

@Injectable({
  providedIn: 'root',
})
export class QuoteService {
  constructor() {}

  getQuotes(): Observable<Quote[]> {
    const quotes = of(QUOTES);

    return quotes;
  }
}
