import { ViewApplicationRole } from './viewapplicationrole';
import { ViewApplicationUser } from './viewapplicationuser';
import { ViewBase } from './viewbase';

export interface ViewApplicationUserRole extends ViewBase {
    ApplicationRole: ViewApplicationRole;
    ApplicationUser: ViewApplicationUser;
}