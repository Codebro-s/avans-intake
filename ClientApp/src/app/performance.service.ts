import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PerformanceModel } from './performance.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PerformanceService {
  url = 'https://localhost:44329';
  api = `${this.url}/api/performances`;

  constructor(private http: HttpClient) { }

  getPerformances(): Observable<PerformanceModel[]> {
    return this.http.get<PerformanceModel[]>(`${this.api}/`);
  }

  getPerformance(id: number): Observable<PerformanceModel> {
    return this.http.get<PerformanceModel>(`${this.api}/${id}`);
  }

  createPerformance(model: PerformanceModel,startDateTime: string, endDateTime: string): Observable<PerformanceModel> {
    return this.http.post<PerformanceModel>(`${this.api}/`, model, {params:{startDateTime: startDateTime, endDateTime: endDateTime } });
  }

  updatePerformance(id: number, model: PerformanceModel): Observable<PerformanceModel> {
    return this.http.put<PerformanceModel>(`${this.api}/${id}`, model);
  }

  deletePerformance(id: number): Observable<PerformanceModel> {
    return this.http.delete<PerformanceModel>(`${this.api}/${id}`);
  }
  getPerformancesByStage(id: number): Observable<PerformanceModel[]> {
    return this.http.get<PerformanceModel[]>(`${this.api}/stage/${id}`);
  }
}
