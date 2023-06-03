import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { QuestionType } from "app/components/question/question.type";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  constructor(private readonly httpClient: HttpClient) {}

  public addQuestion(data: any) {
    return this.httpClient.post<any>('api/Questions/add-question', data);
  }

  public getAllQuestions(): Observable<QuestionType[]> {
    return this.httpClient.get<any>('api/Questions/questions');
  }
}
