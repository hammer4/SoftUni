import {Pipe, PipeTransform} from '@angular/core'

@Pipe({
  name: 'turbo'
})

export class TurboPipe implements PipeTransform {
  transform (value: string) {
    return value + ' TURBO'
  }
}