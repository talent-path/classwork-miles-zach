import { Board } from "../Board";
import { Move } from "../Move";
import { Position } from "../Position";
import { ChessPiece } from "./ChessPiece";
import { PieceType } from "./Piece";

export class Rook extends ChessPiece {

    constructor( isWhite : boolean ){
        super( PieceType.Rook, isWhite );
    }
    

    generateMoves: (moveOn: Board, loc: Position) => Move[] = 
    (moveOn: Board, loc: Position)  => {
    
        return [];
    }
}