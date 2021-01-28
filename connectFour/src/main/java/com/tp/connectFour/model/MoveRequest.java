package com.tp.connectFour.model;

public class MoveRequest {

    private Integer gameId;
    private Integer column;

    public MoveRequest(Integer gameId, Integer column) {
        this.gameId = gameId;
        this.column = column;
    }

    public MoveRequest(Integer gameId) {
        this.gameId = gameId;
    }

    public Integer getGameId() {
        return gameId;
    }

    public void setGameId(Integer gameId) {
        this.gameId = gameId;
    }

    public Integer getColumn() {
        return column;
    }

    public void setColumn(Integer column) {
        this.column = column;
    }
}
