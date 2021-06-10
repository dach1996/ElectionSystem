import { Injectable } from '@angular/core';
import { UserBaseResponse } from '../serviceApi/models';

@Injectable({
  providedIn: 'root',
})
export class StorageCache {

  public get Token(): string | undefined {
    return localStorage.getItem('token')!;
  }

  public get UserCurrent(): UserBaseResponse| undefined {
    return JSON.parse(localStorage.getItem('userCurrent')!) as UserBaseResponse;
  }

}
