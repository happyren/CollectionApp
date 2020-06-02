/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TopCollectorsComponent } from './top-collectors.component';

describe('TopCollectorsComponent', () => {
  let component: TopCollectorsComponent;
  let fixture: ComponentFixture<TopCollectorsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopCollectorsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopCollectorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
