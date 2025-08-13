import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestCard } from './request-card';

describe('RequestCard', () => {
  let component: RequestCard;
  let fixture: ComponentFixture<RequestCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RequestCard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RequestCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
