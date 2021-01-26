package com.tp.diceroller.controller;
import com.tp.diceroller.service.DiceService;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class DiceController {

    @GetMapping("/helloworld")
    public String helloWorld() {
        return "Hello World";
    }

    @GetMapping("/six")
    public int rollSixSidedDie() {
        return DiceService.rollDice(6);
    }

    @GetMapping("/roll/{sides}")
    public int rollDice(@PathVariable("sides") Integer sides) {
        return DiceService.rollDice(sides);
    }
}
