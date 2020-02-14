import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { IStage } from './stage.model';
import { IPerformer } from './performer.model';
import { IPerformance } from './performance.model';
import { ReactiveFormsModule, FormGroup, FormControl,FormsModule} from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';

  stageForm = new FormGroup({
    name: new FormControl()
  });
  performerForm = new FormGroup({
    name: new FormControl(),
    description: new FormControl()
  });
  performanceForm = new FormGroup({
    performer: new FormControl(),
    stage: new FormControl(),
    startDateTime: new FormControl(),
    endDateTime: new FormControl()
  });
}

