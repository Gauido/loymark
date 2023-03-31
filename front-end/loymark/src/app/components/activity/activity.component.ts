import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css'],
})
export class ActivityComponent implements OnInit {
  taskList;

  constructor(private uService: UserService) {}

  ngOnInit(): void {
    this.getList();
  }

  getList() {
    this.uService.getTasks().subscribe((res: any) => {
      this.taskList = res;
    });
  }
}
