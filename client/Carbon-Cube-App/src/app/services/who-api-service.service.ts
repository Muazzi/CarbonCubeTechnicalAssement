import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ICDObject } from '../Models/ICDObject';

@Injectable({
  providedIn: 'root'
})
export class WhoApiServiceService {

  constructor(private HttpClient: HttpClient) { }
 

  SearchDiagnose(term:string)
  {
    return this.HttpClient.post<ICDObject[]>(environment.BaseUrl+'WhoICD/'+term,null);
  }

}
