import { ViewTab } from './../viewmodels/views/viewtab';

import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})

export class NavigationService {

    public GetManagementNavigationTabs(): ViewTab[] {
        return [
            {
                Label: 'Application Roles',
                Link: './applicationroles',
                Index: 0
            }, {
                Label: 'Application Users',
                Link: './applicationusers',
                Index: 1
            }
        ];
    }
}
