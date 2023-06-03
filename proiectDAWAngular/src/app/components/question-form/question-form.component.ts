import {Component, OnInit} from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { QuestionFormType, QuestionType } from './question.type';
import { CustomError } from 'app/shared/utils/error';
import { QuestionService } from 'app/core/services/question.service';

@Component({
  selector: 'question-form',
  styleUrls: ['./question-form.component.scss'],
  templateUrl: './question-form.component.html',
})
export class QuestionFormComponent implements OnInit {
  constructor(private readonly fb: FormBuilder, private readonly questionService: QuestionService, public router: Router) {}

  public readonly questionForm: FormGroup<QuestionFormType> = this.fb.nonNullable.group({
    title: ['', Validators.required],
    content: ['', Validators.required]
  });

  public questionError: CustomError | undefined;

  public ngOnInit(): void {}

  public onSubmit(): void {
    if (this.questionForm.valid) {
      const questionData: QuestionType = {
        title: this.questionForm.value.title!,
        content: this.questionForm.value.content!
      };

      this.questionService
        .addQuestion(questionData as QuestionType)
        .subscribe({
          next: response => {
            console.log("Raspunsul este:");
            console.log(response);
            this.router.navigate(['/feed']);
          },
          error: error => {
            console.log(error);
            this.questionError = {
              errorCode: error.error.code,
              errorMsg: error.error.message
            };
          }
        });
    }
  }

  public get title(): FormControl {
    return this.questionForm.controls.title;
  }

  public get content(): FormControl {
    return this.questionForm.controls.content;
  }
}
