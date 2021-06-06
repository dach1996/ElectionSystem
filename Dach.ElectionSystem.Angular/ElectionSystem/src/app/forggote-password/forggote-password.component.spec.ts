import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForggotePasswordComponent } from './forggote-password.component';

describe('ForggotePasswordComponent', () => {
  let component: ForggotePasswordComponent;
  let fixture: ComponentFixture<ForggotePasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ForggotePasswordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ForggotePasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
