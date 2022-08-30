import { PostVote } from "./PostVote";
import { User } from "./User";

// NOTE: ? = null, ! = not null
export class UserPostVote {
        userId?: number;
        user?: User;
        postVote?: PostVote;
        postVoteId?: number;
        postVoteDirection!: number;
}