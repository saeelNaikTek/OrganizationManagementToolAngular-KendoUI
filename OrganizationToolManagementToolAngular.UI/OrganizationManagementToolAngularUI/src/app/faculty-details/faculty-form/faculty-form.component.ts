import { Component, OnInit } from '@angular/core';
import { FacultyService } from 'src/app/shared/faculty.service';
import {NgForm} from '@angular/forms';
import { FacultyModel } from 'src/app/shared/faculty-model';

@Component({
  selector: 'app-faculty-form',
  templateUrl: './faculty-form.component.html',
  styleUrls: ['./faculty-form.component.css']
})
export class FacultyFormComponent implements OnInit {

  constructor(public facService:FacultyService) { }

  ngOnInit(): void {
    this.getDepartmentList();
  }

  getDepartmentList() {
    this.facService.getDepartmentList().subscribe(data => {
      this.facService.listDepartment = data;
    });
  }
  submit(form:NgForm)
  {
    if(this.facService.facultyData.id == 0)
    this.insertFaculty(form);
    else
    this.insertFaculty(form);
  }

  insertFaculty(myForm:NgForm)
  {
    this.facService.saveFaculty().subscribe(d=>{
      this.resetForm(myForm);
      this.getAllFacultyList();
      console.log('Saved successfully');
    });
  }

  updateFaculty(myForm:NgForm)
  {
    this.facService.saveFaculty().subscribe(d=>{
      this.resetForm(myForm);
      this.getAllFacultyList();
      console.log('Update successfully');
    });
  }

  resetForm(myForm:NgForm)
  {
    myForm.form.reset();
    this.facService.facultyData = new FacultyModel();
  }
  
  getAllFacultyList() {
    this.facService.getAllFacultyList().subscribe(data => {
      this.facService.listFaculty = data;
    });
  }
}
