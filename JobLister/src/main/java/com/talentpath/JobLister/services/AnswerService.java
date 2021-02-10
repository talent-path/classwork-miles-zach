package com.talentpath.JobLister.services;

import com.talentpath.JobLister.models.Answer;
import com.talentpath.JobLister.persistence.AnswerDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AnswerService {

    @Autowired
    private AnswerDao answerDao;

    public List<Answer> saveAnswers(Integer listingId, List<Answer> answers) {
        //TODO: Find all questions with listingId
        throw new UnsupportedOperationException();
    }
}
