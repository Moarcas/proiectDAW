import { Component, Input } from "@angular/core";
import { QuestionType } from "./question.type";

@Component({
  selector: 'daw-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent {
  @Input() public question!: QuestionType;

  constructor() {}


}
