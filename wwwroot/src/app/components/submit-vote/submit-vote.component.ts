import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Candidate } from 'src/app/models/Candidate';
import { Vote } from 'src/app/models/Vote';
import { Voter } from 'src/app/models/Voter';
import { VoteService } from 'src/app/services/vote.service';
@Component({
  selector: 'app-submit-vote',
  templateUrl: './submit-vote.component.html',
  styleUrls: ['./submit-vote.component.scss'],
})
export class SubmitVoteComponent {
  constructor(private voteService: VoteService) {}

  @Input() candidates!: Candidate[];
  @Input() voters!: Voter[];
  @Output() voteAdded: EventEmitter<Vote> = new EventEmitter<Vote>();

  onSubmit(form: NgForm) {
    const selectedCandidate: Candidate = form.value.selectedCandidate;
    const selectedVoter: Voter = form.value.selectedVoter;

    let vote: Vote = {
      voter: selectedVoter,
      candidate: selectedCandidate,
    };

    this.voteService.createVote(vote).subscribe((result: Vote) => {
      vote.id = result.id!;
      this.voteAdded.emit(vote);
    });
  }

  getVotersWhoDidntVote = (): Voter[] => {
    return this.voters.filter((x) => !x.hasVoted);
  };
}
