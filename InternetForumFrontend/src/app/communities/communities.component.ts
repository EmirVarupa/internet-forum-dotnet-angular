import { Component, OnInit } from '@angular/core';
import { CommunitiesService } from '../Services/communities.service';

@Component({
  selector: 'app-communities',
  templateUrl: './communities.component.html',
  styleUrls: ['./communities.component.css']
})
export class CommunitiesComponent implements OnInit {

  title!: string;
  brojac!: number;

  brojevi!: any[];


  constructor(private service: CommunitiesService) { }

  ngOnInit(): void {
    this.title = 'Brojac';
    this.brojac = 0;

    //this.brojevi = this.service.getCommunities();
  }

  /**
   * Povecava brojac
   */
   povecajBrojac(): void{
    this.brojac++;
  }
}
