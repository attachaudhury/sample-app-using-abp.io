import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyDto, CompanyService } from '@proxy/companies';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';


@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.scss'],
  providers: [ListService],
})
export class CompanyComponent implements OnInit {
  book = { items: [], totalCount: 0 } as PagedResultDto<CompanyDto>;
  selectedBook = {} as CompanyDto; // declare selectedBook
  form: FormGroup; // add this line
  isModalOpen = false; // add this lin
  constructor(public readonly list: ListService, private bookService: CompanyService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService // inject the ConfirmationService

    ) {}

  ngOnInit() {
    const bookStreamCreator = (query) => this.bookService.getList(query);

    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.book = response;
    });
  }

  createBook() {
    this.buildForm(); // add this line
    this.isModalOpen = true;
  }

  editBook(id: string) {
    this.bookService.get(id).subscribe((book) => {
      this.selectedBook = book;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      creteadDate: [null, Validators.required],
    });
  }

  // add save method
  save() {
    if (this.form.invalid) {
      return;
    }

    
    var obj = {name:this.form.value.name,creteadDate:this.form.value.creteadDate.year+"-0"+this.form.value.creteadDate.month+"-0"+this.form.value.creteadDate.day};
    console.log(this.form.value);
    console.log(obj);

    const request = this.selectedBook.id
      ? this.bookService.update(this.selectedBook.id, obj)
      : this.bookService.create(obj);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.bookService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

}
