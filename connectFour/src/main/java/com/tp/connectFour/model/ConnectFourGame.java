package com.tp.connectFour.model;

public class ConnectFourGame {

    private Integer[][] gameBoard = new Integer[6][7];
    private Integer gameId;


    //Constructor
    public ConnectFourGame(Integer gameId){
        this.gameId = gameId;
    }

    //copy constructor
    public ConnectFourGame( ConnectFourGame that ){
        this.gameId = that.gameId;
        this.gameBoard =  that.gameBoard;

    }

    public Integer[][] getGameBoard() {
        return gameBoard;
    }

    public void setGameBoard(Integer[][] gameBoard) {
        this.gameBoard = gameBoard;
    }

    public Integer getGameId() {
        return gameId;
    }

    public void setGameId(Integer gameId) {
        this.gameId = gameId;
    }





}
