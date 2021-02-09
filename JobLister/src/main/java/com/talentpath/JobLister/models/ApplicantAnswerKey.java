package com.talentpath.JobLister.models;

import javax.persistence.Column;
import javax.persistence.Embeddable;
import java.io.Serializable;

@Embeddable
public class ApplicantAnswerKey implements Serializable {

    @Column(name = "question_id")
    Integer questionId;

    @Column(name = "applicant_id")
    Integer applicantId;

}
