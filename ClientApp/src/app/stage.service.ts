import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StageModel } from './stage.model';
import { Observable } from 'rxjs';

// decorator
@Injectable({
  providedIn: 'root'
})
export class StageService {
  url = 'https://localhost:44329';
  api = `${this.url}/api/stages`;

  constructor(private http: HttpClient) { }

  getStages(): Observable<StageModel[]> {
    return this.http.get<StageModel[]>(`${this.api}/`);
  }

  getStage(id: number): Observable<StageModel> {
    return this.http.get<StageModel>(`${this.api}/${id}`);
  }

  createStage(model: StageModel): Observable<StageModel> {
    return this.http.post<StageModel>(`${this.api}/`, model);
  }

  updateStage(id: number, model: StageModel): Observable<StageModel> {
    return this.http.put<StageModel>(`${this.api}/${id}`, model);
  }

  deleteStage(id: number): Observable<StageModel> {
    return this.http.delete<StageModel>(`${this.api}/${id}`);
  }
}
