import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CesarCipherComponent } from './cesar-cipher.component';

describe('CesarCipherComponent', () => {
  let component: CesarCipherComponent;
  let fixture: ComponentFixture<CesarCipherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CesarCipherComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CesarCipherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
