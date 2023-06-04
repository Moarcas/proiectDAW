import { Component, Input } from "@angular/core";
import { AnswerService } from "app/core/services/answer.service";
import { AnswerType } from "app/models/answer.model";

@Component({
  selector: 'daw-answers',
  templateUrl: './answers.component.html',
  styleUrls: ['./answers.component.scss']
})
export class AnswersComponent {
  @Input() public questionId!: string;

  public answers: AnswerType[] = [];

  constructor(private readonly answerService: AnswerService) {}

  ngOnInit(): void {
    this.answerService.getAllAnswersByQuestionId(this.questionId).subscribe((answers) => {
      this.answers = answers;
    });
  }
}
