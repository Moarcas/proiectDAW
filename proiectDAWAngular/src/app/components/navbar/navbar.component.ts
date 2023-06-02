import { Component } from '@angular/core';
import { UserService } from 'app/core/services/user.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'daw-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  public readonly isLoggedIn$: Observable<boolean> = this.userService.isAuthenticated;

  constructor(private readonly userService: UserService) {}

  public logout() {
    this.userService.logout();
  }
}
