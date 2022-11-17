import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommentService } from 'src/app/services/comment.service';

@Component({
  selector: 'app-post-comment-button',
  templateUrl: './post-comment-button.component.html',
  styleUrls: ['./post-comment-button.component.css']
})
export class PostCommentButtonComponent implements OnInit {

  @Input() showComments:boolean = false;
  @Input() commentCount:number = 0;
  @Output() showCommentsChange:EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor() { }

  ngOnInit(): void {
  }

  onClick(){
    this.showComments = !this.showComments;
    this.showCommentsChange.emit(this.showComments);
  }

}
