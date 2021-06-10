import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ScriptService } from './service/scripService.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ElectionSystem';
  constructor(private scriptService: ScriptService,
    private route: Router) {
    console.log('Loading External Scripts');
    this.scriptService.load('FontAwesome', 'ButtonsJs');
  }
}
