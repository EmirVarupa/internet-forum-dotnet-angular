import { Community } from "./Community";
import { PostVote } from "./PostVote";
import { User } from "./User";

// NOTE: ? = null, ! = not null
export class Post{
    postId!: number;
    postTitle!: string;
    postContent?: string;
    imageUrl?: string;
    communityId?: number;
    community!: Community;
    userId?: number;
    username?: string;
    user!: User;
    isSpoiler?: boolean;
    link?: number;
    upvotes?: number;
    dateCreated!: Date;
    viewsCount!: number;
    postVote! : PostVote
    isArchived?: boolean;
}