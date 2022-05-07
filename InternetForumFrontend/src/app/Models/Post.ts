import { Community } from "./Community";
import { User } from "./User";

// NOTE: ? = null, ! = not null
export class Post{
    postId!: number;
    postTitle!: string;
    postContent?: string;
    imageUrl?: string;
    communityId?: number;
    communityName?: string;
    community!: Community;
    userId?: number;
    username?: string;
    user!: User;
    // NOTE: Added later, might cause probems
    isSpoiler?: boolean;
    //TODO: Link bi trebao biti nullable
    link!: boolean;
    upvotes?: number;
    viewsCount?: number;
}