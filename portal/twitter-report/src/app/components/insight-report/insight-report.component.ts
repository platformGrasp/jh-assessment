import { Component, DoCheck, Input, OnInit } from '@angular/core';

import { DataResponse } from 'src/app/model/data-response';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { StreamDataResponse } from '../../model/stream-data-response';
import { TwitterService } from '../../services/twitter.service';
import * as moment from 'moment';
import { Report } from '../../model/report';

@Component({
  selector: 'app-insight-report',
  templateUrl: './insight-report.component.html',
  styleUrls: ['./insight-report.component.css']
})
export class InsightReportComponent implements OnInit, DoCheck  {
  public now: Date = new Date();
  public initDate: Date = new Date();
  public duration: number = 0;
  public latestReport: Report | undefined ;
  @Input()
  public model: StreamDataResponse[] = [];
  public subModel: StreamDataResponse[] = [];
  public selectedTwitter: DataResponse | undefined;

  constructor(
    private readonly _modalService: NgbModal,
    private readonly _twitterService: TwitterService) {

      setInterval(() => {
        this.now = new Date();
      }, 1);

      setInterval(() => {
        this.duration = moment.duration(moment().diff(this.initDate)).asMinutes();
      }, 1);


      setInterval(() => {
        this.getReport();
      }, 2000);

    }
  ngDoCheck(): void {
    if(this.subModel.length < 20)
      this.subModel = this.model.slice(0, 10)
  }

  ngOnInit(): void {
  }

  getReport() {
    this._twitterService.GetReport().subscribe(data => {
      this.latestReport = data.result;
    })
  }

  open(content: any, item: StreamDataResponse) {
    this._twitterService.GetTwitter(item.id).subscribe(data => {
      this.selectedTwitter = data;
      this._modalService.open(content, {
        centered: true,
        backdrop: 'static'
      });
    })
  }
}
