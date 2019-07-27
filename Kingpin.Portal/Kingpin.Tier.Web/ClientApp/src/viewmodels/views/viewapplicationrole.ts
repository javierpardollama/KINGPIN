import { ViewKey } from './viewkey';
import { ViewApplicationUserRole } from './viewapplicationuserrole';
import { ViewApplicationUser } from './viewapplicationuser';

export interface ViewApplicationRole extends ViewKey {
  Name: string;
  ApplicationUserRoles: ViewApplicationUserRole[];
  ApplicationUsers: ViewApplicationUser[];
}
