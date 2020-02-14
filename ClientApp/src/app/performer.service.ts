import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PerformerModel } from './performer.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PerformerService {
  url = 'https://localhost:44329';
  api = `${this.url}/api/performers`;

  constructor(private http: HttpClient) { }

  getPerformers(): Observable<PerformerModel[]> {
    return this.http.get<PerformerModel[]>(`${this.api}/`);
  }

  getPerformer(id: number): Observable<PerformerModel> {
    return this.http.get<PerformerModel>(`${this.api}/${id}`);
  }

  createPerformer(model: PerformerModel): void {
    this.http.post<PerformerModel>(`${this.api}/`, model);
  }

  updatePerformer(id: number, model: PerformerModel): void {
    this.http.put<PerformerModel>(`${this.api}/${id}`, model);
  }

  deletePerformer(id: number): void {
    this.http.delete<PerformerModel>(`${this.api}/${id}`);
  }
}
