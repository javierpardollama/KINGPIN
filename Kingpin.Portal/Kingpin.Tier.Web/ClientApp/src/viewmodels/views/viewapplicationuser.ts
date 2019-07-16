import { ViewBase } from './viewbase';
import { ViewApplicationUserRole } from './viewapplicationuserrole';
import { ViewApplicationRole } from './viewapplicationrole';

export interface ViewApplicationUser extends ViewBase {
  Email: string;
  ApplicationUserRoles: ViewApplicationUserRole[];
  ApplicationRoles: ViewApplicationRole[];
}
