import { Component, OnInit } from '@angular/core';
import {CRUDService} from "../services/crud.service";

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  columnDefs = [
    { field: 'id', headerName:'Id' , sortable:true},
    { field: 'name' , headerName:'Product Name' },
    { field: 'price' , headerName:'Price', sortable:true},
    { field: 'createdDate', headerName:'Created Date'},
    {field: '', headerName: 'Actions', cellRenderer:this.actionRender, width:250}
  ];

  rowData: any = [];

  gridOptions ={
    rowHeight: 50
  };
  producList: any = [];
  productListSubscribe: any;
  constructor(private crudService: CRUDService) { }

  ngOnInit(): void {
    this.getProductList();
  }

  getProductList(){

    this.productListSubscribe = this.crudService.loadProducts().subscribe(res => {
      this.producList = res;

      this.rowData = res;
      console.log('res',res)
    })
  }

  actionRender(params: any){

    let div = document.createElement('div');
    let htmlCode = '    <button type="button" class="btn btn-success">View</button>\n' +
      '    <button type="button" class="btn btn-danger">Delete</button>\n' +
      '    <button type="button" class="btn btn-warning">Edit</button>'

    div.innerHTML = htmlCode;

    return div;
  }

}
