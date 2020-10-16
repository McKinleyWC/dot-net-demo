import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public results: Result[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Result[]>(baseUrl + 'api/results').subscribe(result => {
      this.results = result;
    }, error => console.error(error));
  }
}

interface Result {
  resource_id: string;
  fields: Field[];
  records: Record[];
  _links: _Links;
  limit: number;
  total: number;
}

interface Field {
  ResultId: string;
  type: string;
  id: string;
}

interface Record {
  ResultId: string;
  _id: string;
  _5Bills: string;
  _50Bills: string;
  _1Bills: string;
  _10Bills: string;
  _100Bills: string;
  _2Bills: string;
  _20Bills: string;
  FiscalYear: string;
}

interface _Links {
  ResultId: string;
  start: string;
  next: string;
}
