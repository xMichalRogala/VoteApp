import { QuoteStatus } from '../enums/QuoteStatuses';

export interface Quote {
  id?: number;
  siteName: string;
  postCode: string;
  status: QuoteStatus;
}
