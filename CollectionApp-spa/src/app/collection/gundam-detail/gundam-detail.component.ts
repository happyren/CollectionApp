import { Component, OnInit } from '@angular/core';
import { Gundam } from 'src/app/_models/gundam';
import { GundamService } from 'src/app/_services/gundam.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { tick } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-gundam-detail',
  templateUrl: './gundam-detail.component.html',
  styleUrls: ['./gundam-detail.component.css'],
})
export class GundamDetailComponent implements OnInit {
  gundam: Gundam;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(
    private gundamService: GundamService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.gundam = data.gundam;
    });

    this.galleryOptions = [
      {
        width: '600px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 3,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ];
    this.galleryImages = this.getImages();
  }

  getImages() {
    const imageUrls = [];
    for (const photo of this.gundam.photos) {
      imageUrls.push({
        small: photo.url,
        medium: photo.url,
        big: photo.url
      });
    }
    return imageUrls;
  }
}
