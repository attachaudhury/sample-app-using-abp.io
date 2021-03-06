import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/company-store',
        name: '::Menu:soludevabp',
        iconClass: 'fas fa-book',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/companies',
        name: '::Menu:Companies',
        parentName: '::Menu:soludevabp',
        layout: eLayoutType.application,
        requiredPolicy: 'soludevabp.Companies',
      },
      {
        path: '/listings',
        name: '::Menu:Listings',
        parentName: '::Menu:soludevabp',
        layout: eLayoutType.application,
        requiredPolicy: 'soludevabp.Listings',
      }
    ]);
  };
}
