import { ViewBase } from './viewbase';
import { ViewApplicationUserRole } from './viewapplicationuserrole';
import { ViewApplicationRole } from './viewapplicationrole';
import { ViewApplicationUserToken } from './viewapplicationusertoken';

export interface ViewApplicationUser extends ViewBase {
  Email: string;
  ApplicationUserRoles: ViewApplicationUserRole[];
  ApplicationRoles: ViewApplicationRole[];
  ApplicationUserTokens: ViewApplicationUserToken[];
  ApplicationUserToken: ViewApplicationUserToken;
}
