import { QuoteStatus } from '../enums/QuoteStatuses';
import { Quote } from '../models/Quote';

export const QUOTES: Quote[] = [
  {
    id: 1,
    siteName: 'Falcon',
    postCode: 'PO33 2TG',
    status: QuoteStatus.RejectedByAdminApprover,
  },
  {
    id: 2,
    siteName: 'Falcon',
    postCode: 'PO33 2TG',
    status: QuoteStatus.Expired,
  },
  {
    id: 3,
    siteName: 'Falcon',
    postCode: 'PO33 2TG',
    status: QuoteStatus.Draft,
  },
  {
    id: 4,
    siteName: 'Falcon',
    postCode: 'PO33 2TG',
    status: QuoteStatus.AwaitingCustomerGo,
  },
  {
    id: 5,
    siteName: 'New Site',
    postCode: '56 416',
    status: QuoteStatus.RejectedByAdminApprover,
  },
  {
    id: 6,
    siteName: 'New Site',
    postCode: '55 2TG',
    status: QuoteStatus.Declined,
  },
  {
    id: 7,
    siteName: 'New Site',
    postCode: '23 2TG',
    status: QuoteStatus.PassedToDepot,
  },
];
