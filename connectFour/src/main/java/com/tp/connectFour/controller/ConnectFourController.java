package com.tp.connectFour.controller;

import com.tp.connectFour.exception.InvalidColumnException;
import com.tp.connectFour.exception.InvalidGameIdException;
import com.tp.connectFour.exception.NullGameIdException;
import com.tp.connectFour.model.ConnectFourGame;
import com.tp.connectFour.model.MoveRequest;
import com.tp.connectFour.service.ConnectFourService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class ConnectFourController {

    @Autowired
    ConnectFourService connectFourService;

    @GetMapping("/game/{gameId}")
    public ResponseEntity getBoard(@PathVariable Integer gameId){
        try {
            return ResponseEntity.ok(connectFourService.getGameById(gameId));
        } catch (NullGameIdException e) {
            return ResponseEntity.badRequest().body(e.getMessage());
        }
    }

    @GetMapping("/game")
    public List<ConnectFourGame> allBoard(){
        return connectFourService.getAllGames();
    }

    @PostMapping("/makeMove" )
    public ResponseEntity makeMove(@RequestBody MoveRequest request){
        try {
            return ResponseEntity.ok(connectFourService.makeMove(request));
        } catch (InvalidGameIdException | InvalidColumnException | NullGameIdException e) {
            return ResponseEntity.badRequest().body(e.getMessage());
        }

    }

    @PostMapping("/begin")
    public ResponseEntity startGame(){
        return ResponseEntity.ok(connectFourService.startGame());

    }

    @DeleteMapping("/delete/{gameId}")
        public String deleteGame(@PathVariable Integer gameId){
        try {
            connectFourService.deleteGame(gameId);
            return "Deleted game with ID of " + gameId;
        } catch(InvalidGameIdException ex) {
            return ex.getMessage();
        }
    }




}
