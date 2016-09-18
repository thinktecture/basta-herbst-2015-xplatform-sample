import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {GeoLocation} from '../models/geoLocation';
import {AuthenticatedHttp} from './authenticatedHttp';
import {Player} from '../models/player';
import {NearByPlayer} from '../models/nearbyPlayer';

@Injectable()
export class PlayersService {
    constructor(private _http: AuthenticatedHttp) {
    }

    public findNearby(radius: number, coordinates: GeoLocation): Observable<NearByPlayer[]> {
        return this._http.get(`api/players/FindNearby?radius=${radius}&coordinate.latitude=${coordinates.latitude}&coordinate.longitude=${coordinates.longitude}`)
            .map(r => {
                return <NearByPlayer[]>r.json();
            });
    }

    public add(player: Player): Observable<string> {
        return this._http.post(`api/players/add`, JSON.stringify(player))
            .map(response => <string>response.json());
    }

    public update(player: any): Observable<string> {
        return this._http.put(`api/players/update`, JSON.stringify(player))
            .map(response => player.id);
    }

    public delete(id: string): Observable<string> {
        return this._http.delete(`api/players/remove?id=${id}`)
            .map(response => <string>response.text());
    }
}
