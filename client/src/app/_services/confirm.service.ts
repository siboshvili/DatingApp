import { Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { initialState } from 'ngx-bootstrap/timepicker/reducer/timepicker.reducer';
import { ConfirmDialogComponent } from '../modals/confirm-dialog/confirm-dialog.component';

@Injectable({
  providedIn: 'root',
})
export class ConfirmService {
  bsModalRef?: BsModalRef<ConfirmDialogComponent>;

  constructor(private modalService: BsModalService) {}

  confirm(
    title = 'Confirmation',
    message = 'Are you sure you want to do this?',
    btnText = 'Ok',
    btnCancelText = 'Cancel'
  ) {
    const confirm = {
      initialState: {
        title,
        message,
        btnText,
        btnCancelText,
      },
    };
    this.bsModalRef = this.modalService.show(ConfirmDialogComponent, confirm);
  }
}
