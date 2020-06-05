import { Component, OnInit } from '@angular/core';
import { Gundam } from '../../_models/gundam';
import { GundamService } from '../../_services/gundam.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-collectiongundam',
  templateUrl: './gundam.component.html',
  styleUrls: ['./gundam.component.css']
})
export class GundamComponent implements OnInit {
  gundams: Gundam[];

  constructor(private gundamService: GundamService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.gundams = data.gundams;
    });
  }

  // loadGundams() {
  //   this.gundamService.getGundams().subscribe((gundams: Gundam[]) => {
  //     this.gundams = gundams;
  //   }, error => {
  //     this.alertify.error(error);
  //   });
  // }

}
