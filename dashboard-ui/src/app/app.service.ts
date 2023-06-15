import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {catchError, Observable, retry} from 'rxjs';
import {baseUrl} from './shared/globals';
import {DataTablesResponse} from "./shared/models/data-tables-response";

@Injectable({
  providedIn: 'root'
})
export class AppService {
  constructor(private httpClient: HttpClient) {
  }

  getDataTablesResponse(dataTablesParameters: any, urlParams = ''): Observable<DataTablesResponse> {
    return this.httpClient
      .post<DataTablesResponse>(
        baseUrl + '/customer' + urlParams,
        dataTablesParameters
      )
      .pipe(catchError(err => {
          throw new Error(err.error);
        }),
        retry(1));
  }

  get(urlParams: string): Observable<any> {
    return this.httpClient.get(baseUrl + urlParams)
      .pipe(
        catchError(err => {
          throw new Error(err.error);
        }),
        retry(1));
  }

}
