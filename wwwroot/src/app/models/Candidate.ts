import { IEntityBase } from './IEntityBase';
import { Vote } from './Vote';

export type Candidate = IEntityBase & {
  id?: number;
  votes: Vote[];
};
