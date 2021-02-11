package com.talentpath.JobLister.services;

import com.talentpath.JobLister.models.*;
import com.talentpath.JobLister.persistence.AnswerDao;
import com.talentpath.JobLister.persistence.ApplicantDao;
import com.talentpath.JobLister.persistence.ListingDao;
import com.talentpath.JobLister.persistence.QuestionDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.time.Instant;
import java.util.HashSet;
import java.util.List;
import java.util.Optional;
import java.util.Set;

@Service
public class JobListingService {

    @Autowired
    private ListingDao listingDao;

    @Autowired
    private QuestionDao questionDao;

    @Autowired
    ApplicantDao applicantDao;

    @Autowired
    AnswerDao answerDao;

    public Listing saveListing(Listing listing) {
        return listingDao.save(listing);
    }

    public Optional<Listing> getListingById(Integer listingId) {
        return listingDao.findById(listingId);
    }

    public List<Listing> getAllListings() {
        return listingDao.findAll();
    }

    public Optional<List<Listing>> getListingsByJobName(String jobName) {
        return listingDao.findByListingNameContainingIgnoreCase(jobName);
    }

    public Optional<List<Listing>> getListingsByCityAndState(String city, String state) {
        return listingDao.findByCityAndStateAllIgnoreCase(city, state);
    }

    public Optional<List<Listing>> getListingsByEmploymentType(String type) {
        return listingDao.findByEmploymentTypeIgnoreCase(type);
    }

    public Optional<List<Listing>> getListingsByIndustry(String industry) {
        return listingDao.findByIndustryIgnoreCase(industry);
    }

    public Optional<List<Listing>> getListingsByCompany(String company) {
        return listingDao.findByCompanyContainingIgnoreCase(company);
    }

    public Optional<List<Listing>> getListingsBySalaryRange(Integer low, Integer high) {
        return listingDao.findBySalaryBetween(low, high);
    }

    public Listing updateListing(Integer listingId, Listing listing) {
        Listing currentListing = listingDao.findById(listingId).orElseThrow();
        currentListing.setListingName(listing.getListingName());
        currentListing.setCity(listing.getCity());
        currentListing.setCompany(listing.getCompany());
        currentListing.setIndustry(listing.getIndustry());
        currentListing.setEmploymentType(listing.getEmploymentType());
        currentListing.setState(listing.getState());
        currentListing.setSalary(listing.getSalary());
        currentListing.setDatePosted(Instant.now());
        return listingDao.save(currentListing);
    }

    public void deleteListing(Integer listingId) {
        Listing listing = listingDao.findById(listingId).orElseThrow();
        listingDao.delete(listing);
    }

    public List<Question> saveQuestions(Integer listingId, List<Question> questions) {
        Optional<Listing> listing = getListingById(listingId);
        questions.forEach(q -> q.setListing(listing.orElseThrow()));
        return questionDao.saveAll(questions);
    }

    public List<Question> findQuestionsByListing(Integer listingId) {
        Optional<Listing> listing = getListingById(listingId);
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

    public List<Answer> saveAnswers(Integer listingId, List<Answer> answers) {
        //TODO: Once an applicant has answered all required questions, then there must be an entry made to
        // applications with applicantId and listingId
        Listing listingToUpdate = getListingById(listingId).orElseThrow();
        Applicant applicant = answers.get(0).getApplicant();
        applicant.getListings().add(listingToUpdate);
//        listingToUpdate.getApplicants().add(applicant);

//        listingDao.save(listingToUpdate);
        applicantDao.save(applicant);
        return answerDao.saveAll(answers);
    }

    public Applicant saveApplicant(Applicant applicant) {
        return applicantDao.save(applicant);
    }

    public List<Answer> getAllAnswers() {
        return answerDao.findAll();
    }

    public List<Applicant> getApplicants() {
        return applicantDao.findAll();
    }
}
