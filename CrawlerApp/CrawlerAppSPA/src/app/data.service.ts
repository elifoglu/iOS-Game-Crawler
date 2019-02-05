import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constURL = 'http://localhost:5000/api/crawl?';

  constructor(private http: HttpClient) { 
   
  }

  getApps(letter: string, index: number): any {
    let url = this.constURL;
    url += 'letter=' + letter;
    url += '&pageIndex=' + index;
    return this.http.get(url);
  }

}
