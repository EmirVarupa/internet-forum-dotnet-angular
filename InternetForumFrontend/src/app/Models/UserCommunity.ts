import { Community } from "./Community";
import { User } from "./User";

export class UserCommunity {
    userId?: number;
    user?: User;
    communityId?: number;
    community?: Community;
    isJoined!: boolean;
    role!: string;
}