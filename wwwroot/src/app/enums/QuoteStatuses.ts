export enum QuoteStatus {
  New = 0,
  Draft = 1,
  AwaitingFinancialApproval = 2,
  AwaitingAdminApproval = 3,
  AwaitingAgreementApproval = 4,
  AwaitingCustomerGo = 5,
  RejectedByFinanceApprover = 6,
  RejectedByAdminApprover = 7,
  RejectedByAgreementApprover = 8,
  PassedToDepot = 9,
  Deleted = 10,
  AwaitingCustomerSignature = 11,
  AgreementSigned = 12,
  Undeliverable = 13,
  Revoked = 14,
  Expired = 15,
  Declined = 16,
  AwaitingRegalSignature = 17,
}
