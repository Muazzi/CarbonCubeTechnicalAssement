import { Component, OnInit } from '@angular/core';
import { ColumnApi, GridApi, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { ICDObject } from 'src/app/Models/ICDObject';
import { WhoApiServiceService } from 'src/app/services/who-api-service.service';


@Component({
  selector: 'app-icd-display',
  templateUrl: './icd-display.component.html',
  styleUrls: ['./icd-display.component.css']
})
export class ICDDisplayComponent implements OnInit {
  private gridApi: GridApi;
  private columnApi: ColumnApi;
  public gridOptions: GridOptions;

  
 
  columnDefs = [
    {headerName: 'Title', field: 'title', sortable: true, filter: true, resizable:true
  },
    {headerName: 'Score', field: 'score', sortable: true, filter: true , resizable:true },
    {headerName: 'Code', field: 'theCode', sortable: true, filter: true , resizable:true}
];



rowData :ICDObject []=[];


  constructor(private WhoApi:WhoApiServiceService ) { }

  ngOnInit(): void {
    // this.WhoApi.SearchDiagnose('depression').subscribe(data=>{
     
    //   this.rowData = data;
    //   console.log(this.rowData);
      
    // })
  
    this.gridOptions = {
      columnDefs: this.columnDefs,
     
      autoSizePadding: 45,
      rowStyle: { 'font-size': '16px' }
    };
    
  
  }

  onGridReady(params: GridReadyEvent)
  {
    this.gridApi = params.api;
    this.columnApi = params.columnApi;
    this.gridApi.sizeColumnsToFit();

    //   this.WhoApi.SearchDiagnose('depression').subscribe(data=>{
     
    //  this.rowData = data;
    //  console.log(this.rowData);
    //  this.gridApi.setRowData(this.rowData);
      
    //  })
  }

  enterDiagnoses(event:any)
  {
    this.WhoApi.SearchDiagnose(event.target.value).subscribe(data=>{
     
      this.rowData = data;
      console.log(this.rowData);
      this.gridApi.setRowData(this.rowData);
       
      })
  }

}
