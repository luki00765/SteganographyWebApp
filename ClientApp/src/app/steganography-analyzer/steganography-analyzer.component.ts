import { Component, Inject, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-steganography-analyzer',
  templateUrl: './steganography-analyzer.component.html',
  styleUrls: ['./steganography-analyzer.component.css']
})

export class SteganographyAnalyzerComponent {
  oryginalFile: File;
  stegoFile: File;
  response: string;
  baseUrl: string
  isOryginalFileInvalid: boolean = false;
  isStegoFileInvalid: boolean = false;
  @ViewChild('fileInput1') fileInput1;
  @ViewChild('fileInput2') fileInput2;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  onOryginalFileChange(event) {
    this.oryginalFile = event.target.files[0];
    this.validateOryginalFile();
  }

  onStegoFileChange(event) {
    this.stegoFile = event.target.files[0];
    this.validateStegoFile(); 
  }

  validateOryginalFile() {
    if (!this.checkIsFileNull(this.oryginalFile)) {
      this.isOryginalFileInvalid = false;
    } else {
      this.isOryginalFileInvalid = true;
    }
  }

  validateStegoFile() {
    if (!this.checkIsFileNull(this.stegoFile)) {
      this.isStegoFileInvalid = false;
    } else {
      this.isStegoFileInvalid = true;
    }
  }

  checkIsFileNull(file: File): boolean {
    if (file == null || !file.size) { return true; } else { return false; }
  }

  analyze() {
    this.validateOryginalFile();
    this.validateStegoFile();

    let formData = new FormData();
    formData.append('oryginalFile', this.oryginalFile);
    formData.append('stegoFile', this.stegoFile);

    this.http.post(this.baseUrl + 'stego/analyze', formData, { responseType: 'text' })
      .subscribe(data => {
        this.response = data;
      },
        error => {
          this.response = error.error;
        });

    this.fileInput1.nativeElement.value = '';
    this.fileInput2.nativeElement.value = '';
    this.oryginalFile = null;
    this.stegoFile = null;
  }
}
