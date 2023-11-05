import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Candidate } from 'src/app/models/Candidate';
import { Vote } from 'src/app/models/Vote';
import { Voter } from 'src/app/models/Voter';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent {
  constructor() {}

  candidates: Candidate[] = [];
  voters: Voter[] = [];

  voteAdded(vote: Vote) {
    this.candidates.find((x) => x.id === vote.candidate.id)?.votes.push(vote);
    this.voters.find((x) => x.id === vote.voter.id)!.hasVoted = true;
  }
}
