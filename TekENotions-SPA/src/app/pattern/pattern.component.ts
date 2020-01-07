import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from 'util';

@Component({
    selector: 'app-pattern',
    templateUrl: './pattern.component.html',
    styleUrls: ['./pattern.component.css']
})
// tslint:disable-next-line: jsdoc-format
/** pattern component*/
export class PatternComponent implements OnInit {
  values: any;
    /** pattern ctor */
    constructor(private http: HttpClient) {  }
  ngOnInit() {
    this.getPatterns();

  }
  getPatterns() {
    this.http.get('http://localhost:5000/api/patterns').subscribe(response => {
      this.values = response;
    // tslint:disable-next-line: no-shadowed-variable
    }, error => {
          console.log(error); });
  }
}
