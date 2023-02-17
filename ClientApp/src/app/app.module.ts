import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CesarCipherComponent } from './cesar-cipher/cesar-cipher.component';
import { VigenereCipherComponent } from './vigenere-cipher/vigenere-cipher.component';
import { HideMessageComponent } from './hide-message/hide-message.component';
import { ExtractMessageComponent } from './extract-message/extract-message.component';
import { SteganographyAnalyzerComponent } from './steganography-analyzer/steganography-analyzer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CesarCipherComponent,
    VigenereCipherComponent,
    HideMessageComponent,
    ExtractMessageComponent,
    SteganographyAnalyzerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HideMessageComponent, pathMatch: 'full' },
      { path: 'cesar-cipher', component: CesarCipherComponent },
      { path: 'vigenere-cipher', component: VigenereCipherComponent },
      { path: 'hide-message', component: HideMessageComponent },
      { path: 'extract-message', component: ExtractMessageComponent },
      { path: 'steganography-analyzer', component: SteganographyAnalyzerComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
