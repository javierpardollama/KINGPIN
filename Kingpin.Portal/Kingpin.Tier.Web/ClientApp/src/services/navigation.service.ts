import { ViewLink } from './../viewmodels/views/viewlink';

import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})

export class NavigationService {

    public GetManagementNavigationLinks(): ViewLink[] {
        return [
            {
                Label: 'Application Roles',
                Link: './applicationroles',
                Index: 0,
                Class:'management-menu-option-image management-menu-roles-image'
            }, {
                Label: 'Application Users',
                Link: './applicationusers',
                Index: 1,
                Class:'management-menu-option-image management-menu-users-image'
            }
        ];
    }

    public GetHomeNavigationLinks(): ViewLink[] {
        return [
            {
                Label: 'Managenent',
                Link: './management',
                Index: 0,
                Class:'home-menu-option-image home-menu-management-image'
            }, {
                Label: 'Security',
                Link: './security',
                Index: 1,
                Class:'home-menu-option-image home-menu-security-image'
            }
        ];
    }
}
