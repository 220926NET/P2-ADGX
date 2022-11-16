import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-post-like-counter',
  templateUrl: './post-like-counter.component.html',
  styleUrls: ['./post-like-counter.component.css']
})
export class PostLikeCounterComponent implements OnInit {

  @Input() postLikes:number=0;
  ngOnInit(): void {}
}
