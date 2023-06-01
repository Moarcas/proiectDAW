import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterFormType, RegisterType } from './register.type';
import { UserService } from 'app/core/services/user.service';
import { CustomError } from 'app/shared/utils/error';
import { openClosedAnimation } from "app/animations";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  animations: [openClosedAnimation]
})
export class RegisterComponent implements OnInit {
  constructor(private readonly fb: FormBuilder, private readonly userService: UserService, public router: Router) {}

  public readonly registerForm: FormGroup<RegisterFormType> = this.fb.nonNullable.group({
    email: ['', [Validators.required, Validators.email]],
    username: ['', Validators.required],
    password: ['', Validators.required],
    confirmPassword: ['', [Validators.required, this.passwordMatchValidator.bind(this)]]
  });

  public registerError: CustomError | undefined;

  private passwordMatchValidator(control: FormControl): { [key: string]: boolean } | null {
    const password = this.registerForm?.controls.password?.value;
    const confirmPassword = control.value;

    if (password !== confirmPassword) {
      return { passwordMismatch: true };
    }

    return null;
  }

  public ngOnInit(): void {}

  public onSubmit(): void {
    if (this.registerForm.valid) {
      this.userService
        .register(this.registerForm.value as RegisterType)
        .subscribe({
          next: response => {
            this.router.navigate(['/']);
          },
          error: error => {
            console.log(error);
            this.registerError = {
              errorCode: error.error.code,
              errorMsg: error.error.message
            }
          }
        });
    }
  }

  public get email(): FormControl {
    return this.registerForm.controls.email;
  }

  public get username(): FormControl {
    return this.registerForm.controls.username;
  }

  public get password(): FormControl {
    return this.registerForm.controls.password;
  }

  public get confirmPassword(): FormControl {
    return this.registerForm.controls.confirmPassword;
  }
}
