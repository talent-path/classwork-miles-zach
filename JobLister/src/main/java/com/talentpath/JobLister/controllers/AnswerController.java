package com.talentpath.JobLister.controllers;

import com.talentpath.JobLister.models.Answer;
import com.talentpath.JobLister.services.AnswerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class AnswerController {

    @Autowired
    private AnswerService answerService;

    @PostMapping("/answers/{listingId}")
    public ResponseEntity saveAnswers(@PathVariable Integer listingId,
                                      @RequestBody List<Answer> answers) {
        ResponseEntity response;
        try {
            response = ResponseEntity.ok(answerService.saveAnswers(listingId, answers));
        } catch (Exception e) {
            response = ResponseEntity.badRequest().body(e.getMessage());
        }
        return response;
    }
}
