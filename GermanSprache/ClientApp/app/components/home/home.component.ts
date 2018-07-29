import { Component, OnInit, Inject } from '@angular/core';
//import { PercentPipe } from '@angular/common';
//import { Router, ActivatedRoute } from '@angular/router';  
import { Http } from '@angular/http';


@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    public Englishinput = '';
    public Germanoutput = '';
    public Tamiloutput = '';
    public Description = '';
    constructor(public http: Http) {

    }

    save() {
        console.log('test');
        this.http.put('api/Language/Save', { German: this.Germanoutput, English: this.Englishinput, Tamil: this.Tamiloutput, Description: this.Description })
        .subscribe((data) => {
            console.log('test1');
        })
    }


}

export class TeamData {
    public Englishinput = '';
    public Germanoutput = '';
}