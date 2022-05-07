
import { Post } from "./Post";
import { User } from "./User";

export class PostComment {
    commentId!: number;
    postId?: number;
    post!: Post;
    userId?: number;
    user!: User;
    commentContent!: string;
    dateCreated!: Date;
}