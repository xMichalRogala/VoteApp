import { QuoteStatus } from './QuoteStatuses';

enum GroupedQuoteStatusEnum {
  Draft = 'Draft',
  Rejected = 'Rejected',
  AwaitingApproval = 'Awaiting Approval',
  AwaitingForCustomerGo = 'Awaiting for Customer GO',
}

interface GroupedQuoteStatus {
  groupedQuoteStatusEnum: GroupedQuoteStatusEnum;
  statuses: QuoteStatus[];
}

export const GroupedQuoteStatuses: GroupedQuoteStatus[] = [
  {
    groupedQuoteStatusEnum: GroupedQuoteStatusEnum.Draft,
    statuses: [QuoteStatus.Draft],
  },
  {
    groupedQuoteStatusEnum: GroupedQuoteStatusEnum.Rejected,
    statuses: [
      QuoteStatus.RejectedByFinanceApprover,
      QuoteStatus.RejectedByAdminApprover,
      QuoteStatus.RejectedByAgreementApprover,
      QuoteStatus.Undeliverable,
      QuoteStatus.Revoked,
      QuoteStatus.Expired,
      QuoteStatus.Declined,
    ],
  },
  {
    groupedQuoteStatusEnum: GroupedQuoteStatusEnum.AwaitingApproval,
    statuses: [
      QuoteStatus.AwaitingFinancialApproval,
      QuoteStatus.AwaitingAdminApproval,
      QuoteStatus.AwaitingAgreementApproval,
      QuoteStatus.AwaitingCustomerSignature,
      QuoteStatus.AwaitingRegalSignature,
    ],
  },
  {
    groupedQuoteStatusEnum: GroupedQuoteStatusEnum.AwaitingForCustomerGo,
    statuses: [QuoteStatus.AwaitingCustomerGo],
  },
];
