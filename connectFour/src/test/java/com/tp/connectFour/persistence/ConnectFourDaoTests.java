package com.tp.connectFour.persistence;

import com.tp.connectFour.exception.InvalidGameIdException;
import com.tp.connectFour.model.ConnectFourGame;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import static org.junit.jupiter.api.Assertions.*;

import java.util.List;

@SpringBootTest
public class ConnectFourDaoTests {

    @Autowired
    ConnectFourDao dao;

    @BeforeEach
    public void setup() throws InvalidGameIdException {
        List<ConnectFourGame> allGames = dao.getAllGames();

        for(ConnectFourGame game : allGames) {
            dao.deleteGame(game.getGameId());
        }

        dao.startGame();
    }

    @Test
    public void testStartGame() {
        int id = dao.startGame();
        assertEquals(2, id);
        int nextId = dao.startGame();
        assertEquals(3, nextId);
    }
}
