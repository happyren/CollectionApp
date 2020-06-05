/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GundamCardComponent } from './gundam-card.component';

describe('CollectiongundamcardComponent', () => {
  let component: GundamCardComponent;
  let fixture: ComponentFixture<GundamCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GundamCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GundamCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
