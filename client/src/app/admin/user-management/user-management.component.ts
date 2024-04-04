import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { User } from 'src/app/_models/user';
import { AdminService } from 'src/app/_services/admin.service';
import { RolesModalComponent } from 'src/app/models/roles-modal/roles-modal.component';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css'],
})
export class UserManagementComponent implements OnInit {
  users: User[] = [];
  bsModalRef: BsModalRef<RolesModalComponent> =
    new BsModalRef<RolesModalComponent>();

  constructor(
    private adminServices: AdminService,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.getUsersWithRoles();
  }

  getUsersWithRoles() {
    this.adminServices.getUserWithRoles().subscribe({
      next: (users) => (this.users = users),
    });
  }

  openRolesModal() {
    const initialState: ModalOptions = {
      initialState: {
        list: ['Do thing', 'Another thing', 'Something elese'],
        title: 'Test modal',
      },
    };

    this.bsModalRef = this.modalService.show(RolesModalComponent, initialState);
    this.bsModalRef.content!.closeBtnName = 'Close';
  }
}
