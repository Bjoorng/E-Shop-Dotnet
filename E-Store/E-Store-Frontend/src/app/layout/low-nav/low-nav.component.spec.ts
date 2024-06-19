import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LowNavComponent } from './low-nav.component';

describe('LowNavComponent', () => {
  let component: LowNavComponent;
  let fixture: ComponentFixture<LowNavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LowNavComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LowNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
