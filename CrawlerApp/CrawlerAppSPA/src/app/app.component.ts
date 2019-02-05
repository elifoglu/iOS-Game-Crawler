import { Component } from '@angular/core';
import { DataService } from './data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'iOS Games';
  games: object;
  letters: string[] = new Array(26);
  nums: number[] = new Array(15);
  selectedLetter = 'A';
  selectedNum = 1;
  loading = 'Loading...';

  constructor(private dataService: DataService) {
    for (let i = 65; i < 91; i++) {
      this.letters[i - 65] = String.fromCharCode(i);
    }
    for (let i = 0; i < 15; i++) {
      this.nums[i] = i + 1;
    }
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit(): void {
    this.getApps();
  }

  setLetter(letter: string) {
    if (this.loading.length > 0) {
      return;
    }
    this.loading = 'Loading...';
    this.selectedLetter = letter;
    this.selectedNum = 1;
    this.getApps();
  }

  setNum(num: number) {
    if (this.loading.length > 0) {
      return;
    }
    this.loading = 'Loading...';
    this.selectedNum = num;
    this.getApps();
  }

  getApps() {
    this.dataService.getApps(this.selectedLetter, this.selectedNum).subscribe(data => {
      if (data != null) {
        this.games = data;
      } else {
      }
      this.loading = '';
    });
  }
}
