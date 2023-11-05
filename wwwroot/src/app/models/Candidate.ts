import { Vote } from './Vote';

export type Candidate = {
  id?: number;
  name: string;
  votes: Vote[];
};
