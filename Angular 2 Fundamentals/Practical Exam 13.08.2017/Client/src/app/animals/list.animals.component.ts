import {Component, OnInit} from '@angular/core'
import {AnimalsService} from './animal.service'
import {Router, ActivatedRoute} from '@angular/router'

@Component({
  selector: 'list-animals',
  templateUrl: './list.animals.component.html',
  styleUrls: ['./list.animals.component.css']
})

export class ListAnimalsComponent implements OnInit {
  usersCount: number;
  animalsCount: number;
  page: number = 1;
  searchText: string = ''
  animals: Array<object> = null;

  constructor (private animalsService: AnimalsService, private router: Router, private route: ActivatedRoute) {}

  ngOnInit () {
    this.animalsService.getStats().subscribe(res => {
      this.usersCount = res.users;
      this.animalsCount = res.animals;
    });
    this.route.queryParams.subscribe(params => {
      this.page = +params.page || 1;
      this.searchText = params.search;
      this.animalsService.allAnimals(this.page, this.searchText).subscribe(res => this.animals = res);
    })
  }

  search () {
    this.router.navigateByUrl(`/?search=${this.searchText}`);
  }

  prevPage () {
    if (this.page === 1) {
      return;
    }

    const url = this.getUrl(this.page - 1);
    this.router.navigateByUrl(url);
  }

  nextPage () {
    if (this.animals.length === 0 || this.animals.length < 10) {
      return;
    }
    const url = this.getUrl(this.page + 1);
    this.router.navigateByUrl(url);
  }

  private getUrl(page) {
    let url = `/?page=${page}`;
    if (this.searchText) {
      url += `&search=${this.searchText }`;
    }
    
    return url;
  }
}