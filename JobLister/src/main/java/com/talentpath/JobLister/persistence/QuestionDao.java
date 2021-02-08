package com.talentpath.JobLister.persistence;

import com.talentpath.JobLister.models.Question;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface QuestionDao extends JpaRepository<Question, Integer> {
}
