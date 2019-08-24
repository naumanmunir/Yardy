import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DataService } from 'src/app/data.service';
import { YardSale } from 'src/app/interfaces/yardsale';

@Component({
  selector: 'app-createsale',
  templateUrl: './createsale.component.html',
  styleUrls: ['./createsale.component.css']
})
export class CreatesaleComponent implements OnInit {

  submitted = false;
  success = false;
  saleForm: FormGroup

  constructor(private saleFormBuilder: FormBuilder, private dataService: DataService) {

    this.saleForm = this.saleFormBuilder.group(
      {
        title: ['', Validators.required],
        descr: ['', Validators.required], //character limit validation
        startDate: ['', Validators.required],
        endDate: ['', Validators.required]
      }
    )
  }

  ngOnInit() {
  }

  createSale(newSaleModel: YardSale) {

    
    this.submitted = true;
    //model valid?
    if (this.saleForm.valid) {
      this.success = true;

      console.log(newSaleModel);

      this.dataService.CreateYardSale(newSaleModel).subscribe();
    }
    else
      return;
    
  }

}
