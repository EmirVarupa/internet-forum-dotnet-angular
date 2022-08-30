import { PostComment } from "./PostComment";
import { UserPostCommentVote } from "./UserPostCommentVote";


// NOTE: ? = null, ! = not null
export class PostCommentVote{ 
        voteId?: number;
        voteCount!: number;
        postCommentId?: number;
        postComment?: PostComment;
        userPostCommentVotes?: UserPostCommentVote;
}