import { PostCommentVote } from "./PostCommentVote";
import { User } from "./User";

// NOTE: ? = null, ! = not null
export class UserPostCommentVote {
        userId?: number;
        user?: User;
        postCommentVote?: PostCommentVote;
        postCommentVoteId?: number;
        postCommentVoteDirection!: number;
}