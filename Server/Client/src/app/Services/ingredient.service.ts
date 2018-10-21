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
/*
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Following } from '../../models/following';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable()
export class FollowingsService {
  constructor(private http: HttpClient) { }

  public addRelationship(following: Following): Observable<Following> {
    return this.http.post<Following>('http://localhost:5000/api/followings', following, httpOptions);
  }

  public checkOnRelationship(idBlogger: number, idSubscriber: number): Observable<boolean> {
    return this.http.get<boolean>('http://localhost:5000/api/followings/?idBlogger='
    + idBlogger + '&idSubscriber=' + idSubscriber);
  }

  public deleteRelationship(idBlogger: number, idSubscriber: number): Observable<{}> {
    return this.http.delete('http://localhost:5000/api/followings/?idBlogger='
     + idBlogger + '&idSubscriber=' + idSubscriber, httpOptions);
  }
}

*/
