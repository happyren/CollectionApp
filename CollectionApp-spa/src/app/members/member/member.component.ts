import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.css'],
})
export class MemberComponent implements OnInit {
  users: User[];
  usersTop3: User[];
  usersRest: User[];

  constructor(
    private userService: UserService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.users = data.users;
    });

    this.usersTop3 = this.users.slice(0, 3);
    this.addRank();
    this.usersRest = this.users.slice(3);
  }

  addRank() {
    for (let i = 0; i < this.usersTop3.length; i++) {
      this.usersTop3[i].rank = i + 1;
    }
  }
}
