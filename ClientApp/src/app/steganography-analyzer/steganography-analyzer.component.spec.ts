import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SteganographyAnalyzerComponent } from './steganography-analyzer.component';

describe('SteganographyAnalyzerComponent', () => {
  let component: SteganographyAnalyzerComponent;
  let fixture: ComponentFixture<SteganographyAnalyzerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SteganographyAnalyzerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SteganographyAnalyzerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
