import { Component, OnInit } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  value: any;

  constructor(private http: HttpClient) {
   }

  ngOnInit() {
    this.getvalues();
  }

  getvalues(){
    this.http.get('http://localhost:5000/api/values').subscribe(response => {
      this.value = response;
     }, error => {
       console.log(error);
        }
    );



  }

}
