import { IEntityBase } from './IEntityBase';

export type Voter = IEntityBase & {
  id?: number;
  hasVoted: boolean;
};
