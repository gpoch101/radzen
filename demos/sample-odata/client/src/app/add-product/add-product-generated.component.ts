/*
  This file is automatically generated. Any changes will be overwritten.
  Modify add-product.component.ts instead.
*/
import { ViewChild, Injector, OnInit, OnDestroy } from '@angular/core';
import { NavigationEnd, Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';
import { FormComponent } from '@radzen/angular';

import { SampleService } from '../sample.service';

export class AddProductGenerated implements OnInit, OnDestroy {
  // Components
  @ViewChild(FormComponent) form0: FormComponent;

  // Array of messages displayed by the notification component.
  messages = [];

  router: Router;

  route: ActivatedRoute;

  _location: Location;

  subscription: Subscription;


  sample: SampleService;

  parameters: any;

  constructor(private injector: Injector) {
  }

  ngOnInit() {
    this.router = this.injector.get(Router);

    this._location = this.injector.get(Location);

    this.route = this.injector.get(ActivatedRoute);

    this.sample = this.injector.get(SampleService);

    this.subscription = this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd && this instanceof <any>this.route.component) {
        this.parameters = this.route.snapshot.params;

        this.load();
      }
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }


  load() {

  }

  form0Cancel(event: any) {
    this._location.back();
  }

  form0Submit(event: any) {
    this.sample.createProduct(event)
    .then(result => {
      this.router.navigate([{ outlets: { popup: null } }]).then(() => this.router.navigate(['products']));
    }, result => {
      this.messages.push({ severity: "error", summary: `Error`, detail: `Unable to create new Product!` });
    });
  }
}
