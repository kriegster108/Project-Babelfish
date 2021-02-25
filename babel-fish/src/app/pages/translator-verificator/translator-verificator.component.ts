import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';

@Component({
  selector: 'app-translator-verificator',
  templateUrl: './translator-verificator.component.html',
  styleUrls: ['./translator-verificator.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [
    trigger('slide', [
      state('left', style({ transform: 'translateX(0)' })),
      state('right', style({ transform: 'translateX(-50%)' })),
      transition('* => *', animate(300))
  ])
]
})

export class TranslatorVerificatorComponent implements OnInit {

  @Input() activePane: PaneType = 'left';

  isLeftVisible = true;

  constructor() {

  }

  ngOnInit(): void {

  }

}

type PaneType = 'left' | 'right';
