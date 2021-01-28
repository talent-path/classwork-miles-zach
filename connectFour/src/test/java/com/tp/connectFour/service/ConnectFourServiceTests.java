package com.tp.connectFour.service;

import com.tp.connectFour.exception.InvalidColumnException;
import com.tp.connectFour.exception.InvalidGameIdException;
import com.tp.connectFour.exception.NullGameIdException;
import com.tp.connectFour.model.ConnectFourGame;
import com.tp.connectFour.model.MoveRequest;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
public class ConnectFourServiceTests {

    @Autowired
    ConnectFourService service;

    @BeforeEach
    public void setup() throws InvalidGameIdException {
        List<ConnectFourGame> allGames = service.getAllGames();

        for(ConnectFourGame game : allGames) {
            service.deleteGame(game.getGameId());
        }
    }

    @Test
    public void deletingGameWithIdThatDoesNotExist() {
        try {
            service.deleteGame(-1);
            fail();
        } catch(InvalidGameIdException e) {

        }
    }

    @Test
    public void addingGamesTest() {
        service.startGame();
        service.startGame();
        List<ConnectFourGame> games = service.getAllGames();
        assertEquals(1, games.get(0).getGameId());
        assertEquals(2, games.get(1).getGameId());
    }

    @Test
    public void gettingGameByNullId() {
        try {
            ConnectFourGame game = service.getGameById(null);
            fail();
        } catch(NullGameIdException e) {

        }
    }

    @Test
    public void gettingGameByIdThatDoesNotExistReturnsNull() throws NullGameIdException {
        ConnectFourGame game = service.getGameById(-200);
        assertNull(game);
    }

    @Test
    public void gameBoardShouldNotBeNull() throws NullGameIdException {
        Integer id = service.startGame();
        ConnectFourGame game = service.getGameById(id);
        assertNotNull(game.getGameBoard());
    }

    @Test
    public void makingMoveOnNullGameId() throws InvalidColumnException, InvalidGameIdException {
        MoveRequest moveRequest = new MoveRequest(null, 5);
        try {
            service.makeMove(moveRequest);
            fail();
        } catch(NullGameIdException e) {

        }
    }

    @Test
    public void makingMoveOnInvalidGameId() throws InvalidColumnException, NullGameIdException {
        MoveRequest moveRequest = new MoveRequest(Integer.MIN_VALUE, 2);
        try {
            service.makeMove(moveRequest);
            fail();
        } catch(InvalidGameIdException e) {

        }
    }

    @Test
    public void makingMoveOnInvalidColumn() throws NullGameIdException, InvalidGameIdException {
        service.startGame();
        MoveRequest moveRequest = new MoveRequest(1, 100);
        try {
            service.makeMove(moveRequest);
            fail();
        } catch(InvalidColumnException e) {

        }
    }

    @Test
    public void makingMoveOnFullColumn() throws NullGameIdException, InvalidGameIdException {
        Integer gameId = service.startGame();
        ConnectFourGame game = service.getGameById(gameId);
        Integer[][] board = game.getGameBoard();
        for (int i = 0 ; i < board.length; i++) {
            board[i][0] = 0;
        }

        MoveRequest request = new MoveRequest(gameId, 0);
        try {
            service.makeMove(request);
            fail();
        } catch(InvalidColumnException e) {

        }
    }



}
