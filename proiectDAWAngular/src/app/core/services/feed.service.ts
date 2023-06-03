import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class FeedService {
  constructor(private readonly httpClient: HttpClient) {}

}
