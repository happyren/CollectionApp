import { Component, OnInit, Input } from '@angular/core';
import { Gundam } from 'src/app/_models/gundam';

@Component({
  selector: 'app-collectiongundamcard',
  templateUrl: './gundam-card.component.html',
  styleUrls: ['./gundam-card.component.css']
})
export class GundamCardComponent implements OnInit {
  @Input() gundam: Gundam;

  constructor() { }

  ngOnInit() {
  }

}
