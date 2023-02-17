import { Component, ViewChild, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { saveAs } from 'file-saver';


@Component({
  selector: 'app-hide-message',
  templateUrl: './hide-message.component.html',
  styleUrls: ['./hide-message.component.css']
})

export class HideMessageComponent {
  file: File;
  message: string;
  baseUrl: string
  response: string;
  isFileInvalid: boolean = false;
  isMessageEmpty: boolean = false;
  @ViewChild('fileInput') fileInput;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.message = '';
  }

  onFileChange(event) {
    this.file = event.target.files[0];
    this.validateFile();
  }

  onMessageChange() {
    this.checkIsMessageEmpty();
  }

  checkIsMessageEmpty() {
    if (this.message.trim() === '') {
      this.isMessageEmpty = true;
    } else {
      this.isMessageEmpty = false;
    }
  }

  validateFile() {
    if (this.file == null || !this.file.size) {
      this.isFileInvalid = true;
    } else {
      this.isFileInvalid = false;
    }
  }

  hide() {

    this.validateFile();
    this.checkIsMessageEmpty();

    let formData = new FormData();
    formData.append('formFile', this.file);
    formData.append('message', this.message);

    this.http.post(this.baseUrl + 'stego/hide', formData, { responseType: 'blob' })
      .subscribe(data => {
        let blob = new Blob([data], { type: 'application/octet-stream' });
        const extension = data.type.split('/')[1];
        saveAs(blob, 'response.' + extension);
        this.response = 'Downloading a file with a hidden message has started.';
      },
        error => {
          let reader = new FileReader();
          reader.readAsText(error.error);
          reader.onload = () => {
            this.response = reader.result.toString();
          }
        });

    this.message = '';
    this.fileInput.nativeElement.value = '';
    this.file = null;
  }
}
