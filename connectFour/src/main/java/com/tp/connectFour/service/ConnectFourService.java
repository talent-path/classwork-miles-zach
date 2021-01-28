package com.tp.connectFour.service;

import com.tp.connectFour.controller.ConnectFourController;
import com.tp.connectFour.exception.InvalidColumnException;
import com.tp.connectFour.exception.InvalidGameIdException;
import com.tp.connectFour.exception.NullGameIdException;
import com.tp.connectFour.model.ConnectFourGame;
import com.tp.connectFour.model.MoveRequest;
import com.tp.connectFour.persistence.ConnectFourDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@Component
public class ConnectFourService {


    @Autowired
    ConnectFourDao connectFourDao;

    public ConnectFourGame getGameById(Integer game) throws NullGameIdException {

        if(game == null) throw new NullGameIdException("Game ID cannot be null");

        return connectFourDao.getGameById(game);
    }

    public List<ConnectFourGame> getAllGames(){
        return connectFourDao.getAllGames();
    }


    public ConnectFourGame makeMove(MoveRequest request) throws InvalidGameIdException,
            InvalidColumnException, NullGameIdException {

        if(request.getGameId() == null) {
            throw new NullGameIdException("You must provide a game id");
        }

        List<ConnectFourGame> allGames = getAllGames();
        List<Integer> gameIds = allGames.stream()
                .map(ConnectFourGame::getGameId).collect(Collectors.toList());

        if(!gameIds.contains(request.getGameId())) {
            throw new InvalidGameIdException("That was an invalid game id");
        }

        ConnectFourGame game = allGames.stream()
                .filter(e -> e.getGameId() == request.getGameId())
                .findAny()
                .orElseThrow();

        if(!isValidColumn(game.getGameBoard(), request.getColumn())) {
            throw new InvalidColumnException("That is an invalid column or the column is full.");
        }



        return null;
    }

    public boolean isValidColumn(Integer[][] board, Integer column) {
        if(column < 0 || column > 7) return false;
        for (Integer[] integers : board) {
            if (integers[column] != 0) {
                return false;
            }
        }
        return true;
    }

    public Integer startGame() {
        return connectFourDao.startGame();
    }

    public void deleteGame(Integer gameId) throws InvalidGameIdException {
        connectFourDao.deleteGame(gameId);
    }

    public String buildBoard(Integer[][] grid){
        StringBuilder str = new StringBuilder();

        throw new UnsupportedOperationException();
    }

}
