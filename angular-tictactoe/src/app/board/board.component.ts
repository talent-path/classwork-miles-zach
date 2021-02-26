import { Component, OnInit } from '@angular/core';
import { SquareComponent } from '../square/square.component';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {

  xIsNext: boolean;
  board: string[];

  constructor() { }

  ngOnInit(): void {
    this.newGame();
  }

  newGame(): void {
    this.board = Array(9).fill(null);
    this.xIsNext = true;
  }

  squareClick(position: number): void {
    if(!this.board[position]) {
      this.board[position] = this.xIsNext ? "X" : "O";
      this.xIsNext = !this.xIsNext;
    }
    const winner = this.calculateWinner();
    if(winner) {
      alert(`${winner} has won!`)
      this.newGame();
    }
  }

  calculateWinner() {
    const lines = [
      [0, 1, 2],
      [3, 4, 5],
      [6, 7, 8],
      [0, 3, 6],
      [1, 4, 7],
      [2, 5, 8],
      [0, 4, 8],
      [2, 4, 6]
    ];
    for (let i = 0; i < lines.length; i++) {
      const [a, b, c] = lines[i];
      if (
        this.board[a] &&
        this.board[a] === this.board[b] &&
        this.board[a] === this.board[c]
      ) {
        return this.board[a];
      }
    }
    return null;
  }

}
