import { Component, OnInit } from '@angular/core';
import { FacultyService } from '../shared/faculty.service';
import { FacultyModel } from '../shared/faculty-model';
import {NgForm} from '@angular/forms';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { SortDescriptor } from '@progress/kendo-data-query';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-faculty-details',
  templateUrl: './faculty-details.component.html',
  styleUrls: ['./faculty-details.component.css']
})
export class FacultyDetailsComponent implements OnInit {

  constructor(public facService:FacultyService) {}

  ngOnInit(): void {
    this.getAllFacultyList();
    this.getDepartmentList();
  }

  populateFaculty(selectedFaculty:FacultyModel = new FacultyModel()){
    console.log(selectedFaculty);
    this.facService.facultyData=selectedFaculty;
  }

  deleteFaculty(id: number) {
    if(confirm('Are you sure want to delete the record?')){
      this.facService.DeleteFaculty(id).subscribe(data => {
        console.log('Record Deleted');
        this.getAllFacultyList();
      });
    }
  }

  getDepartmentList() {
    this.facService.getDepartmentList().subscribe(data => {
      this.facService.listDepartment = data;
    });
  }

  getAllFacultyList() {
    this.facService.getAllFacultyList().subscribe(data => {
      this.facService.listFaculty = data;
    });
  }

  getFacultyList(temp: string) {
    this.facService.getFacultyList(temp).subscribe(data => {
      this.facService.listFaculty = [];
      this.facService.listFaculty = data;
    })
  }
  

}
