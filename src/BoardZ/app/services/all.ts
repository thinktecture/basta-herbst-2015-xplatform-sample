import {provide} from 'angular2/core';
import {ApplicationConfiguration, Configuration} from '../app-config';
import {ConnectionBackend, XHRBackend} from 'angular2/http';
import {AuthenticatedHttp} from './authenticated.http';
import {LoginService} from './login.service';
import {LogLevel} from '../models/loglevel';
import {GamesService} from './games.service';
import {GeolocationService} from './geolocation.service';
import {PlayersService} from './players.service';
import {NotificationService} from './notification.service';
import {SignalRService} from './signalr.service';
import {UiNotificationService} from './ui.notification.service';
import {CameraService} from './camera.service';
import {DesktopCameraService} from './desktop.camera.service';
import {MobileCameraService} from './mobile.camera.service';

declare var window;

export var APP_SERVICES = [
    provide(Configuration, { useValue: new ApplicationConfiguration() }),
    provide(ConnectionBackend, { useClass: XHRBackend }),
    provide(AuthenticatedHttp, { useClass: AuthenticatedHttp }),
    provide(LoginService, { useClass: LoginService }),
    provide(LogLevel, { useValue: LogLevel }),
    provide(GamesService, { useClass: GamesService }),
    provide(GeolocationService, { useClass: GeolocationService }),
    provide(PlayersService, { useClass: PlayersService }),
    provide(NotificationService, { useClass: NotificationService }),
    provide(CameraService, { useClass: window.cordova ? MobileCameraService : DesktopCameraService }),
    UiNotificationService,
    SignalRService,
];
