import {
  Component,
  OnInit,
  ViewChild
} from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { ViewApplicationUser } from './../../../../viewmodels/views/viewapplicationuser';

import { ApplicationUserService } from './../../../../services/applicationuser.service';

import {
  ApplicationUserUpdateModalComponent
} from './../../modals/updates/applicationuser-update-modal/applicationuser-update-modal.component';


@Component({
  selector: 'app-applicationuser-grid',
  templateUrl: './applicationuser-grid.component.html',
  styleUrls: ['./applicationuser-grid.component.css']
})
export class ApplicationUserGridComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  public ELEMENT_DATA: ViewApplicationUser[];

  public displayedColumns: string[] = ['Id', 'Email', 'ApplicationRoles', 'LastModified'];

  public dataSource: MatTableDataSource<ViewApplicationUser>;

  // Constructor
  constructor(
    private applicationUserService: ApplicationUserService,
    public matDialog: MatDialog) {

  }

  // Life Cicle
  ngOnInit() {
    this.FindAllApplicationUser();
  }

  // Get Data from Service
  public FindAllApplicationUser() {
    this.applicationUserService.FindAllApplicationUser().subscribe(applicationUsers => {
      this.ELEMENT_DATA = applicationUsers;

      this.SetupMyTableSettings();
    });
  }

  // Setup Table Settings
  public SetupMyTableSettings() {
    this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  // Filter Data
  public ApplyMyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  // Get Record from Table
  public GetRecord(row: ViewApplicationUser) {
    const dialogRef = this.matDialog.open(ApplicationUserUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllApplicationUser();
    });
  }
}
