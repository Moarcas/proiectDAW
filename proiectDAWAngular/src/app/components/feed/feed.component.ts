import { Component } from "@angular/core";
import { QuestionType } from "../question/question.type";
import { QuestionService } from "app/core/services/question.service";

@Component({
  selector: 'daw-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss']
})
export class FeedComponent {
  public questions: QuestionType[] = [];

  constructor(private readonly questionService: QuestionService) {
    this.questionService.getAllQuestions().subscribe((questions) => {
      console.log(questions);
      this.questions = questions;
    });
  }
}
