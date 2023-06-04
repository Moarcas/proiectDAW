import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginType } from 'app/components/login/login.type';
import { RegisterType } from 'app/components/register/register.type';
import { CustomError } from 'app/shared/utils/error';
import { BehaviorSubject, Observable, ReplaySubject, catchError, map, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private isAuthenticatedSubject = new ReplaySubject<boolean>(0);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(private readonly httpClient: HttpClient) {
    this.isLoggedIn().subscribe((isLoggedIn) => {
      this.isAuthenticatedSubject.next(isLoggedIn);
    });
  }

  public register(data: RegisterType) {
    console.log("Datele trimise la server:");
    console.log(data);
    return this.httpClient
      .post<any>('api/Authentication/register', data)
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

  isLoggedIn(): Observable<boolean> {
    return this.httpClient.get('api/Authentication/is-logged-in').pipe(
      map(() => true),
      catchError((error: any) => {
        return of(false);
      })
    );
  }

}
