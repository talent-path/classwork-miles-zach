import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Piece, PieceType } from '../chess/Pieces/Piece';
import { Position } from '../chess/Position';

@Component({
  selector: 'app-chess-square',
  templateUrl: './chess-square.component.html',
  styleUrls: ['./chess-square.component.css']
})
export class ChessSquareComponent implements OnInit {

  @Input() piece: Piece;
  imgSrc: string = './assets/';
  @Input() row: number;
  @Input() col: number;
  isLightSquare: boolean;

  @Output() squareClickedEvent: EventEmitter<Position> = new EventEmitter<Position>();

  constructor() {

  }

  ngOnInit(): void {
    if(this.piece) {
      this.imgSrc += this.piece.isWhite ? 'w' : 'b';
      switch (this.piece.kind) {
        case PieceType.Bishop:
          this.imgSrc += 'B';
          break;
        case PieceType.King:
          this.imgSrc += 'K';
          break;
        case PieceType.Knight:
          this.imgSrc += 'N';
          break;
        case PieceType.Pawn:
          this.imgSrc += 'P';
          break;
        case PieceType.Queen:
          this.imgSrc += 'Q';
          break;
        case PieceType.Rook:
          this.imgSrc += 'R';
          break;
      }
      this.imgSrc += '.png';
    } else {
      this.imgSrc = ' ';
    }
    this.isLightSquare = (this.row + this.col) % 2 === 0;
  }

  squareClicked(): void {
    this.squareClickedEvent.emit({row: this.row, col: this.col});
  }

}
