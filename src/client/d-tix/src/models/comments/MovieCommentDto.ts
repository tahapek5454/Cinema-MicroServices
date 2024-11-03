export default class MovieCommentDto{
    id: number;
    createdDate: Date;
    updatedDate?: Date | null;
    comment: string;
    movieId: number;
    userId: number;
    userName: string;
    likeCount: number;
    parentId?: number | null;
}