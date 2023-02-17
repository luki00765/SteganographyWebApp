import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-cesar-cipher',
  templateUrl: './cesar-cipher.component.html',
  styleUrls: ['./cesar-cipher.component.css']
})

export class CesarCipherComponent {
  shift: string;
  baseUrl: string
  message: string;
  response: string;
  invalidFeedbackText: string = '';
  isShiftValid: boolean = false;
  checkboxValue: boolean = false;
  isMessageEmpty: boolean = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.message = "";
    this.shift = "";
    this.baseUrl = baseUrl;
  }

  onMessageChange() {
    this.checkIsMessageEmpty();
  }

  onShiftChange(event) {
    this.shift = event.target.value;
    this.validateShift();
  }

  checkIsMessageEmpty() {
    if (this.message.trim() === '') {
      this.isMessageEmpty = true;
    } else {
      this.isMessageEmpty = false;
    }
  }

  validateShift() {
    if (this.shift.trim() === "") {
      this.isShiftValid = true;
      this.invalidFeedbackText = 'Please write a message.';
    } else if (!/^\d+$/.test(this.shift.trim())) {
      this.isShiftValid = true;
      this.invalidFeedbackText = 'Please write a digit.';
    } else {
      this.isShiftValid = false;
    }
  }

  submitForm() {
    this.checkIsMessageEmpty();
    this.validateShift();

    let params = new HttpParams()
      .set('Message', this.message)
      .set('Shift', this.shift);

    let param = 'cipher/encrypt';
    if (this.checkboxValue == true)
      param = 'cipher/decrypt';

    this.http.post(this.baseUrl + param, params, { responseType: 'text' })
      .subscribe(data => {
        this.response = data;
      },
        error => {
          this.response = error.error;
        }
      );

    this.message = '';
    this.shift = '';
  }
}
