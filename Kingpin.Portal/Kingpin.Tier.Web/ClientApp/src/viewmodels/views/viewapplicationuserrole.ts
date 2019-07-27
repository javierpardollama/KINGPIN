import { ViewApplicationRole } from './viewapplicationrole';
import { ViewApplicationUser } from './viewapplicationuser';

export interface ViewApplicationUserRole {
    ApplicationRole: ViewApplicationRole;
    ApplicationUser: ViewApplicationUser;
}