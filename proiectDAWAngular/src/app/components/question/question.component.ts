import { Component, ElementRef, Input, ViewChild } from "@angular/core";
import { QuestionType } from "./question.type";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { CustomError } from "app/shared/utils/error";
import { Router } from "@angular/router";
import { AnswerService } from "app/core/services/answer.service";

@Component({
  selector: 'daw-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent {
  @Input() public question!: QuestionType;
  public showInput: boolean = false;
  public buttonText: string = 'Answer';
  public buttonColor: string = 'primary';

  constructor(private formBuilder: FormBuilder, private readonly answerService: AnswerService, public router: Router) {}

  public readonly answerForm = this.formBuilder.group({
    answerInput: ['', Validators.required]
  });

  public answerError: CustomError | undefined;

  toggleInput() {
    this.showInput = !this.showInput;
    this.buttonText = this.showInput ? 'Cancel' : 'Answer';
    this.buttonColor = this.showInput ? 'warn' : 'primary';
  }

  postAnswer() {
    if (this.answerForm.valid) {
      const answer = {
        content: this.answerInput.value,
        questionId: this.question.id
      };
      this.answerService.addAnswer(answer).subscribe({
        next: response => {
          this.router.navigate(['/feed']);
        },
        error: error => {
          console.log(error);
          this.answerError = {
            errorCode: error.error.code,
            errorMsg: error.error.message
          };
        }
      });

    }
  }

  public get answerInput(): FormControl {
    return this.answerForm.controls.answerInput;
  }
}
