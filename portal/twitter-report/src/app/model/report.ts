export interface Report {
  tweetsPerMinutes: number;
  tweetsPerSecond: number ;
  tweetsAmount: number ;
}


export class ServiceResult
{
    public result:Report | undefined
}
