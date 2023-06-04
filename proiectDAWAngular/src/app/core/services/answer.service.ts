import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AnswerType } from "app/models/answer.model";

@Injectable({
  providedIn: 'root'
})
export class AnswerService {
  constructor(private readonly httpClient: HttpClient) {}

  public getAllAnswersByQuestionId(questionId: string) {
    return this.httpClient.get<any>(`api/Answers/${questionId}`);
  }

  public addAnswer(data: AnswerType) {
    console.log(data);
    return this.httpClient.post<any>('api/Answers/add-answer', data);
  }
}
