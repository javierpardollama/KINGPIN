
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog } from '@angular/material';
import { ViewApplicationRole } from './../../../../viewmodels/views/viewapplicationrole';

import { ApplicationRoleService } from './../../../../services/applicationrole.service.module';

import { ApplicationRoleUpdateModalComponent } from './../../modals/updates/applicationrole-update-modal/applicationrole-update-modal.component';
import { ApplicationRoleAddModalComponent } from './../../modals/additions/applicationrole-add-modal/applicationrole-add-modal.component';

@Component({
  selector: 'app-applicationrole-grid',
  templateUrl: './applicationrole-grid.component.html',
  styleUrls: ['./applicationrole-grid.component.css']
})
export class ApplicationRoleGridComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  public ELEMENT_DATA: ViewApplicationRole[];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewApplicationRole>;

  // Constructor
  constructor(private applicationRoleService: ApplicationRoleService,
    public matDialog: MatDialog) {

  }

  // Life Cicle
  ngOnInit() {
    this.FindAllApplicationRole();
  }

  // Get Data from Service
  public FindAllApplicationRole() {
    this.applicationRoleService.FindAllApplicationRole().subscribe(applicationRoles => {
      this.ELEMENT_DATA = applicationRoles;

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
  public GetRecord(row: ViewApplicationRole) {
    const dialogRef = this.matDialog.open(ApplicationRoleUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllApplicationRole();
    });
  }

  public AddRecord() {
    const dialogRef = this.matDialog.open(ApplicationRoleAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllApplicationRole();
    });
  }
}
