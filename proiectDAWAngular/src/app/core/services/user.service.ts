import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginType } from 'app/components/login/login.type';
import { RegisterType } from 'app/components/register/register.type';
import { CustomError } from 'app/shared/utils/error';
import { BehaviorSubject, Observable, ReplaySubject, catchError, map, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private isAuthenticatedSubject = new ReplaySubject<boolean>(1);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(private readonly httpClient: HttpClient) {}

  public register(data: RegisterType) {
    console.log(data);
    return this.httpClient
      .post<any>('api/Authentication/register', data)
      .pipe(
        map((response: any) => {
          console.log("Raspunsul de la server:");
          console.log(response);
          if (response) {
            localStorage.setItem('token', response.jwtToken);
            this.isAuthenticatedSubject.next(true);
          }
          return response;
        })
      );
  }

  public login(data: LoginType) {
    console.log(data);
    return this.httpClient
      .post<any>('api/Authentication/login', data)
      .pipe(
        map((response: any) => {
          if (response) {
            localStorage.setItem('token', response.jwtToken);
            this.isAuthenticatedSubject.next(true);
          }
          return response;
        })
      );
  }

  public logout(): void {
    localStorage.removeItem('token');
    this.isAuthenticatedSubject.next(false);
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
}
