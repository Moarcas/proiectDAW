import { FormControl } from "@angular/forms";

export interface QuestionFormType {
  title: FormControl<string>;
  content: FormControl<string>;
}

export interface QuestionType {
  title: string;
  content: string;
}
