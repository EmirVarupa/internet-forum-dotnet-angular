import { Post } from "./Post";
import { UserPostVote } from "./UserPostVote";

// NOTE: ? = null, ! = not null
export class PostVote{ 
        voteId?: number;
        voteCount!: number;
        postId?: number;
        post?: Post;
        userPostVotes?: UserPostVote;
}