import { Injectable } from '@angular/core';
import { NgRedux } from 'ng2-redux';
import { IAppState } from '..';
import { StatsService } from '../../stats/stats.service';

export const STATS_REQUESTED = 'stats/REQUESTED';

@Injectable()
export class StatsActions {
  constructor (
    private statsService: StatsService,
    private ngRedux: NgRedux<IAppState>
  ) { }
  
  get () {
    return this.statsService
    .get()
    .subscribe(stats => {
      this.ngRedux.dispatch({
        type: STATS_REQUESTED,
        stats
      })
    });
  }
}