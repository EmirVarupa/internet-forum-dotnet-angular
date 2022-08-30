
import { Post } from "./Post";
import { PostCommentVote } from "./PostCommentVote";
import { User } from "./User";

export class PostComment {
    commentId?: number;
    postId!: number;
    post?: Post;
    userId!: number;
    user!: User;
    commentContent?: string;
    dateCreated?: Date;
    postCommentVote!: PostCommentVote;
}