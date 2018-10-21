import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Ingredient } from '../Models/ingredient';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class IngredientService {

  constructor(private http: HttpClient) { }

  public addRelationship(ingredient: Ingredient): Observable<Ingredient> {
    return this.http.post<Ingredient>(window.location.href, ingredient, httpOptions);
  }
}

