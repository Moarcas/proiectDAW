import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'app/core/services/user.service';
import { LoginFormType, LoginType } from './login.type';
import { CustomError } from 'app/shared/utils/error';
import { openClosedAnimation } from 'app/animations';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  animations: [openClosedAnimation]
})
export class LoginComponent implements OnInit {
  constructor(private readonly fb: FormBuilder, private readonly userService: UserService, public router: Router) {}

  public readonly loginForm: FormGroup<LoginFormType> = this.fb.nonNullable.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  });

  public loginError: CustomError | undefined;

  public ngOnInit(): void {}

  public onSubmit(): void {
    if (this.loginForm.valid) {
      this.userService
        .login(this.loginForm.value as LoginType)
        .subscribe({
          next: response => {
            this.router.navigate(['/']);
          },
          error: error => {
            console.log(error);
            this.loginError = {
              errorCode: error.error.code,
              errorMsg: error.error.message
            };
          }
        });
    }
  }

  public get email(): FormControl {
    return this.loginForm.controls.email;
  }

  public get password(): FormControl {
    return this.loginForm.controls.password;
  }
}
