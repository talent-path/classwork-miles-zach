package com.tp.connectFour.persistence;

import com.tp.connectFour.exception.InvalidGameIdException;
import com.tp.connectFour.model.ConnectFourGame;
import com.tp.connectFour.service.ConnectFourService;

import java.util.List;

public interface ConnectFourDao {

    ConnectFourGame getGameById(Integer gameId);

    List<ConnectFourGame> getAllGames();

    void updateGame(ConnectFourGame game);

    int startGame();

    void deleteGame(Integer gameId) throws InvalidGameIdException;
}
