import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DesactiveCandidateComponent } from './desactive-candidate.component';

describe('DesactiveCandidateComponent', () => {
  let component: DesactiveCandidateComponent;
  let fixture: ComponentFixture<DesactiveCandidateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DesactiveCandidateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DesactiveCandidateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
