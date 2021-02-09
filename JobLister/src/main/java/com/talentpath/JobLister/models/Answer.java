package com.talentpath.JobLister.models;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@Entity
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
@Table
public class Answer {

    @EmbeddedId
    ApplicantAnswerKey id;

    @ManyToOne
    @MapsId("applicantId")
    @JoinColumn(name = "applicant_id")
    Applicant applicant;

    @ManyToOne
    @MapsId("questionId")
    @JoinColumn(name = "question_id")
    Question question;

    String answer;
}
