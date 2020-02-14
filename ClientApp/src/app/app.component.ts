import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { ReactiveFormsModule, FormGroup, FormControl,FormsModule} from '@angular/forms';
import { StageModel } from './stage.model';
import { StageService } from './stage.service';
import { PerformerModel } from './performer.model';
import { PerformerService } from './performer.service';
import { PerformanceService } from './performance.service';
import { PerformanceModel } from './performance.model';
import { dashCaseToCamelCase } from '@angular/compiler/src/util';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'ClientApp';

  stages: StageModel[];
  performers: PerformerModel[];
  performance: PerformanceModel[];

  stageForm: FormGroup;
  performerForm: FormGroup;
  performanceForm: FormGroup;

  constructor(private stageService: StageService, private performerService: PerformerService, private performancesService: PerformanceService) {
    this.stageForm = new FormGroup({
      name: new FormControl()
    });
    this.performerForm = new FormGroup({
      name: new FormControl(),
      description: new FormControl()
    });
    this.performanceForm = new FormGroup({
      performerId: new FormControl(),
      stageId: new FormControl(),
      startDateTime: new FormControl(),
      endDateTime: new FormControl(),
    });
  }

  // populate stages variable on initialise of page
  ngOnInit() {
    this.stageService.getStages().subscribe(data => {
      this.stages = data;
    });
    this.performerService.getPerformers().subscribe(data => {
      this.performers = data;
    })
    this.performancesService.getPerformances().subscribe(data => {
      this.performance = data;
    });
  }
  storeStage(){
    const stage: StageModel = {
      name: this.stageForm.controls.name.value
    };
    this.stageService.createStage(stage).subscribe();
    window.location.reload();
  }
  storePerformer(){
    const performer: PerformerModel = {
      name: this.performerForm.controls.name.value,
      description: this.performerForm.controls.description.value
    };
    this.performerService.createPerformer(performer).subscribe();
    window.location.reload();
  }
  storePerformance(){
    const performance: PerformanceModel = {
      stageId: this.performanceForm.controls.stageId.value,
      performerId: this.performanceForm.controls.performerId.value
    }
    console.log(performance);
    this.performancesService.createPerformance(performance,this.performanceForm.controls.startDateTime.value,this.performanceForm.controls.endDateTime.value).subscribe();
  }
  getPerformancesByStageForm(id: number){
    let performances: PerformanceModel[];
    this.performancesService.getPerformancesByStage(id).subscribe(data =>{
      performances = data
    });
    console.log(performances);
    return performances
  }
}


