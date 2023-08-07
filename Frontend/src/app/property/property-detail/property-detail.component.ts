import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HousingService } from 'src/app/services/housing.service';
import { Property } from 'src/app/model/property';
import {GalleryImage } from '@daelmaak/ngx-gallery';


@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.css']
})
export class PropertyDetailComponent implements OnInit {
public propertyId: number;
property = new Property();
galleryImages: GalleryImage[];

  constructor(private route: ActivatedRoute,
              private router: Router,
              private housingService: HousingService) { }

  ngOnInit() {
    this.propertyId = +this.route.snapshot.params['id'];
    this.route.data.subscribe(
      (data: any) => {
        this.property = data['prp'];
      }
    );

    // this.route.params.subscribe(
    //   (params) => {
    //     this.propertyId = +params['id'];
    //     this.housingService.getProperty(this.propertyId).subscribe(
    //       (data: Property) => {
    //         this.property = data;
    //       }, error => this.router.navigate(['/'])
    //     );
    //   }
    // );

    this.galleryImages = [
      {
        src: 'assets/images/prop1.jpg',
        thumbSrc: 'assets/images/prop1.jpg',
        alt: 'image',
        description: 'description',
        data: ''
      },
      {
        src: 'assets/images/prop2.jpg',
        thumbSrc: 'assets/images/prop2.jpg',
        alt: 'image',
        description: 'description',
        data: ''
      },
      {
        src: 'assets/images/prop3.jpg',
        thumbSrc: 'assets/images/prop3.jpg',
        alt: 'image',
        description: 'description',
        data: ''
      },
      {
        src: 'assets/images/prop4.jpg',
        thumbSrc: 'assets/images/prop4.jpg',
        alt: 'image',
        description: 'description',
        data: ''
      },
      {
        src: 'assets/images/prop5.jpg',
        thumbSrc: 'assets/images/prop5.jpg',
        alt: 'image',
        description: 'description',
        data: ''
      }
    ];


  }
}