import { Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { DecimalPipe } from '@angular/common';
import { Observable } from 'rxjs';
//import { NgbdSortableHeader, SortEvent } from './sortable.directive';
import { Yardsales } from '../../const/yardsales';

@Component({
  selector: 'app-current-yard-sales',
  templateUrl: './current-yard-sales.component.html',
  styleUrls: ['./current-yard-sales.component.css']
})
export class CurrentYardSalesComponent implements OnInit {

  sales = Yardsales;

  constructor() { }

  ngOnInit() {
  }

}
