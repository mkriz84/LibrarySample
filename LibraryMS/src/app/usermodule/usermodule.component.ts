import { Component, OnInit  } from '@angular/core';

import { UserOwnedService } from '../userServices/user-owned.service';
import { IMember } from '../adminmodule/members/members';
import { AdminMembersService } from '../adminServices/admin-members.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usermodule',
  templateUrl: './usermodule.component.html',
  styleUrls: ['./usermodule.component.css']
})
export class UsermoduleComponent implements OnInit {

  userid;
  mode ;
  userProfile;
  constructor(private userDet: UserOwnedService,private router: Router ) { }

  ngOnInit() {
    if (sessionStorage) {
      this.userid = sessionStorage.getItem("userid");
      if (this.userid != null) { }
    }
    this.get(this.userid);



  }


  SelectedMode(mode:string){

    sessionStorage.setItem("mode",mode);
     this.mode = sessionStorage.getItem("mode");
    if(this.mode == 'Search')
    this.router.navigate(['user/profile1']);
    else if(this.mode == 'Most')
    this.router.navigate(['user/profile']);
  
  }


  get(id: number) {
    this.userDet.getUser(id)
      .subscribe(data => this.userProfile = data);

  }

  resetSession() {
    sessionStorage.removeItem("userid");

  }

}
