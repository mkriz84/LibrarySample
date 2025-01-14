import { Component, OnInit } from '@angular/core';
import { IMember } from 'src/app/adminmodule/members/members';
import { UserOwnedService } from 'src/app/userServices/user-owned.service';
import { AdminMembersService } from 'src/app/adminServices/admin-members.service';
import { FormBuilder, Validators } from '@angular/forms';
import { AdminBooksService } from 'src/app/adminServices/admin-books.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  userProfile;
  userid;
  mode;
  id;
  bookName;
  bookSearch;
  adminMembersUp;
  stringList:any;
  public members = [];
  constructor(private userDet: UserOwnedService, private bookSer: AdminBooksService, private memberSer: AdminMembersService, private fbd: FormBuilder, ) { 

    this.bookSearch="";
  }

  ngOnInit() {
    //local storage
    if (sessionStorage) {
      this.userid = sessionStorage.getItem("userid");  
      this.mode =sessionStorage.getItem("mode");
      this.bookName= sessionStorage.getItem("BookName");
      this.id= sessionStorage.getItem("BookId");
 
      if (this.userid != null) { }
    }

    if  (this.mode='Match'){

      this.getMostCommonWords(this.id);
    } else{

      this.stringList= null;
    }
    // this.getUser();
    this.get(this.userid);
    console.log(this.userProfile);
    this.getMember();



    this.adminMembersUp = this.fbd.group({
      uname: ['', [Validators.required, Validators.minLength(5)]],
      uadmid: ['', [Validators.required, Validators.minLength(5)]],
      umail: ['', [Validators.required, Validators.email]],
      udep: ['', [Validators.required]],
      upassword: ['', [Validators.required, Validators.minLength(8),]],

    })
  }

  get(userid: number) {
    this.userDet.getUser(userid)
      .subscribe(data => this.userProfile = data);
  }

  TextSearch()
  {
   
    var Txt = this.bookSearch;
    this.SearchWithText(this.id,Txt)

  }
  getMostCommonWords(id: number) {
    this.bookSer.getMostCommonWords(id)
    .subscribe(data => this.stringList = data);
  }

  SearchWithText(id: number,txt:string) {
    this.bookSer.SearchWithText(id,txt)
      .subscribe(data => this.stringList = data);
  }
  edit(member: IMember) {
    this.memberSer.currentMember = Object.assign({}, member)
  }



  update(member: IMember) {
    this.memberSer.updateMember(member).subscribe();
  }

  getMember() {
    this.memberSer.getMember()
      .subscribe(data => this.members = data);
  }

  OnUpdate(currentMember) {
    console.log(currentMember.id);
    if (currentMember.id != null) {
      console.log("Update!!");
      console.log("Update!!");


      let mailCheck: Boolean;
      let admidCheck: Boolean;
      this.members.forEach(member => {
        console.log(currentMember.umail)
        console.log(member.umail)
        if (member.umail == currentMember.umail && member.id != currentMember.id) {
          mailCheck = false;
        } else { }
        if (member.uadmid == currentMember.uadmid && member.id != currentMember.id) {
          admidCheck = false;
        } else { }
      })
      if (mailCheck == false || admidCheck == false) {
        if (mailCheck == false && admidCheck == false) {
          alert("Email id and admission id are already existing...");
        }
        else if (admidCheck == false) {
          alert("Admission id is already existing...");
        }
        else {
          alert("Email id is already existing...");
        }
      } else {
        /*logic for to add member details*/
        let cnf = confirm("Press Ok to change your details..");
        if (cnf == true) {
          this.update(currentMember);
        }
        else { }
      }

      // let cnf = confirm("Press Ok to update the user..");
      // if (cnf == true) {
      //   this.update(currentMember);
      // }
      // else { }
    }
    else { }
  }
}
