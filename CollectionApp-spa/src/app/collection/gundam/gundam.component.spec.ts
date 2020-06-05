/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GundamComponent } from './gundam.component';

describe('CollectiongundamComponent', () => {
  let component: GundamComponent;
  let fixture: ComponentFixture<GundamComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GundamComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GundamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
