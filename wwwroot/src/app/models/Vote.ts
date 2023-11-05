import { Candidate } from './Candidate';
import { Voter } from './Voter';

export type Vote = {
  id?: number;
  voter: Voter;
  candidate: Candidate;
};
