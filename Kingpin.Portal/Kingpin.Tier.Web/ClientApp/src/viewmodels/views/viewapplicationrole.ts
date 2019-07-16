import { ViewBase } from './viewbase';
import { ViewApplicationUserRole } from './viewapplicationuserrole';
import { ViewApplicationUser } from './viewapplicationuser';

export interface ViewApplicationRole extends ViewBase {
  Name: string;
  ApplicationUserRoles: ViewApplicationUserRole[];
  ApplicationUsers: ViewApplicationUser[];
}
