import { Component, ViewChild, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-extract-message',
  templateUrl: './extract-message.component.html',
  styleUrls: ['./extract-message.component.css']
})

export class ExtractMessageComponent {
  file: File;
  response: string;
  baseUrl: string
  isFileInvalid: boolean = false;
  @ViewChild('fileInput') fileInput;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  onFileChange(event) {
    this.file = event.target.files[0];
    this.validateFile();
  }

  validateFile() {
    if (this.file == null || !this.file.size) {
      this.isFileInvalid = true;
    } else {
      this.isFileInvalid = false;
    }
  }

  extract() {
    this.validateFile();

    let formData = new FormData();
    formData.append('formFile', this.file);

    this.http.post(this.baseUrl + 'stego/extract', formData, { responseType: 'text' })
      .subscribe(data => {
        this.response = data;
      },
        error => {
          this.response = error.error;
        });

    this.fileInput.nativeElement.value = '';
    this.file = null;
  }
}
