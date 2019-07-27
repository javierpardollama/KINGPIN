import { ViewKey } from './viewkey';
import { ViewApplicationUserRole } from './viewapplicationuserrole';
import { ViewApplicationRole } from './viewapplicationrole';
import { ViewApplicationUserToken } from './viewapplicationusertoken';

export interface ViewApplicationUser extends ViewKey {
  Email: string;
  ApplicationUserRoles: ViewApplicationUserRole[];
  ApplicationRoles: ViewApplicationRole[];
  ApplicationUserTokens: ViewApplicationUserToken[];
  ApplicationUserToken: ViewApplicationUserToken;
}
