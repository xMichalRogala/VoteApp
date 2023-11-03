import { Vote } from './Vote';

export type Voter = {
  id?: number;
  name: string;
  hasVoted: boolean;
  vote: Vote;
};
