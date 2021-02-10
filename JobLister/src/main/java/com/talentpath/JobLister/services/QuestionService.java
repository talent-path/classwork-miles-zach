package com.talentpath.JobLister.services;

import com.talentpath.JobLister.models.Listing;
import com.talentpath.JobLister.models.Question;
import com.talentpath.JobLister.persistence.QuestionDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class QuestionService {

    @Autowired
    private QuestionDao questionDao;

    @Autowired
    private ListingService listingService;

    public List<Question> saveQuestions(Integer listingId, List<Question> questions) {
        Optional<Listing> listing = listingService.getListingById(listingId);
        questions.forEach(q -> q.setListing(listing.orElseThrow()));
        return questionDao.saveAll(questions);
    }

    public List<Question> findQuestionsByListing(Integer listingId) {
        Optional<Listing> listing = listingService.getListingById(listingId);
        return questionDao.findQuestionsByListing(listing.orElseThrow());
    }

    public Question updateQuestion(Integer questionId, Question question) {
        Question currQuestion = questionDao.findById(questionId).orElseThrow();
        currQuestion.setQuestion(question.getQuestion());
        currQuestion.setRequired(question.getRequired());
        return questionDao.save(currQuestion);
    }

    public void deleteQuestion(Integer questionId) {
        questionDao.deleteById(questionId);
    }
}
