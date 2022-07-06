import { DataResponse } from '../model/data-response';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from './../../environments/environment';
import { Report, ServiceResult } from '../model/report';

@Injectable({
  providedIn: 'root'
})
export class TwitterService {
  constructor(
    private http: HttpClient) { }

  public GetTwitter(id: string): Observable<DataResponse> {
    return this.http
      .get<DataResponse>(
        `${environment.apiUrl}/Twitter/${id}`
      );
  }

  public GetReport(): Observable<ServiceResult> {
    return this.http
      .get<ServiceResult>(
        `${environment.apiUrl}/Report`
      );
  }
}
