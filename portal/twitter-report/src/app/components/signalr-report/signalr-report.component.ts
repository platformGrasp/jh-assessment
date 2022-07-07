import { Component, OnInit } from '@angular/core';
import { SignalRService } from '../../services/signal-r.service';
import { StreamDataResponse } from 'src/app/model/stream-data-response';

@Component({
  selector: 'app-signalr-report',
  templateUrl: './signalr-report.component.html',
  styleUrls: ['./signalr-report.component.css']
})
export class SignalrReportComponent implements OnInit {

  public model: StreamDataResponse[] = [];
  constructor(private readonly _signalRService: SignalRService) { }

  ngOnInit(): void {
    this._signalRService.transferChartDataListenerFromSignalR().subscribe(data =>{
      this.model.push(data);
      console.warn(data);
    });
  }
}
