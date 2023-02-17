import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HideMessageComponent } from './hide-message.component';

describe('HideMessageComponent', () => {
  let component: HideMessageComponent;
  let fixture: ComponentFixture<HideMessageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HideMessageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HideMessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
