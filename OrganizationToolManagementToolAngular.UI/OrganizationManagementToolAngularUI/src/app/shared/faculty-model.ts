export class FacultyModel {
    id: number=0;
    name: string = '';
    email: string = '';
    mobile: string = '';
    age: number;
    gender: string = '';
    deptId: number=0;
    deptName: string = '';
    department:DepartmentModel;
}

export class DepartmentModel{
    id: number=0;
    deptName: string;
}
