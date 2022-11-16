export interface Post {
  postID: number;
  userID: number;
  title: string;
  text: string;
  datePosted: Date;
  image: any;
  imageUrl?: string,
  description?:string
  isTextPost: string;
}
