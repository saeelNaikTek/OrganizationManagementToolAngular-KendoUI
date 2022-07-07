import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FacultyModel, DepartmentModel } from './faculty-model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class FacultyService {

  constructor(private myhttp : HttpClient) { }

  readonly APIUrl = "https://localhost:44371/";
  listFaculty:FacultyModel[]=[];
  listDepartment:DepartmentModel[]=[];
  facultyData:FacultyModel=new FacultyModel();//for post/insert data;

  saveFaculty()
  {
    return this.myhttp.post(this.APIUrl+ 'api/Faculty/AddEditFaculty',this.facultyData);
  }

  updateFaculty()
  {
    return this.myhttp.put(`${this.APIUrl+'api/Faculty/AddEditFaculty'}/${this.facultyData.id}`,this.facultyData);
  }

  getAllFacultyList(): Observable<FacultyModel[]> {
    return this.myhttp.get<any>(this.APIUrl + 'api/Faculty/GetAllFaculty');
  }

  getFacultyList(temp: string): Observable<any[]> {
    return this.myhttp.get<any>(this.APIUrl + 'api/Faculty/GetFaculty/' + temp);
  }

  getDepartmentList(): Observable<DepartmentModel[]> {
    return this.myhttp.get<any>(this.APIUrl + 'api/Faculty/GetAllDepartments');
  }

  DeleteFaculty(id: number) {
    return this.myhttp.get<any>(this.APIUrl + 'api/Faculty/DeleteFaculty/' + id);
  }

}
